/* ======================================================================================================
 * 功能名稱：加班費用分析表
 * 功能代號：ZZ44
 * 功能路徑：報表列印 > 薪資 > 加班費用分析表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ44.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/29    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/01/29
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
    public partial class ZZ44 : JBControls.JBForm
    {
        ZZ44_Report zz44_report;
        public ZZ44()
        {
            InitializeComponent();
        }

        private void ZZ44_Load(object sender, EventArgs e)
        {
            //comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            //comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(comp_b, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(comp_e, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            //emp_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //emp_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(emp_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(emp_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            emp_e.SelectedIndex = emp_e.Items.Count - 1;

            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');

            otyymm_b.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year);
            otyymm_e.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year);
            otmonth_b.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            otmonth_e.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');

        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz44_report != null)
                {
                    zz44_report.Dispose();
                    zz44_report.Close();
                }
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string _empb = (emp_b.SelectedIndex == -1) ? "" : emp_b.SelectedValue.ToString();
                string _empe = (emp_e.SelectedIndex == -1) ? "" : emp_e.SelectedValue.ToString();
                string type_data = "";
                if (!MainForm.MANGSUPER) type_data += " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                zz44_report = new ZZ44_Report(yymm_b.Text + month_b.Text, yymm_e.Text + month_e.Text, otyymm_b.Text +otmonth_b.Text, otyymm_e.Text + otmonth_e.Text, deptb, depte, compb, compe, _empb, _empe, type_data, ExportExcel.Checked,MainForm.COMPANY_NAME);
                zz44_report.Show();
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
                month_b.Text = month_b.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void otmonth_b_Validated(object sender, EventArgs e)
        {
            try
            {
                otmonth_b.Text = otmonth_b.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void otmonth_e_Validated(object sender, EventArgs e)
        {
            try
            {
                otmonth_e.Text = otmonth_e.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
