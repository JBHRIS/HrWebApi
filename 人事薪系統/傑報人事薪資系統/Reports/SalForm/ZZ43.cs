/* ======================================================================================================
 * 功能名稱：加班費用報表
 * 功能代號：ZZ43
 * 功能路徑：報表列印 > 薪資 > 加班費用報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ43.cs
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
    public partial class ZZ43 : JBControls.JBForm
    {
        ZZ43_Report zz43_report;
        public ZZ43()
        {
            InitializeComponent();
        }

        private void ZZ43_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            //depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(depts_b, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(depts_e, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

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
            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_e.Text, month_b.Text);
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            date_t.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);

            report_type.SelectedIndex = 0;
        }

        private void da_op1_Click(object sender, EventArgs e)
        {
            yymm_b.Enabled = true;
            yymm_e.Enabled = true;
            date_b.Enabled = false;
            date_e.Enabled = false;
            month_b.Enabled = true;
            month_e.Enabled = true;
        }

        private void da_op2_Click(object sender, EventArgs e)
        {
            yymm_b.Enabled = false;
            yymm_e.Enabled = false;
            date_b.Enabled = true;
            date_e.Enabled = true;
            month_b.Enabled = false;
            month_e.Enabled = false;
        }

        private void yymm_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void yymm_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
                date_t.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
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

                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
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

                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
                date_t.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
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
                if (zz43_report != null)
                {
                    zz43_report.Dispose();
                    zz43_report.Close();
                }
                string _nobrb = nobr_b.Text;
                string _nobre = nobr_e.Text;
                string _deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string _depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string _deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string _deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string _empb = (emp_b.SelectedIndex == -1) ? "" : emp_b.SelectedValue.ToString();
                string _empe = (emp_e.SelectedIndex == -1) ? "" : emp_e.SelectedValue.ToString();
                string _yymmb = yymm_b.Text + month_b.Text;
                string _yymme = yymm_e.Text + month_e.Text;
                string _dateb = date_b.Text;
                string _datee = date_e.Text;
                string datet = date_t.Text;
                if (da_op1.Checked && report_type.SelectedIndex==13)
                    datet = Convert.ToDateTime(Convert.ToString(Convert.ToInt32(_yymme.Substring(0, 4))) + "/" + _yymme.Substring(4, 2) + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                string _da = "";
                string _typedata = "";
                if (da_op1.Checked) _da = "1";
                if (da_op2.Checked) _da = "2";               

                if (type_data2.Checked) _typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) _typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) _typedata = " AND A.COUNT_MA=1 ";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                //if (type_data1.Checked) _typedata = "1";
                //if (type_data2.Checked) _typedata = "2";
                //if (type_data3.Checked) _typedata = "3";
                //if (type_data4.Checked) _typedata = "4";
                //if (!MainForm.MANGSUPER) workadr = " AND B.SALADR='" + MainForm.WORKADR + "'";
                bool _exportexcel=ExportExcel.Checked;
                bool nodisp=no_disp.Checked;
                bool prrest=pr_rest.Checked;
                bool otsum=ot_sum.Checked;
                bool ot21 = ot_21.Checked;
                string _reporttype = report_type.SelectedIndex.ToString();
                bool _labchedk = LABCHECK.Checked;
                zz43_report = new ZZ43_Report(_nobrb, _nobre, _deptb, _depte, _deptsb, _deptse, _empb, _empe, _yymmb, _yymme, _dateb, _datee, datet, _reporttype, _da, _typedata, _exportexcel, nodisp, prrest, otsum, ot21, _labchedk, MainForm.USER_NAME, workadr, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz43_report.Show();
                
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
