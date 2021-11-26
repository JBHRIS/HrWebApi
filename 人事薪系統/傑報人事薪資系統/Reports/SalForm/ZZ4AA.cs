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
    public partial class ZZ4AA : JBControls.JBForm
    {
        ZZ4AA_Report zz4aa_report;
        public ZZ4AA()
        {
            InitializeComponent();
        }

        private void ZZ4AA_Load(object sender, EventArgs e)
        {
            nobr_b.Text = JBHR.Reports.ReportClass.GetNobrMin().Rows[0][0].ToString();
            nobr_e.Text = JBHR.Reports.ReportClass.GetNobrMax().Rows[0][0].ToString();

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");           

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            report_type.SelectedIndex = 0;
            seq.Text = "2";
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            if (zz4aa_report != null)
            {
                zz4aa_report.Dispose();
                zz4aa_report.Close();
            }
            string nobrb = nobr_b.Text;
            string nobre = nobr_e.Text;
            string deptb = dept_b.SelectedValue.ToString();
            string depte = dept_e.SelectedValue.ToString();        
            string _year = year.Text;
            string _month = month.Text;
            string _seq = seq.Text;
            string dateb = date_b.Text;
            string type_data = ""; string workadr = "";
            string _username = MainForm.USER_NAME;
            bool _exportexcel = ExportExcel.Checked;
            if (type_data1.Checked) type_data = "1";
            if (type_data2.Checked) type_data = "2";
            if (type_data3.Checked) type_data = "3";
            if (type_data4.Checked) type_data = "4";
            if (type_data5.Checked) type_data = "5";
            string reporttype = report_type.SelectedIndex.ToString();
            if (!MainForm.MANGSUPER) workadr += " and b.saladr='" + MainForm.WORKADR + "'";
            zz4aa_report = new ZZ4AA_Report(nobrb, nobre, deptb, depte, _year, _month, _seq, dateb, type_data, _username, _exportexcel, reporttype);
            zz4aa_report.Show();
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
