/* ======================================================================================================
 * 功能名稱：部門人力統計表
 * 功能代號：ZZ1E
 * 功能路徑：報表列印 > 人事 > 部門人力統計表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1E_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/11    Daniel Chih    Ver 1.0.01     1. 增加條件欄位：【年齡】、【年資】並篩選掉不在區間內的資料
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/11
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ1E : JBControls.JBForm
    {
        ZZ1E_Report zz1e_report;
        public ZZ1E()
        {
            InitializeComponent();
        }

        private void ZZ1E_Load(object sender, EventArgs e)
        {
            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            rotet_b.DataSource = JBHR.Reports.ReportClass.GetRotet(MainForm.COMPANY);
            rotet_e.DataSource = JBHR.Reports.ReportClass.GetRotet(MainForm.COMPANY);
            rotet_e.SelectedIndex = rotet_e.Items.Count - 1;


            job_b.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            job_e.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            job_e.SelectedIndex = job_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;            

            sex_b.SelectedIndex = 0;
            sex_e.SelectedIndex = 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            report_type.SelectedIndex = 0;
            date_b.Text = DateTime.Now.ToString("yyyy/MM") + "/01";            
            date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyyMMdd");

            //年齡
            age_b.Text = "1"; age_e.Text = "999";
            //年資
            seniority_b.Text = "0"; seniority_e.Text = "99";
        }


        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {   
                if (zz1e_report != null)
                {
                    zz1e_report.Dispose();
                    zz1e_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string sexb = "";
                string sexe = "";

                //年齡
                string ageb = age_b.Text;
                string agee = age_e.Text;

                //年資
                string seniorityb = seniority_b.Text;
                string senioritye = seniority_e.Text;

                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string jobb = (job_b.SelectedIndex == -1) ? "" : job_b.SelectedValue.ToString();
                string jobe = (job_e.SelectedIndex == -1) ? "" : job_e.SelectedValue.ToString();
                string rotetb = (rotet_b.SelectedIndex == -1) ? "" : rotet_b.SelectedValue.ToString();
                string rotete = (rotet_e.SelectedIndex == -1) ? "" : rotet_e.SelectedValue.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string _username = MainForm.USER_NAME;
                if (sex_b.SelectedIndex == 0)
                    sexb = "F";
                if (sex_b.SelectedIndex == 1)
                    sexb = "M";
                if (sex_e.SelectedIndex == 0)
                    sexe = "F";
                if (sex_e.SelectedIndex == 1)
                    sexe = "M";
                string datareport = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                
                zz1e_report = new ZZ1E_Report(dateb, datee
                    , deptb, depte
                    , sexb, sexe
                    , empb, empe
                    , workb, worke
                    , compb, compe
                    , jobb, jobe
                    , reporttype
                    , _exportexcel
                    , _username
                    , datareport
                    , rotetb, rotete
                    , ageb, agee
                    , seniorityb, senioritye
                    , MainForm.COMPANY_NAME
                );
                zz1e_report.Show();
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
