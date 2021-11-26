/* ======================================================================================================
 * 功能名稱：薪資異動通知單
 * 功能代號：ZZ4F
 * 功能路徑：報表列印 > 薪資 > 薪資異動通知單
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4F.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/04    Daniel Chih    Ver 1.0.01     1. 調整畫面控制項：下拉式選單欄位增加可輸入模糊查詢
 * 2021/05/10    Daniel Chih    Ver 1.0.02     1. 增加預約發送通知的功能
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
    public partial class ZZ4F : JBControls.JBForm
    {
        ZZ4F_Report zz4f_report;
        public ZZ4F()
        {
            InitializeComponent();
        }

        private void ZZ4F_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
            date_e.Text = DateTime.Now.ToString("yyyy/MM/dd");
            report_type.SelectedIndex = 0;
            note1.Text = "合人(  ) 字第     號";
            note2.Text = "職務及薪資調整";
            note3.Text = "本公司薪資係屬機密,有關薪資內容,請勿相互談論。";

        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz4f_report != null)
                {
                    zz4f_report.Dispose();
                    zz4f_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string reporttype = report_type.SelectedIndex.ToString();

                bool _excelexport = ExportExcel.Checked;
                bool ckdispatch = ck_dispatch.Checked;
                bool ckfile = ck_file.Checked;
                bool _sendmail = sendmail.Checked;

                string testemail = test_email.Text;
                string testpwd = test_pwd.Text;

                string dd = send_date.Value.ToString("yyyy/MM/dd");
                int hrs = send_time.Value.Hour;
                int mins = send_time.Value.Minute;
                DateTime _send_date_time = DateTime.Parse(dd).AddHours(hrs).AddMinutes(mins);

                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (ttscode.Checked)
                    workadr += " and b.ttscode in ('1','4','6')";

                zz4f_report = new ZZ4F_Report(nobrb, nobre, deptb, depte,empb,empe, dateb, datee, reporttype, workadr, note1.Text, note2.Text, note3.Text, note4.Text, note5.Text, testemail, testpwd, _excelexport,MainForm.COMPANY_NAME, _sendmail, ckdispatch, ckfile, _send_date_time);
                zz4f_report.Show();
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
