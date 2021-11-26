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
    public partial class ZZ64 : JBControls.JBForm
    {
        ZZ64_Report zz64_report;
        public ZZ64()
        {
            InitializeComponent();
        }

        private void ZZ64_Load(object sender, EventArgs e)
        {
            nobr_b.Text = JBHR.Reports.ReportClass.GetNobrMin().Rows[0][0].ToString();
            nobr_e.Text = JBHR.Reports.ReportClass.GetNobrMax().Rows[0][0].ToString();

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz64_report != null)
                {
                    zz64_report.Dispose();
                    zz64_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string _year = year.Text;
                string _month = month.Text;              
                string dateb = date_b.Text;                
                string _username = MainForm.USER_NAME;
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                zz64_report = new ZZ64_Report(nobrb, nobre, deptb, depte, _year, _month, dateb, _username, workadr, MainForm.COMPANY);
                zz64_report.Show();
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
