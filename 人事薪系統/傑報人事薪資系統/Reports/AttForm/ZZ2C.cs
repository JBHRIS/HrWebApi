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
    public partial class ZZ2C : JBControls.JBForm
    {
        ZZ2C_Report zz2c_report;
        public ZZ2C()
        {
            InitializeComponent();
        }

        private void ZZ2C_Load(object sender, EventArgs e)
        {
            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            h_codeb.DataSource = JBHR.Reports.ReportClass.GetHcode(MainForm.COMPANY);
            h_codee.DataSource = JBHR.Reports.ReportClass.GetHcode(MainForm.COMPANY);
            h_codee.SelectedIndex = h_codee.Items.Count - 1;

            rote_b.DataSource = JBHR.Reports.ReportClass.GetRote(MainForm.COMPANY);
            rote_e.DataSource = JBHR.Reports.ReportClass.GetRote(MainForm.COMPANY);
            rote_e.SelectedIndex = rote_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
            basetime.Text = "4.0";
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
                if (basetime.Text.Trim() == "")
                {
                    basetime.Focus();
                    return;
                }
                if (zz2c_report != null)
                {
                    zz2c_report.Dispose();
                    zz2c_report.Close();
                }
                string deptb = dept_b.SelectedValue.ToString();
                string depte = dept_e.SelectedValue.ToString();
                string hcodeb = (h_codeb.SelectedIndex == -1) ? "" : h_codeb.SelectedValue.ToString();
                string hcodee = (h_codee.SelectedIndex == -1) ? "" : h_codee.SelectedValue.ToString();
                string dateb = date_b.Text;
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string roteb = (rote_b.SelectedIndex == -1) ? "" : rote_b.SelectedValue.ToString();
                string rotee = (rote_e.SelectedIndex == -1) ? "" : rote_e.SelectedValue.ToString();
                decimal _basetime = decimal.Parse(basetime.Text);
                bool _exportexcel = ExportExcel.Checked;
                string data_report = " AND " + Sal.Function.GetFilterCmdByDataGroup("a.saladr");
                zz2c_report = new ZZ2C_Report(deptb, depte, hcodeb, hcodee, empb, empe, compb, compe, roteb, rotee, dateb, _exportexcel, _basetime,data_report,MainForm.COMPANY_NAME);
                zz2c_report.Show();
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
