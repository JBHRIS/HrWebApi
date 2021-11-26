/* ======================================================================================================
 * 功能名稱：補扣發明細表
 * 功能代號：ZZ4I
 * 功能路徑：報表列印 > 薪資 > 補扣發明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4I.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/14    Daniel Chih    Ver 1.0.01     1. 增加主要與次要排序的項目條件
 * 2021/04/29    Daniel Chih    Ver 1.0.02     1. 增加【產出報表不分頁】的勾選選項
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/29
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
    public partial class ZZ4I : JBControls.JBForm
    {
        ZZ4I_Report zz4i_report;
        public ZZ4I()
        {
            InitializeComponent();
        }

        private void ZZ4I_Load(object sender, EventArgs e)
        {           
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            SystemFunction.SetComboBoxItems(depts_b, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(depts_e, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            //depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            //depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(salcode_b, ReportClass.SourceConvert(ReportClass.GetSalcode()), false, true, true);
            SystemFunction.SetComboBoxItems(salcode_e, ReportClass.SourceConvert(ReportClass.GetSalcode()), false, true, true);
            //salcode_b.DataSource = JBHR.Reports.ReportClass.GetSalcode();
            //salcode_e.DataSource = JBHR.Reports.ReportClass.GetSalcode();
            salcode_e.SelectedIndex = salcode_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
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
            try
            {
                if (zz4i_report != null)
                {
                    zz4i_report.Dispose();
                    zz4i_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string salcodeb = (salcode_b.SelectedIndex == -1) ? "" : salcode_b.SelectedValue.ToString();
                string salcodee = (salcode_e.SelectedIndex == -1) ? "" : salcode_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string yy = year_b.Text;
                string mm = month_b.Text;
                string seq = seq_b.Text;
                string dateb = date_b.Text;
                bool _excelexport = ExportExcel.Checked;
                bool _page_check = page_check.Checked;
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");

                string main_sort = "";
                string minor_sort = "";

                //主要排序項
                if (main_sort_depts.Checked == true)
                {
                    main_sort = "DEPTS";
                }
                else if (main_sort_nobr.Checked == true)
                {
                    main_sort = "NOBR";
                }
                else
                {
                    main_sort = "SAL_CODE";
                }

                //次要排序項
                if (minor_sort_depts.Checked == true)
                {
                    minor_sort = "DEPTS";
                }
                else if (minor_sort_nobr.Checked == true)
                {
                    minor_sort = "NOBR";
                }
                else
                {
                    minor_sort = "SAL_CODE";
                }

                zz4i_report = new ZZ4I_Report(nobrb, nobre, deptb, depte, deptsb, deptse, salcodeb, salcodee, empb, empe, dateb, yy, mm, seq, workadr, _excelexport, _page_check, MainForm.COMPANY_NAME, main_sort, minor_sort);
                zz4i_report.Show();
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

        /// <summary>
        /// 選擇主要排序項：成本部門
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_sort_depts_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                minor_sort_depts.Enabled = false;
                minor_sort_nobr.Enabled = true;
                minor_sort_salcode.Enabled = true;
                if(minor_sort_depts.Checked == true)
                {
                    minor_sort_depts.Checked = false;
                    minor_sort_salcode.Checked = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 選擇主要排序項：薪資代碼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_sort_salcode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                minor_sort_salcode.Enabled = false;
                minor_sort_depts.Enabled = true;
                minor_sort_nobr.Enabled = true;

                if (minor_sort_salcode.Checked == true)
                {
                    minor_sort_salcode.Checked = false;
                    minor_sort_nobr.Checked = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 選擇主要排序項：員工編號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_sort_nobr_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                minor_sort_nobr.Enabled = false;
                minor_sort_depts.Enabled = true;
                minor_sort_salcode.Enabled = true;

                if (minor_sort_nobr.Checked == true)
                {
                    minor_sort_nobr.Checked = false;
                    minor_sort_depts.Checked = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
