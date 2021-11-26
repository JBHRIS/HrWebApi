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
    public partial class ZZ31A : JBControls.JBForm
    {
        ZZ31A_Report zz31a_report;
        public ZZ31A()
        {
            InitializeComponent();
        }

        private void ZZ31A_Load(object sender, EventArgs e)
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

            sno_b.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.SelectedIndex = sno_e.Items.Count - 1;

            year_b.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            //date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));

            report_type.SelectedIndex = 0;
            
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            if (zz31a_report != null)
            {
                zz31a_report.Dispose();
                zz31a_report.Close();
            }
            string nobrb = nobr_b.Text;
            string nobre = nobr_e.Text;
            string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
            string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
            string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
            string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
            string yearb = year_b.Text;
            string monthb = month_b.Text;
            string snob = (sno_b.SelectedIndex == -1) ? "" : sno_b.SelectedValue.ToString();
            string snoe = (sno_e.SelectedIndex == -1) ? "" : sno_e.SelectedValue.ToString();            
            string reporttype = report_type.SelectedIndex.ToString();
            string typedata = "";
            if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
            if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
            if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";
            if (!MainForm.MANGSUPER) typedata += " and b.saladr='" + MainForm.WORKADR + "'";
            bool _excelexport = ExportExcel.Checked;
            zz31a_report = new ZZ31A_Report(nobrb, nobre, deptb, depte, yearb, monthb, snob, snoe, empb, empe, reporttype, typedata,note.Text, _excelexport);
            zz31a_report.Show();
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
