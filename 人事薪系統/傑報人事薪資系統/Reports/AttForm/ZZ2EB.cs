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
    public partial class ZZ2EB : JBControls.JBForm
    {
        ZZ2EB_Report zz2eb_report;
        public ZZ2EB()
        {
            InitializeComponent();
        }

        private void ZZ2EB_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            string y1 = Convert.ToString(DateTime.Now.Year);
            date_b.Text = y1 + "/01/01";
            date_e.Text = DateTime.Parse(date_b.Text).AddYears(4).AddDays(-1).ToString("yyyy/MM/dd");
            date_t.Text = DateTime.Parse(date_b.Text).AddYears(4).AddDays(-1).ToString("yyyy/MM/dd");
            report_type.SelectedIndex = 0;
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
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string datet = date_t.Text;
                bool _exportexcel = ExportExcel.Checked;
                string reporttype = report_type.SelectedIndex.ToString();
                string _w8 = "";
                string inout = "";
                if (!in_out.Checked)
                    inout = " and b.ttscode in ('1','4','6')";
                if (w8.Checked)
                    _w8 = " and a.nobr in (select distinct nobr from abs where bdate between '" + dateb + "' and '" + datee + "' and h_code='w8')";
                string data_report = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                
                zz2eb_report = new ZZ2EB_Report(nobrb, nobre, deptb, depte, workb, worke, compb, compe, dateb, datee, datet, inout, _exportexcel, reporttype, _w8, data_report, MainForm.COMPANY_NAME);
                zz2eb_report.Show();
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
