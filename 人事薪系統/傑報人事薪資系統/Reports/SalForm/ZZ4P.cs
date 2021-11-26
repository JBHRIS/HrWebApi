/* ======================================================================================================
 * 功能名稱：薪資傳票
 * 功能代號：ZZ4P
 * 功能路徑：報表列印 > 薪資 > 薪資傳票
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4P.cs
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
    public partial class ZZ4P : JBControls.JBForm
    {
        ZZ4P_Report zz4p_report;
        public ZZ4P()
        {
            InitializeComponent();
        }

        private void ZZ4P_Load(object sender, EventArgs e)
        {
            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";
            date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

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

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4P", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("Payable", "應付薪資", "", "會科", "TextBox", "", "String");
        }

        private void dept_type1_Click(object sender, EventArgs e)
        {
            dept_b.Enabled = false;
            dept_e.Enabled = false;
            depts_b.Enabled = true;
            depts_e.Enabled = true;
        }

        private void dept_type2_Click(object sender, EventArgs e)
        {
            
            dept_b.Enabled = true;
            dept_e.Enabled = true;
            depts_b.Enabled = false;
            depts_e.Enabled = false;
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void year_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
                month_b.Focus();
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
                if (zz4p_report != null)
                {
                    zz4p_report.Dispose();
                    zz4p_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string datee = date_e.Text;
                string _yy = year_b.Text;
                string _mm = month_b.Text;
                string _seq = seq_b.Text;
                bool _exportexcel = ExportExcel.Checked;
                string depttype = "";
                if (dept_type1.Checked) depttype = "1";
                if (dept_type2.Checked) depttype = "2";
                string typedata = "";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";
                string reporttype = "";
                if (report_type1.Checked) reporttype = "1";
                if (report_type2.Checked) reporttype = "2";
                //if (report_type3.Checked) reporttype = "3";//公司與工地
                string _note = note.Text;
                
                bool _mangsuper = MainForm.MANGSUPER;
                zz4p_report = new ZZ4P_Report(nobrb, nobre, compb, compe, deptb, depte, deptsb, deptse, empb, empe, datee, _seq, _yy, _mm, typedata, reporttype, _note, workadr, depttype, MainForm.USER_NAME, _exportexcel, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz4p_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        
    }
}
