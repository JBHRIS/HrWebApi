/* ======================================================================================================
 * 功能名稱：基本薪資
 * 功能代號：ZZ41
 * 功能路徑：報表列印 > 薪資 > 基本薪資
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ41.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/20    Daniel Chih    Ver 1.0.01     1. 新增異動種類：期間在職
 * 2021/01/29    Daniel Chih    Ver 1.0.02     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
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
    public partial class ZZ41 : JBControls.JBForm
    {
        ZZ41_Report zz41_report;
        public ZZ41()
        {
            InitializeComponent();
        }

        private void ZZ41_Load(object sender, EventArgs e)
        {
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

            //jobl_b.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            //jobl_e.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(jobl_b, ReportClass.SourceConvert(ReportClass.GetJobl(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(jobl_e, ReportClass.SourceConvert(ReportClass.GetJobl(MainForm.COMPANY)), false, true, true);
            jobl_b.SelectedIndex = -1;
            jobl_e.SelectedIndex = jobl_e.Items.Count - 1;

            //job_b.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            //job_e.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(job_b, ReportClass.SourceConvert(ReportClass.GetJob(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(job_e, ReportClass.SourceConvert(ReportClass.GetJob(MainForm.COMPANY)), false, true, true);
            job_e.SelectedIndex = job_e.Items.Count - 1;

            //rotet_b.DataSource = JBHR.Reports.ReportClass.GetRotet(MainForm.COMPANY);
            //rotet_e.DataSource = JBHR.Reports.ReportClass.GetRotet(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(rotet_b, ReportClass.SourceConvert(ReportClass.GetRotet(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(rotet_e, ReportClass.SourceConvert(ReportClass.GetRotet(MainForm.COMPANY)), false, true, true);
            rotet_e.SelectedIndex = rotet_e.Items.Count - 1;

            //saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            //saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(saladr_b, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(saladr_e, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            date_b.Text = ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            ttstype.SelectedIndex = 0;            
            date_b.Enabled = false;

            report_type.SelectedIndex = 0;
            
        }

        private void ttstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ttstype.SelectedIndex == 0 || ttstype.SelectedIndex == 1)
                date_b.Enabled = false;
            else
                date_b.Enabled = true;
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

        private void date_b_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime dtb = DateTime.Parse(date_b.Text);
            //    date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            //}
            //catch (Exception Ex)
            //{
            //    return;
            //}
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz41_report != null)
                {
                    zz41_report.Dispose();
                    zz41_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string jobb = (job_b.SelectedIndex == -1) ? "" : job_b.SelectedValue.ToString();
                string jobe = (job_e.SelectedIndex == -1) ? "" : job_e.SelectedValue.ToString();
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string joblb = (jobl_b.SelectedIndex != -1) ? jobl_b.SelectedValue.ToString() : "";
                string joble = (jobl_e.SelectedIndex == -1) ? "" : jobl_e.SelectedValue.ToString();
                string rotetb = (rotet_b.SelectedIndex == -1) ? "" : rotet_b.SelectedValue.ToString();
                string rotete = (rotet_e.SelectedIndex == -1) ? "" : rotet_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string salarb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string salare = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();                
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string _ttstype = ttstype.SelectedIndex.ToString();
                string datet = date_e.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string order_type = ""; string depttype = "";
                string deptstr = ""; string deptstr1 = ""; string deptstr2 = ""; string d_ename = "";
                
                if (dept_type1.Checked)
                {
                    d_ename = ", C.D_NO_DISP AS DEPT, C.D_ENAME";
                    depttype = "DEPT";
                    deptstr = "DEPT C";
                    deptstr1 = "AND C.D_NO_DISP BETWEEN '" + deptb + "' AND '" + depte + "'";
                    deptstr2 = "B.DEPT";
                }
                else
                {
                    d_ename = ", C.D_NO_DISP AS DEPTS, '' AS D_ENAME";
                    depttype = "DEPTS";
                    deptstr = "DEPTS C";
                    deptstr1 = "AND C.D_NO_DISP BETWEEN '" + deptsb + "' AND '" + deptse + "'";
                    deptstr2 = "B.DEPTS";
                }

                if (type_data2.Checked) type_data += " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) type_data += " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) type_data += " AND A.COUNT_MA=1 ";
                if (type_data5.Checked) type_data += " AND A.COUNT_MA=0 ";
                
                if (order1.Checked) order_type = "1";
                if (order2.Checked) order_type = "2";
                if (order3.Checked) order_type = "3";
                if (order4.Checked) order_type = "4";
                if (order5.Checked) order_type = "5";
                bool _floating = Floating.Checked;
                zz41_report = new ZZ41_Report(nobrb, nobre, jobb, jobe, deptb, depte, deptsb, deptse, joblb, joble, rotetb, rotete, compb, compe, dateb, datee, salarb, salare, empb, empe, datet, order_type, _exportexcel, type_data, deptstr, deptstr1, deptstr2, _ttstype, depttype, reporttype, _floating, d_ename, MainForm.COMPANY_NAME);
                zz41_report.Show();
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
