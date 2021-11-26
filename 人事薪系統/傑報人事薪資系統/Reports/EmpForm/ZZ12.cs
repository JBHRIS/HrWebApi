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
    public partial class ZZ12 : JBControls.JBForm
    {
        ZZ12_Report zz12_report;
        public ZZ12()
        {
            InitializeComponent();
        }
        

        private void ZZ12_Load(object sender, EventArgs e)
        {
            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyyMMdd");
            date_e.Text = DateTime.Now.ToString("yyyyMMdd");
            birdt_b.Text = Convert.ToString(DateTime.Now.Month);
            birdt_e.Text = Convert.ToString(DateTime.Now.Month);
        }
        
        private void Create_Report_Click(object sender, EventArgs e)
        {           
            try 
            {
                if (zz12_report != null)
                {
                    zz12_report.Dispose();
                    zz12_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string birtdb = birdt_b.Text;
                string birtde = birdt_e.Text;
                string _username = MainForm.USER_NAME;
                bool _exportexcel = ExportExcel.Checked;
                string _locals = "";
                if (locals.Checked) _locals = " AND A.COUNT_MA=0";
                string data_report = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");

                zz12_report = new ZZ12_Report(dateb, datee, deptb, depte, empb, empe, compb, compe, birtdb,birtde, _exportexcel, _username, _locals, data_report, MainForm.COMPANY_NAME);
                zz12_report.Show();
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

        private void birdt_b_Validated(object sender, EventArgs e)
        {
            try
            {
                birdt_b.Text = birdt_b.Text.PadLeft(2, '0');
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void birdt_e_Validated(object sender, EventArgs e)
        {
            try
            {
                birdt_e.Text = birdt_e.Text.PadLeft(2, '0');
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
