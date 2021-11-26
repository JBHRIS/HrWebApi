using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.AttForm
{
    public partial class ZZ2Z : JBControls.JBForm
    {
        ZZ2Z_Report zz2z_report; ZZ2Z1_Report zz2z1_report; ZZ2Z2_Report zz2z2_report; ZZ2Z_Report4 zz2z_report4; ZZ2Z_Report5 zz2z_report5; ZZ2Z_Report6 zz2z_report6;

        public ZZ2Z()
        {
            InitializeComponent();
        }

        private void ZZ2Z_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            jobl_b.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            jobl_e.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            //jobl_b.SelectedIndex = -1;
            jobl_e.SelectedIndex = jobl_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            //Responsibility_b.DataSource = JBHR.Reports.ReportClass.GetResponsibilityType();
            //Responsibility_e.DataSource = JBHR.Reports.ReportClass.GetResponsibilityType();
            //Responsibility_e.SelectedIndex = Responsibility_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));

            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            report_type.SelectedIndex = 0;

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ2Z", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("AttSalCode1", "出勤津貼1", "", "出勤津貼1薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode2", "出勤津貼2", "", "出勤津貼2薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode3", "出勤津貼3", "", "出勤津貼3薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode4", "出勤津貼4", "", "出勤津貼4薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode5", "出勤津貼5", "", "出勤津貼5薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode6", "出勤津貼6", "", "出勤津貼6薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode7", "出勤津貼7", "", "出勤津貼7薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode8", "出勤津貼8", "", "出勤津貼8薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCode9", "出勤津貼9", "", "出勤津貼9薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AttSalCodeA", "出勤津貼10", "", "出勤津貼10薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where sal_attr< 'L' and dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            
        }


        private void yymm_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
                month_b.Focus();
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
                month_e.Focus();

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
                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
                yymm_e.Focus();
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
                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_type.SelectedIndex == 11 || report_type.SelectedIndex == 12)
            {
                ExportExcel.Checked = true;
                ExportExcel.Enabled = false;
            }
            else
            {
                ExportExcel.Checked = false;
                ExportExcel.Enabled = true;
            }
            //if (report_type.SelectedIndex == 5)
            //{
            //    ear.Checked = true;
            //    ear.Enabled = false;
            //    later.Checked = true;
            //    later.Enabled = false;
            //}
            //else
            //{
            //    ear.Enabled = true;
            //    later.Enabled = true;
            //}
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string joblb = (jobl_b.SelectedIndex != -1) ? jobl_b.SelectedValue.ToString() : "";
                string joble = (jobl_e.SelectedIndex == -1) ? "" : jobl_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string yymmb = yymm_b.Text + month_b.Text;
                string yymme = yymm_e.Text + month_e.Text;
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();

                string Responsibilityb = "";
                string Responsibilitye = "";
                string repottype = report_type.SelectedIndex.ToString();
                bool _late = later.Checked;
                bool _ear = ear.Checked;
                bool _abs = abs.Checked;
                bool _abs1 = abs1.Checked;
                bool _forget = forget.Checked;
                bool _card = card.Checked;
                bool _forcard = forcard.Checked;
                bool otfix = ot_fix00.Checked;
                bool _ot1 = ot1.Checked;
                bool _ot2 = ot2.Checked;
                bool _exportexcel = ExportExcel.Checked;
                bool _labchedk = labcheck.Checked;
                bool _NoSevenBreak = NoSevenBreak.Checked;
                bool checkduty = check_duty.Checked;
                string data_report = " AND " + Sal.Function.GetFilterCmdByNobr("b.nobr");
                if (type_data2.Checked)
                    data_report += " and b.di='I' and a.count_ma=0 ";
                if (type_data3.Checked)
                    data_report += " and b.di='D' and a.count_ma=0";
                if (type_data4.Checked)
                    data_report += " and a.count_ma=1 ";
//遲到.早退.曠職.忘刷個人明細
//遲到.早退.曠職.忘刷個人彙總
//部門彙總2(by個人)
//實際刷卡個人明細表
//實際刷卡個人彙總表
//實際刷卡部門彙總表
//實際刷卡個人月報表
//實際刷卡部門月報表
                switch (repottype)
                {
                    case "0":
                    case "3":
                    case "4":
                        if (zz2z_report != null)
                        {
                            zz2z_report.Dispose();
                            zz2z_report.Close();
                        }                    
                        zz2z_report = new ZZ2Z_Report(nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, dateb, datee, yymmb, yymme, empb, empe, compb, compe, workb, worke, Responsibilityb, Responsibilitye, data_report, repottype, _late, _ear, _abs, _abs1, _forget, _card, _forcard, otfix, _ot1, _ot2, _exportexcel, _labchedk, _NoSevenBreak, checkduty, MainForm.COMPANY_NAME, MainForm.COMPANY);
                        zz2z_report.Show();
                        break;
                    case "1":
                    case "7":
                        if (zz2z1_report != null)
                        {
                            zz2z1_report.Dispose();
                            zz2z1_report.Close();
                        }
                        zz2z1_report = new ZZ2Z1_Report(nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, dateb, datee, yymmb, yymme, empb, empe, compb, compe, workb, worke,Responsibilityb,Responsibilitye, data_report, _exportexcel, MainForm.COMPANY_NAME,MainForm.COMPANY);
                        zz2z1_report.Show();
                        break;
                    case "2":
                        if (zz2z2_report != null)
                        {
                            zz2z2_report.Dispose();
                            zz2z2_report.Close();
                        }
                        zz2z2_report = new ZZ2Z2_Report(nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, dateb, datee, yymmb, yymme, empb, empe, compb, compe, workb, worke, Responsibilityb, Responsibilitye, data_report, _exportexcel, MainForm.COMPANY_NAME);
                        zz2z2_report.Show();
                        break;
                    case "8":
                    case "9":
                    case "10":
                        if (zz2z_report5 != null)
                        {
                            zz2z_report5.Dispose();
                            zz2z_report5.Close();
                        }
                        zz2z_report5 = new ZZ2Z_Report5(nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, dateb, datee, yymmb, yymme, empb, empe, compb, compe, workb, worke, Responsibilityb, Responsibilitye, data_report, repottype, _exportexcel, MainForm.COMPANY_NAME, MainForm.COMPANY);
                        zz2z_report5.Show();
                        break;
                    case "11":
                    case "12":
                        if (zz2z_report6 != null)
                        {
                            zz2z_report6.Dispose();
                            zz2z_report6.Close();
                        }
                        zz2z_report6 = new ZZ2Z_Report6(nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, dateb, datee, yymmb, yymme, empb, empe, compb, compe, workb, worke, Responsibilityb, Responsibilitye, data_report, repottype, _exportexcel, MainForm.COMPANY_NAME, MainForm.COMPANY);
                        zz2z_report6.Show();
                        break;
                    default:
                        if (zz2z_report4 != null)
                        {
                            zz2z_report4.Dispose();
                            zz2z_report4.Close();
                        }
                        zz2z_report4 = new ZZ2Z_Report4(nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, dateb, datee, yymmb, yymme, empb, empe, compb, compe, workb, worke, Responsibilityb, Responsibilitye, data_report, repottype, _exportexcel, MainForm.COMPANY_NAME);
                        zz2z_report4.Show();
                        break;
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
