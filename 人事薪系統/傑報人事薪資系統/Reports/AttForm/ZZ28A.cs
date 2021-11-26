using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.AttForm
{
    public partial class ZZ28A : JBControls.JBForm
    {
        ZZ28A_Report zz28a_report;
        public ZZ28A()
        {
            InitializeComponent();
        }

        private void ZZ28A_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            job_b.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            job_e.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            job_e.SelectedIndex = job_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
        }

        private void date_b_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            //}
            //catch (Exception Ex)
            //{
            //    return;
            //}
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {  
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string jobb = (job_b.SelectedIndex == -1) ? "" : job_b.SelectedValue.ToString();
                string jobe = (job_e.SelectedIndex == -1) ? "" : job_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string salarb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string salare = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string type_data1 = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked)
                {
                    type_data += " and b.di='I' and b.count_ma=0 ";
                    type_data1 += " and b.di='I' and d.count_ma=0 ";
                }
                if (type_data3.Checked)
                {
                    type_data += " and b.di='D' and b.count_ma=0";
                    type_data1 += " and b.di='D' and d.count_ma=0";
                }
                if (type_data4.Checked)
                {
                    type_data += " and b.count_ma=1 ";
                    type_data1 += " and d.count_ma=1 ";
                }
                if (type_data5.Checked)
                {
                    type_data += " and b.di='D'";
                    type_data1 += " and b.di='D'";
                }
                bool export_excel = ExportExcel.Checked;
                string report_type = "";
                if (repo_type1.Checked) report_type = "1";
                if (repo_type2.Checked) report_type = "2";
                if (repo_type3.Checked) report_type = "3";
                if (zz28a_report != null)
                {
                    zz28a_report.Dispose();
                    zz28a_report.Close();
                }
                zz28a_report = new ZZ28A_Report(nobrb, nobre, deptb, depte, jobb, jobe, compb, compe, salarb, salare, dateb, datee, type_data, type_data1, export_excel, report_type, MainForm.COMPANY_NAME);               
                zz28a_report.Show();
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
