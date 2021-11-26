/* ======================================================================================================
 * 功能名稱：費用分攤明細表
 * 功能代號：ZZ1B
 * 功能路徑：報表列印 > 人事 > 費用分攤明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1B.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/01    Daniel Chih    Ver 1.0.01     1. 新增功能：增加【只列印目前在職人員】的判斷
 * 2021/05/18    Daniel Chih    Ver 1.0.02     1. 新增功能：增加【只列印加總非100%的異常人員】的判斷
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/01
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
    public partial class ZZ1B : JBControls.JBForm
    {
        ZZ1B_Report zz1b_report;
        public ZZ1B()
        {
            InitializeComponent();
        }

        private void ZZ1B_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyyMMdd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                 
                //if (nobr_b.Text.Trim() == "")
                //{
                //    nobr_b.Focus();
                //    return;
                //}

                //if (nobr_e.Text.Trim() == "")
                //{
                //    nobr_e.Focus();
                //    return;
                //}

                DateTime dt;
                if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                {
                    date_b.Focus();
                    return;
                }

                string dateb = date_b.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string datareport = " AND " + Sal.Function.GetFilterCmdByDataGroup("d.saladr");

                //增加判斷：只列印目前在職人員 - Added By Daniel Chih - 2021/02/01
                bool _current = checkBox_Current.Checked;

                bool _check_sum = check_sum.Checked;
                bool _exportexcel = ExportExcel.Checked;
                string _username = MainForm.USER_NAME;
                zz1b_report = new ZZ1B_Report(dateb, nobrb, nobre, deptb, depte, compb, compe, _exportexcel, _current, _username, datareport, MainForm.COMPANY_NAME, _check_sum);
                zz1b_report.Show();
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
