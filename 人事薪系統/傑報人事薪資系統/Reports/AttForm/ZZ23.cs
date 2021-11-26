/* ======================================================================================================
 * 功能名稱：請假報表
 * 功能代號：ZZ23
 * 功能路徑：報表列印 > 出勤 > 請假報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ23.cs
 * 功能用途：
 *  用於請假報表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/07/08    Daniel Chih    Ver 1.0.01     1. 【異動種類】篩選條件預設選【在職】
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/07/08
 */

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
    public partial class ZZ23 : JBControls.JBForm
    {
        ZZ23_Report zz23_report; ZZ23_Report1 zz23_report1;
        public ZZ23()
        {
            InitializeComponent();
        }

        private void ZZ23_Load(object sender, EventArgs e)
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

            h_codeb.DataSource = JBHR.Reports.ReportClass.GetHcode(MainForm.COMPANY);
            h_codee.DataSource = JBHR.Reports.ReportClass.GetHcode(MainForm.COMPANY);
            //h_codeb.SelectedIndex = -1;
            h_codee.SelectedIndex = h_codee.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            report_type.SelectedIndex = 0;
            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            ttstype.SelectedIndex = 1;
        }

        private void date_type1_Click(object sender, EventArgs e)
        {
            date_b.Enabled = false;
            date_e.Enabled = false;
            yymm_b.Enabled = true;
            yymm_e.Enabled = true;
            month_b.Enabled = true;
            month_e.Enabled = true;
        }

        private void date_type2_Click(object sender, EventArgs e)
        {
            date_b.Enabled = true;
            date_e.Enabled = true;
            yymm_b.Enabled = false;
            yymm_e.Enabled = false;
            month_b.Enabled = false;
            month_e.Enabled = false;
        }

        private void yymm_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
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
                month_b.Text = month_b.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void yymm_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_e_Validated(object sender, EventArgs e)
        {
            try
            {
                month_e.Text = month_e.Text.PadLeft(2, '0');

                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
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
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string hcodeb = (h_codeb.SelectedIndex != -1) ? h_codeb.SelectedValue.ToString() : "";
                string hcodee = (h_codee.SelectedIndex == -1) ? "" : h_codee.SelectedValue.ToString();
                string salarb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string salare = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string yymmb = yymm_b.Text + month_b.Text;
                string yymme = yymm_e.Text + month_e.Text;
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string _reporttype = report_type.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string checkrote = ""; string _lcstr = "";
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked) typedata += " AND B.DI='I'  AND A.COUNT_MA=0";
                if (type_data3.Checked) typedata += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked) typedata += " AND A.COUNT_MA=1";
                if (ttstype.SelectedIndex == 1) typedata += " AND B.TTSCODE IN ('1','4','6')";
                if (ttstype.SelectedIndex == 2) typedata += " AND B.TTSCODE IN ('2','3','5')";
                if (date_type1.Checked) _lcstr = " and a.yymm between '" + yymmb + "' and '" + yymme + "'";
                if (date_type2.Checked) _lcstr = " and a.bdate between '" + dateb + "' and '" + datee + "'";
                string _username = MainForm.USER_NAME;
               
                if (_reporttype == "6")
                {
                    if (zz23_report1 != null)
                    {
                        zz23_report1.Dispose();
                        zz23_report1.Close();
                    }

                    zz23_report1 = new ZZ23_Report1(nobrb, nobre, deptb, depte, compb, compe, hcodeb, hcodee, salarb, salare, yymmb, yymme, dateb, datee, checkrote, typedata, _lcstr, _reporttype, _exportexcel, _username,MainForm.COMPANY_NAME);
                    zz23_report1.Show();
                }
                else
                {
                    if (zz23_report != null)
                    {
                        zz23_report.Dispose();
                        zz23_report.Close();
                    }

                    zz23_report = new ZZ23_Report(nobrb, nobre, deptb, depte, compb, compe, hcodeb, hcodee, salarb, salare, yymmb, yymme, dateb, datee, checkrote, typedata, _lcstr, _reporttype, _exportexcel, _username, MainForm.COMPANY_NAME);
                    zz23_report.Show();
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
