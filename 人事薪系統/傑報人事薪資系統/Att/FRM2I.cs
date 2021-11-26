using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
namespace JBHR.Att
{
    public partial class FRM2I : JBControls.JBForm
    {
        public FRM2I()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定這個值來控制當資料重複時，要選擇複寫或是略過
        /// </summary>
        bool RepeatOverWrite = false;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        private void FRM2P_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2I", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("LeaveCode", "特休(得)代碼", "", "設定特休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("CalcMode", "進位模式", "Ceiling", "特休滿10年後的進位模式", "ComboBox", "select  'Floor' value,'無條件捨去' union select 'Ceiling' value,'無條件進位'", "String");
            AppConfig.CheckParameterAndSetDefault("LastRangeMode", "滿10年末段年資計算方式", "Full", "Full:當整年，Reference：參考比例", "ComboBox", "select  'Full' value,'當整年' union select 'Reference' value,'參考比例'", "String");
            AppConfig.CheckParameterAndSetDefault("CalcType", "計算方式", "2", "", "ComboBox", "SELECT CODE,NAME FROM MTCODE WHERE CATEGORY='FRM2I_CALCTYPE'", "String");
            SystemFunction.SetComboBoxItems(popupTextBox1, CodeFunction.GetDept(), true);
            popupTextBox1.Enabled = false;
            fullDataCtrl1.bnAddEnable = false;
            this.dEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.yEAR_HOLIDAYTableAdapter.FillByInit(this.dsAtt.YEAR_HOLIDAY);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("YEAR_HOLIDAY");

            fullDataCtrl1.DataAdapter = this.yEAR_HOLIDAYTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Function.GetDate();
            DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            SalaryDate sd = new SalaryDate(d1);
            txtYear.Text = sd.YYMM;

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            chkTrans.Enabled = false;
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            SalaryDate sd = new SalaryDate(d1);
            txtYear.Text = sd.YYMM;
        }

        private void txtEtime_Validated(object sender, EventArgs e)
        {

        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
            }
        }

        private void cbxHcode_SelectedIndexChange(object sender, EventArgs e)
        {

        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            chkTrans.Enabled = false;
        }

        private void btnMultiOperation_Click(object sender, EventArgs e)
        {
            FRM2IiA frm = new FRM2IiA();
            frm.ShowDialog();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2I", MainForm.COMPANY);
            DateTime t1, t2;
            t1 = DateTime.Now;

            string hcode = AppConfig.GetConfig("LeaveCode").GetString();
            if (hcode.Trim().Length == 0)
            {
                MessageBox.Show("請先設定特休延休代碼", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var data = from r in dsAtt.YEAR_HOLIDAY where r.PTRANS == false && MainForm.NobrListOfWrite.Contains(r.NOBR) select r;

            dcAttDataContext dbTran = new dcAttDataContext();
            dcAttDataContext dbDelete = new dcAttDataContext();
            int needTran = data.Count();
            int hasTran = 0;
            int repeat = 0;

            foreach (var row in data)
            {
                var absSQL = from r in dbDelete.ABS where r.NOBR == row.NOBR && r.YYMM == row.YEARS && r.H_CODE == hcode select r;
                var CalcType = AppConfig.GetConfig("CalcType").GetString("1");
                if (CalcType == "1")
                    absSQL = from r in dbDelete.ABS where r.NOBR == row.NOBR && r.YYMM == row.YEARS && r.H_CODE == hcode && (!row.IsNOTE3Null() ?  r.BTIME == string.Empty: r.BTIME == row.NOTE3) select r;
                if (absSQL.Any())//如果有重複資料
                {
                    repeat++;
                    if (RepeatOverWrite)//且設定重複要複寫，則刪除原紀錄
                        dbDelete.ABS.DeleteAllOnSubmit(absSQL);
                    else continue;//否則就略過此筆記錄
                }
                //decimal yearRestHrs = 8;
                //decimal.TryParse(row.NOTE2, out yearRestHrs);
                ABS abs = new ABS();
                abs.A_NAME = "";
                abs.BDATE = row.ADATE;
                abs.BTIME = !row.IsNOTE3Null() ? row.NOTE3 : string.Empty;
                abs.EDATE = row.DDATE;
                abs.ETIME = "";
                abs.H_CODE = hcode;
                abs.KEY_DATE = DateTime.Now;
                abs.KEY_MAN = MainForm.USER_NAME;
                abs.NOBR = row.NOBR;
                if (!row.IsNOTENull())
                    abs.NOTE = row.NOTE;
                else abs.NOTE = "";
                abs.NOTEDIT = false;
                abs.Guid = Guid.NewGuid().ToString();
                abs.SERNO = row.NOTE1;
                abs.SYSCREATE = true;
                abs.TOL_DAY = 0;
                abs.TOL_HOURS = row.GET_DAYS;
                abs.YYMM = row.YEARS;
                abs.LeaveHours = 0;
                abs.Balance = abs.TOL_HOURS;
                dbTran.ABS.InsertOnSubmit(abs);
                row.PTRANS = true;
                hasTran++;
            }
            //先刪除，後先增
            dbDelete.SubmitChanges();
            dbTran.SubmitChanges();
            new dsAttTableAdapters.YEAR_HOLIDAYTableAdapter().Update(dsAtt.YEAR_HOLIDAY);
            //再異動

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan + Environment.NewLine + "應轉換" + needTran.ToString() + "筆資料，實際轉換" + hasTran.ToString() + "筆資料，已存在" + repeat.ToString() + "筆相同資料", ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
        //public static void CreateYearHoloiday(string Nobr, int Year, DateTime YearHolidayDate, DateTime DDate, bool DirectlyInsertABS = false)
        //{
        //    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        //    JBModule.Data.ApplicationConfigSettings config = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);
        //    string sno = "";
        //    List<string> ttscodeList = new List<string>();
        //    ttscodeList.Add("1");
        //    ttscodeList.Add("4");
        //    ttscodeList.Add("6");
        //    var sql = from a in db.BASE
        //              join b in db.BASETTS on a.NOBR equals b.NOBR
        //              join c in db.ROTET on b.ROTET equals c.ROTET1
        //              join d in db.DEPT on b.DEPT equals d.D_NO
        //              let TotalYears = db.GetHolidayYears(a.NOBR, YearHolidayDate).Value
        //              let TotalLeaveWithoutPay = db.GetTotalLeaveWithoutPay(a.NOBR, DateTime.Now).Value
        //              let BASETTSs = from f in db.BASETTS where f.NOBR == b.NOBR && f.TTSCODE == "3" select f
        //              where DDate >= b.ADATE && DDate <= b.DDATE.Value && ttscodeList.Contains(b.TTSCODE)//這一天還在職的人員資料
        //              && a.NOBR.CompareTo(Nobr) >= 0 && a.NOBR.CompareTo(Nobr) <= 0
        //                  //&& d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
        //              && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
        //              select new
        //              {
        //                  NOBR = a.NOBR,
        //                  NAME = a.NAME_C,
        //                  TotalYears,
        //                  TotalLeaveWithoutPay,
        //                  IN_DATE = b.CINDT.Value,
        //                  DEPT = b.DEPT,
        //                  BASETTS = b,
        //                  BASETTSs,
        //                  ROTET = c,
        //                  a.COUNT_MA
        //              };
        //    JBModule.Data.Linq.U_SYS8 parms;
        //    var qq = from a in db.U_SYS8 where a.Comp == MainForm.COMPANY select a;
        //    if (qq.Any())
        //        parms = qq.First();
        //    else
        //    {
        //        qq = from a in db.U_SYS8 select a;
        //        parms = qq.First();
        //    }
        //    var hcodeList = (from a in db.HCODE select a).ToList();
        //    foreach (var itm in sql)
        //    {
        //        JBHR.BLL.Att.Holiday holi = new BLL.Att.Holiday(itm.NOBR, DDate);
        //        holi.parms = parms;
        //        holi.hcodeList = hcodeList;
        //        DateTime HoliDayIndt = itm.IN_DATE;
        //        int stopDays = 0;
        //        foreach (var r in itm.BASETTSs)
        //        {
        //            JBTools.Intersection its = new JBTools.Intersection();
        //            its.Inert(itm.IN_DATE, YearHolidayDate);
        //            its.Inert(r.ADATE, r.DDATE.Value);
        //            stopDays += its.GetDays();
        //        }
        //        HoliDayIndt = HoliDayIndt.AddDays(stopDays);
        //        sno = holi.CreateYearHolidayDiv(HoliDayIndt, itm.BASETTS, Year, itm.TotalYears, itm.TotalLeaveWithoutPay, itm.ROTET.YRREST_HRS, itm.BASETTSs.Count());

        //    }

        //    if (DirectlyInsertABS)
        //    {
        //        var query = from a in db.YEAR_HOLIDAY where a.NOTE1 == sno select a;
        //        //decimal yearRestHrs = 8;
        //        //decimal.TryParse(row.NOTE2, out yearRestHrs);
        //        if (query.Any())
        //        {
        //            var yh = query.First();
        //            var htype = db.HcodeType.SingleOrDefault(p => p.HTYPE == config.GetConfig("AnnualLeaveTypeCode").GetString("1"));
        //            string hcode = htype.GetCode;
        //            var absSQL = from r in db.ABS where r.NOBR == yh.NOBR && r.YYMM == Year.ToString() && r.NOTEDIT == true && r.SYSCREATE && r.H_CODE == hcode select r;
        //            if (absSQL.Any())//如果有重複資料,update
        //            {
        //                //if (RepeatOverWrite)//且設定重複要複寫，則刪除原紀錄
        //                foreach (var abs in absSQL)
        //                {
        //                    abs.TOL_HOURS = yh.GET_DAYS;
        //                    abs.Balance = abs.TOL_HOURS - abs.LeaveHours;
        //                }
        //                db.SubmitChanges();
        //            }
        //            else
        //            {
        //                JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
        //                abs.A_NAME = "";
        //                abs.BDATE = DDate;
        //                abs.BTIME = "";
        //                abs.EDATE = yh.DDATE;
        //                abs.ETIME = "";
        //                abs.H_CODE = hcode;
        //                abs.KEY_DATE = DateTime.Now;
        //                abs.KEY_MAN = MainForm.USER_NAME;
        //                abs.NOBR = yh.NOBR;
        //                abs.NOTE = yh.NOTE;

        //                abs.NOTEDIT = true;
        //                abs.SERNO = yh.NOTE1;
        //                abs.SYSCREATE = true;
        //                abs.TOL_DAY = 0;
        //                abs.TOL_HOURS = yh.GET_DAYS;
        //                abs.Balance = abs.TOL_HOURS;
        //                abs.LeaveHours = 0;
        //                abs.Guid = Guid.NewGuid().ToString();
        //                abs.YYMM = yh.YEARS;
        //                db.ABS.InsertOnSubmit(abs);
        //                yh.PTRANS = true;
        //                db.SubmitChanges();
        //            }
        //        }
        //    }
        //}
        public static void CreateNewHireYearHoloiday(string Nobr, int Year, DateTime YearHolidayDate, DateTime InDt, bool DirectlyInsertABS = false)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBModule.Data.ApplicationConfigSettings config = new JBModule.Data.ApplicationConfigSettings("FRM2I", MainForm.COMPANY);
            string sno = "";
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.ROTET on b.ROTET equals c.ROTET1
                      //join d in db.DEPT on b.DEPT equals d.D_NO //↓防止由匯入員工歷史資料所產生的半年特休出現資料異常
                      let TotalYears = db.GetHolidayYears(a.NOBR, InDt.AddMonths(6).AddDays(-1)) != null ? db.GetHolidayYears(a.NOBR, InDt.AddMonths(6).AddDays(-1)).Value : 0
                      let TotalLeaveWithoutPay = db.GetTotalLeaveWithoutPay(a.NOBR, DateTime.Now) != null ? db.GetTotalLeaveWithoutPay(a.NOBR, DateTime.Now).Value : 0
                      let BASETTSs = from f in db.BASETTS where f.NOBR == b.NOBR && f.TTSCODE == "3" select f
                      where InDt >= b.ADATE && InDt <= b.DDATE.Value && ttscodeList.Contains(b.TTSCODE)//這一天還在職的人員資料
                      && a.NOBR.CompareTo(Nobr) >= 0 && a.NOBR.CompareTo(Nobr) <= 0
                      //&& d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select new
                      {
                          NOBR = a.NOBR,
                          NAME = a.NAME_C,
                          TotalYears,
                          TotalLeaveWithoutPay,
                          IN_DATE = b.CINDT.Value,
                          DEPT = b.DEPT,
                          BASETTS = b,
                          BASETTSs,
                          ROTET = c,
                          a.COUNT_MA
                      };
            JBModule.Data.Linq.U_SYS8 parms;
            var qq = from a in db.U_SYS8 where a.Comp == MainForm.COMPANY select a;
            if (qq.Any())
                parms = qq.First();
            else
            {
                qq = from a in db.U_SYS8 select a;
                parms = qq.First();
            }
            var hcodeList = (from a in db.HCODE select a).ToList();
            string hcode = config.GetConfig("LeaveCode").GetString();
            if (hcode.Trim().Length == 0)
            {
                MessageBox.Show("請先至 FRM2I計算特休 設定特休(得)代碼", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            foreach (var itm in sql)
            {
                JBHR.BLL.Att.Holiday holi = new BLL.Att.Holiday(itm.NOBR, InDt);
                holi.parms = parms;
                holi.hcodeList = hcodeList;
                DateTime HoliDayIndt = itm.IN_DATE;
                int stopDays = 0;
                foreach (var r in itm.BASETTSs)
                {
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(itm.IN_DATE, YearHolidayDate);
                    its.Inert(r.ADATE, r.DDATE.Value);
                    stopDays += its.GetDays();
                }
                HoliDayIndt = HoliDayIndt.AddDays(stopDays);
                sno = holi.CreateNewHireYearHoliday(HoliDayIndt, itm.BASETTS, Year, itm.TotalYears, itm.TotalLeaveWithoutPay, itm.ROTET.YRREST_HRS, itm.BASETTSs.Count(), hcode);
            }

            if (DirectlyInsertABS)
            {
                var query = from a in db.YEAR_HOLIDAY where a.NOTE1 == sno select a;
                //decimal yearRestHrs = 8;
                //decimal.TryParse(row.NOTE2, out yearRestHrs);
                if (query.Any())
                {
                    var yh = query.First();
                    //var htype = db.HcodeType.SingleOrDefault(p => p.HTYPE == config.GetConfig("AnnualLeaveTypeCode").GetString("1"));
                    //hcode = htype.GetCode;
                    var absSQL = from r in db.ABS where r.NOBR == yh.NOBR && r.YYMM == Year.ToString() && r.NOTEDIT == true && r.SYSCREATE && r.H_CODE == hcode select r;
                    if (absSQL.Any())//如果有重複資料,update
                    {
                        //if (RepeatOverWrite)//且設定重複要複寫，則刪除原紀錄
                        foreach (var abs in absSQL)
                        {
                            abs.TOL_HOURS = yh.GET_DAYS;
                            abs.Balance = abs.TOL_HOURS - abs.LeaveHours;
                            //abs.BDATE = InDt.AddMonths(6);
                            abs.EDATE = InDt.AddMonths(12).AddDays(-1);
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            //if (local) abs.BDATE = InDt;
                        }
                        db.SubmitChanges();
                    }
                    else
                    {
                        JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                        abs.A_NAME = "";
                        abs.BDATE = InDt.AddMonths(6);
                        abs.EDATE = InDt.AddMonths(12).AddDays(-1);
                        //if (local) abs.BDATE = InDt;
                        abs.BTIME = "0000" + DateTime.Now.ToOADate().ToString();
                        abs.ETIME = "0000" + DateTime.Now.ToOADate().ToString();
                        abs.H_CODE = hcode;
                        abs.KEY_DATE = DateTime.Now;
                        abs.KEY_MAN = MainForm.USER_NAME;
                        abs.NOBR = yh.NOBR;
                        abs.NOTE = "半年特休";

                        abs.NOTEDIT = true;
                        abs.SERNO = yh.NOTE1;
                        abs.SYSCREATE = true;
                        abs.TOL_DAY = 0;
                        abs.TOL_HOURS = yh.GET_DAYS;
                        abs.Balance = abs.TOL_HOURS;
                        abs.LeaveHours = 0;
                        abs.Guid = Guid.NewGuid().ToString();
                        abs.YYMM = yh.YEARS;
                        db.ABS.InsertOnSubmit(abs);
                        yh.PTRANS = true;
                        db.SubmitChanges();
                    }
                }
            }
        }
        private void ptxNobr_Validated(object sender, EventArgs e)  //修正(家瑜)考勤模組-計算特休單筆新增欄位問題 by 建華 2012/11/15
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime today = DateTime.Now;
            var absSQL = from r in db.BASETTS
                         where r.NOBR == ptxNobr.Text
                         && r.ADATE < today && r.DDATE > today
                         select r;
            int count = absSQL.Count();
            if (count > 0)
            {
                textBox1.Text = absSQL.FirstOrDefault().INDT.ToString();   //取得到職日期
                txtStopDate.Text = absSQL.FirstOrDefault().STDT.ToString();   //取得留停日期
                textBox4.Text = absSQL.FirstOrDefault().STINDT.ToString(); //取得復職日期
                popupTextBox1.Text = absSQL.FirstOrDefault().DEPT.ToString(); //取得編制部門
            }
            else
            {
                textBox1.Text = "";
                txtStopDate.Text = "";
                textBox4.Text = "";
                popupTextBox1.Text = "";
                txtAbsHrs.Text = "";
                txtSugHrs.Text = "";
            }

            var absSQL2 = from r in db.BASETTS  //取得留停次數
                          where r.NOBR == ptxNobr.Text
                          && r.TTSCODE == "3"
                          select r;
            int stCount = absSQL2.Count();
            textBox5.Text = stCount.ToString();
            string a, b, c, d = "";
            dsBasTableAdapters.BASETTSTableAdapter ad = new dsBasTableAdapters.BASETTSTableAdapter();
            ad.FillByNobr(dsBas.BASETTS, ptxNobr.Text);
            double totalDays = dsBas.BASETTS.Sum(
                   ROW =>
                   {
                       d = "0";
                       if (new string[] { "1", "4", "6" }.Contains(ROW.TTSCODE)) //需求修改(Lanayeh)人事模組-集團到職日與在職年資 by 建華 2012/11/16
                       {
                           a = ROW.ADATE.ToString();  //debug用參數
                           b = ROW.DDATE.ToString();  //debug用參數
                           c = ROW.CINDT.ToString();  //debug用參數
                           d = ROW.TTSCODE.ToString();//debug用參數
                           if (ROW.DDATE < ROW.CINDT)
                           {
                               d = "1";
                               return 0;
                           }
                           else if (ROW.TTSCODE == "1")
                           {
                               if (ROW.DDATE < ROW.CINDT)
                               {
                                   d = "2";
                                   return 0;
                               }
                               else
                               {
                                   if (ROW.ADATE > DateTime.Now)
                                   {
                                       d = "3";
                                       return 0;
                                   }
                                   else if (ROW.DDATE >= DateTime.Now && ROW.ADATE < DateTime.Now)
                                   {
                                       d = "4";
                                       return (DateTime.Now.Date - ROW.CINDT).TotalDays + 1;
                                   }
                                   else
                                   {
                                       d = "5";
                                       return (ROW.DDATE - ROW.CINDT).TotalDays + 1;
                                   }
                               }
                           }
                           else if (ROW.ADATE <= ROW.CINDT && ROW.DDATE >= ROW.CINDT)
                           {
                               if (ROW.ADATE > DateTime.Now)
                               {
                                   d = "6";
                                   return 0;
                               }
                               else if (ROW.DDATE >= DateTime.Now && ROW.CINDT <= DateTime.Now)
                               {
                                   d = "7";
                                   return (DateTime.Now.Date - ROW.CINDT).TotalDays + 1;
                               }
                               else
                               {
                                   d = "8";
                                   return (ROW.DDATE - ROW.CINDT).TotalDays + 1;
                               }
                           }
                           else
                           {
                               if (ROW.DDATE >= DateTime.Now && ROW.ADATE <= DateTime.Now)
                               {
                                   d = "9";
                                   return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
                               }
                               else if (ROW.ADATE > DateTime.Now)
                               {
                                   d = "10";
                                   return 0;
                               }
                               else
                               {
                                   d = "11";
                                   return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
                               }
                           }
                       }
                       else
                       {
                           d = "12";
                           return 0;
                       }
                   }
               );

            txtAbsHrs.Text = Math.Round(totalDays / 365.25, 2).ToString();//工作年資

            double totalStopDays = dsBas.BASETTS.Sum(
                   ROW =>
                   {
                       a = ROW.ADATE.ToString();
                       b = ROW.DDATE.ToString();
                       c = ROW.CINDT.ToString();
                       if (new string[] { "3" }.Contains(ROW.TTSCODE)) //bug修正，留停年資未顯示 by 建華 2012/12/03
                       {
                           if (ROW.DDATE < ROW.CINDT || ROW.ADATE > DateTime.Now.Date)
                           {
                               return 0;
                           }
                           else if (ROW.ADATE < ROW.CINDT && ROW.DDATE < DateTime.Now.Date)
                           {
                               return (ROW.DDATE - ROW.CINDT).TotalDays + 1;
                           }
                           else if (ROW.ADATE < ROW.CINDT && ROW.DDATE >= DateTime.Now.Date)
                           {
                               return (DateTime.Now.Date - ROW.CINDT).TotalDays + 1;
                           }
                           else if (ROW.ADATE >= ROW.CINDT && ROW.DDATE > DateTime.Now.Date)
                           {
                               return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
                           }
                           else
                           {
                               return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
                           }
                       }
                       else return 0;
                   }
               );

            txtSugHrs.Text = Math.Round(totalStopDays / 365.25, 2).ToString(); //留停年資
        }
    }
}
