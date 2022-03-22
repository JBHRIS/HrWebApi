/* ======================================================================================================
 * 功能名稱：人事資料
 * 功能代號：ZZ11
 * 功能路徑：報表列印 > 人事 >　人事資料
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ11.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/07/20    Daniel Chih    Ver 1.0.01     1. 增加期間在職條件控制項【包含已離職人員】預設勾選
 * 
 * ======================================================================================================
 * 
 * 最後修改：2021/07/20
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace JBHR.Reports.EmpForm
{
    public partial class ZZ11 : JBControls.JBForm
    {
        ZZ11_Report zz11_report;
        //public object objForm;
        public ZZ11()
        {
            InitializeComponent();
        }
        
        private void ZZ11_Load(object sender, EventArgs e)
        {
            //ttstype.SelectedIndex = 0;
            //report_type.SelectedIndex = 0;
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            date_b.Text = DateTime.Now.ToString("yyyyMMdd").PadLeft(8,'0');
            date_e.Text = DateTime.Now.ToString("yyyyMMdd").PadLeft(8,'0');
            age_b.Text = "1"; age_e.Text = "999";
            
            seniority_b.Text = "0"; seniority_e.Text = "99";

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            jobl_b.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            jobl_e.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);           
            jobl_e.SelectedIndex = jobl_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            report_type.SelectedIndex = 0;
            ttstype.SelectedIndex = 0;

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ11", MainForm.COMPANY);

            AppConfig.CheckParameterAndSetDefault("CINDT_Check", "【預設勾選】固定以集團到職日計算年資", "False", "設定是否預設勾選【固定以集團到職日計算年資】", "ComboBox", "SELECT CODE, RESULT FROM (SELECT CAST('True' AS NVARCHAR) AS True, CAST('False' AS NVARCHAR) AS False) AS TF UNPIVOT(CODE FOR RESULT IN(TF.TRUE,TF.FALSE)) AS PV"
                , "String");

            JBModule.Data.Linq.HrDBDataContext dcHr = new JBModule.Data.Linq.HrDBDataContext();
            var configs = dcHr.AppConfig.Where(p => p.Category == "ZZ11" && p.Comp == string.Empty);

            if(AppConfig.GetConfig("CINDT_Check").GetString("False").Trim() == "True")
            {
                cindt_check.Checked = true;
            }
            else
            {
                cindt_check.Checked = false;
            }
        }

        private void ttstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ttstype.SelectedIndex.ToString() == "0")
            {
                date_e.Enabled = false;
                include_leave.Visible = false;
                include_leave.Enabled = false;

                if (Convert.ToDecimal(report_type.SelectedIndex.ToString()) > 4 && Convert.ToDecimal(report_type.SelectedIndex.ToString()) < 10)
                    report_type.SelectedIndex = 0;
            }
            else
            {
                date_e.Enabled = true;
                include_leave.Visible = false;
                include_leave.Enabled = false;

                if (ttstype.SelectedIndex.ToString() == "6")
                {
                    include_leave.Checked = true;
                    include_leave.Visible = true;
                    include_leave.Enabled = true;
                }
            }

            switch (ttstype.SelectedIndex.ToString())
            {
                case "1":
                    report_type.SelectedIndex = 5;
                    break;
                case "2":
                    report_type.SelectedIndex = 6;
                    break;
                case "5":
                    report_type.SelectedIndex = 7;
                    break;
                case "6":
                    report_type.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
            
        }

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (report_type.SelectedIndex.ToString())
            {
                //case "1":
                //    ExportExcel.Checked = true;
                //    break;
                ////case "5":
                ////    ttstype.SelectedIndex = 1;
                ////    break;
                //case "6":
                //    ttstype.SelectedIndex = 2;
                //    break;
                //case "7":
                //    ttstype.SelectedIndex = 5;
                //    break;
                //default:
                //    ttstype.SelectedIndex = 0;
                    //break;
            }
            if (report_type.SelectedIndex == 8 || report_type.SelectedIndex == 9)
                ExportExcel.Enabled = false;
            else
                ExportExcel.Enabled = true;
        }

       

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                //string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                //string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptb = dept_b.SelectedValue.ToString();
                string depte = dept_e.SelectedValue.ToString();
                string deptsb = depts_b.SelectedValue.ToString();
                string deptse = depts_e.SelectedValue.ToString();
                string joblb = (jobl_b.SelectedIndex != -1) ? jobl_b.SelectedValue.ToString() : "";
                string joble = (jobl_e.SelectedIndex == -1) ? "" : jobl_e.SelectedValue.ToString();
                string empcdb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empcde = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string _ttstype = ttstype.SelectedIndex.ToString();
                string reporttype = report_type.Text.ToString();
                string ageb = age_b.Text;
                string agee = age_e.Text;
                string seniorityb = seniority_b.Text;
                string senioritye = seniority_e.Text;
                string datet = date_b.Text;
                string reportname = report_type.SelectedItem.ToString();
                bool _exportexcel = ExportExcel.Checked;
                bool _include_leave = include_leave.Checked;
                bool _cindt_check = cindt_check.Checked;

                string data_report = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string _username = MainForm.USER_NAME;                
                if (type_data2.Checked)
                    data_report += " AND B.DI='I'  AND A.COUNT_MA=0 ";
                else if (type_data3.Checked)
                    data_report += " AND B.DI='D'  AND A.COUNT_MA=0";
                else if (type_data4.Checked)
                    data_report += " AND A.COUNT_MA=1 ";
               
                zz11_report = new ZZ11_Report(dateb, datee, nobrb, nobre, deptb, depte, deptsb, deptse, joblb, joble, empcdb, empcde, workb, worke, compb, compe, _ttstype, reporttype, datet, reportname, data_report, _exportexcel, _include_leave, ageb, agee, seniorityb, senioritye, _username,MainForm.COMPANY_NAME, _cindt_check);
                zz11_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
        }

        private void Leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
    }
}
