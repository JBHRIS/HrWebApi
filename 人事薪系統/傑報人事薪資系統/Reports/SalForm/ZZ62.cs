using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ62 : JBControls.JBForm
    {
        ZZ62_Report zz62_report;
        public ZZ62()
        {
            InitializeComponent();
        }

        private void ZZ62_Load(object sender, EventArgs e)
        {
            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "1";
            seq_e.Text = "z";
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            wcode_b.DataSource = JBHR.Reports.ReportClass.GetWcode();
            wcode_e.DataSource = JBHR.Reports.ReportClass.GetWcode();
            wcode_e.SelectedIndex = wcode_e.Items.Count - 1;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                if (zz62_report != null)
                {
                    zz62_report.Dispose();
                    zz62_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string yymmb = yymm_b.Text + month_b.Text;
                string yymme = yymm_e.Text + month_e.Text;
                string seqb = seq_b.Text;
                string seqe = seq_e.Text;
                string wcodeb = (wcode_b.SelectedIndex == -1) ? "" : wcode_b.SelectedValue.ToString();
                string wcodee = (wcode_e.SelectedIndex == -1) ? "" : wcode_e.SelectedValue.ToString();
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("c.saladr");
               
                bool _exportexcel = ExportExcel.Checked;
                zz62_report = new ZZ62_Report(nobrb, nobre, deptb, depte, yymmb, yymme, seqb, seqe, wcodeb, wcodee, typedata, MainForm.USER_NAME, _exportexcel,MainForm.COMPANY_NAME);
                zz62_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
