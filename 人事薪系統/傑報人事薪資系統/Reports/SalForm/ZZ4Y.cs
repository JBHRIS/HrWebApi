/* ======================================================================================================
 * 功能名稱：全勤獎金明細表
 * 功能代號：ZZ4Y
 * 功能路徑：報表列印 > 薪資 > 全勤獎金明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4Y.cs
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
    public partial class ZZ4Y : JBControls.JBForm
    {
        ZZ4Y_Report zz4y_report;
        public ZZ4Y()
        {
            InitializeComponent();
        }

        private void ZZ4Y_Load(object sender, EventArgs e)
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
            seq_b.Text = "2";

            date_b.Text = ReportClass.GetAttBDate(year_b.Text, month_b.Text);
            date_e.Text = ReportClass.GetAttEDate(year_b.Text, month_b.Text);           
        }

        private void year_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year_b.Text, month_b.Text);
                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year_b.Text, month_b.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(year_b.Text, month_b.Text);
                date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
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
                if (zz4y_report != null)
                {
                    zz4y_report.Dispose();
                    zz4y_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();  
                string yyb = year_b.Text;                
                string monb = month_b.Text;               
                string seb = seq_b.Text;                
                string dateb = date_b.Text;
                string datee = date_e.Text;
                bool _excelexport = ExportExcel.Checked;                
                string typedata = "";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";                
                zz4y_report = new ZZ4Y_Report(nobrb, nobre, dateb, datee, yyb, monb, seb, deptb, depte, empb, empe, typedata, _excelexport, MainForm.USER_NAME, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz4y_report.Show();
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
