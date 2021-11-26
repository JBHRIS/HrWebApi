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
    public partial class FRM2IiA : JBControls.JBForm
    {
        public FRM2IiA()
        {
            InitializeComponent();
        }
        public static int autokey = 2;
        private void FRM2O_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false, true, true);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false, true, true);
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            this.ptxNobrB.Text = Sal.BaseValue.MinNobr;
            this.ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;
            this.txtDdate.Text = new DateTime(DateTime.Now.Year, 1, 1).AddDays(-1).ToString("yyyy/MM/dd");// Sal.Function.GetDate();
            this.textBoxWorkYearEndDate.Text = new DateTime(DateTime.Now.Year, 1, 1).AddDays(-1).ToString("yyyy/MM/dd");

            this.txtYear.Text = DateTime.Now.Year.ToString();
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1;
            d1 = DateTime.Now.Date;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2I", MainForm.COMPANY);
            string CalcMode = AppConfig.GetConfig("CalcMode").GetString();
            string LastRangeMode = AppConfig.GetConfig("LastRangeMode").GetString();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime t1, t2, ddate,WorkYearEndDate;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e;
            int year = 0;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            year = int.Parse(txtYear.Text);
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            ddate = Convert.ToDateTime(txtDdate.Text);
            WorkYearEndDate = Convert.ToDateTime(textBoxWorkYearEndDate.Text);
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.ROTET on b.ROTET equals c.ROTET1
                      join d in db.DEPT on b.DEPT equals d.D_NO
                      let TotalYears = db.GetHolidayYears(a.NOBR, WorkYearEndDate).Value
                      let TotalLeaveWithoutPay = db.GetTotalLeaveWithoutPay(a.NOBR, ddate).Value
                      let BASETTSs = from f in db.BASETTS where f.NOBR == b.NOBR && new string[] { "2", "3", "5" }.Contains(f.TTSCODE) && f.ADATE <= ddate select new { f.ADATE, f.DDATE, f.TTSCODE }
                      where ddate >= b.ADATE && ddate <= b.DDATE.Value && ttscodeList.Contains(b.TTSCODE)//這一天還在職的人員資料
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
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
            string hcode = AppConfig.GetConfig("LeaveCode").GetString();
            if (hcode.Trim().Length == 0)
            {
                MessageBox.Show("請先至FRM2I設定特休(得)代碼", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            foreach (var itm in sql)
            {
                JBHR.BLL.Att.Holiday holi = new BLL.Att.Holiday(itm.NOBR, ddate);
                if (CalcMode == "Floor")
                    holi.CalculationMode = BLL.Att.CalcMode.Floor;
                else
                    holi.CalculationMode = BLL.Att.CalcMode.Ceiling;
                if (LastRangeMode == "Full")
                    holi.LastYearRangeMode = BLL.Att.LastRangeMode.Full;
                else
                    holi.LastYearRangeMode = BLL.Att.LastRangeMode.Reference;
                holi.parms = parms;
                holi.hcodeList = hcodeList;
                DateTime HoliDayIndt = itm.IN_DATE;
                int stopDays = 0;
                foreach (var r in itm.BASETTSs)
                {
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(itm.IN_DATE, ddate);
                    its.Inert(r.ADATE, r.DDATE.Value);
                    stopDays += its.GetDays();
                }
                HoliDayIndt = HoliDayIndt.AddDays(stopDays);
                if (AppConfig.GetConfig("CalcType").GetString("1") == "1")
                    holi.CreateYearHolidayAB(HoliDayIndt, itm.BASETTS.DEPT, itm.BASETTS.STDT, itm.BASETTS.STINDT, year, itm.TotalYears, itm.TotalLeaveWithoutPay, itm.ROTET.YRREST_HRS, itm.BASETTSs.Count(), false, hcode);
                else
                    holi.CreateYearHoliday(HoliDayIndt, itm.BASETTS.DEPT, itm.BASETTS.STDT, itm.BASETTS.STINDT, year, itm.TotalYears, itm.TotalLeaveWithoutPay, itm.ROTET.YRREST_HRS, itm.BASETTSs.Count(), false, hcode);
            }

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime t1, t2, ddate;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e;
            int year = 0;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;
            year = int.Parse(txtYear.Text);
            //List<string> ttscodeList = new List<string>();
            //ttscodeList.Add("1");
            //ttscodeList.Add("4");
            //ttscodeList.Add("6");
            ddate = Convert.ToDateTime(txtDdate.Text);
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.ROTET on b.ROTET equals c.ROTET1
                      join d in db.DEPT on b.DEPT equals d.D_NO
                      let TotalYears = db.GetHolidayYears(a.NOBR, ddate).Value
                      //let BASETTSs = from d in db.BASETTS where d.NOBR == b.NOBR && b.TTSCODE == "3" select d
                      where ddate >= b.ADATE && ddate <= b.DDATE.Value
                      //&& ttscodeList.Contains(b.TTSCODE)//這一天還在職的人員資料
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select new
                      {
                          NOBR = a.NOBR,
                          NAME = a.NAME_C,
                          TotalYears,
                          IN_DATE = b.INDT,
                          DEPT = b.DEPT,
                          BASETTS = b,
                          //BASETTSs,
                          ROTET = c
                      };
            var hcodeList = (from a in db.HCODE select a).ToList();
            foreach (var itm in sql)
            {
                JBHR.BLL.Att.Holiday holi = new BLL.Att.Holiday(itm.NOBR, ddate);
                holi.hcodeList = hcodeList;
                holi.DeleteYearHoliday(year);
            }
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            this.txtDdate.Text = new DateTime(int.Parse(txtYear.Text), 1, 1).AddDays(-1).ToString("yyyy/MM/dd");// Sal.Function.GetDate();
            this.textBoxWorkYearEndDate.Text = new DateTime(int.Parse(txtYear.Text), 1, 1).AddDays(-1).ToString("yyyy/MM/dd");
        }
    }
}
