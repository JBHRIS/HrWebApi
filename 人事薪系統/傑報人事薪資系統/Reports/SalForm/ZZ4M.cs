/* ======================================================================================================
 * 功能名稱：扣繳稅額繳款書
 * 功能代號：ZZ4M
 * 功能路徑：報表列印 > 薪資 > 扣繳稅額繳款書
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4M.cs
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
    public partial class ZZ4M : JBControls.JBForm
    {
        ZZ4M_Report zz4m_report;
        public ZZ4M()
        {
            InitializeComponent();
        }

        private void ZZ4M_Load(object sender, EventArgs e)
        {
            //comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            //comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(comp_b, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(comp_e, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;           

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            year_e.Text = Convert.ToString(DateTime.Now.Year);
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "2";
            seq_e.Text = "9";
            //date_b.Text = Convert.ToDateTime(JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text)).AddMonths(1).ToString("yyyy/MM/dd");
            date_b.Text=Convert.ToDateTime(year_b.Text+"/"+month_b.Text+"/01").AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd");

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

            datet_b.Text = Convert.ToDateTime(year_b.Text + "/" + month_b.Text + "/01").ToString("yyyy/MM/dd");
            //datet_e.Text = Convert.ToDateTime(year_e.Text + "/" + month_e.Text + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            datet_e.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);

            //date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate1(year_b.Text + month_b.Text,seq_b.Text, seq_e.Text);
        }

        private void seq_b_Validated(object sender, EventArgs e)
        {
            //date_t.SelectedIndex = -1;
            //date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate1(year_b.Text + month_b.Text, seq_b.Text, seq_e.Text);
        }

        private void seq_e_Validated(object sender, EventArgs e)
        {
            //date_t.SelectedIndex = -1;
            //date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate1(year_b.Text + month_b.Text, seq_b.Text, seq_e.Text);
        }

        
        private void year_b_Validated(object sender, EventArgs e)
        {
            try
            {
                //date_t.SelectedIndex = -1;
                //date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate1(year_b.Text + month_b.Text, seq_b.Text, seq_e.Text);
                //date_b.Text = Convert.ToDateTime(JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text)).AddMonths(1).ToString("yyyy/MM/dd");
                date_b.Text = Convert.ToDateTime(year_b.Text + "/" + month_b.Text + "/01").AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd");
                month_b.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

                //date_t.SelectedIndex = -1;
                //date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate1(year_b.Text + month_b.Text, seq_b.Text, seq_e.Text);
                //date_b.Text =Convert.ToDateTime( JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text)).AddMonths(1).ToString("yyyy/MM/dd");
                date_b.Text = Convert.ToDateTime(year_b.Text + "/" + month_b.Text + "/01").AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd");
                year_e.Focus();
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

                datet_e.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void year_e_Validated(object sender, EventArgs e)
        {
            try
            {

                datet_e.Text = JBHR.Reports.ReportClass.GetSalEDate1(year_e.Text, month_e.Text);
                month_e.Focus();
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
                if (zz4m_report != null)
                {
                    zz4m_report.Dispose();
                    zz4m_report.Close();
                }
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = JBHR.Reports.ReportClass.GetSalEDate(year_b.Text, month_b.Text);
                string datetb = datet_b.Text;
                string datete = datet_e.Text;
                string yyb = year_b.Text;
                string monb = month_b.Text;
                string yye = year_e.Text;
                string mone = month_e.Text;
                string seqb = seq_b.Text;
                string seqe = seq_e.Text;
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string workadr = "";
                if (!MainForm.MANGSUPER) workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                bool _excelexport = ExportExcel.Checked;
                zz4m_report = new ZZ4M_Report(nobrb, nobre, deptb, depte, dateb, datee, datetb, datete, yyb,yye, monb,mone, seqb, seqe, compb, compe, empb, empe, workadr, MainForm.COMPANY_NAME, _excelexport, MainForm.COMPANY);
                zz4m_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void bnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
