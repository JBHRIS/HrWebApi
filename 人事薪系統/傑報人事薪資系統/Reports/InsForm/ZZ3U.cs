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
    public partial class ZZ3U : JBControls.JBForm
    {
        ZZ3U_Report zz3u_report;
        public ZZ3U()
        {
            InitializeComponent();
        }

        private void ZZ3U_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;
            
            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text =Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
            report_type.SelectedIndex = 0;
        }

        private void yymm_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
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

                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_type.SelectedIndex == 1)
            {
                ExportExcel.Enabled = false;
                ExportExcel.Checked = true;
            }
            else
                ExportExcel.Enabled = true;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                if (zz3u_report != null)
                {
                    zz3u_report.Dispose();
                    zz3u_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string yyb = yymm_b.Text + month_b.Text;
                string yye = yymm_e.Text + month_e.Text;
                string typedata = "";
                string saladr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked) typedata += " and a.insur_type='1' ";
                if (type_data3.Checked) typedata += " and a.insur_type='2' ";
                if (type_data4.Checked) typedata += " and a.insur_type='4' ";
                
                string reporttype = report_type.SelectedIndex.ToString();
                bool _excelexport = ExportExcel.Checked;
                zz3u_report = new ZZ3U_Report(nobrb, nobre, deptb, depte, dateb, yyb, yye, typedata, saladr, reporttype, _excelexport, prn_tts.Checked,MainForm.COMPANY_NAME,MainForm.COMPANY);
                zz3u_report.Show();
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
    }
}
