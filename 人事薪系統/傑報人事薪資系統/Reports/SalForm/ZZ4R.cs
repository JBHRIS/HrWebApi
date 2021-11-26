/* ======================================================================================================
 * 功能名稱：福利金代扣明細表
 * 功能代號：ZZ4R
 * 功能路徑：報表列印 > 薪資 > 福利金代扣明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4R.cs
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
    public partial class ZZ4R : JBControls.JBForm
    {
        ZZ4R_Report zz4r_report;
        public ZZ4R()
        {
            InitializeComponent();
        }

        private void ZZ4R_Load(object sender, EventArgs e)
        {
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

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "1";

            year_e.Text = Convert.ToString(DateTime.Now.Year );
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_e.Text = "z";
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_e.Text, month_e.Text);
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_e_Validated(object sender, EventArgs e)
        {
            try
            {
                month_e.Text = month_e.Text.PadLeft(2, '0');

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
                if (zz4r_report != null)
                {
                    zz4r_report.Dispose();
                    zz4r_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string yyb = year_b.Text;
                string yye = year_e.Text;
                string monb = month_b.Text;
                string mone = month_e.Text;
                string seb = seq_b.Text;
                string see = seq_e.Text;
                string dateb = date_b.Text;
                bool _excelexport = ExportExcel.Checked;
                string typedata = ""; 
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";
               
                zz4r_report = new ZZ4R_Report(typedata, nobrb, nobre, yyb, yye, monb, mone, seb, see, deptb, depte,empb,empe, dateb, workadr, MainForm.USER_NAME, _excelexport,MainForm.COMPANY_NAME,MainForm.COMPANY);
                zz4r_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
