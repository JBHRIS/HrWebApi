/* ======================================================================================================
 * 功能名稱：補充保費明細表
 * 功能代號：ZZ411A
 * 功能路徑：報表列印 > 薪資 > 補充保費明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ411A.cs
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
    public partial class ZZ411A : JBControls.JBForm
    {
        ZZ411A_Report zz411a_report;
        public ZZ411A()
        {
            InitializeComponent();
        }

        private void ZZ411A_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            //sno_b.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            //sno_e.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(sno_b, ReportClass.SourceConvert(ReportClass.GetInscomp(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(sno_e, ReportClass.SourceConvert(ReportClass.GetInscomp(MainForm.COMPANY)), false, true, true);
            sno_b.SelectedIndex = -1;
            sno_e.SelectedIndex = sno_e.Items.Count - 1;

            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            //month_b.Text = "01";
            //seq_b.Text = "2";

            //year_e.Text = Convert.ToString(DateTime.Now.Year);
            //month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //seq_e.Text = "Z";
            datet_b.Text = DateTime.Now.ToString("yyyy/01/01");
            datet_e.Text = DateTime.Now.ToString("yyyy/12/31");
           
        }

        private void year_b_Validated(object sender, EventArgs e)
        {
            datet_b.Text = year_b.Text + "/01/01";
            datet_e.Text = year_b.Text + "/12/31";
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz411a_report != null)
                {
                    zz411a_report.Dispose();
                    zz411a_report.Close();
                }               
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = dept_b.SelectedValue.ToString();
                string depte = dept_e.SelectedValue.ToString();
                string snob = (sno_b.SelectedIndex == -1) ? "" : sno_b.SelectedValue.ToString();
                string snoe = (sno_e.SelectedIndex == -1) ? "" : sno_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                //string dateb = "";
                //dateb = JBHR.Reports.ReportClass.GetSalEDate(year_e.Text, month_e.Text);
                string yyb = year_b.Text;
                string datetb = datet_b.Text;
                string datete = datet_e.Text;
                //string yye = year_e.Text;
                //string monb = month_b.Text;
                //string mone = month_e.Text;
                //string seqb = seq_b.Text;
                //string seqe = seq_e.Text;
                string type_data="";
                if (type_data2.Checked) type_data = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) type_data = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) type_data = " AND A.COUNT_MA=1 ";
                if (!MainForm.MANGSUPER) type_data += " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
               
                bool _excelexport = ExportExcel.Checked;
                zz411a_report = new ZZ411A_Report(nobrb, nobre, datetb, datete, deptb, depte, snob, snoe, empb, empe, yyb, type_data, _excelexport, MainForm.COMPANY);
                zz411a_report.Show();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
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
