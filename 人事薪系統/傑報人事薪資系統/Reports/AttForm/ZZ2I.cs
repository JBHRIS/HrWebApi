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
    public partial class ZZ2I : JBControls.JBForm
    {
        ZZ2I_Report zz2i_report;
        public ZZ2I()
        {
            InitializeComponent();
        }

        private void ZZ2I_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            date_b.Text = DateTime.Parse(Convert.ToString(DateTime.Now.Year) + "/01/01").ToString("yyyy/MM/dd");
            date_e.Text = DateTime.Now.ToString("yyyyMMdd");

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;
            report_type.SelectedIndex = 0;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (nobr_b.Text.Trim() == "")
                {
                    nobr_b.Focus();
                    return;
                }
                if (nobr_e.Text.Trim() == "")
                {
                    nobr_e.Focus();
                    return;
                }

                DateTime dt;
                if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                {
                    date_b.Focus();
                    return;
                }
                if (DateTime.TryParseExact(date_e.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                {
                    date_e.Focus();
                    return;
                }

                if (zz2i_report != null)
                {
                    zz2i_report.Dispose();
                    zz2i_report.Close();
                }
                string _nobrb = nobr_b.Text;
                string _nobre = nobr_e.Text;
                string _deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string _depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string _dateb = date_b.Text;
                string _datee = date_e.Text;
                bool _exportexcel = ExportExcel.Checked;
                string data_report = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string reporttype = report_type.SelectedIndex.ToString();

                zz2i_report = new ZZ2I_Report(_nobrb, _nobre, _deptb, _depte, _dateb, _datee, _exportexcel, data_report,reporttype,MainForm.COMPANY_NAME);
                zz2i_report.Show();
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
