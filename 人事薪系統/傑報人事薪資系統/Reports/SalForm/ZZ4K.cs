/* ======================================================================================================
 * 功能名稱：屆退人員明細表
 * 功能代號：ZZ4K
 * 功能路徑：報表列印 > 薪資 > 屆退人員明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4K.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/04    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/04
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
    public partial class ZZ4K : JBControls.JBForm
    {
        ZZ4K_Report zz4k_report; ZZ4K_Report2 zz4k_report2;
        public ZZ4K()
        {
            InitializeComponent();
        }

        private void ZZ4K_Load(object sender, EventArgs e)
        {
            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";

            year_e.Text = Convert.ToString(DateTime.Now.Year);
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_e.Text = "9";
            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;
            
            re_year.Text = "60";
            in_year.Text = "25";
        }

        private void count_type1_Click(object sender, EventArgs e)
        {
            re_year.Enabled = true;
            in_year.Enabled = true;
        }

        private void count_type2_Click(object sender, EventArgs e)
        {
            re_year.Enabled = false;
            in_year.Enabled = false;
        }

        private void type_data1_Click(object sender, EventArgs e)
        {
            in_year.Enabled = true;
            re_year.Enabled = true;
        }

        private void type_data2_Click(object sender, EventArgs e)
        {
            in_year.Enabled = false;
            re_year.Enabled = true;
        }

        private void type_data3_Click(object sender, EventArgs e)
        {
            in_year.Enabled = true;
            re_year.Enabled = false;
        }        

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz4k_report != null)
                {
                    zz4k_report.Dispose();
                    zz4k_report.Close();
                }
                if (zz4k_report2 != null)
                {
                    zz4k_report2.Dispose();
                    zz4k_report2.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string yyb = year_b.Text;
                string yye = year_e.Text;
                string monb = month_b.Text;
                string mone = month_e.Text;
                string seb = seq_b.Text;
                string see = seq_e.Text;
                string typedata = "";
                if (type_data1.Checked) typedata = "1";
                if (type_data2.Checked) typedata = "2";
                if (type_data3.Checked) typedata = "3";
                string counttype = "";
                if (count_type1.Checked) counttype = "1";
                if (count_type2.Checked) counttype = "2";
                decimal inyear = decimal.Parse(in_year.Text);
                decimal reyear = decimal.Parse(re_year.Text);
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                
                bool _excelexport = ExportExcel.Checked;
                if (count_type1.Checked)
                {
                    zz4k_report = new ZZ4K_Report(nobrb, nobre, deptb, depte,empb,empe, dateb, yyb, monb, seb, yye, mone, see, typedata, workadr, counttype, inyear, reyear, _excelexport, MainForm.COMPANY_NAME, MainForm.COMPANY);
                    zz4k_report.Show();
                }
                else
                {
                    zz4k_report2 = new ZZ4K_Report2(nobrb, nobre, deptb, depte,empb,empe, dateb, yyb, monb, seb, yye, mone, see, typedata, workadr, counttype, inyear, reyear, _excelexport, MainForm.COMPANY_NAME, MainForm.COMPANY);
                    zz4k_report2.Show();
                }
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

        private void month_e_Validated(object sender, EventArgs e)
        {
            try
            {
                month_e.Text = month_e.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
