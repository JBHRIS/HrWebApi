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
    public partial class ZZ4O : JBControls.JBForm
    {
        ZZ4O_Report zz4o_report;
        public ZZ4O()
        {
            InitializeComponent();
        }

        private void ZZ4O_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";

            year_e.Text = Convert.ToString(DateTime.Now.Year);
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_e.Text = "Z";
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);
            report_type.SelectedIndex = 0;

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4O", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("Basic", "本薪薪資代碼", "A01", "請用半形分號區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("OT", "加班薪資代碼", "B06;H01", "請用半形分號區隔", "TextBox", "", "String");
        }

        private void year_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_e.Text, month_e.Text);
                month_e.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_e.Text, month_e.Text);
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
                if (zz4o_report != null)
                {
                    zz4o_report.Dispose();
                    zz4o_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string workb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string worke = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string yyb = year_b.Text;
                string yye = year_e.Text;
                string monb = month_b.Text;
                string mone = month_e.Text;
                string seb = seq_b.Text;
                string see = seq_e.Text;
                string dateb = date_b.Text;
                bool _excelexport = ExportExcel.Checked;
                string reporttype = report_type.SelectedIndex.ToString();
                string typedata = "";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";

                zz4o_report = new ZZ4O_Report(nobrb, nobre, yyb, yye, monb, mone, seb, see, deptb, depte, deptsb, deptse, workb, worke, empb, empe, dateb, typedata, _excelexport, workadr, reporttype);
                zz4o_report.Show();
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
