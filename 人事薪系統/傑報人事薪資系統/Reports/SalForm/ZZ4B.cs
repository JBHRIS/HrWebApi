/* ======================================================================================================
 * 功能名稱：其他費用總表
 * 功能代號：ZZ4B
 * 功能路徑：報表列印 > 薪資 > 其他費用總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4B.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/03    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 2021/04/15    Daniel Chih    Ver 1.0.02     1. 增加報表內容的控制項：允許選擇全部、退休金提撥表、年終獎金提撥表
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/15
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
    public partial class ZZ4B : JBControls.JBForm
    {
        ZZ4B_Report zz4b_report;
        public ZZ4B()
        {
            InitializeComponent();
        }

        private void ZZ4B_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq.Text = "2";

            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
            //depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            //depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(depts_b, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(depts_e, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

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
        }


        private void year_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
                month.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_Validated(object sender, EventArgs e)
        {
            try
            {
                month.Text = month.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
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
                //DateTime dt;
                //if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_b.Focus();
                //    return;
                //}
                
                if (zz4b_report != null)
                {
                    zz4b_report.Dispose();
                    zz4b_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string depte = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string yyb = year.Text;
                string monb = month.Text;
                string seb = seq.Text;
                string dateb = date_b.Text;
                string reporttype = "";
                bool _excelexport = ExportExcel.Checked;

                string typedata = "";
                string workadr = "AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                if (report_type1.Checked) reporttype = "1";
                if (report_type2.Checked) reporttype = "2";

                string report_content = "";
                if(report_content_pension.Checked)
                {
                    report_content = "pension";
                }
                else if (report_content_bonuses.Checked)
                {
                    report_content = "bonuses";
                }
                else
                {
                    report_content = "all";
                }

                zz4b_report = new ZZ4B_Report(nobrb, nobre, deptsb, deptse, compb, compe,empb,empe, yyb, monb, seb, dateb, workadr, reporttype, report_content, _excelexport, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz4b_report.Show();
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
