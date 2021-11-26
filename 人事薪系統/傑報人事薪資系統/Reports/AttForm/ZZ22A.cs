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
    public partial class ZZ22A : JBControls.JBForm
    {
        ZZ22A_Report zz22a_report;
        public ZZ22A()
        {
            InitializeComponent();
        }

        private void ZZ22A_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
            date_e.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked) type_data += " AND B.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked) type_data += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked) type_data += " AND A.COUNT_MA=1 ";
                bool _exportexcel = ExportExcel.Checked;
                string _username = MainForm.USER_NAME;
                
                zz22a_report = new ZZ22A_Report(nobrb, nobre, empb, empe, deptb, depte, dateb, datee, type_data, _username, _exportexcel,MainForm.COMPANY_NAME);
                zz22a_report.Show();
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
