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
    public partial class ZZ41A : JBControls.JBForm
    {
        ZZ41A_Report zz41a_report;
        public ZZ41A()
        {
            InitializeComponent();
        }

        private void ZZ41A_Load(object sender, EventArgs e)
        {
            bASETableAdapter.Fill(salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            date_b.Text = ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            ttstype.SelectedIndex = 0;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            if (zz41a_report != null)
            {
                zz41a_report.Dispose();
                zz41a_report.Close();
            }
            string nobrb = nobr_b.Text;
            string nobre = nobr_e.Text;
            string deptb = dept_b.SelectedValue.ToString();
            string depte = dept_e.SelectedValue.ToString();
            string empb = empcd_b.SelectedValue.ToString();
            string empe = empcd_e.SelectedValue.ToString();
            string dateb = date_b.Text;
            string datee = date_e.Text;
            string _ttstype = ttstype.SelectedIndex.ToString();
            bool _exportexcel = ExportExcel.Checked;
            bool _floating = Floating.Checked;
            string type_data = "";
            if (type_data2.Checked) type_data = " AND B.DI='I'  AND A.COUNT_MA=0  ";
            if (type_data3.Checked) type_data = " AND B.DI='D'  AND A.COUNT_MA=0 ";
            if (type_data4.Checked) type_data = " AND A.COUNT_MA=1 ";
            if (type_data5.Checked) type_data = " AND A.COUNT_MA=0 ";
            if (!MainForm.MANGSUPER) type_data += " AND B.SALADR='" + MainForm.WORKADR + "'";
            zz41a_report = new ZZ41A_Report(nobrb, nobre, deptb, depte,empb,empe, dateb, datee, type_data,_ttstype, _exportexcel,_floating);
            zz41a_report.Show();
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
