using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.InsForm
{
    public partial class ZZ39 : JBControls.JBForm
    {
        ZZ39_Report zz39_report;
        public ZZ39()
        {
            InitializeComponent();
        }

        private void ZZ39_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt;
                //if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_b.Focus();
                //    return;
                //}
                //if (DateTime.TryParseExact(date_e.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_e.Focus();
                //    return;
                //}
                //if (nobr_b.Text.Trim() == "")
                //{
                //    nobr_b.Focus();
                //    return;
                //}
                //if (nobr_e.Text.Trim() == "")
                //{
                //    nobr_e.Focus();
                //    return;
                //}
                if (zz39_report != null)
                {
                    zz39_report.Dispose();
                    zz39_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                //if (!MainForm.MANGSUPER) typedata += " and b.saladr='" + MainForm.WORKADR + "'";
                bool _excelexport = ExportExcel.Checked;
                zz39_report = new ZZ39_Report(nobrb, nobre, deptb, depte, dateb, datee, workb, worke, typedata, _excelexport,MainForm.COMPANY_NAME);
                zz39_report.Show();
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
