using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.TraForm
{
    public partial class ZZ91 : JBControls.JBForm
    {
        ZZ91_Report zz91_report;
        public ZZ91()
        {
            InitializeComponent();
        }

        private void ZZ91_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            jobl_b.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            jobl_e.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);            
            jobl_e.SelectedIndex = jobl_e.Items.Count - 1;

            jobs_b.DataSource = JBHR.Reports.ReportClass.GetJobs(MainForm.COMPANY);
            jobs_e.DataSource = JBHR.Reports.ReportClass.GetJobs(MainForm.COMPANY);
            jobs_e.SelectedIndex = jobs_e.Items.Count - 1;

            subcode_b.DataSource = JBHR.Reports.ReportClass.GetTrtype();
            subcode_e.DataSource = JBHR.Reports.ReportClass.GetTrtype();
            subcode_e.SelectedIndex = subcode_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM") + "/01";
            date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz91_report != null)
                {
                    zz91_report.Dispose();
                    zz91_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string jobsb = jobs_b.SelectedValue.ToString();
                string jobse = jobs_e.SelectedValue.ToString();
                string deptb = dept_b.SelectedValue.ToString();
                string depte = dept_e.SelectedValue.ToString();
                string joblb = (jobl_b.SelectedIndex != -1) ? jobl_b.SelectedValue.ToString() : "";
                string joble = jobl_e.SelectedValue.ToString();
                string compb = comp_b.SelectedValue.ToString();
                string compe = comp_e.SelectedValue.ToString();
                string sub_b = subcode_b.SelectedValue.ToString();
                string sub_e = subcode_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string type_data = "";
                if (!MainForm.MANGSUPER) type_data += " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                zz91_report = new ZZ91_Report(nobrb, nobre, compb, compe, deptb, depte, joblb, joble, jobsb, jobse, sub_b, sub_e, dateb, datee, type_data, ExportExcel.Checked, incu_out.Checked,MainForm.COMPANY_NAME);
                zz91_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void bnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
