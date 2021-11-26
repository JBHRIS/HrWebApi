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
    public partial class FRM2QA : JBControls.JBForm
    {
        public FRM2QA()
        {
            InitializeComponent();
        }
        private void FRM2O_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false, true, true);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false, true, true);
            //this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            this.ptxNobrB.Text = Sal.BaseValue.MinNobr;
            this.ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;

            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1;
            d1 = DateTime.Now.Date;
            txtDDate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtYymm.Text = DateTime.Now.ToString("yyyyMM");
            txtSeq.Text = "2";
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime t1, t2;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;

            object[] ttscodes = new object[] { 1, 4, 6 };//UNDONE: 2010/04/01 提出來當全域變數

            DateTime d1, d2, dd;
            dd = Convert.ToDateTime(txtDDate.Text);
            d1 = new DateTime(dd.Year, 1, 1);
            d2 = new DateTime(dd.Year, 12, 31);
            List<string> yearrestList = new List<string>();
            if (rdb1.Checked || rdb2.Checked) yearrestList.Add("1");//特休得
            if (rdb1.Checked || rdb3.Checked) yearrestList.Add("3");//補休得

            var sql = from a in db.BASETTS
                      join b in db.BASE on a.NOBR equals b.NOBR
                      join c in db.JOBS on a.JOBS equals c.JOBS1
                      join d in db.DEPT on a.DEPT equals d.D_NO
                      where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && dd >= a.ADATE && dd <= a.DDATE.Value
                       && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                       && ttscodes.Contains(a.TTSCODE)
                       && !b.COUNT_MA
                       //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      let tYear = db.GetTotalYears(a.NOBR, dd)
                      select new { BASETTS = a, c.JOB_NAME, TOTAL_YEARS = tYear == null ? 0 : (tYear.Value + 1), BASE = b };//在職人員
            DeleteAbsPre(dd);
            foreach (var itm in sql)
            {
                var result = Dll.Att.AbsCal.AbsInfo(itm.BASETTS.NOBR, dd);
                var data = from a in result where yearrestList.Contains(a.sYearRest) select a;

                foreach (var row in data)
                {
                    JBModule.Data.Linq.ABS_EXT ae = new JBModule.Data.Linq.ABS_EXT();
                    ae.ADATE = d1;
                    ae.DDATE = d2;
                    ae.AMT = 0;
                    ae.CASH_HOURS = 0;
                    ae.EXT_HOURS = 0;
                    ae.HCODE = row.sYearRest;
                    ae.KEY_DATE = DateTime.Now;
                    ae.KEY_MAN = MainForm.USER_NAME;
                    ae.NOBR = itm.BASETTS.NOBR;
                    ae.NOTE = "";
                    ae.NTRANS = true;
                    ae.PTRANS = false;
                    ae.SNO = 0;
                    ae.SYSCREAT = true;
                    ae.TOL_HOURS = row.iBalance;
                    ae.YYMM = txtYymm.Text;
                    ae.SEQ = txtSeq.Text;
                    ae.NAME = itm.BASE.NAME_C;
                    ae.DEPT = itm.BASETTS.DEPT;
                    ae.H_NAME = ae.HCODE == "1" ? "特休" : "補休";
                    var rangeSQL = from a in db.RANGE_SET
                                   where a.PID == 1 && a.NOTE == itm.JOB_NAME
                                   && itm.TOTAL_YEARS >= Convert.ToDecimal(a.RANGE_BEGIN)
                                   && itm.TOTAL_YEARS <= Convert.ToDecimal(a.RANGE_END)
                                   && a.NOTE3 == ae.HCODE
                                   orderby a.RANGE_BEGIN
                                   select a;
                    if (rangeSQL.Any())
                    {
                        var range_item = rangeSQL.First();
                        decimal ext_days = Convert.ToDecimal(range_item.NOTE1);
                        decimal total_hrs = ae.TOL_HOURS;

                        if (total_hrs >= ext_days * 8)
                        {
                            ae.EXT_HOURS = ext_days * 8;
                            total_hrs -= ext_days * 8;
                        }
                        else if (total_hrs < ext_days * 8)
                        {
                            ae.EXT_HOURS = total_hrs;
                            total_hrs = 0;
                        }

                        decimal money_days = Convert.ToDecimal(range_item.NOTE2);
                        if (total_hrs > 0 && money_days > 0)
                        {
                            var salbasdSQL = from a in db.SALBASD
                                             join b in db.SALCODE on a.SAL_CODE equals b.SAL_CODE
                                             where a.NOBR == itm.BASETTS.NOBR
                                             && dd >= a.ADATE && dd <= a.DDATE
                                             && b.YEARPAY
                                             select a;
                            decimal amt = salbasdSQL.ToList().Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                            decimal amtOfHrs = amt / 240;
                            if (total_hrs >= money_days * 8)
                            {
                                ae.CASH_HOURS = money_days * 8;
                                total_hrs -= money_days * 8;
                            }
                            else if (total_hrs < money_days * 8)
                            {
                                ae.CASH_HOURS = total_hrs;
                                total_hrs = 0;
                            }
                            ae.AMT = JBModule.Data.CEncrypt.Number(Math.Round(amtOfHrs * ae.CASH_HOURS, MidpointRounding.AwayFromZero));
                        }

                    }
                    db.ABS_EXT.InsertOnSubmit(ae);
                }
            }

            db.SubmitChanges();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void DeleteAbsPre(DateTime dd)
        {
            List<string> yearrestList = new List<string>();

            string nobr_b, nobr_e, dept_b, dept_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;
            //rote_b = ptxRoteB.Text;
            //rote_e = ptxRoteE.Text;
            //date_b = Convert.ToDateTime(txtBdate.Text);
            //date_e = Convert.ToDateTime(txtEdate.Text);
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string cmd = "DELETE ABS_EXT WHERE " +
                " EXISTS (SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE ABS_EXT.NOBR=A.NOBR AND CONVERT(DATETIME,CONVERT(NVARCHAR(50),dbo.Today())) BETWEEN A.ADATE AND A.DDATE AND B.D_NO_DISP BETWEEN {2} AND {3} AND A.NOBR BETWEEN {0} AND {1}) " +
                " AND {4} BETWEEN ABS_EXT.ADATE AND ABS_EXT.DDATE AND PTRANS=0"
                //+ " AND dbo.GetFilterByNobr(ABSPRE.NOBR,{5},{6},{7})=1";//只針對未轉檔作刪除
                + "AND exists(select 1 from BASETTS x where x.NOBR=ABSPRE.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({5},{6},{7})))";
            object[] PARA = new object[] { nobr_b, nobr_e, dept_b, dept_e, dd, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            //db.ExecuteCommand(cmd, PARA);
            if (rdb1.Checked || rdb2.Checked) //特休得
                db.ExecuteCommand(cmd + " AND HCODE='1'", PARA);
            if (rdb1.Checked || rdb3.Checked)//補休得
                db.ExecuteCommand(cmd + " AND HCODE='3'", PARA);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //DateTime date_b, date_e;
            //date_b = Convert.ToDateTime(txtBdate.Text);
            //date_e = Convert.ToDateTime(txtEdate.Text);
            DateTime dd = Convert.ToDateTime(txtDDate.Text);
            DateTime t1, t2;
            t1 = DateTime.Now;

            //for (DateTime dd = date_b; dd <= date_e; dd = dd.AddDays(1))
            DeleteAbsPre(dd);

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
