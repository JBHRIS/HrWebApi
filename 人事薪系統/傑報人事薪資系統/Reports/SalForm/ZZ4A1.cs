/* ======================================================================================================
 * 功能名稱：薪資分攤表
 * 功能代號：ZZ4A1
 * 功能路徑：報表列印 > 薪資 > 薪資分攤表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4A1.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/03    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/03
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
    public partial class ZZ4A1 : JBControls.JBForm
    {
        ZZ4A1_Report zz4a1_report;
        public ZZ4A1()
        {
            InitializeComponent();
        }

        private void ZZ4A1_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            //depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(depts_b, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(depts_e, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            //work_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            //work_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(work_b, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(work_e, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
            seq.Text = "2";
            report_type.SelectedIndex = 0;
        }

        private void year_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
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

                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;               
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string yyb = year.Text;
                string monb = month.Text;
                string seb = seq.Text;
                string dateb = date_b.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                bool _excelexport = ExportExcel.Checked;               
                string typedata = "";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                string depttype = "";
                string repo_name = "";
               
                if (type_data2.Checked)
                {
                    typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                    repo_name = "間接";
                }
                if (type_data3.Checked)
                {
                    typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                    repo_name = "直接";
                }
                if (type_data4.Checked)
                {
                    typedata = " AND A.COUNT_MA=1 ";
                    repo_name = "外勞";
                }

                if (zz4a1_report != null)
                {
                    zz4a1_report.Dispose();
                    zz4a1_report.Close();
                }
                zz4a1_report = new ZZ4A1_Report(typedata, depttype, nobrb, nobre, deptsb, deptse, empb, empe, workb, worke, yyb, monb, seb, dateb, MainForm.USER_NAME, workadr, reporttype, repo_name, _excelexport,MainForm.COMPANY, MainForm.COMPANY_NAME);
                zz4a1_report.Show();

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
