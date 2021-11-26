using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ14 : JBControls.JBForm
    {
        ZZ14_Report zz14_report;
        public ZZ14()
        {
            InitializeComponent();
        }

        private void ZZ14_Load(object sender, EventArgs e)
        {
            bASETableAdapter.Fill(salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            report_type.SelectedIndex = 0;
            date_b.Text = DateTime.Now.ToString("yyyyMMdd");
            date_e.Text = DateTime.Now.ToString("yyyyMMdd");
        }        

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {   
                if (zz14_report != null)
                {
                    zz14_report.Dispose();
                    zz14_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string _username = MainForm.USER_NAME;
                string workadr = " AND " + Sal.Function.GetFilterCmdByNobr("d.nobr");   
               

                zz14_report = new ZZ14_Report(nobrb, nobre, dateb, datee, deptb, depte, compb, compe, reporttype, _exportexcel, _username,workadr,MainForm.COMPANY_NAME);
                //zz14_report.MdiParent = this.MdiParent;
                zz14_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void Leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
