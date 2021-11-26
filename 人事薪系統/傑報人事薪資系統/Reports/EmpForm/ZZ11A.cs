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
    public partial class ZZ11A : JBControls.JBForm
    {
        ZZ11A_Report zz11a_report;
        public ZZ11A()
        {
            InitializeComponent();
        }

        private void ZZ11A_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            date_b.Text = ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            report_type.SelectedIndex = 0;
            
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empcdb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empcde = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                string _username = MainForm.USER_NAME;
                bool _exportexcel = ExportExcel.Checked;
                string data_report = "";
                if (type_data1.Checked)
                    data_report = "";
                if (type_data2.Checked)
                    data_report = " AND B.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked)
                    data_report = " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked)
                    data_report = " AND A.COUNT_MA=1 ";
                if (!MainForm.MANGSUPER)
                    data_report += " AND B.SALADR='" + MainForm.WORKADR + "'";
                zz11a_report = new ZZ11A_Report(dateb, datee, nobrb, nobre, deptb, depte, empcdb, empcde, reporttype, data_report, _username, _exportexcel);
                zz11a_report.Show();
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
