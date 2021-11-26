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
    public partial class ZZ4X1 : JBControls.JBForm
    {
        ZZ4X1_Report zz4x1_report;
        public ZZ4X1()
        {
            InitializeComponent();
        }

        private void ZZ4X1_Load(object sender, EventArgs e)
        {
            bASETableAdapter.Fill(salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            year.Text = Convert.ToString(DateTime.Now.Year);

            int _mon = DateTime.Now.Month;
            date_b.Text = Convert.ToString(DateTime.Now.Year + 1) + "/03/31";
            date_e.Text = year.Text + "/03/31";
            date_t.Text = year.Text + "/12/31";
            
        }

        
        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz4x1_report != null)
                {
                    zz4x1_report.Dispose();
                    zz4x1_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptsb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string deptse = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string datet = date_t.Text;
                string _year = year.Text;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                bool _exportexcel = ExportExcel.Checked;
                if (type_data2.Checked) type_data += " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) type_data += " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) type_data += " AND A.COUNT_MA=1 ";
                if (type_data5.Checked) type_data += " AND A.COUNT_MA=0 ";
                
               
                zz4x1_report = new ZZ4X1_Report(deptsb, deptse, empb, empe, nobrb, nobre, dateb, datee, datet, _year, type_data, MainForm.USER_NAME, _exportexcel);
                zz4x1_report.Show();
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
