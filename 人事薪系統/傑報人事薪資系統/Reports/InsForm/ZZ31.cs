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
    public partial class ZZ31 : JBControls.JBForm
    {
        ZZ31_Report zz31_report;
        public ZZ31()
        {
            InitializeComponent();
        }

        private void ZZ31_Load(object sender, EventArgs e)
        {
            insure_type.SelectedIndex = 3;
            report_type.SelectedIndex = 0;
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            sno_b.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.SelectedIndex = sno_e.Items.Count - 1;

        }        

        private void insure_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (insure_type.SelectedIndex == 3)
                date_b.Enabled = false;
            else
                date_b.Enabled = true;
            if (insure_type.SelectedIndex == 5)
                report_type.SelectedIndex = 4;
            if (report_type.SelectedIndex == 4 || report_type.SelectedIndex == 5)
                insure_type.SelectedIndex = 5;
            else
                report_type.SelectedIndex = 0;            
        }

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (report_type.SelectedIndex == 4 || report_type.SelectedIndex == 5)
                insure_type.SelectedIndex = 5;
            if (insure_type.SelectedIndex == 5 && !(report_type.SelectedIndex == 4 || report_type.SelectedIndex == 5))
                insure_type.SelectedIndex = 3;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz31_report != null)
                {
                    zz31_report.Dispose();
                    zz31_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string snob = (sno_b.SelectedIndex == -1) ? "" : sno_b.SelectedValue.ToString();
                string snoe = (sno_e.SelectedIndex == -1) ? "" : sno_e.SelectedValue.ToString();
                string insuretype =insure_type.SelectedIndex.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked) typedata += " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata += " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata += " AND A.COUNT_MA=1 ";
                
                string insuername = insure_type.Text;
                bool _excelexport = ExportExcel.Checked;
                bool _nocompexp = nocompexp.Checked;
                zz31_report = new ZZ31_Report(nobrb, nobre, deptb, depte, dateb, datee, snob, snoe, insuretype, reporttype, insuername, typedata, _excelexport,MainForm.COMPANY_NAME,MainForm.COMPANY,_nocompexp);
                zz31_report.Show();
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
