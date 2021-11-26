using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JBHR.Att
{
    public partial class FRM29IN : JBControls.U_FIELD
    {
        public FRM29IN()
        {
            InitializeComponent();
            //cbAmt.Tag = "AMT";
            BindingControls.Add(cbxBDATE);
            BindingControls.Add(cbxBTIME);
            BindingControls.Add(cbxNOTE);
            BindingControls.Add(cbxETIME);
            BindingControls.Add(cbxMeal);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxROTE);
            BindingControls.Add(cbxDEPTS);
            BindingControls.Add(cbxREST_HRS);
            BindingControls.Add(cbxOT_HRS);
            BindingControls.Add(cbxYYMM);
            BindingControls.Add(cbCheckAttend);
            BindingControls.Add(cbxADate);
        }
        private void FRM29IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxBDATE);
            cc.AddControl(cbxBTIME);
            //cc.AddControl(cbxOTRCD);
            cc.AddControl(cbxETIME);
            //cc.AddControl(cbxMeal);
            cc.AddControl(cbxNOBR);
            //cc.AddControl(cbxNOTE);
            cc.AddControl(cbxREST_HRS);
            cc.AddControl(cbxOT_HRS);
            cc.AddControl(cbxYYMM);
        }
        CheckControl cc;//必填欄位
        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }





    }
    public class ImportTransferToOT : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            string serNo = Guid.NewGuid().ToString();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                string YYMM = TransferRow["計薪年月"].ToString();
                string NOBR = TransferRow["員工編號"].ToString();
                string NAME = TransferRow["員工姓名"].ToString();
                string BTIME = TransferRow["加班起時間"].ToString();
                string ETIME = TransferRow["加班迄時間"].ToString();
                bool isCheckAttend = Convert.ToBoolean(TransferRow["檢查出勤時間"].ToString());
                string OT_HRS = TransferRow["加班時數"].ToString();
                string REST_HRS = TransferRow["補休時數"].ToString();

                string TOT_HOURS = TransferRow["總時數"].ToString();
                string OT_EDATE = TransferRow["有效日期"].ToString();
                string BDATE = TransferRow["加班日期"].ToString();
                string OT_ROTE = TransferRow["加班班別代碼"].ToString();
                string OT_DEPTS = TransferRow["加班部門代碼"].ToString();
                string D_NAME = TransferRow["加班部門名稱"].ToString();
                string OT_FOOD1 = TransferRow["誤餐費"].ToString();
                string NOTE = TransferRow["備註"].ToString();
                var roteSql = from ac in db.ATTEND where ac.NOBR == NOBR && ac.ADATE == Convert.ToDateTime(BDATE) select ac;


                JBModule.Data.Linq.OT r = new JBModule.Data.Linq.OT();


                r.NOBR = NOBR;
                r.BDATE = Convert.ToDateTime(BDATE);
                r.BTIME = BTIME;
                r.ETIME = ETIME;
                r.OT_FOOD1 = OT_FOOD1 != "" ? Convert.ToDecimal(OT_FOOD1) : 0;
                r.OT_HRS = Convert.ToDecimal(OT_HRS);
                r.OT_ROTE = OT_ROTE != "" ? CheckData["加班班別代碼"].Where(p => p.DisplayCode == OT_ROTE).First().RealCode : OT_ROTE;
                r.REST_HRS = Convert.ToDecimal(REST_HRS);
                r.TOT_HOURS = Convert.ToDecimal(TOT_HOURS);
                r.NOTE = NOTE;
                r.YYMM = YYMM;
                r.OT_DEPT = OT_DEPTS != "" ? CheckData["加班部門代碼"].Where(p => p.DisplayCode == OT_DEPTS).First().RealCode : OT_DEPTS;
                r.YYMM = YYMM;
                r.OT_EDATE = Convert.ToDateTime(OT_EDATE);
                r.KEY_DATE = DateTime.Now;
                r.KEY_MAN = MainForm.USER_NAME;

                r.OT_CAR = 0;
                r.OT_FOOD = 0;
                r.FOOD_PRI = 0;
                r.FOOD_CNT = 0;
                r.SER = "";
                r.NOT_W_133 = 0;
                r.NOT_W_167 = 0;
                r.NOT_W_200 = 0;
                r.NOT_H_200 = 0;
                r.TOT_W_100 = 0;
                r.TOT_W_133 = 0;
                r.TOT_W_167 = 0;
                r.TOT_W_200 = 0;
                r.TOT_H_200 = 0;
                r.NOT_EXP = 0;
                r.TOT_EXP = 0;
                r.REST_EXP = 0;
                r.FST_HOURS = 0;
                r.SALARY = 0;
                r.NOTMODI = false;
                r.OTRCD = "";
                r.NOFOOD = false;
                r.FIX_AMT = false;
                r.REC = 0;
                r.CANT_ADJ = false;
                r.OTNO = "FRM29IN";
                r.OT_FOODH = 0;
                r.OT_FOODH1 = 0;
                r.NOP_W_133 = 0;
                r.NOP_W_167 = 0;
                r.NOP_W_200 = 0;
                r.NOP_H_100 = 0;
                r.NOP_H_133 = 0;
                r.NOP_H_167 = 0;
                r.NOP_H_200 = 0;
                r.TOP_W_133 = 0;
                r.TOP_W_167 = 0;
                r.TOP_W_200 = 0;
                r.TOP_H_200 = 0;
                r.NOT_H_133 = 0;
                r.NOT_H_167 = 0;
                r.HOT_133 = 0;
                r.HOT_166 = 0;
                r.HOT_200 = 0;
                r.WOT_133 = 0;
                r.WOT_166 = 0;
                r.WOT_200 = 0;
                r.SUM = false;
                r.SYSCREAT = false;
                r.OTRATE_CODE = "";
                r.NOT_W_100 = 0;
                r.TOP_W_100 = 0;
                r.SYSCREAT1 = false;
                r.NOP_W_100 = 0;
                r.SYS_OT = false;
                r.SERNO = serNo;
                r.DIFF = 0;
                r.EAT = false;
                r.RES = false;
                r.NOFOOD1 = false;

                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
                var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
                JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                abs.A_NAME = "";
                abs.BDATE = r.BDATE;
                abs.BTIME = r.BTIME;
                abs.EDATE = r.OT_EDATE;// abs.BDATE.AddMonths(6).AddDays(-1);
                abs.ETIME = r.ETIME;
                abs.H_CODE = CompseCode;
                abs.KEY_DATE = DateTime.Now;
                abs.KEY_MAN = MainForm.USER_NAME;
                abs.NOBR = r.NOBR;
                abs.nocalc = false;
                abs.NOTE = r.NOTE;
                abs.NOTEDIT = false;
                abs.SERNO = serNo;
                abs.SYSCREATE = false;
                abs.TOL_DAY = 0;
                abs.TOL_HOURS = r.REST_HRS;
                abs.Balance = r.REST_HRS;
                abs.Guid = Guid.NewGuid().ToString();
                abs.LeaveHours = 0;
                abs.YYMM = r.YYMM;

                if (isCheckAttend)
                {
                    if (!CheckAttCard(r.NOBR, r.BDATE, r.BTIME, r.ETIME))
                    {
                        ErrMsg += "加班時間無介於出勤刷卡時間內";
                        return false;
                    }
                }

                //var sql = (from a in db.OT where a.NOBR == r.NOBR && a.BDATE == r.BDATE && a.BTIME == r.BTIME select a).ToList();
                if (GetOT(r.NOBR, r.BDATE.ToString(), r.BTIME, r.ETIME))
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        DeleteOT(r, abs, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        UpdateOT(r, abs, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同時段的加班資料";
                        return false;
                    }
                }
                else
                {
                    InsertOT(r, abs, out ErrMsg);
                }
            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }
        bool GetOT(string EmployeeId, string BDATE, string BTIME, string ETIME)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OT where a.NOBR == EmployeeId && a.BDATE == Convert.ToDateTime(BDATE) && a.BTIME.CompareTo(ETIME) < 0 && a.ETIME.CompareTo(BTIME) > 0 select a;
            if (sql.Any())
            {
                return true;
            }
            return false;
        }
        bool GetAttend(string EmployeeId, string BDATE, string BTIME, string ETIME)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ATTEND 
                      join b in db.ROTE on a.ROTE equals b.ROTE1
                      where a.NOBR == EmployeeId && a.ADATE == Convert.ToDateTime(BDATE) 
                      && b.ON_TIME.CompareTo(ETIME) < 0 && b.OFF_TIME.CompareTo(BTIME) > 0 
                      select a;
            if (sql.Any())
            {
                return true;
            }
            return false;
        }
        bool CheckAttCard(string Nobr, DateTime Adate, string Btime, string Etime)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.ATTCARD where a.NOBR == Nobr && a.ADATE == Adate select a).FirstOrDefault();
            if (sql != null)
            {
                var b = Convert.ToInt32(Btime);
                var e = Convert.ToInt32(Etime);
                if (sql.T1.Length < 4 || sql.T2.Length <4)
                    return false;
                var sb = Convert.ToInt32(sql.T1);
                var se = Convert.ToInt32(sql.T2);

                if (sb <= b && e <= se)
                    return true;
            }
            return false;
        }
        public decimal OtCalc(string NOBR, string ROTE, DateTime BDATE, string BTIME, string ETIME)
        {
            string t1, t2;
            DateTime d1;
            d1 = Convert.ToDateTime(BDATE);
            t1 = Convert.ToInt32(BTIME).ToString("0000");
            t2 = Convert.ToInt32(ETIME).ToString("0000");
            var details = JBHR.Dll.Att.OtCal.CalculationOt(NOBR, ROTE, d1, t1, t2);
            return details.iHour;
        }
        bool DeleteOT(JBModule.Data.Linq.OT Instance, JBModule.Data.Linq.ABS abs, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.OT where a.NOBR == Instance.NOBR && a.BDATE == Instance.BDATE && a.BTIME == Instance.BTIME select a).ToList();
                if (sql.Any())//有資料
                {
                    var s = sql.First();
                    if (!string.IsNullOrWhiteSpace(s.SERNO))
                    {
                        var absSql = (from a in db.ABS where a.SERNO == s.SERNO && a.NOBR == s.NOBR && a.BDATE == s.BDATE && a.H_CODE == abs.H_CODE select a).ToList();
                        if (absSql.Any()) db.ABS.DeleteAllOnSubmit(absSql);
                    }
                    db.OT.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        bool InsertOT(JBModule.Data.Linq.OT Instance, JBModule.Data.Linq.ABS abs, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.OT where a.NOBR == Instance.NOBR && a.BDATE == Instance.BDATE && a.BTIME == Instance.BTIME select a).ToList();
                if (sql.Any())
                {
                    Msg += "已存在更新的加班資料;";
                    return false;
                }
                sql.Add(Instance);
                db.OT.InsertOnSubmit(Instance);
                db.SubmitChanges();
                var absSql = (from a in db.ABS where a.NOBR == Instance.NOBR && a.BDATE == Instance.BDATE && a.BTIME == Instance.BTIME && a.H_CODE == abs.H_CODE select a).ToList();
                if (absSql.Any())
                {
                    db.ABS.DeleteOnSubmit(absSql.First());
                    db.SubmitChanges();
                }
                if (Instance.REST_HRS > 0)
                {
                    db.ABS.InsertOnSubmit(abs);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        bool UpdateOT(JBModule.Data.Linq.OT Instance, JBModule.Data.Linq.ABS abs, out string Msg)
        {
            //var instanceRow = Instance.Clone();
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.OT where a.NOBR == Instance.NOBR && a.BDATE == Convert.ToDateTime(Instance.BDATE) && a.BTIME.CompareTo(Instance.ETIME) < 0 && a.ETIME.CompareTo(Instance.BTIME) > 0 select a).ToList();
                if (sql.Any())
                {

                    //if (sql.Any())
                    //{
                    //    Msg += "已存在更新的薪資異動;";
                    //    return false;
                    //}


                    var rCurrent = sql.First();

                    //var sql1 = from ac in db.ATTEND where ac.NOBR == rCurrent.NOBR && ac.ADATE == Convert.ToDateTime(rCurrent.BDATE) select ac;
                    rCurrent.OT_EDATE = Instance.OT_EDATE;
                    rCurrent.ETIME = Instance.ETIME;
                    rCurrent.OT_FOOD1 = Instance.OT_FOOD1;
                    rCurrent.OT_HRS = Instance.OT_HRS;
                    rCurrent.OT_ROTE = Instance.OT_ROTE;
                    rCurrent.REST_HRS = Instance.REST_HRS;
                    rCurrent.TOT_HOURS = Instance.TOT_HOURS;
                    rCurrent.NOTE = Instance.NOTE;
                    rCurrent.YYMM = Instance.YYMM;
                    rCurrent.OT_DEPT = Instance.OT_DEPT;
                    rCurrent.YYMM = Instance.YYMM;
                    rCurrent.KEY_DATE = DateTime.Now;
                    rCurrent.KEY_MAN = MainForm.USER_NAME;
                    if (!string.IsNullOrWhiteSpace(rCurrent.SERNO))
                    {
                        var absSql = (from a in db.ABS where a.SERNO == rCurrent.SERNO && a.NOBR == abs.NOBR && a.BDATE == abs.BDATE && a.H_CODE == abs.H_CODE select a).ToList();
                        if (absSql.Any() && Instance.REST_HRS == 0) db.ABS.DeleteOnSubmit(absSql.First());
                        else if (absSql.Any())
                        {
                            if (absSql.First().TOL_HOURS != rCurrent.REST_HRS)
                            {
                                var a = absSql.First();
                                a.EDATE = rCurrent.OT_EDATE;
                                a.TOL_HOURS = rCurrent.REST_HRS;
                                a.KEY_DATE = rCurrent.KEY_DATE;
                                a.KEY_MAN = rCurrent.KEY_MAN;
                                if (a.LeaveHours <= rCurrent.REST_HRS)
                                {
                                    a.Balance = rCurrent.REST_HRS - a.LeaveHours;
                                }
                                else
                                {
                                    a.Balance = rCurrent.REST_HRS;
                                    a.LeaveHours = 0;
                                }
                            }
                        }
                        else if (Instance.REST_HRS > 0) db.ABS.InsertOnSubmit(abs);
                    }
                    //if (sql.First().ADATE == instanceRow.ADATE)
                    //{
                    //    Msg += "已存在相同日期的薪資異動;";
                    //    return false;
                    //}
                }
                //if(sql.Where(pp=>pp.ADATE==r.ADATE))//是否是同一天
                //sql.Add(instanceRow);
                //db.SALBASD.InsertOnSubmit(Instance);
                //DateTime ddate = new DateTime(9999, 12, 31);
                //foreach (var it in sql.OrderByDescending(pp => pp.ADATE))
                //{
                //    it.DDATE = ddate;
                //    ddate = it.ADATE.AddDays(-1);
                //}
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            string Msg = "";
            string YYMM = TargetRow["計薪年月"].ToString();
            string NOBR = TargetRow["員工編號"].ToString();
            string BTIME = TargetRow["加班起時間"].ToString();
            string ETIME = TargetRow["加班迄時間"].ToString();
            bool CheckAttend = Convert.ToBoolean(TargetRow["檢查出勤時間"].ToString());
            string OT_HRS = TargetRow["加班時數"].ToString();
            string REST_HRS = TargetRow["補休時數"].ToString();
            string TOT_HOURS = TargetRow["總時數"].ToString();
            string OT_EDATE = TargetRow["有效日期"].ToString();
            string BDATE = TargetRow["加班日期"].ToString();
            string OT_ROTE = TargetRow["加班班別代碼"].ToString();
            string OT_DEPTS = TargetRow["加班部門代碼"].ToString();
            string D_NAME = TargetRow["加班部門名稱"].ToString();
            string OT_FOOD1 = TargetRow["誤餐費"].ToString();
            string NOTE = TargetRow["備註"].ToString();
            if (!string.IsNullOrEmpty(BDATE) && string.IsNullOrEmpty(OT_EDATE))
            {
                //DateTime dateTime = DateTime.Today;
                if (!DateTime.TryParse(BDATE, out DateTime DTime))
                {
                    TargetRow["錯誤註記"] = errorMsg("加班日期");
                    return false;
                }

                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM29", MainForm.COMPANY);
                bool RestHoursEqu1231 = Convert.ToBoolean(AppConfig.GetConfig("RestHoursEqu1231").Value);
                bool ComposeEndEqulAnnualEnd = Convert.ToBoolean(AppConfig.GetConfig("ComposeEndEqulAnnualEnd").Value);
                int YYYY = DateTime.Parse(BDATE).Year;
                if (ComposeEndEqulAnnualEnd)
                {
                    TargetRow["有效日期"] = db.GetAnnualLeaveEndDate(NOBR, DTime).Value.ToString();
                }
                else if (RestHoursEqu1231)
                {
                    TargetRow["有效日期"] = new DateTime(YYYY, 12, 31).ToString();
                }
                else
                {
                    TargetRow["有效日期"] = Sal.Function.GetDate(DTime.AddMonths(6));//20150714chpt要求由三個月改為六個月 
                }
            }

            if (string.IsNullOrWhiteSpace(OT_HRS))
            {
                TargetRow["加班時數"] = "0";
                OT_HRS = TargetRow["加班時數"].ToString();
            }
            if (string.IsNullOrWhiteSpace(REST_HRS))
            {
                TargetRow["補休時數"] = "0";
                REST_HRS = TargetRow["補休時數"].ToString();
            }
            if (!checkDecimal(OT_HRS))
            {
                TargetRow["錯誤註記"] = errorMsg("加班時數");
            }
            if (!checkDecimal(REST_HRS))
            {
                TargetRow["錯誤註記"] = errorMsg("補修時數");
            }
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["員工姓名"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }


            //if (ColumnValidate(TargetRow, "加班部門代碼", TransferCheckDataField.DisplayName, out Msg))
            //{
            //    TargetRow["加班部門名稱"] = Msg;
            //}
            //else
            //{

            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] = Msg;
            //    }
            //}


            if (!check_YYMM(YYMM, out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (OT_HRS != "" && REST_HRS != "")
            {
                decimal otTime = Convert.ToDecimal(OT_HRS);
                decimal destTime = Convert.ToDecimal(REST_HRS);

                if (otTime + destTime > 0)
                {
                    if ((otTime == 0 && destTime != 0) || (otTime != 0 && destTime == 0))
                    {
                        TargetRow["總時數"] = (otTime + destTime).ToString();
                    }
                    else
                    {
                        TargetRow["錯誤註記"] = "補休時數和加班時數只可填寫一項";
                    }
                }
                else
                {
                    TargetRow["錯誤註記"] = "補休時數或加班時數尚未填寫";
                }
            }

            if (OT_ROTE == "")
            {
                var rote = "";
                var roteSql1 = from a in db.ATTEND where a.NOBR == NOBR && a.ADATE == Convert.ToDateTime(BDATE) && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE) select a;
                if (roteSql1.Any()) rote = getRote_DispCode(roteSql1.First().ROTE);
                if (rote == "")
                {
                    var roteSql2 = from a in db.ATTEND where a.NOBR == NOBR && a.ADATE < Convert.ToDateTime(BDATE) && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE) orderby a.ADATE descending select a;
                    if (roteSql2.Any()) rote = getRote_DispCode(roteSql2.First().ROTE);
                }
                if (rote == "")
                {
                    var roteSql3 = from a in db.ATTEND where a.NOBR == NOBR && a.ADATE > Convert.ToDateTime(BDATE) && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE) orderby a.ADATE select a;
                    if (roteSql3.Any()) rote = getRote_DispCode(roteSql3.First().ROTE);
                }
                if (rote != "")
                {
                    TargetRow["加班班別代碼"] = rote;
                }
            }
            if (ColumnValidate(TargetRow, "加班班別代碼", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["加班班別名稱"] = Msg;
            }
            else
            {
                if (OT_ROTE != "")
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = Msg;
                    }
                }
            }

            if (!check_timeSort(BTIME, ETIME, out Msg))
            {
                TargetRow["錯誤註記"] = Msg;
            }

            if (OT_DEPTS == "")
            {
                var deptsSql = from ac in db.BASETTS where ac.NOBR == NOBR && ac.ADATE <= Convert.ToDateTime(BDATE) && ac.DDATE >= Convert.ToDateTime(BDATE) select ac;
                if (deptsSql.Any())
                {
                    var ds = deptsSql.First().DEPTS;
                    var depts_disp_code = from a in db.DEPTS where a.D_NO == ds select a;
                    if (depts_disp_code.Any())
                    {
                        TargetRow["加班部門代碼"] = depts_disp_code.First().D_NO_DISP;
                    }
                }
            }
            if (ColumnValidate(TargetRow, "加班部門代碼", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["加班部門名稱"] = Msg;
            }
            else
            {
                if (OT_DEPTS != "")
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = Msg;
                    }
                }
            }

            if (GetOT(NOBR, BDATE, BTIME, ETIME))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告"))
                {
                    TargetRow["警告"] = "與既有資料時段重疊";
                }
            }

            if (GetAttend(NOBR, BDATE, BTIME, ETIME))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告"))
                {
                    TargetRow["警告"] = "與上班時段重疊.";
                }
            }


            return true;
        }
        string getRote_DispCode(string realCode)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var roteSql = from a in db.ROTE
                          where a.ROTE1 == realCode
                          select a;
            return roteSql.Any() ? roteSql.First().ROTE_DISP : "";
        }

        bool checkDecimal(string i)
        {
            try
            {
                var v = Convert.ToDecimal(i);
            }
            catch
            {
                return false;

            }
            return true;
        }
        bool check_timeSort(string btime, string etime, out string msg)
        {
            try
            {
                msg = "";
                if (!check_time(btime, out msg))
                {
                    msg += errorMsg("加班起時間");
                }
                if (!check_time(etime, out msg))
                {
                    msg += errorMsg("加班迄時間");
                }
                if (msg.Length > 0)
                    return false;

                var b = int.Parse(btime);
                var e = int.Parse(etime);
                if (e > b)
                    return true;
                msg = "起時間不可大於等於迄時間;";
                return false;
            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
                msg = "時間格式錯誤(HHmm);";
                return false;
            }
        }
        bool check_time(string time, out string msg)
        {
            msg = "";
            if (time.Length == 4)
            {
                try
                {
                    var hh = int.Parse(time.Substring(0, 2));
                    var mm = int.Parse(time.Substring(2));
                    if (hh >= 0 && mm >= 0 && hh <= 48 && mm <= 59)
                        return true;
                }
                catch { }
            }
            msg = "無效的數據[時間];";
            return false;
        }
        bool check_YYMM(string YYMM, out string msg)
        {
            msg = "";
            if (YYMM.Length == 6)
            {
                try
                {
                    var yy = int.Parse(YYMM.Substring(0, 4));
                    var mm = int.Parse(YYMM.Substring(4));

                    var d = new DateTime(yy, mm, 1);
                    //msg = msg;
                    return true;
                }
                catch { }
            }
            msg = "無效的數據[計薪年月];";
            return false;
        }
        string errorMsg(string msg)
        {
            return string.Format("無效的數據[{0}];", msg);
        }
    }

}

