/* ======================================================================================================
 * 功能名稱：各期薪資表
 * 功能代號：ZZ46
 * 功能路徑：報表列印 > 薪資 > 各期薪資表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ46.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/03    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 2021/08/05    Daniel Chih    Ver 1.0.02     1. 修正中位數篩選條件不能正確判斷的錯誤
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/05
 */

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
    public partial class ZZ46 : JBControls.JBForm
    {
        ZZ46_Report zz46_report;
        public ZZ46()
        {
            InitializeComponent();
        }

        private void ZZ46_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            //work_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            //work_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(work_b, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(work_e, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            //comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            //comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(comp_b, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(comp_e, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;
            report_type.SelectedIndex = 0;

            jobl_b.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            jobl_e.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            //jobl_b.SelectedIndex = -1;
            jobl_e.SelectedIndex = jobl_e.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";

            year_e.Text = Convert.ToString(DateTime.Now.Year);
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_e.Text = "Z";
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);

        }

        private void year_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);
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
                month_e.Text = month_e.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_type.SelectedIndex == 8)
            {
                ExportExcel.Enabled = false;
                ExportExcel.Checked = true;
            }
            else
            {

                ExportExcel.Enabled = true;
                ExportExcel.Checked = false;
            }
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz46_report != null)
                {
                    zz46_report.Dispose();
                    zz46_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string joblb = (jobl_b.SelectedIndex != -1) ? jobl_b.SelectedValue.ToString() : "";
                string joble = (jobl_e.SelectedIndex == -1) ? "" : jobl_e.SelectedValue.ToString();
                string yyb = year_b.Text;
                string yye = year_e.Text;
                string monb = month_b.Text;
                string mone = month_e.Text;
                string seb = seq_b.Text;
                string see = seq_e.Text;
                string dateb = date_b.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                bool _excelexport = ExportExcel.Checked;
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string typedata = "";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";

                string MedianMon = string.Empty;
                if (MedianMon2.Checked) MedianMon = "1";
                if (MedianMon3.Checked) MedianMon = "2";

                zz46_report = new ZZ46_Report(nobrb, nobre, yyb, yye, monb, mone, seb, see, deptb, depte, joblb, joble, compb, compe, workb, worke, empb, empe, typedata, reporttype, _excelexport, dateb, workadr, MedianMon, MainForm.USER_NAME, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz46_report.Show();
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

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
