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
    public partial class ZZ26 : JBControls.JBForm
    {
        ZZ26_Report zz26_report;
        public ZZ26()
        {
            InitializeComponent();
        }

        private void ZZ26_Load(object sender, EventArgs e)
        {
            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            h_codeb.DataSource = JBHR.Reports.ReportClass.GetOtrcd();
            h_codee.DataSource = JBHR.Reports.ReportClass.GetOtrcd();
            h_codee.SelectedIndex = h_codee.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

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
                if (zz26_report != null)
                {
                    zz26_report.Dispose();
                    zz26_report.Close();
                }
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string hcodeb = (h_codeb.SelectedIndex == -1) ? "" : h_codeb.SelectedValue.ToString();
                string hcodee = (h_codee.SelectedIndex == -1) ? "" : h_codee.SelectedValue.ToString();
                string salarb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string salare = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                bool _exportexcel = ExportExcel.Checked;
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string _username = MainForm.USER_NAME;                
                zz26_report = new ZZ26_Report(compb, compe, deptb, depte, hcodeb, hcodee, salarb, salare, dateb, datee, _exportexcel, typedata, _username,MainForm.COMPANY_NAME);
                zz26_report.Show();
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
