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


namespace JBHR.ImportC.ABS
{
    class ABSC1 : ImportC.ImportGen
    {
        JBHR.Att.dsAtt.ABS2DataTable _ABS2DTable;

        public DateTime maxDate;
        public DateTime minDate;
        public String currentFileName = "";
        public DateTime ForOTNO = DateTime.Now;
        public string guid;
        List<JBModule.Data.Linq.ABS> ABSList = null;
        List<JBModule.Data.Linq.BASETTS> basettsList = null;
        List<JBModule.Data.Linq.HCODE> HCODEList = null;
        public List<JBModule.Data.Linq.ABS1> ABS1List = null;
        //public List<OVERTIME_TYPE> otTypeList = null;
        public override System.Data.DataTable ceateRoteChgTable(Dictionary<string, string> dic, System.Windows.Forms.ProgressBar PB)
        {
            basettsList = getBasettsList();
            setDateRange(dic["BDATE"]);
            //ABSList = getABSList();
            //ABSList = getABS1List();
            HCODEList = getHCODEList();
           
            _ABS2DTable = new Att.dsAtt.ABS2DataTable();

            Dictionary<String,String> ExcelABSErrorDic = new Dictionary<String,String>();
            
            bool hasNOTE = dic["NOTE"].Length != 0 ? true : false;
            bool hasYYMM = dic["YYMM"].Length != 0 ? true : false;
                        
            Sal.Core.SalaryDate SD;
           
            String NOBRData;
            string NAMEData;
            DateTime BDATEData = DateTime.MaxValue;
            DateTime EDATEData = DateTime.MaxValue;
            String ETIMEData;
            String BTIMEData;
            String H_CODEData;
            decimal TOTALData ;
            String _YYMM = "";
            String _NOTE = "";
            decimal TotalHours = 0;
   
            PB.Value = 0;
            PB.Maximum = excelDT.Rows.Count;
            foreach (DataRow item in excelDT.Rows)
            {
                bool TimeErrorFlag = false;
                PB.Value += 1;
                TOTALData = 0;

                #region 初始化BDATE/EDATE
                //if (BDATEData.Date.CompareTo(Convert.ToDateTime(item[dic["BDATE"]].ToString()).Date)!=0)
                //{
                //}
                BDATEData = Convert.ToDateTime(item[dic["BDATE"]].ToString()).Date;
                EDATEData = Convert.ToDateTime(item[dic["EDATE"]].ToString()).Date;
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

                TOTALData = 0;
               
                //請假時數
                try
                {
                    TOTALData = Convert.ToDecimal(item[dic["TOL_HOURS"]].ToString());
                }
                catch (Exception)
                {
                    TOTALData = 0;
                }
               
                //請假代碼
                H_CODEData = item[dic["H_CODE"]].ToString().Trim();
                
                //員工編號
                NOBRData = item[dic["NOBR"]].ToString().Trim().ToUpper();

                //員工姓名
                NAMEData = item[dic["NAME_C"]].ToString().Trim().ToUpper();

                //請假事由
                _NOTE = hasNOTE ? item[dic["NOTE"]].ToString().Trim() : "";

 
                #region 時間格式判斷

                ETIMEData = getTime(item[dic["ETIME"]].ToString(),"ETIME",out TimeErrorFlag);
                BTIMEData = getTime(item[dic["BTIME"]].ToString(), "BTIME", out TimeErrorFlag);
                if (TimeErrorFlag)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "請假起時間格式錯誤");
                    continue;
                }

                if (TimeErrorFlag)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "請假迄時間格式錯誤");
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
                        InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "員工編號與員工姓名對應錯誤");
                        continue;
                    }
                }
                else
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "無此員工編號");
                    continue;
                }
                #endregion

                #region 判斷時間起迄
                if (TimeError(BTIMEData,ETIMEData))
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "加班起迄時間錯誤");
                    continue;
                }
                #endregion

                #region 判斷計薪年月格式/計薪年月已鎖檔
                if (FormatValidate.CheckYearMonthFormat(_YYMM) != true)
                {   
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "計薪年月格式輸入錯誤");
                    continue;
                }
                if (IsLockedYYMM(BDATEData))
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "計薪年月已鎖檔");
                    continue;
                }
                #endregion



                #region 判斷請假時數不正確
                var details = JBHR.Dll.Att.AbsCal.AbsCalculationBy24(NOBRData, H_CODEData, BDATEData, EDATEData, BTIMEData, ETIMEData, "");
                TotalHours = details.sHcodeUnit == "天" ? details.iTotalDay : details.iTotalHour;
                if (TOTALData != TotalHours)
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "請假總時數不正確(請假總時數" + TotalHours.ToString() + "小時)");
                    continue;
                }
                #endregion

                #region 判斷假別代碼錯誤/申請的時段已存在請假資料/剩餘時數不足
                decimal Balance, BalanceGroup, tothours;
                tothours = 0;
                JBModule.Data.Linq.HrDBDataContext linqdb = new JBModule.Data.Linq.HrDBDataContext();
                var hcodeSQL = from a in HCODEList
                               where a.H_CODE.Equals(H_CODEData)
                               select a;
                if (hcodeSQL.Any())
                {
                    JBModule.Data.Dto.AbsenceApply absApply = new JBModule.Data.Dto.AbsenceApply();
                    absApply.EmployeeID = NOBRData;
                    absApply.ApplyBeginDate = BDATEData.AddTime(BTIMEData);
                    absApply.ApplyEndDate = EDATEData.AddTime(ETIMEData);
                    absApply.Hcode = H_CODEData;
                    JBHR.BLL.AbsenseFactory af = new BLL.AbsenseFactory();
                    
                    //var hcode = new CodeAgent().GetHCODEByCode(Condition.HolidayCode);
                    var ap = af.CreateAbsApply();
                    var apData = ap.GenerateABS(absApply);
                    var av = af.CreateAbsValidate();
                    var checkAp = av.Validate(apData);
                    if (!checkAp)
                    {
                        if (av.RejectCode == 201001)
                        {
                            InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "申請的時段已存在請假資料");
                            continue;
                        }
                        //if (av.RejectCode == 201002)
                        //    MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"剩餘時數不足", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Dal.Dao.Att.AbsDao oAbsDao = new Dal.Dao.Att.AbsDao(linqdb.Connection);
                        var rsBalance = oAbsDao.GetBalance(NOBRData, BDATEData);
                        var rBalance = rsBalance.Where(p => p.Hcode == H_CODEData).First();
                        Balance = rBalance.Balance;
                        BalanceGroup = rBalance.BalanceGroup;

                        if (Balance > 0 && BalanceGroup > 0)
                            tothours = Balance;
                        else if (Balance <= 0)
                            tothours = Balance;
                        else if (Balance > 0 && BalanceGroup < 0)
                            tothours = BalanceGroup;
                        if (tothours < apData.Sum(p => p.TOL_HOURS))
                        {
                            InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "剩餘時數不足");
                            continue;
                        }
                    }
                }
                else
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "假別代碼錯誤");
                    continue;
                }
                #endregion

                #region 判斷申請的時段內已有存在的請假資料
                var absData = JBHR.BLL.Att.Absence.GetExistsABS(NOBRData, BDATEData, EDATEData, BTIMEData, ETIMEData, H_CODEData);
                if (absData.Any())
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "申請的時段內已有存在的請假資料");
                    continue;
                }
                #endregion

                #region 判斷申請的時段內已有存在的刷卡資料
                var AttCardData = JBHR.BLL.Att.Absence.GetExistsAtt(NOBRData, BDATEData, EDATEData, BTIMEData, ETIMEData);
                if (AttCardData.Any())
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "申請的時段內已有存在的刷卡資料");
                    continue;
                }
                #endregion

                #region EXCEL重複判斷
                if (ExcelABSError(ExcelABSErrorDic, NOBRData, BDATEData, EDATEData, BTIMEData, ETIMEData, H_CODEData)) 
                {
                    InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "Excel請假資料重複");
                    continue;
                }
                #endregion

                InsertDataTable("", NOBRData, NAMEData, BDATEData, EDATEData, BTIMEData, ETIMEData, TOTALData, _YYMM, H_CODEData, "");
            }
            setExcelName();
            return _ABS2DTable;
        }


        public override int insertRoteChg(System.Windows.Forms.DataGridView DGW, System.Windows.Forms.ProgressBar PB)
        {
            //ABSList = getABSList();
            ForOTNO  = DateTime.Now;
            currentFileName = FileName.Substring(FileName.LastIndexOf("\\") + 1, FileName.Length - FileName.LastIndexOf("\\") - 1);
            //JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
            ////取得補休得假代碼
            //var leaveType = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
            JBHR.Att.dsAtt.ABS2DataTable _ABS2DTable = new Att.dsAtt.ABS2DataTable();
            PB.Value = 0;
            PB.Maximum = DGW.Rows.Count;

            string nobr = "", btime = "", etime = "", depts = "", memo = "", username = "", hcode = "";
            DateTime date_b = DateTime.Now.Date, date_e = DateTime.Now.Date;
            decimal tol_hours = 0;
            string guid;
            int cnt = 0;

            //List<JBModule.Data.Linq.OT> list = new List<JBModule.Data.Linq.OT>();
            List<JBModule.Data.Linq.ABS> absList = new List<JBModule.Data.Linq.ABS>();
            foreach (DataGridViewRow item in DGW.Rows)
            {
                PB.Value += 1;
                if (item.Cells["SERNO"].Value != null)
                {
                    if (item.Cells["SERNO"].Value.ToString().Trim() == "")
                    {
                        cnt = cnt + 1;
                        guid = Guid.NewGuid().ToString();
                        nobr = item.Cells["員工編號"].Value.ToString();
                        btime = item.Cells["請起時間"].Value.ToString();
                        etime = item.Cells["請迄時間"].Value.ToString();
                        depts = "";
                        memo = item.Cells["請假事由"].Value.ToString();
                        username = MainForm.USER_NAME;
                        date_b = Convert.ToDateTime(item.Cells["請假日期起"].Value.ToString());
                        date_e = Convert.ToDateTime(item.Cells["請假日期迄"].Value.ToString());
                        hcode = item.Cells["假別代碼"].Value.ToString();
                        tol_hours = Convert.ToDecimal(item.Cells["請假時數/天"].Value.ToString());

                        DateTime t1, t2;
                        t1 = DateTime.Now;
                        if (date_b == date_e && btime.CompareTo(etime) < 0)
                            absList.Add(doInsertABS(item, guid));
                        else
                        {
                            if (date_b.AddDays(1) == date_e && btime.CompareTo(etime) > 0)//日期差一天，但是申請時間大於結束時間，代表跨天
                                Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", tol_hours, guid);
                            else if (date_b < date_e)//請多天要拆每天時數
                                Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", 0, guid);

                            //t2 = DateTime.Now;
                            //JBHR.Att.dsAtt.ABSDataTable dtAbs = new JBHR.Att.dsAtt.ABSDataTable();

                            //dtAbs = new JBHR.Att.dsAttTableAdapters.ABSTableAdapter().GetDataByKeyDate(t1, t2);
                            //JBHR.Att.dsAtt.ABS.Merge(dtAbs);
                        }
                    }
                    else
                    {
                        _ABS2DTable.AddABS2Row(creatErrorRow(item, "", _ABS2DTable));
                    }
                }
            }
            setExcelName();
            if (_ABS2DTable.Rows.Count > 0)
            {
                String errorDataPath = "C:\\Temp\\請假資料(" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ").xls";
                JBModule.Data.CNPOI.ExportToExcel(_ABS2DTable, errorDataPath, "");
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"錯誤資料匯出 : " + errorDataPath, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            try
            {
                //absList
                HDDC.ABS.InsertAllOnSubmit(absList);

#region 

                HDDC.ABS.InsertAllOnSubmit(absList);

#endregion 
                HDDC.SubmitChanges();
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"成功匯入:" + cnt + "筆");
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

                //return absList.Count;
                return cnt;

            }
            catch (DuplicateKeyException dke)
            {
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"請重新匯入再產生。");
                return 0;
            }
            
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
        public bool ExcelABSError(Dictionary<String, String> dic, String NOBR, DateTime Bdate, DateTime Edate, String BTime, String ETime, String Hcode)
        {
            String key = NOBR.ToUpper() + Bdate.Date.ToString() + Edate.Date.ToString() + BTime + Hcode;
            try
            {
                dic.Add(key, "");
            }
            catch (Exception)
            {
                return true;
            }
            var abssql = from a in _ABS2DTable where a.NOBR == NOBR && a.BDATE <= Bdate && a.EDATE >= Edate select a;
            if (abssql.Any())
                return true;
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
                //if (hasAttend.ROTE.Equals("00"))
                //{
                //    return false;
                //}

               
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
            foreach (DataColumn item in _ABS2DTable.Columns)
            {
                item.ColumnName = item.Caption;
            }
        }
        public void InsertDataTable(String note, String NOBR, string NAME_C, DateTime BDate, DateTime EDate, String BTime, String ETime, decimal TotleHours, String YYMM, String HCode, String ErrorMsg)
        {
            var row = _ABS2DTable.NewABS2Row();
            row.NOBR = NOBR;
            row.NAME_C = NAME_C;
            row.BDATE = BDate.Date;
            row.EDATE = EDate.Date;
            row.BTIME = BTime;
            row.ETIME = ETime;
            row.YYMM = YYMM;
            row.TOL_HOURS = TotleHours;
            row.KEY_MAN = MainForm.USER_NAME;
            row.KEY_DATE = DateTime.Now;
            row.NOTE = note;
            row.H_CODE = HCode;
            //row.SERNO = OC;
            row.SERNO = ErrorMsg;
            _ABS2DTable.AddABS2Row(row);
        }
        public String createYYMM(String YYMM) {
            String reg = "^(19|20)\\d\\d(0[1-9]|1[012])";
            Match m = Regex.Match(YYMM, reg);
            if (m.Success)
                return YYMM.Substring(0, 6);
            else
                return YYMM;
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
       

        public List<JBModule.Data.Linq.HCODE> getHCODEList()
        {
            return (from a in HDDC.HCODE where !new string[] { "1", "3", "5", "7", "9" }.Contains(a.YEAR_REST) select a).ToList();
        }

        
        #region 按下產生
        //public bool doInsertABS(List<JBModule.Data.Linq.ABS> list, DateTime BDATE, String NOBR, String YYMM, Decimal totalHour, String leaveType , String BTime,String ETime)
        //{
        //    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
        //    abs.A_NAME = "";
        //    abs.BDATE = BDATE;
        //    abs.BTIME = BTime;
        //    DateTime dt_E = BDATE.AddMonths(3);
        //    abs.EDATE = new DateTime(dt_E.Year, dt_E.Month, DateTime.DaysInMonth(dt_E.Year, dt_E.Month));
        //    abs.ETIME = ETime;
        //    abs.H_CODE = leaveType;
        //    abs.KEY_DATE = DateTime.Now;
        //    abs.KEY_MAN = MainForm.USER_NAME;
        //    abs.NOBR = NOBR;
        //    abs.nocalc = false;
        //    if ((currentFileName + ForOTNO.ToString("MMddhhmmss")).Length <= 49)
        //    {
        //        abs.NOTE = currentFileName + ForOTNO.ToString("MMddhhmmss");
        //    }
        //    else {
        //        abs.NOTE = (currentFileName + ForOTNO.ToString("MMddhhmmss")).Substring(0,49);
        //    }
        //    abs.NOTEDIT = false;
        //    abs.SERNO = Guid.NewGuid().ToString();
        //    abs.SYSCREATE = true;
        //    abs.TOL_DAY = 0;
        //    abs.TOL_HOURS = totalHour;
            
        //    abs.YYMM = YYMM;
        //    var sql = from a in ABSList
        //              where
        //              a.NOBR == abs.NOBR
        //              && a.BDATE == abs.BDATE
        //              && a.BTIME == abs.BTIME
        //              && a.H_CODE == abs.H_CODE
        //              select a;
        //    if (!sql.Any())//不存在才新增
        //    {
        //        list.Add(abs);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public JBModule.Data.Linq.ABS doInsertABS(DataGridViewRow item, string serno)
        {
            JBModule.Data.Linq.ABS _ABS = new JBModule.Data.Linq.ABS();
            
            _ABS.NOBR = item.Cells["員工編號"].Value.ToString();
            _ABS.BDATE = Convert.ToDateTime(item.Cells["請假日期起"].Value.ToString());
            _ABS.EDATE = Convert.ToDateTime(item.Cells["請假日期迄"].Value.ToString());
            _ABS.BTIME = item.Cells["請起時間"].Value.ToString();
            _ABS.ETIME = item.Cells["請迄時間"].Value.ToString();
            _ABS.H_CODE = item.Cells["假別代碼"].Value.ToString();
            _ABS.TOL_HOURS = Convert.ToDecimal(item.Cells["請假時數/天"].Value.ToString());
            _ABS.KEY_MAN = MainForm.USER_NAME;
            _ABS.KEY_DATE = DateTime.Now;
            _ABS.YYMM = item.Cells["計薪年月"].Value.ToString();
            _ABS.NOTEDIT = false;
            _ABS.NOTE = item.Cells["請假事由"].Value.ToString();
            _ABS.SYSCREATE = false;
            _ABS.TOL_DAY = 0M;
            _ABS.A_NAME = "";
            _ABS.SERNO = serno;
            _ABS.nocalc = false;
            _ABS.SYSCREATE1 = false;
            return _ABS;
        }

   
        public JBHR.Att.dsAtt.ABS2Row creatErrorRow(DataGridViewRow item, String note, JBHR.Att.dsAtt.ABS2DataTable _ABS2DTable)
        {
            var row = _ABS2DTable.NewABS2Row();
            row.NOBR = item.Cells["員工編號"].Value.ToString();
            row.NAME_C = item.Cells["員工姓名"].Value.ToString();
            row.BDATE = Convert.ToDateTime(item.Cells["請假日期起"].Value.ToString());
            row.BDATE = Convert.ToDateTime(item.Cells["請假日期迄"].Value.ToString());
            row.BTIME = item.Cells["請起時間"].Value.ToString();
            row.ETIME = item.Cells["請迄時間"].Value.ToString();
            row.H_CODE = item.Cells["假別代碼"].Value.ToString();
            row.TOL_HOURS = Convert.ToDecimal(item.Cells["請假時數/天"].Value.ToString());
            row.KEY_MAN = MainForm.USER_NAME;
            row.KEY_DATE = DateTime.Now;
            row.NOTE = item.Cells["請假事由"].Value.ToString();
            row.YYMM = item.Cells["計薪年月"].Value.ToString();
            row.SERNO = item.Cells["SERNO"].Value.ToString();
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
