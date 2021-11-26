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
    public partial class ZZ29 : JBControls.JBForm
    {
        ZZ29_Report zz29_report;
        public ZZ29()
        {
            InitializeComponent();
        }

        private void ZZ29_Load(object sender, EventArgs e)
        {
            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt;
                if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                {
                    date_b.Focus();
                    return;
                }
                if (DateTime.TryParseExact(date_e.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                {
                    date_e.Focus();
                    return;
                }

                if (zz29_report != null)
                {
                    zz29_report.Dispose();
                    zz29_report.Close();
                }

                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                bool _exportexcel = ExportExcel.Checked;
                string report_type = "";

                if (printord1.Checked)
                    report_type = "1";
                if (printord2.Checked)
                    report_type = "2";
                zz29_report = new ZZ29_Report(deptb, depte, compb, compe, dateb, datee, _exportexcel, report_type, type_data, MainForm.COMPANY_NAME);
                zz29_report.Show();
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
