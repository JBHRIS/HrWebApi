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
    public partial class ZZ35 : JBControls.JBForm
    {
        ZZ35_Report zz35_report;
        public ZZ35()
        {
            InitializeComponent();
        }

        private void ZZ35_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_b.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            report_type.SelectedIndex = 0;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz35_report != null)
                {
                    zz35_report.Dispose();
                    zz35_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string yearb = year_b.Text;
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                string saladr = " AND " + Sal.Function.GetFilterCmdByDataGroup("a.saladr");
                string depttype = ""; string typedata = string.Empty;
                if (type_data2.Checked) typedata += " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata += " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata += " AND A.COUNT_MA=1 ";
                if (type_data5.Checked) typedata += " AND A.COUNT_MA=0 ";
                if (dept_type2.Checked) depttype = " and b.ttscode in ('1','4','6')";
                if (dept_type3.Checked) depttype = " and b.ttscode in ('2','3','5')";
                
                bool _excelexport = ExportExcel.Checked;
                zz35_report = new ZZ35_Report(nobrb, nobre, deptb, depte, compb, compe, yearb, depttype, reporttype, typedata, saladr, _excelexport, MainForm.COMPANY_NAME);
                zz35_report.Show();
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

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_type.SelectedIndex == 0)
                ExportExcel.Enabled = true;
            else
            {
                ExportExcel.Enabled = false;
                ExportExcel.Checked = false;
            }
        }
    }
}
