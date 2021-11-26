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
    public partial class ZZ4X : JBControls.JBForm
    {
        ZZ4X_Report zz4x_report;
        public ZZ4X()
        {
            InitializeComponent();
        }

        private void ZZ4X_Load(object sender, EventArgs e)
        {
            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();

            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;
            date_b.Text = DateTime.Now.ToString("yyyyMMdd").PadLeft(8, '0');
            ttstype.SelectedIndex = 0;            
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string data_report = "";
                string dateb = date_b.Text;
                if (type_data2.Checked)
                    data_report = " AND B.DI='I'  AND A.COUNT_MA=0 ";
                else if (type_data3.Checked)
                    data_report = " AND B.DI='D'  AND A.COUNT_MA=0";
                else if (type_data4.Checked)
                    data_report = " AND A.COUNT_MA=1 ";
                else if (type_data5.Checked)
                    data_report = " AND A.COUNT_MA=0 ";
                if (!MainForm.MANGSUPER)
                    data_report += " AND B.SALADR='" + MainForm.WORKADR + "'";
                

                zz4x_report = new ZZ4X_Report(empb, empe, dateb, ttstype.SelectedIndex.ToString(), data_report,ExportExcel.Checked);
                zz4x_report.Show();
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
