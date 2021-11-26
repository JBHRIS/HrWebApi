/* ======================================================================================================
 * 功能名稱：舊制勞退金提撥明細表
 * 功能代號：ZZ4BA
 * 功能路徑：報表列印 > 薪資 > 舊制勞退金提撥明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4BA.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/04    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 2021/03/24    Daniel Chih    Ver 1.0.02     1. 增加選擇到職日類型的控制項
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/24
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
    public partial class ZZ4BA : JBControls.JBForm
    {
        ZZ4BA_Report zz4ba_report;
        public ZZ4BA()
        {
            InitializeComponent();
        }

        private void ZZ4BA_Load(object sender, EventArgs e)
        {
            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

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
        }

        private void year_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
                month_b.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            if (zz4ba_report != null)
            {
                zz4ba_report.Dispose();
                zz4ba_report.Close();
            }
            string nobrb = nobr_b.Text;
            string nobre = nobr_e.Text;
            string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
            string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
            string dateb = date_b.Text;
            string yyb = year_b.Text;
            string monb = month_b.Text;
            string seb = seq_b.Text;
            string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
            string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
            string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
            string indt_type = "";
            if (cindt_radio_button.Checked)
            {
                indt_type = "CINDT";
            }
            else if (indt_radio_button.Checked)
            {
                indt_type = "INDT";
            }
            bool _excelexport = ExportExcel.Checked;
            zz4ba_report = new ZZ4BA_Report(nobrb, nobre, deptsb, deptse, dateb, yyb, monb, seb, compb, compe, workadr, _excelexport,MainForm.COMPANY_NAME, indt_type);
            zz4ba_report.Show();
        }

        private void bnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
