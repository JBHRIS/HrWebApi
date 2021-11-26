/* ======================================================================================================
 * 功能名稱：薪資異動表
 * 功能代號：ZZ47
 * 功能路徑：報表列印 > 薪資 > 薪資異動表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ47.cs
 * 功能用途：
 *  用於產出薪資異動表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/03    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 2021/04/20    Daniel Chih    Ver 1.0.02     1. 新增條件欄位：公司
 * 2021/05/07    Daniel Chih    Ver 1.0.03     1. 修改篩選模式的選項
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/05/07
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
    public partial class ZZ47 : JBControls.JBForm
    {
        ZZ47_Report zz47_report;
        public ZZ47()
        {
            InitializeComponent();
        }

        private void ZZ47_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));

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

            //salcode_b.DataSource = JBHR.Reports.ReportClass.GetSalcode();
            //salcode_e.DataSource = JBHR.Reports.ReportClass.GetSalcode();
            SystemFunction.SetComboBoxItems(salcode_b, ReportClass.SourceConvert(ReportClass.GetSalcode()), false, true, true);
            SystemFunction.SetComboBoxItems(salcode_e, ReportClass.SourceConvert(ReportClass.GetSalcode()), false, true, true);
            salcode_e.SelectedIndex = salcode_e.Items.Count - 1;

            //work_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            //work_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(work_b, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(work_e, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            ttstype.SelectedIndex = 0;
            report_type.SelectedIndex = 0;
            year_no_adjust.Text = "365";
        }

        private void dept_type1_Click(object sender, EventArgs e)
        {
            dept_b.Enabled = true;
            dept_e.Enabled = true;
            depts_b.Enabled = false;
            depts_e.Enabled = false;
        }

        private void dept_type2_Click(object sender, EventArgs e)
        {
            dept_b.Enabled = false;
            dept_e.Enabled = false;
            depts_b.Enabled = true;
            depts_e.Enabled = true;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt;
                //if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_b.Focus();
                //    return;
                //}
                //if (DateTime.TryParseExact(date_e.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_e.Focus();
                //    return;
                //}
                if (zz47_report != null)
                {
                    zz47_report.Dispose();
                    zz47_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string salcodeb = (salcode_b.SelectedIndex == -1) ? "" : salcode_b.SelectedValue.ToString();
                string salcodee = (salcode_e.SelectedIndex == -1) ? "" : salcode_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                double _year_no_adjust = double.Parse(year_no_adjust.Text.ToString());
                bool _exportexcel = ExportExcel.Checked;
                bool _ttsnone = tts_none.Checked;
                bool _ttssalary = tts_salary.Checked;
                bool _tts_no_adjust = tts_no_adjust.Checked;
                bool _tts_include_before = tts_include_before.Checked;
                string depttype = "";
                if (dept_type1.Checked) depttype = "1";
                if (dept_type2.Checked) depttype = "2";
                string _ttstype = ttstype.SelectedIndex.ToString();
                string typedata =" AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");                
                if (type_data2.Checked) typedata += " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata += " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata += " AND A.COUNT_MA=1 ";
              
                zz47_report = new ZZ47_Report(nobrb, nobre, compb, compe, deptb, depte, deptsb, deptse, dateb, datee, salcodeb, salcodee, workb, worke,empb,empe, typedata, _ttstype, depttype, _ttsnone, _ttssalary, _tts_no_adjust, _year_no_adjust, _tts_include_before, _exportexcel, reporttype,MainForm.COMPANY_NAME);
                zz47_report.Show();
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

        private void tts_none_CheckedChanged(object sender, EventArgs e)
        {
            date_b.Enabled = false;
        }

        private void tts_salary_CheckedChanged(object sender, EventArgs e)
        {
            date_b.Enabled = true;
        }

        private void tts_no_adjust_CheckedChanged(object sender, EventArgs e)
        {
            date_b.Enabled = false;
        }
    }
}
