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
using JBHR.Sal.Core.OvertTime;
namespace JBHR.Sal
{
    public partial class FRM4F : JBControls.JBForm
    {

        TimeSpan ts;
        int year;
        int month;
        string yymm, nobr_b, nobr_e, dept_b, dept_e, seq;
        DateTime DateB;
        DateTime DateE;
        decimal NoTaxHours;
        public FRM4F()
        {
            InitializeComponent();
        }

        private void FRM4B_Load(object sender, EventArgs e)
        {
            this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            Function.SetAvaliableBase(this.salaryDS.BASE);
            txtYear.Text = Sal.Core.SalaryDate.YearString();// (DateTime.Now.Year - 1911).ToString("000");
            txtMonth.Text = Sal.Core.SalaryDate.MonthString();
            ptxDeptB.Text = BaseValue.MinDept;
            ptxDeptE.Text = BaseValue.MaxDept;
            ptxNobrB.Text = BaseValue.MinNobr;
            ptxNobrE.Text = BaseValue.MaxNobr;
            txtYear.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            year = Convert.ToInt32(txtYear.Text);
            month = Convert.ToInt32(txtMonth.Text);
            Sal.Core.SalaryDate sd = new SalaryDate(year, month);
            yymm = sd.YYMM;
           
            DateB = new DateTime(year, month, 1);
            DateE = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;
            BW.RunWorkerAsync();
            this.panel1.Enabled = false;
        }

        void calc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length >= 2)
                this.SelectNextControl(txtYear, true, true, true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            InslabCNCalculation calc = new InslabCNCalculation(nobr_b, nobr_e, dept_b, dept_e, yymm);
            calc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(calc_StatusChanged);
            calc.Run();
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;
           
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.panel1.Enabled = true;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            trpState.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }
    }

}