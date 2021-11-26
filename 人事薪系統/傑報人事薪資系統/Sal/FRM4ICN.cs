using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal;
using JBHR.Sal.Core;
namespace JBHR.Sal
{
    public partial class FRM4ICN : JBControls.JBForm
    {
        public FRM4ICN()
        {
            InitializeComponent();
        }

        private void FRM4I_Load(object sender, EventArgs e)
        {
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE);
            this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            Function.SetAvaliableBase(this.salaryDS.BASE);
            this.fRM4ITYPETableAdapter.Fill(this.viewDS.FRM4ITYPE);
            SalaryDate sd = new SalaryDate(DateTime.Now.Date.ToString("yyyyMM"));
            SetYYMM(sd.FirstDayOfSalary);
            txtSeq.Text = "2";
            txtSeq1.Text = "2";
            txtBdate.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfSalary);
            DateTime dBank = new DateTime(sd.FirstDayOfMonth.Year, sd.GetNextSalaryDate().FirstDayOfMonth.Month, 5);

            txtBank.Text = Sal.Core.SalaryDate.DateString(dBank);
            ptxNobrB.Text = BaseValue.MinNobr;
            ptxNobrE.Text = BaseValue.MaxNobr;
            ptxDeptB.Text = BaseValue.MinDept;
            ptxDeptE.Text = BaseValue.MaxDept;
            cbxFormat.SelectedValue = "50";
            cbxSalcodeB.SelectedValue = salaryDS.SALCODE.First().SAL_CODE;
            cbxSalcodeE.SelectedValue = salaryDS.SALCODE.Last().SAL_CODE;
            DateTime dIndt = new DateTime(sd.FirstDayOfMonth.Year, sd.FirstDayOfMonth.Month, 28);
            txtInEndDate.Text = Function.GetDate(dIndt);
        }
        void SetYYMM(DateTime date)
        {
            SalaryDate sd = new SalaryDate(date);
            txtYymm.Text = sd.YYMM;
            txtYymm1.Text = sd.YYMM;
            txtChgYymm.Text = sd.YYMM;
            txtEdate.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfSalary);
            txtAttDateB.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfAttend);
            txtAttDateE.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfAttend);
            txtChgSeq.Text = "2";
            DateTime dBank = new DateTime(sd.FirstDayOfMonth.Year, sd.GetNextSalaryDate().FirstDayOfMonth.Month, 5);
            //if (dBank.DayOfWeek == DayOfWeek.Sunday) dBank = dBank.AddDays(-1);
            txtBank.Text = Sal.Core.SalaryDate.DateString(dBank);
            DateTime dIndt = new DateTime(sd.FirstDayOfMonth.Year, sd.FirstDayOfMonth.Month, 28);
            txtInEndDate.Text = Function.GetDate(dIndt);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行薪資計算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.Text;
            string dept_e = ptxDeptE.Text;
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue;
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM, c.SEQ, c.SALADR }
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && b.DEPT.CompareTo(dept_b) >= 0 && b.DEPT.CompareTo(dept_e) <= 0
                      && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //string msg = Sal.Function.AttendAlert(a1, a2);
            //if (msg.Trim().Length > 0)
            //{
            //    if (MessageBox.Show(msg + Environment.NewLine + "是否要繼續?", Resources.All.DialogTitle,
            //            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.OK)
            //    {
            //        return;
            //    }
            //}
            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, " MainForm.WORKADR", false, false, type, Prev, inEdate);
            BW.RunWorkerAsync(sc);
            this.Enabled = false;
        }
        private void txtBdate_Validated(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtBdate.Text);
            SetYYMM(date);
            txtEdate.Text = Function.GetDate(date.AddMonths(1).AddDays(-1));
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.Text;
            string dept_e = ptxDeptE.Text;
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue;
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db=new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM,c.SEQ,c.SALADR}
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && b.DEPT.CompareTo(dept_b) >= 0 && b.DEPT.CompareTo(dept_e) <= 0
                      && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, " MainForm.WORKADR", false, false, type, Prev, inEdate);
            sc.DeleteAll();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.Text;
            string dept_e = ptxDeptE.Text;
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue;
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM, c.SEQ, c.SALADR }
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && b.DEPT.CompareTo(dept_b) >= 0 && b.DEPT.CompareTo(dept_e) <= 0
                      && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, "MainForm.WORKADR", false, false, type, Prev, inEdate);
            sc.DeleteWaged();
            sc.DeleteWage();
            sc.ImportEnrich();
            sc.CreateWage();
            if (chkTax.Checked)
                sc.TaxCalc();
            if (chkTeco.Checked)
            {
                sc.TecoCalc();
                sc.ImportWagedd();
            }
            sc.WriteToDB();
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtAttDateB_Validated(object sender, EventArgs e)
        {
            DateTime d1, d2;
            d1 = Convert.ToDateTime(txtAttDateB.Text);
            d2 = d1.AddMonths(1).AddDays(-1);
            txtAttDateE.Text = Sal.Core.SalaryDate.DateString(d2);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.Text;
            string dept_e = ptxDeptE.Text;
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue;
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);

            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      where a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                      && b.NOBR.CompareTo(nobr_b) >= 0 && b.NOBR.CompareTo(nobr_e) <= 0
                      && b.DEPT.CompareTo(dept_b) >= 0 && b.DEPT.CompareTo(dept_e) <= 0
                      && a.YYMM == yymm && a.SEQ == seq
                      select a;

            foreach (var itm in sql)
            {
                itm.FORMAT = type;
            }
            db.SubmitChanges();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            SalaryCalculation sc = (SalaryCalculation)e.Argument;
            sc.BW = BW;
            sc.Calc(chkTeco.Checked, true, chkAbs.Checked, chkOT.Checked);
            if (chkReCalc.Checked)
                sc.Calc(chkTeco.Checked, false, chkAbs.Checked, chkOT.Checked);
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.Text;
            string dept_e = ptxDeptE.Text;
            string seq = txtSeq.Text;
            string seq1 = txtSeq1.Text;
            string yymm = txtYymm.Text;
            string yymm1 = txtYymm1.Text;
            string type = cbxFormat.SelectedValue;
            string salcodeB = cbxSalcodeB.SelectedValue;
            string salcodeE = cbxSalcodeE.SelectedValue;
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);

            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.BASE on a.NOBR equals c.NOBR
                      where a.YYMM == yymm && a.SEQ == seq
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && b.DEPT.CompareTo(dept_b) >= 0 && b.DEPT.CompareTo(dept_e) <= 0
                          //&& (b.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)
                       && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.DATE_E >= b.ADATE && a.DATE_E <= b.DDATE.Value
                      select new { a.NOBR, c.NAME_C };

            var sql1 = from a in db.WAGE
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       join c in db.BASE on a.NOBR equals c.NOBR
                       where a.YYMM == yymm1 && a.SEQ == seq1
                       && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && b.DEPT.CompareTo(dept_b) >= 0 && b.DEPT.CompareTo(dept_e) <= 0
                           //&& (b.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)
                       && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && a.DATE_E >= b.ADATE && a.DATE_E <= b.DDATE.Value
                       select new { a.NOBR, c.NAME_C };

            var waged = from a in db.WAGED
                        join b in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                        join c in db.BASETTS on a.NOBR equals c.NOBR
                        where b.DATE_E >= c.ADATE && b.DATE_E <= c.DDATE.Value
                        && c.NOBR.CompareTo(nobr_b) >= 0 && c.NOBR.CompareTo(nobr_e) <= 0
                        && c.DEPT.CompareTo(dept_b) >= 0 && c.DEPT.CompareTo(dept_e) <= 0
                            //&& (c.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)//權限由前端的名單控制
                        && a.SAL_CODE.CompareTo(salcodeB) >= 0 && a.SAL_CODE.CompareTo(salcodeE) <= 0
                        && a.YYMM == yymm && a.SEQ == seq
                        select a;
            var waged1 = from a in db.WAGED
                         join b in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                         join c in db.BASETTS on a.NOBR equals c.NOBR
                         where b.DATE_E >= c.ADATE && b.DATE_E <= c.DDATE.Value
                         && c.NOBR.CompareTo(nobr_b) >= 0 && c.NOBR.CompareTo(nobr_e) <= 0
                         && c.DEPT.CompareTo(dept_b) >= 0 && c.DEPT.CompareTo(dept_e) <= 0
                             //&& (c.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)
                         && a.SAL_CODE.CompareTo(salcodeB) >= 0 && a.SAL_CODE.CompareTo(salcodeE) <= 0
                         && a.YYMM == yymm1 && a.SEQ == seq1
                         select a;

            var unionSQL = sql.Union(sql1);//只取人員名單
            viewDS.WAGE_COMPARE.Clear();

            var salcodeSQL = from a in db.SALCODE
                             where a.SAL_CODE.CompareTo(salcodeB) >= 0 && a.SAL_CODE.CompareTo(salcodeE) <= 0
                             select a;
            var joinSQL = from a in unionSQL
                          from b in salcodeSQL
                          select new { a.NOBR, a.NAME_C, b.SAL_CODE, b.SAL_NAME };
            var diffSQL = from a in joinSQL
                          join c in waged on new { a.NOBR, a.SAL_CODE } equals new { c.NOBR, c.SAL_CODE } into cc
                          from w in cc.DefaultIfEmpty()
                          join d in waged1 on new { a.NOBR, a.SAL_CODE } equals new { d.NOBR, d.SAL_CODE } into dd
                          from w1 in dd.DefaultIfEmpty()
                          let amt = JBModule.Data.CDecryp.Number(w == null ? 0 : w.AMT)
                          let amt1 = JBModule.Data.CDecryp.Number(w1 == null ? 0 : w1.AMT)
                          where w != null || w1 != null
                          select new
                          {
                              a.NOBR,
                              a.NAME_C,
                              a.SAL_CODE,
                              a.SAL_NAME,
                              YYMM = yymm,
                              SEQ = seq,
                              AMT = amt,
                              YYMM1 = yymm1,
                              SEQ1 = seq1,
                              AMT1 = amt1
                          };

            //foreach (var itm in diffSQL)
            //{
            //    ViewDS.WAGE_COMPARERow r = viewDS.WAGE_COMPARE.NewWAGE_COMPARERow();
            //    r.
            //}

            DataTable DT = new DataTable();
            DT = diffSQL.CopyToDataTable();

            DT.Columns["nobr"].ColumnName = Resources.Sal.colNobr;
            DT.Columns["name_c"].ColumnName = Resources.Sal.colName;
            DT.Columns["amt"].ColumnName = Resources.Sal.colAmt;
            DT.Columns["amt1"].ColumnName = Resources.Sal.colAmt + "1";
            DT.Columns["sal_name"].ColumnName = Resources.Sal.colSalName;
            DT.Columns["sal_code"].ColumnName = Resources.Sal.colSalcode;
            DT.Columns["seq"].ColumnName = Resources.Sal.colSeq;
            DT.Columns["seq1"].ColumnName = Resources.Sal.colSeq + "1";
            DT.Columns["yymm"].ColumnName = Resources.Sal.colYymm;
            DT.Columns["yymm1"].ColumnName = Resources.Sal.colYymm + "1";

            Function.ShowView("薪資比較", DT, 800, 600);


        }

        private void txtChgYymm_Validated(object sender, EventArgs e)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.WAGE where a.YYMM == txtChgYymm.Text group a by a.SEQ into gp select gp.Key;
            comboBox1.Items.Clear();
            if (sql.Any())
            {
                comboBox1.Items.AddRange(sql.ToArray());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SalaryMDDataContext db = new SalaryMDDataContext();

                object[] objs = new object[] { txtChgYymm.Text, comboBox1.Text, txtChgSeq.Text };

                db.ExecuteCommand("UPDATE WAGE SET SEQ={2} WHERE YYMM={0} AND SEQ={1} ", objs);
                db.ExecuteCommand("UPDATE WAGED SET SEQ={2} WHERE YYMM={0} AND SEQ={1} ", objs);

                MessageBox.Show(Resources.Sal.StatusFinish, Resources.All.DialogTitle,
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤，" + ex.Message, Resources.All.DialogTitle,
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
