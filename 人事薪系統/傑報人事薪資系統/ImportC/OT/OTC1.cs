using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.Linq;
using System.Text.RegularExpressions;
using JBModule.Data.Linq;
using JBHR.Sal.Core;
using JBTools;
using JBHR.Att;

//當資料為ONCALL時起迄時間為"0000"

//當請假是SHIFT時 CODE 是S開頭 OVERTIME_TYPE 表 COM_LEAVE 攔 狀態是 TRUE 和 MEAL 判斷用餐為 Y 就得補修八小時 且 就得假

//當資料為ONCALL時資料無條件匯入程式為 if(HardS.Equals("是"))

//OverTime 的 CODE ， OnCall 的 CODE 為可以重複之OT 

//錯誤資料加班判斷匯出到 OT SERNO 欄位

namespace JBHR.ImportC.OT 
{
    class OTC1 : ImportC.ImportGen
    {
        JBHR.Att.dsAtt.OT1DataTable _OT1DTable;

        public DateTime maxDate;
        public DateTime minDate;
        public String currentFileName = "";
        public DateTime ForOTNO = DateTime.Now;
        public string ot_rote = "";
        public string Org_ot_rote = "";
        List<JBModule.Data.Linq.ABS> ABSList = null;
        List<JBModule.Data.Linq.BASETTS> basettsList = null;
        List<JBModule.Data.Linq.OTRCD> OTRCDList = null;
        public List<JBModule.Data.Linq.OT> OTList = null;
        //public List<OVERTIME_TYPE> otTypeList = null;
        public override System.Data.DataTable ceateRoteChgTable(Dictionary<string, string> dic, System.Windows.Forms.ProgressBar PB)
        {
            basettsList = getBasettsList();
            setDateRange(dic["BDATE"]);
            ABSList = getABSList();
            OTList = getOTList();
            OTRCDList = getOTRCDList();
            //otTypeList = getOVERTIME_TYPEList();

            _OT1DTable = new Att.dsAtt.OT1DataTable();

            //#region ASML OT存取需求
            //List<String> OverTimerepeatCode = new List<String>();
            //OverTimerepeatCode.Add("OverTime");
            //OverTimerepeatCode = canRepeat(OverTimerepeatCode);
            //List<String> OnCallrepeatCode = new List<String>();
            //OnCallrepeatCode.Add("OnCall");
            //OnCallrepeatCode = canRepeat(OnCallrepeatCode);
            IQueryable<JBModule.Data.Linq.ROTE> roteData = from rotei in HDDC.ROTE select rotei;
            //#endregion
            //List<String> OverTimeCode = (from OverTimeCodei in otTypeList select OverTimeCodei).Select(a => a.CODE.Trim()).ToList();
            Dictionary<String,String> ExcelOTErrorDic = new Dictionary<String,String>();
            Dictionary<String,String> ExcelABSErrorDic = new Dictionary<String,String>();
            bool hasOTType = dic["OTType"].Length != 0 ? true : false;
            bool hasETIME = dic["ETIME"].Length != 0 ? true : false;
            bool hasBTIME = dic["BTIME"].Length != 0 ? true : false;
            bool hasMeal = dic["Meal"].Length != 0 ? true : false;
            bool hasCODE = dic["CODE"].Length != 0 ? true : false;
            bool hasNOTE = dic["NOTE"].Length != 0 ? true : false;
            bool hasYYMM = dic["YYMM"].Length != 0 ? true : false;
            Sal.Core.SalaryDate SD;
            String HardS = dic["Approve"];
            String OTTypeData;
            String ETIMEData;
            String BTIMEData;
            decimal MealData;
            String CODEData;
            String NOBRData;
            string NAMEData;
            string DEPTNAMEData;
            DateTime BDATEData = DateTime.MaxValue;
            decimal TOTALData ;
            String _YYMM = "";
            String _NOTE = "";
            decimal OT_HRS;
            decimal REST_HRS;
            String Depts;
            //bool Meal;
            PB.Value = 0;
            PB.Maximum = excelDT.Rows.Count;
            foreach (DataRow item in excelDT.Rows)
            {
                bool TimeErrorFlag = false;
                PB.Value += 1;
                TOTALData = 0;

                #region 初始化BDATE
                //if (BDATEData.Date.CompareTo(Convert.ToDateTime(item[dic["BDATE"]].ToString()).Date)!=0)
                //{
                //}
                BDATEData = Convert.ToDateTime(item[dic["BDATE"]].ToString()).Date;
                #endregion

                #region 自動取得YYMM
                if (hasYYMM)
                {
                    if (item[dic["YYMM"]].ToString().Trim().Length != 0 && item[dic["YYMM"]].ToString().Trim().Length >= 6)
                    {
                        _YYMM = item[dic["YYMM"]].ToString().Substring(0, 6);
                    }
                    else
                    {
                        SD = new Sal.Core.SalaryDate(BDATEData);
                        _YYMM = SD.YYMM;
                    }
                }
                else
                {
                    SD = new Sal.Core.SalaryDate(BDATEData);
                    _YYMM = SD.YYMM;
                }
                #endregion

                _YYMM = createYYMM(item[dic["YYMM"]].ToString().Trim());
                OT_HRS = 0;
                REST_HRS = 0;

                //加班時數
                try
                {
                    OT_HRS = Convert.ToDecimal(item[dic["TOT_HOURS"]].ToString());
                }
                catch (Exception)
                {
                    OT_HRS = 0;
                }

                //補休時數
                try
                {
                    REST_HRS = Convert.ToDecimal(item[dic["OTType"]].ToString());
                }
                catch (Exception)
                {
                    REST_HRS = 0;
                }

                TOTALData = TOTALData + OT_HRS + REST_HRS;

                //誤餐費
                try
                {
                    MealData = Convert.ToDecimal(item[dic["Meal"]].ToString());
                }
                catch (Exception)
                {
                    MealData = 0;
                }
     
                //加班代碼
                CODEData = hasCODE ? item[dic["CODE"]].ToString().Trim() : "";
                
                //員工編號
                NOBRData = item[dic["NOBR"]].ToString().Trim().ToUpper();

                //員工姓名
                NAMEData = item[dic["NAME_C"]].ToString().Trim().ToUpper();

                //加班部門代號
                _NOTE = hasNOTE ? item[dic["NOTE"]].ToString().Trim() : "";

                if (_NOTE == "")
                    Depts = (from basettsListi in basettsList where basettsListi.NOBR.ToUpper().Equals(NOBRData) select basettsListi.DEPTS).FirstOrDefault();
                else
                    Depts = _NOTE;

                //加班部門名稱
                DEPTNAMEData = item[dic["DEPTNAME"]].ToString().Trim().ToUpper();

                
                #region 時間格式判斷

                ETIMEData = hasETIME ? getTime(item[dic["ETIME"]].ToString(),"ETIME",out TimeErrorFlag) : "0000";
                BTIMEData = hasBTIME ? getTime(item[dic["BTIME"]].ToString(), "BTIME", out TimeErrorFlag) : "0000";
                if (TimeErrorFlag)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班起時間格式錯誤", Depts, DEPTNAMEData);
                    continue;
                }

                if (TimeErrorFlag)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班迄時間格式錯誤", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                ETIMEData = setETime(BTIMEData,ETIMEData);


                #region 員工編號&&員工姓名檢查
                var baseSQL = from a in HDDC.BASE where a.NOBR == NOBRData select new { a.NOBR, a.NAME_C };
                if (baseSQL.Any())
                {
                    var name_c = baseSQL.First().NAME_C;
                    if (name_c.Trim().ToUpper() != NAMEData)//名字對應不對
                    {
                        InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "員工編號與員工姓名對應錯誤", Depts, DEPTNAMEData);
                        continue;
                    }
                }
                else
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "無此員工編號", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 加班部門&&部門名稱檢查
                var deptsSQL = from a in HDDC.DEPTS where a.D_NO_DISP == Depts select new { a.D_NO_DISP, a.D_NAME };
                if (deptsSQL.Any())
                {
                    var d_name = deptsSQL.First().D_NAME;
                    if (d_name.Trim().ToUpper() != DEPTNAMEData)
                    {
                        InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班部門編號與部門名稱對應錯誤", Depts, DEPTNAMEData);
                        continue;
                    }
                }
                else
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "無此加班部門編號", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 判斷時間起迄
                if (TimeError(BTIMEData,ETIMEData))
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班起迄時間錯誤", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 判斷加班時數及補休時數只能擇一申請
                if (OT_HRS > 0 && REST_HRS > 0)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班時數及補休時數只能擇一申請", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 加班費時數及補休時數不可同時為0
                if (OT_HRS == 0 && REST_HRS == 0)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班費時數及補休時數不可同時為0", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 判斷計薪年月格式
                if (FormatValidate.CheckYearMonthFormat(_YYMM) != true)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "計薪年月格式輸入錯誤", Depts, DEPTNAMEData);
                    continue;
                }
                if (IsLockedYYMM(BDATEData))
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "計薪年月已鎖檔", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 判斷加班原因代碼錯誤
                    if (hasCODE){
                        var otrcd = from otrcdi in OTRCDList
                              where otrcdi.OTRCD1.Equals(CODEData)
                              select otrcdi;
                    if (otrcd.Any())
                    {
                        InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班原因代碼錯誤", Depts, DEPTNAMEData);
                        continue;
                    }
                }
                #endregion

                #region 判斷申請的時段內已有存在的加班資料
                var otData = JBHR.BLL.Att.OverTime.GetExistsOT(NOBRData, BDATEData, BDATEData, BTIMEData, ETIMEData);
                if (otData.Any())
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "申請的時段內已有存在的加班資料", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                #region 判斷申請的時段為上班時間 && 加班總時數不正確
                //if (AttendError(NOBRData, BDATEData, BTIMEData, ETIMEData, roteData))
                //decimal CheckHours = CheckOtHours(NOBRData, BDATEData, BTIMEData, ETIMEData);
                decimal CheckHours = CheckOtHours(NOBRData, BDATEData, BTIMEData, ETIMEData, false);
                //需重新檢查加班總時數
                if (CheckHours != OT_HRS + REST_HRS)
                {
                    //MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (CheckHours == 0 && !CodeFunction.GetHolidayRoteList().Contains(Org_ot_rote))
                    {
                        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                        var sql = from a in db.ROTE where a.ROTE1 == ot_rote select a;
                        if (sql.Any())
                        {
                            if (sql.First().ON_TIME.CompareTo(BTIMEData) <= 0 && sql.First().OFF_TIME.CompareTo(ETIMEData) >= 0)//如果申請時間等於上下班時間
                            {
                                InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "申請的時段為上班時間", Depts, DEPTNAMEData);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)", Depts, DEPTNAMEData);
                        continue;
                    }
                }
                #endregion

                #region 判斷申請日期與出勤刷卡資料
                //1.申請日期出勤刷卡資料不完整
                //2.申請時間未在刷卡時段內
                //3.申請日期查無出勤刷卡資料
                //4.申請日期查無出勤資料
                JBModule.Data.Dto.OvertimeApply otApply = new JBModule.Data.Dto.OvertimeApply();
                otApply.EmployeeID = NOBRData;
                otApply.ApplyBeginDate = BDATEData.AddTime(BTIMEData);
                otApply.ApplyEndDate = BDATEData.AddTime(ETIMEData);
                otApply.OtRote = ot_rote;
                otApply.AttendDate = BDATEData;
                if (OT_HRS > 0)
                    otApply.OtType = JBModule.Data.Dto.OvertimeApply.OverTimeType.OtHours;
                else if (REST_HRS > 0)
                    otApply.OtType = JBModule.Data.Dto.OvertimeApply.OverTimeType.RestHours;
                JBHR.BLL.OverTimeFactory otf = new BLL.OverTimeFactory();
                var ap = otf.CreateOtApply();
                var apData = ap.GenerateOT(otApply);
                var av = otf.CreateOtValidate();
                var checkAp = av.Validate(apData);
                if (!checkAp && av.RejectCode != 202001)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, av.RejectReason, Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

               
                //#region 不判斷OT重複 EXCEL重複
                //if (HardS.Equals("是"))
                //{
                //    InsertDataTable(_NOTE, NOBRData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "_", "", Depts);
                //    continue;
                //}
                //#endregion

                #region EXCEL重複判斷
                if (ExcelOTError(ExcelOTErrorDic, NOBRData, BDATEData, BTIMEData)) {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班資料Excel重複錯誤", Depts, DEPTNAMEData);
                    continue;
                }
                #endregion

                //#region 加班重複錯誤
                //hasOT(String NOBR, DateTime BDATE, String BTime, String Code, List<String> OCrepeat, List<String> OTrepeat, String ETime)
                //if (hasOT(NOBRData, BDATEData, BTIMEData, CODEData, OnCallrepeatCode,OverTimerepeatCode,ETIMEData))
                //if (hasOT(NOBRData, BDATEData, BTIMEData, CODEData, ETIMEData))
                //{
                //    InsertDataTable(_NOTE, NOBRData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "加班資料重複錯誤_。", OTTypeData, Depts);
                //    continue;
                //}
                //#endregion
                
                #region 已有存在的補休得假資料
                if (REST_HRS != 0)
                {
                    if (ExcelABSError(NOBRData, BDATEData, BTIMEData, ExcelABSErrorDic))
                    {
                        InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "已有存在的補休得假資料", Depts, DEPTNAMEData);
                        continue;
                    }
                }
                #endregion

                InsertDataTable("", NOBRData, NAMEData, BDATEData, BTIMEData, ETIMEData, TOTALData, OT_HRS, REST_HRS, _YYMM, MealData, CODEData, "", Depts, DEPTNAMEData);
            }
            setExcelName();
            return _OT1DTable;
        }




        public override int insertRoteChg(System.Windows.Forms.DataGridView DGW, System.Windows.Forms.ProgressBar PB)
        {
            ABSList = getABSList();
            ForOTNO  = DateTime.Now;
            currentFileName = FileName.Substring(FileName.LastIndexOf("\\") + 1, FileName.Length - FileName.LastIndexOf("\\") - 1);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
            //取得補休得假代碼
            var leaveType = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
            JBHR.Att.dsAtt.OT1DataTable _OTDataTable = new Att.dsAtt.OT1DataTable();
            PB.Value = 0;
            PB.Maximum = DGW.Rows.Count;

            List<JBModule.Data.Linq.OT> list = new List<JBModule.Data.Linq.OT>();
            List<JBModule.Data.Linq.ABS> absList = new List<JBModule.Data.Linq.ABS>();
            foreach (DataGridViewRow item in DGW.Rows)
            {
                PB.Value += 1;
                if (item.Cells["OTNO"].Value != null)
                {
                    if (item.Cells["OTNO"].Value.ToString().Trim() == "")
                    {
                        if (Convert.ToDecimal(item.Cells["補休時數"].Value.ToString()) != 0)
                        {
                            if (doInsertABS(absList, Convert.ToDateTime(item.Cells["加班日期"].Value.ToString()), item.Cells["員工編號"].Value.ToString(), item.Cells["計薪年月"].Value.ToString(), Convert.ToDecimal(item.Cells["補休時數"].Value.ToString()), leaveType, item.Cells["加起時間"].Value.ToString(), item.Cells["加迄時間"].Value.ToString()))
                            {
                                list.Add(doInsertOT(item));
                            }
                            else
                            {
                                _OTDataTable.AddOT1Row(creatErrorRow(item, "已有重複的補休資料，", _OTDataTable));
                            }
                        }
                        else
                        {
                            list.Add(doInsertOT(item));
                        }
                    }
                    else
                    {
                        _OTDataTable.AddOT1Row(creatErrorRow(item, "", _OTDataTable));
                    }
                }
            }
            setExcelName();
            if (_OTDataTable.Rows.Count > 0)
            {
                String errorDataPath = "C:\\Temp\\加班資料(" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ").xls";
                JBModule.Data.CNPOI.ExportToExcel(_OTDataTable, errorDataPath, "");
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"錯誤資料匯出 : " + errorDataPath, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            try
            {
                //absList
                HDDC.OT.InsertAllOnSubmit(list);

#region 

                HDDC.ABS.InsertAllOnSubmit(absList);

#endregion 
                HDDC.SubmitChanges();
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"成功匯入:" + list.Count + "筆");
                try
                {
                    while (DGW.Rows.Count > 0)
                    {
                        DGW.Rows.RemoveAt(0);
                    }
                }
                catch (Exception)
                {
                }

                return list.Count;

            }
            catch (DuplicateKeyException dke)
            {
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"請重新匯入再產生。");
                return 0;
            }
            
        }
        public bool ExcelABSError(String NOBR, DateTime BDate,String BTime, Dictionary<String, String> dic)
        {
            try
            {
                dic.Add(NOBR + BDate.Date.ToString() + BTime.ToUpper(), "");
                var abs = from absi in ABSList
                          where absi.NOBR.Equals(NOBR)
                          && absi.BDATE.Date.CompareTo(BDate.Date) == 0
                          && absi.BTIME.Equals(BTime)
                          && absi.H_CODE.Equals("W2")
                          select absi;
                if (abs.Any())
                {
                    return true;                    
                }
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }
        public bool insertABS(String NOBR,DateTime BDate,List<JBModule.Data.Linq.ABS> absList){
            JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
            abs.NOBR = NOBR;
            abs.BDATE = BDate;
            abs.BTIME = "0000";
            abs.EDATE = BDate.AddMonths(3);
            abs.H_CODE = "W2";
            try
            {
                absList.Add(abs);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool ExcelOTError(Dictionary<String,String> dic,String NOBR,DateTime DT,String BTime) {

            String key = NOBR.ToUpper() + DT.Date.ToString() + BTime;
            try
            {
                dic.Add(key, "");
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }
        public String getTime(String time, String _TimeType , out bool TimeError)
        {
            TimeError = false;
            String _Time = time;
            if (time.Trim().Length == 5) {

                _Time = time.Substring(0, 2) + time.Substring(3, 2);
            
            }
            else if (time.Trim().Length == 19)
            {
                _Time = time.Substring(time.Length - 8, 2) + time.Substring(time.Length - 5, 2);

            }
                else if (time.Trim().Length == 4)
            {
                _Time = time;
            }

            else if (time.Trim().Length == 10)
            {
                if (_TimeType.ToUpper().Equals("BTIME"))
                {
                    _Time = "0000";
                }
                else
                {
                    _Time = "0000";
                }
            }
            else {

                TimeError = true;
            
            
            }
            return _Time;
        }
        //public List<String> canRepeat(List<String> groupName) {
        //    List<String> reapt = new List<string>();
        //    foreach (String item in groupName)
        //    {
        //        foreach (var item1 in (from aaai in otTypeList where aaai.CATEGORY.Trim().Equals(item) select new { aaai.CODE }).ToList())
        //        {
        //            reapt.Add(item1.CODE.Trim());
        //        }
        //    }
        //    return reapt;
        //}
        public bool TimeError(String BTime,String ETime){
            int BT = (Convert.ToInt32(BTime.Substring(0, 2)) * 60) + Convert.ToInt32(BTime.Substring(2, 2));
            int ET = (Convert.ToInt32(ETime.Substring(0, 2)) * 60) + Convert.ToInt32(ETime.Substring(2, 2));
            return (BT > ET);
        }
        public bool AttendError(String NOBR , DateTime BDate , String BTime , String ETime , IQueryable<JBModule.Data.Linq.ROTE> rote)
        {
            try
            {
                var hasAttend = (from hasAttendi in HDDC.ATTEND
                                    where hasAttendi.NOBR.Equals(NOBR)
                                    && hasAttendi.ADATE.Date.CompareTo(BDate.Date) == 0
                                    select new { hasAttendi.ROTE }).FirstOrDefault();

               
                var canOT = from rotei in rote 
                                where rotei.ROTE1.Equals(hasAttend.ROTE)
                                && ((rotei.ON_TIME.CompareTo(ETime) >= 0
                                && rotei.OFF_TIME.CompareTo(BTime) >= 0)
                                || (rotei.ON_TIME.CompareTo(ETime) <= 0
                                && rotei.OFF_TIME.CompareTo(BTime) <= 0)
                                )
                                select rotei;

                if (canOT.Any())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="BTime"></param>
        /// <param name="ETime"></param>
        /// <param name="hasBreak">是否要參考班別的休息時間</param>
        /// <returns></returns>
        public decimal CheckOtHours(String nobr , DateTime BDate , String BTime , String ETime , bool hasBreak)
        {
            string t1, t2;
            DateTime d1;
            decimal TotalHours = 0;
            d1 = BDate;
            t1 = Convert.ToInt32(BTime).ToString("0000");
            t2 = Convert.ToInt32(ETime).ToString("0000");


            if (hasBreak)
            {
                var hasAttend = (from hasAttendi in HDDC.ATTEND
                                 where hasAttendi.NOBR.Equals(nobr)
                                 && hasAttendi.ADATE.Date.CompareTo(BDate.Date) == 0
                                 select new { hasAttendi.ROTE }).FirstOrDefault();


                if (CodeFunction.GetHolidayRoteList().Contains(hasAttend.ROTE))
                {
                    var filterAttend = from a in HDDC.ATTEND where a.NOBR == nobr && a.ADATE >= BDate.AddDays(-1) && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE) orderby a.ADATE select new { a.NOBR, a.ADATE, a.ROTE };
                    if (filterAttend.Any())
                        ot_rote = filterAttend.First().ROTE;
                }
                else
                    ot_rote = hasAttend.ROTE;

                Org_ot_rote = hasAttend.ROTE;

                var details =Dll.Att.OtCal.CalculationOt(nobr, hasAttend.ROTE, d1, t1, t2, false);
                TotalHours = details.iHour;
            }
            else
            {
                DateTime b_dt = d1;
                DateTime e_dt = d1;
                b_dt.AddHours(int.Parse(t1.Substring(0, 2)));
                b_dt.AddMinutes(int.Parse(t1.Substring(2, 2)));
                e_dt.AddHours(int.Parse(t2.Substring(0, 2)));
                e_dt.AddMinutes(int.Parse(t2.Substring(2, 2)));
                TimeSpan ts = e_dt - b_dt;
                TotalHours = ts.Hours + ((ts.Minutes) / 60);
            }
            return TotalHours;
        }


        //public bool hasCom_Leave(String Code) {
        //    var comLeave = from comLeavei in otTypeList
        //                       where comLeavei.CODE.Equals(Code)
        //                       && comLeavei.COM_LEAVE == true
        //                       select comLeavei;
        //        if (comLeave.Any())
        //        {
        //            return true;
        //        }

        //    return false;
        //}


        public void setExcelName() {
            foreach (DataColumn item in _OT1DTable.Columns)
            {
                item.ColumnName = item.Caption;
            }
        }
        public void InsertDataTable(String note, String NOBR, string NAME_C, DateTime BDate, String BTime, String ETime, decimal TotleHours, decimal OT_HRS, decimal REST_HRS, String YYMM, decimal meal, String Code, String ErrorMsg, String depts, String DEPTNAME)
        {
            var row = _OT1DTable.NewOT1Row();
            row.NOBR = NOBR;
            //row.OT_DEPT = _Attend.FirstOrDefault().emp_DEPT;
            //row.NAME_C = _Attend.FirstOrDefault().emp_NAME;
            row.NAME_C = NAME_C;
            row.BDATE = BDate.Date;
            row.BTIME = BTime;
            row.ETIME = ETime;
            row.YYMM = YYMM;
            row.OT_DEPT = depts;
            row.DEPTNAME = DEPTNAME;
            row.TOT_HOURS = TotleHours;
            row.OT_HRS = OT_HRS;
            row.REST_HRS = REST_HRS;
            row.KEY_MAN = MainForm.USER_NAME;
            row.KEY_DATE = DateTime.Now;
            row.NOTE = note;
            //row.OTTYPE = Code;
            row.OT_FOOD1 = meal;
            row.OTRCD = "";
            //row.SERNO = OC;
            row.OTNO = ErrorMsg;
            _OT1DTable.AddOT1Row(row);
        }
        public String createYYMM(String YYMM) {
            String reg = "^(19|20)\\d\\d(0[1-9]|1[012])";
            Match m = Regex.Match(YYMM, reg);
            if (m.Success)
                return YYMM.Substring(0, 6);
            else
                return YYMM;
        }
        public bool Meal_D(String mealData) {
            String rex = "((^[Y]$)|(^[1-9]$))";
            Match m = Regex.Match(mealData, rex);
            return m.Success;
        }
        public void setDateRange(String dateStr){
            maxDate = DateTime.MinValue;
            minDate = DateTime.MaxValue;
            
            foreach (DataRow item in excelDT.Rows)
            {
                DateTime tarDate = Convert.ToDateTime(item[dateStr].ToString()).Date;
                maxDate = tarDate > maxDate ? tarDate : maxDate;
                minDate = tarDate < minDate ? tarDate : minDate;
            }
        }
        public List<JBModule.Data.Linq.ABS> getABSList() {
            List<JBModule.Data.Linq.ABS> ABSList = (from OTListi in HDDC.ABS
                                                  where
                                                  OTListi.BDATE.CompareTo(maxDate) <= 0
                                                  &&
                                                  OTListi.BDATE.CompareTo(minDate) >= 0
                                                  select OTListi).ToList();
            return ABSList;
        
        
        }

        public List<JBModule.Data.Linq.OTRCD> getOTRCDList()
        {
            return (from c in HDDC.OTRCD select c).ToList();
        }

        public List<JBModule.Data.Linq.OT> getOTList()
        {
            //DateTime D1 = DateTime.Now;
            List<JBModule.Data.Linq.OT> OTList = (from OTListi in HDDC.OT
                                                 where
                                                 OTListi.BDATE.CompareTo(maxDate) <= 0
                                                 &&
                                                 OTListi.BDATE.CompareTo(minDate) >= 0
                                                 select OTListi).ToList();
            //TimeSpan TS = DateTime.Now - D1;
            //MessageBox.Show(new Form() { TopMost = true, TopLevel = true },D1.Second.ToString());
            return OTList;
        }
        #region 按下產生
        public bool doInsertABS(List<JBModule.Data.Linq.ABS> list, DateTime BDATE, String NOBR, String YYMM, Decimal totalHour, String leaveType , String BTime,String ETime)
        {
            JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
            abs.A_NAME = "";
            abs.BDATE = BDATE;
            abs.BTIME = BTime;
            DateTime dt_E = BDATE.AddMonths(3);
            abs.EDATE = new DateTime(dt_E.Year, dt_E.Month, DateTime.DaysInMonth(dt_E.Year, dt_E.Month));
            abs.ETIME = ETime;
            abs.H_CODE = leaveType;
            abs.KEY_DATE = DateTime.Now;
            abs.KEY_MAN = MainForm.USER_NAME;
            abs.NOBR = NOBR;
            abs.nocalc = false;
            if ((currentFileName + ForOTNO.ToString("MMddhhmmss")).Length <= 49)
            {
                abs.NOTE = currentFileName + ForOTNO.ToString("MMddhhmmss");
            }
            else {
                abs.NOTE = (currentFileName + ForOTNO.ToString("MMddhhmmss")).Substring(0,49);
            }
            abs.NOTEDIT = false;
            abs.SERNO = Guid.NewGuid().ToString();
            abs.SYSCREATE = true;
            abs.TOL_DAY = 0;
            abs.TOL_HOURS = totalHour;
            
            abs.YYMM = YYMM;
            var sql = from a in ABSList
                      where
                      a.NOBR == abs.NOBR
                      && a.BDATE == abs.BDATE
                      && a.BTIME == abs.BTIME
                      && a.H_CODE == abs.H_CODE
                      select a;
            if (!sql.Any())//不存在才新增
            {
                list.Add(abs);
                return true;
            }
            else
            {
                return false;
            }
        }
        public JBModule.Data.Linq.OT doInsertOT(DataGridViewRow item)
        {

            JBModule.Data.Linq.OT _OT = new JBModule.Data.Linq.OT();
            _OT.NOBR = item.Cells["員工編號"].Value.ToString();
            _OT.BDATE = Convert.ToDateTime(item.Cells["加班日期"].Value.ToString());
            _OT.BTIME = item.Cells["加起時間"].Value.ToString();
            _OT.ETIME = item.Cells["加迄時間"].Value.ToString();
            _OT.OTRCD = item.Cells["加班原因"].Value.ToString();
            //_OT.OTRCD = "";
            _OT.YYMM = item.Cells["計薪年月"].Value.ToString();
            _OT.OT_DEPT = item.Cells["加班部門"].Value.ToString();
            _OT.KEY_MAN = MainForm.USER_NAME;
            _OT.OT_EDATE = Convert.ToDateTime(item.Cells["加班日期"].Value.ToString());
            _OT.KEY_DATE = DateTime.Now;
            _OT.TOT_HOURS = Convert.ToDecimal(item.Cells["總時數"].Value.ToString());
            _OT.OT_HRS = Convert.ToDecimal(item.Cells["加班時數"].Value.ToString());
            _OT.REST_HRS = Convert.ToDecimal(item.Cells["補休時數"].Value.ToString());
            _OT.NOTE = item.Cells["備註"].Value.ToString();
            _OT.SYSCREAT = true;
            //_OT.OTTYPE = item.Cells["加班類別"].Value.ToString();
            _OT.OT_CAR = 0M;
            _OT.OT_FOOD = 0m;
            _OT.FOOD_PRI = 0M;
            _OT.FOOD_CNT = 0M;
            _OT.SER = "";
            _OT.NOT_W_133 = 0M;
            _OT.NOT_W_167 = 0M;
            _OT.NOT_W_200 = 0M;
            _OT.NOT_H_200 = 0M;
            _OT.TOT_W_100 = 0M;
            _OT.TOT_W_133 = 0M;
            _OT.TOT_W_167 = 0M;
            _OT.TOT_W_200 = 0M;
            _OT.TOT_H_200 = 0M;
            _OT.NOT_EXP = 0M;
            _OT.TOT_EXP = 0M;
            _OT.REST_EXP = 0M;
            _OT.FST_HOURS = 0M;
            _OT.SALARY = 0M;
            _OT.NOTMODI = false;
            _OT.NOFOOD = false;
            _OT.FIX_AMT = false;
            _OT.REC = 0M;
            _OT.CANT_ADJ = false;
            if ((currentFileName + ForOTNO.ToString("MMddhhmmss")).Length <= 49)
            {
                _OT.OTNO = currentFileName + ForOTNO.ToString("MMddhhmmss");
            }
            else {
                _OT.OTNO = (currentFileName + ForOTNO.ToString("MMddhhmmss")).Substring(0,49);
            }
            _OT.OT_ROTE = "";
            _OT.OT_FOOD1 = Convert.ToDecimal(item.Cells["誤餐費"].Value.ToString()); 
            _OT.OT_FOODH = 0M;
            _OT.OT_FOODH1 = 0M;
            _OT.NOP_W_133 = 0M;
            _OT.NOP_W_167 = 0M;
            _OT.NOP_W_200 = 0M;
            _OT.NOP_H_100 = 0M;
            _OT.NOP_H_133 = 0M;
            _OT.NOP_H_167 = 0M;
            _OT.NOP_H_200 = 0M;
            _OT.TOP_W_133 = 0M;
            _OT.TOP_W_167 = 0M;
            _OT.TOP_W_200 = 0M;
            _OT.TOP_H_200 = 0M;
            _OT.NOT_H_133 = 0M;
            _OT.NOT_H_167 = 0M;
            _OT.HOT_133 = 0M;
            _OT.HOT_166 = 0M;
            _OT.HOT_200 = 0M;
            _OT.WOT_133 = 0M;
            _OT.WOT_166 = 0M;
            _OT.WOT_200 = 0M;
            _OT.SUM = false;
            //_OT.SYSCREAT = false;
            _OT.OTRATE_CODE = "";
            _OT.NOT_W_100 = 0M;
            _OT.TOP_W_100 = 0M;
            _OT.SYSCREAT1 = false;
            _OT.NOP_W_100 = 0M;
            _OT.SYS_OT = false;
            _OT.SERNO = "";
            _OT.DIFF = 0M;
            //_OT.EAT = Convert.ToBoolean(item.Cells["誤餐費"].Value.ToString());
            _OT.EAT = false;
            _OT.RES = false;
            _OT.NOFOOD1 = false;
            return _OT;
        }
        public JBHR.Att.dsAtt.OT1Row creatErrorRow(DataGridViewRow item, String note, JBHR.Att.dsAtt.OT1DataTable _OTDataTable)
        {
            var row = _OTDataTable.NewOT1Row();
            row.NOBR = item.Cells["員工編號"].Value.ToString();
            row.NAME_C = item.Cells["員工姓名"].Value.ToString();
            row.BDATE = Convert.ToDateTime(item.Cells["加班日期"].Value.ToString());
            row.BTIME = item.Cells["加起時間"].Value.ToString();
            row.OT_DEPT = item.Cells["加班部門"].Value.ToString();
            row.DEPTNAME = item.Cells["部門名稱"].Value.ToString();
            row.ETIME = item.Cells["加迄時間"].Value.ToString();
            row.TOT_HOURS = Convert.ToDecimal(item.Cells["總時數"].Value.ToString());
            row.OT_HRS = Convert.ToDecimal(item.Cells["加班時數"].Value.ToString());
            row.REST_HRS = Convert.ToDecimal(item.Cells["補休時數"].Value.ToString());
            row.KEY_MAN = MainForm.USER_NAME;
            row.KEY_DATE = DateTime.Now;
            row.NOTE = item.Cells["備註"].Value.ToString();
            row.YYMM = item.Cells["計薪年月"].Value.ToString();
            //row.OTTYPE = item.Cells["加班類別"].Value.ToString();
            row.OTRCD = "";
            row.SERNO = item.Cells["SERNO"].Value.ToString();
            row.OT_FOOD1 = Convert.ToDecimal(item.Cells["誤餐費"].Value.ToString());
            row.OTNO = item.Cells["OTNO"].Value.ToString() + note;

            return row;
        }
        #endregion
        //不可重複ot

        public List<JBModule.Data.Linq.BASETTS> getBasettsList() { 
        
        var basettsList = (from basettsListi in HDDC.BASETTS 
                          where 
                          DateTime.Now.CompareTo(basettsListi.ADATE) >= 0
                          &&
                          DateTime.Now.CompareTo(basettsListi.DDATE) <= 0
                           select basettsListi
                               ).ToList();

        return basettsList;
        
        }
        public String setETime(String BTime, String ETime)
        {
            if (Convert.ToInt32(BTime) > Convert.ToInt32(ETime))
            {
                return ((Convert.ToInt32(ETime.Substring(0, 2)) + 24).ToString()) + ETime.Substring(2, 2);
            }else{
                return ETime;
            }
        }
        public bool hasOT(String Nobr, DateTime BDate, String BTime, String ETime)
        {
           
            var _OT = from _OTi in OTList
                      where
                          _OTi.NOBR.Equals(Nobr)
                          &&
                          _OTi.BDATE.CompareTo(BDate) == 0
                          &&
                          !((_OTi.BTIME.CompareTo(ETime) >= 0 && _OTi.ETIME.CompareTo(BTime) > 0) || (_OTi.BTIME.CompareTo(ETime) < 0 && _OTi.ETIME.CompareTo(BTime) <= 0))
                      select _OTi;
            return _OT.Any();
        }
        //public bool hasOT(String NOBR, DateTime BDATE, String BTime, String Code, List<String> OCrepeat, List<String> OTrepeat, String ETime)
        public bool hasOT(String NOBR, DateTime BDATE, String BTime, String Code, String ETime)
        {
            //bool canReapt = OCrepeat.Contains(Code) || OTrepeat.Contains(Code) ? true : false;

            //if (Code.Length == 0 || !canReapt)
            if (Code.Length == 0 )
            {
                if (BTime.Length == 0)
                {
                    var _OT = from _OTi in OTList
                              where _OTi.NOBR.Equals(NOBR)
                              && 
                              _OTi.BDATE.CompareTo(BDATE.Date) == 0
                              select _OTi;
                    return _OT.Any();
                }
                else
                {
                    var _OT = from _OTi in OTList
                              where _OTi.NOBR.Equals(NOBR)
                              && 
                              _OTi.BDATE.CompareTo(BDATE.Date) == 0
                              &&
                              !((_OTi.BTIME.CompareTo(ETime) >= 0 && _OTi.ETIME.CompareTo(BTime) > 0) || (_OTi.BTIME.CompareTo(ETime) < 0 && _OTi.ETIME.CompareTo(BTime) <= 0))
                              select _OTi;
                    return _OT.Any();
                }
            }
            else
            {
                //if (BTime.Length == 0)
                //{
                    //var _OT = from _OTi in OTList
                    //          where _OTi.NOBR.Equals(NOBR)
                    //          && _OTi.BDATE.CompareTo(BDATE.Date) == 0
                    //          select new { _OTi.OTTYPE };

                    //if (_OT.Count() == 0)
                    //{
                    //    return false;
                    //}
                    //else
                    //{

                    //    bool hasOTFlag = false;

                    //    foreach (var item in _OT)
                    //    {
                    //        if ((OCrepeat.Contains(item.OTTYPE) && OCrepeat.Contains(Code)) || (OTrepeat.Contains(item.OTTYPE) && OTrepeat.Contains(Code)))
                    //        {
                    //            hasOTFlag =  true;
                    //        }
                    //    }
                    //    return hasOTFlag;
                    //}

                    //if (_OT.Count() > 1)
                    //{
                    //    return true;
                    //}
                    //else if (_OT.Count() == 0)
                    //{
                    //    return false;
                    //}
                    //else
                    //{
                    //    if ((OCrepeat.Contains(_OT.FirstOrDefault().OTTYPE) && OCrepeat.Contains(Code)) || (OTrepeat.Contains(_OT.FirstOrDefault().OTTYPE) && OTrepeat.Contains(Code)))
                    //    {
                    //        return true;
                    //    }
                    //    else
                    //    {
                    //        return false; ;
                    //    }
                    //}
                //}
                //else
                //{
                    //var _OT = from _OTi in OTList
                    //          where _OTi.NOBR.Equals(NOBR)
                    //          && _OTi.BDATE.CompareTo(BDATE.Date) == 0
                    //          && 
                    //          !((_OTi.BTIME.CompareTo(ETime) >= 0 && _OTi.ETIME.CompareTo(BTime) > 0) || (_OTi.BTIME.CompareTo(ETime) < 0 && _OTi.ETIME.CompareTo(BTime) <= 0))
                    //          select new { _OTi.OTTYPE };
                    //if (_OT.Count() > 1)
                    //{
                    //    return true;
                    //}
                    //else 
                    //if (_OT.Count() == 0)
                    //{
                    //    return false;
                    //}
                    //else
                    //{
                    //    bool hasOTFlag = false;
                    //    foreach (var item in _OT)
                    //    {

                    //        if ((OCrepeat.Contains(item.OTTYPE) && OCrepeat.Contains(Code)) || (OTrepeat.Contains(item.OTTYPE) && OTrepeat.Contains(Code)))
                    //        {
                    //            hasOTFlag =  true;
                    //        }
                    //    }
                    //    return hasOTFlag;
                    //}
            //    }
                return false;
            }
        }

        public bool IsLockedYYMM(DateTime date)
        {
            dcAttDataContext db = new dcAttDataContext();
            var sql = from a in db.DATA_PASS where a.DATA_PASS1 >= date select a;
            var gg = from a in sql.ToList() orderby a.DATA_PASS1 select new SalaryDate(a.DATA_PASS1).YYMM;
            var orderList = gg.Distinct();
            SalaryDate sd = new SalaryDate(date);
            sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有這筆計薪年月，就在往下個月
                return true;
            return false;
        }
    }
}
