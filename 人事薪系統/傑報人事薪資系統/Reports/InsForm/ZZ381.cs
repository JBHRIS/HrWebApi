/* ======================================================================================================
 * 功能名稱：勞健團保費用分攤
 * 功能代號：ZZ381
 * 功能路徑：報表列印 > 保險 > 勞健團保費用分攤
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\InsForm\ZZ381.cs
 * 功能用途：
 *  用於產出勞健團保費用分攤資料
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/12    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：只列印有發薪者
 *                                             2. 新增條件欄位：只列印無發薪者
 *                                             3. 重新調整視窗畫面與控制項位置
 * 2021/02/25    Daniel Chih    Ver 1.0.02     1. 移除條件欄位：只列印有發薪者
 *                                             2. 移除條件欄位：只列印無發薪者
 * 2021/05/20    Daniel Chih    Ver 1.0.03     1. 修正查詢年月篩選條件以年月迄篩選
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/05/20
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.InsForm
{
    public partial class ZZ381 : JBControls.JBForm
    {
        ZZ38_Report1 zz38_report1; 
        public ZZ381()
        {
            InitializeComponent();
        }

        private void ZZ381_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            sno_b.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.SelectedIndex = sno_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;
            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";

            year_e.Text = Convert.ToString(DateTime.Now.Year);
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_e.Text = "Z";

            report_type.SelectedIndex = 0;
            
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {

                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string dateb = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
                string datee = JBHR.Reports.ReportClass.GetSalEDate(year_e.Text, month_e.Text);
                string snob = (sno_b.SelectedIndex == -1) ? "" : sno_b.SelectedValue.ToString();
                string snoe = (sno_e.SelectedIndex == -1) ? "" : sno_e.SelectedValue.ToString();
                string yyb = year_b.Text + month_b.Text;
                string yye = year_e.Text + month_e.Text;
                string seqb = seq_b.Text;
                string seqe = seq_e.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string saladr = " AND " + Sal.Function.GetFilterCmdByDataGroup("a.saladr");
                if (type_data2.Checked) typedata += " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata += " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata += " AND A.COUNT_MA=1 ";

                ////是否只列印有 & 無發薪者 - Added By Daniel Chih - 2021/01/12
                //bool _checkbox_print_with_salary_only = checkbox_print_with_salary_only.Checked;
                //bool _checkbox_print_without_salary_only = checkbox_print_without_salary_only.Checked;

                bool _excelexport = ExportExcel.Checked;
                if (zz38_report1 != null)
                {
                    zz38_report1.Dispose();
                    zz38_report1.Close();
                }
                zz38_report1 = new ZZ38_Report1(nobrb, nobre, deptsb, deptse, dateb, datee, yyb, yye, seqb, seqe, snob, snoe, empb, empe, reporttype, typedata, saladr, _excelexport, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz38_report1.Show();
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

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

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

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
