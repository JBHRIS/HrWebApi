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
    public partial class ZZ2D : JBControls.JBForm
    {
        ZZ2D_Report zz2d_report;
        public ZZ2D()
        {
            InitializeComponent();
        }

        private void ZZ2D_Load(object sender, EventArgs e)
        {
            bASETableAdapter.Fill(salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz2d_report != null)
                {
                    zz2d_report.Dispose();
                    zz2d_report.Close();
                }

                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();

                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string dateb = date_e.Text;
                string yymmb = Convert.ToString(DateTime.Parse(date_b.Text).Year) + Convert.ToString(DateTime.Parse(date_b.Text).Month).PadLeft(2, '0');
                string yymme = Convert.ToString(DateTime.Parse(date_e.Text).Year) + Convert.ToString(DateTime.Parse(date_e.Text).Month).PadLeft(2, '0');
                bool _exportexcel = ExportExcel.Checked;
                string data_report = " AND " + Sal.Function.GetFilterCmdByNobr("b.nobr");
                
                zz2d_report = new ZZ2D_Report(nobrb, nobre, deptb, depte, compb, compe, dateb, yymmb, yymme, _exportexcel, data_report,MainForm.COMPANY_NAME);
                zz2d_report.Show();
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
