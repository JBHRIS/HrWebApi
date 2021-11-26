/* ======================================================================================================
 * 功能名稱：薪資總表
 * 功能代號：ZZ4A
 * 功能路徑：報表列印 > 薪資 > 薪資總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4A.cs
 * 功能用途：
 *  用於產出薪資總表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/13    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：公司
 * 2021/09/10    Daniel Chih    Ver 1.0.02     1. 增加合併期別欄位
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/09/10
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
    public partial class ZZ4A : JBControls.JBForm
    {
        ZZ4A_Report zz4a_report; ZZ4A_Report2 zz4a_report2;
        public ZZ4A()
        {
            InitializeComponent();
        }

        private void ZZ4A_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //增加【公司】下拉式選單控制欄位 - Added By Daniel Chih - 2021/01/13
            SystemFunction.SetComboBoxItems(comp_b, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(comp_e, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            //comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            //comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(depts_b, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(depts_e, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            //depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            //depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(work_b, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(work_e, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            //work_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            //work_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
            seq.Text = "2";
            report_type.SelectedIndex = 0;

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4A", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("DeptDspNewLine", "部門分攤是否折行", "True", "True:折行 , False:不折行", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
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

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_type.SelectedIndex > 8)
            {
                ExportExcel.Checked = true;
                ExportExcel.Enabled = false;
            }
            else
                ExportExcel.Enabled = true;

            if (report_type.SelectedIndex == 8)
            {
                dept_type1.Checked = true;
                dept_type2.Checked = false;
                dept_type2.Enabled = false;
                dept_b.Enabled = false;
                dept_e.Enabled = false;
                depts_b.Enabled = true;
                depts_e.Enabled = true;
            }
            else
                dept_type2.Enabled = true;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;

                //增加【公司】下拉式選單控制欄位 - Added By Daniel Chih - 2021/01/13
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();

                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string yyb = year.Text;
                string monb = month.Text;
                string seb = seq.Text;
                string _seqmerge = seqmerge.Text;
                string dateb = date_b.Text;                
                string reporttype = report_type.SelectedIndex.ToString();
                bool _excelexport = ExportExcel.Checked;
                string _note = note.Text;
                string typedata = "";
                string workadr = "AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                string depttype = "";
                string repo_name = "";
                if (dept_type1.Checked) depttype = "1";
                if (dept_type2.Checked) depttype = "2";
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
               
                if (zz4a_report != null)
                {
                    zz4a_report.Dispose();
                    zz4a_report.Close();
                }
                if (zz4a_report2 != null)
                {
                    zz4a_report2.Dispose();
                    zz4a_report2.Close();
                }

                if (reporttype == "8")
                {
                    zz4a_report2 = new ZZ4A_Report2(typedata, depttype, nobrb, nobre, deptb, depte, deptsb, deptse, compb, compe, empb, empe, workb, worke, yyb, monb, seb, _seqmerge, dateb, MainForm.USER_NAME, workadr, _note, reporttype, repo_name, _excelexport, MainForm.COMPANY_NAME);
                    zz4a_report2.Show();
                }
                else
                {
                    zz4a_report = new ZZ4A_Report(typedata, depttype, nobrb, nobre, deptb, depte, deptsb, deptse, compb, compe, empb, empe, workb, worke, yyb, monb, seb, _seqmerge, dateb, MainForm.USER_NAME, workadr, _note, reporttype, repo_name, _excelexport, MainForm.COMPANY_NAME);
                    zz4a_report.Show();
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
    }
}
