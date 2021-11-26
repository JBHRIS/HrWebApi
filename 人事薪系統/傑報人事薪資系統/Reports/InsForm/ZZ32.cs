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
    public partial class ZZ32 : JBControls.JBForm
    {
        ZZ32_Report zz32_report;
        public ZZ32()
        {
            InitializeComponent();
        }

        private void ZZ32_Load(object sender, EventArgs e)
        {
            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
            date_e.Text = DateTime.Now.ToString("yyyy/MM/dd");
            date_t.Text = DateTime.Now.ToString("yyyy/MM/dd");
            report_type.SelectedIndex = 0;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {               
                if (zz32_report != null)
                {
                    zz32_report.Dispose();
                    zz32_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string datet = date_t.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
               
                zz32_report = new ZZ32_Report(dateb, datee, datet, reporttype, workadr,MainForm.COMPANY_NAME,MainForm.COMPANY);
                zz32_report.Show();
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
