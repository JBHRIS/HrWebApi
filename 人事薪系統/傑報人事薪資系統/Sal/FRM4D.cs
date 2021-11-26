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
using JBHR.Sal.Core.Inslab;
namespace JBHR.Sal
{
    public partial class FRM4D : JBControls.JBForm
    {
        public FRM4D()
        {
            InitializeComponent();
        }
        TimeSpan ts;
        string nobr_b, nobr_e, dept_b, dept_e, yymm;
        DateTime inEdate;
        bool Prev = false;
        JBModule.Data.Linq.SALARYCALC sclc = new JBModule.Data.Linq.SALARYCALC();
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            //if (txtYear.Text.Length >= 3)
            //    this.SelectNextControl(txtYear, true, true, true, true);
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            //if (txtMonth.Text.Length >= 2)
            //    this.SelectNextControl(txtMonth, true, true, true, true);
        }

        private void FRM4D_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(txtDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(txtDeptE, deptData, false);
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            Function.SetAvaliableBase(this.salaryDS.BASE);

            txtYear.Text = Sal.Core.SalaryDate.YearString();
            txtMonth.Text = Sal.Core.SalaryDate.MonthString();
            txtDeptB.SelectedValue = deptData.First().Key;
            txtDeptE.SelectedValue = deptData.Last().Key;
            txtNobrB.Text = BaseValue.MinNobr;
            txtNobrE.Text = BaseValue.MaxNobr;
            int yy, mm;
            yy = int.Parse(txtYear.Text);
            mm = int.Parse(txtMonth.Text);
            yymm = yy.ToString("0000") + mm.ToString("00");
            SalaryDate sd = new SalaryDate(yymm);
            DateTime dIndt = new DateTime(sd.FirstDayOfMonth.Year, sd.FirstDayOfMonth.Month, 28);
            txtInEdate.Text = Function.GetDate(dIndt);
            //txtYear.Focus();
            //JBModule.Salary.Salary oSalary = new JBModule.Salary.Salary("870011", "09710");
            //var itm = oSalary.GetAbsSalaryItems();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行保險計算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            nobr_b = txtNobrB.Text;
            nobr_e = txtNobrE.Text;
            dept_b = txtDeptB.SelectedValue.ToString();
            dept_e = txtDeptE.SelectedValue.ToString();
            Prev = chkPrev.Checked;
            int yy, mm;
            yy = int.Parse(txtYear.Text);
            mm = int.Parse(txtMonth.Text);
            yymm = yy.ToString("0000") + mm.ToString("00");
            if (Function.IsSalaryLocked(yymm, "2", MainForm.WORKADR))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            inEdate = Convert.ToDateTime(txtInEdate.Text);
            var NoExplab = Inslab.GetPreviousExplab(yymm, nobr_b, nobr_e, dept_b, dept_e);
            if (!chkPrev.Checked)
            {
                if (NoExplab.Any())
                {
                    if (MessageBox.Show("檢查到有" + NoExplab.Count().ToString() + "位員工有上期未計算之保險費，是否繼續?選[是]繼續，選[否]取消並顯示人員名單", Resources.All.DialogTitle,
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        PreviewForm frm = new PreviewForm();
                        frm.DataTable = NoExplab.Select(p => new { 員工編號 = p.Key, 員工姓名 = p.Value }).CopyToDataTable();
                        frm.Form_Title = "上期未計保險費人員";
                        frm.ShowDialog();
                        return;
                    }
                }
            }
            this.panel1.Enabled = false;
            BW.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime d1, d2;
            d1 = DateTime.Now;

            var db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime DT = DateTime.Now;
            sclc = new JBModule.Data.Linq.SALARYCALC();
            sclc.GUID = Guid.NewGuid();
            sclc.USERID = MainForm.USER_ID;
            sclc.TIMEB = DT;
            sclc.SOURCE = this.Name;
            db.SALARYCALC.InsertOnSubmit(sclc);
            db.SubmitChanges();

            //var sqlNobrTable = db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).ToList();
            //if (sqlNobrTable.Count > 0)
            //{
            //    foreach (var item in sqlNobrTable)
            //    {
            //        JBModule.Data.Linq.WriteRuleNobrTable WriteRuleTable = new JBModule.Data.Linq.WriteRuleNobrTable();
            //        WriteRuleTable.GUID = sclc.GUID;
            //        WriteRuleTable.EMPID = item.NOBR;
            //        WriteRuleTable.KEY_DATE = DT;
            //        db.WriteRuleNobrTable.InsertOnSubmit(WriteRuleTable);
            //    }
            //    db.SubmitChanges();
            //}

            Inslab.backgroundWorker = BW;
            Inslab.guid = sclc.GUID;
            Inslab.Calc(yymm, nobr_b, nobr_e, dept_b, dept_e, inEdate, Prev);
            d2 = DateTime.Now;
            ts = d2 - d1;

        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes.ToString(), ts.Seconds.ToString());
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.panel1.Enabled = true;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            trpState.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void txtMonth_Validated(object sender, EventArgs e)
        {
            int yy, mm;
            yy = int.Parse(txtYear.Text);
            mm = int.Parse(txtMonth.Text);
            yymm = yy.ToString("0000") + mm.ToString("00");
            SalaryDate sd = new SalaryDate(yymm);
            DateTime dIndt = new DateTime(sd.FirstDayOfMonth.Year, sd.FirstDayOfMonth.Month, 28);
            txtInEdate.Text = Function.GetDate(dIndt);
        }


    }
}
