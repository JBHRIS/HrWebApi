using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.ExaForm
{
    public partial class ZZ81 : JBControls.JBForm
    {
        ZZ81_Report zz81_report;
        public ZZ81()
        {
            InitializeComponent();
        }

        private void ZZ81_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            effg_b.DataSource = JBHR.Reports.ReportClass.GetEffgcd();
            effg_e.DataSource = JBHR.Reports.ReportClass.GetEffgcd();
            effg_e.SelectedIndex = effg_e.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            year_e.Text = Convert.ToString(DateTime.Now.Year);
            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
            report_type.SelectedIndex = 0;
        }

        private void year_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_e.Text, "12");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz81_report != null)
                {
                    zz81_report.Dispose();
                    zz81_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string dateb = date_b.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string apgb = (effg_b.SelectedIndex == -1) ? "" : effg_b.SelectedValue.ToString();
                string apge = (effg_e.SelectedIndex == -1) ? "" : effg_e.SelectedValue.ToString();
                string yyb = year_b.Text;
                string yye = year_e.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr"); ;
                zz81_report = new ZZ81_Report(dateb, nobrb, nobre, deptb, depte, apgb, apge, yyb, yye, type_data, reporttype, MainForm.COMPANY_NAME, _exportexcel);
                zz81_report.Show();
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
