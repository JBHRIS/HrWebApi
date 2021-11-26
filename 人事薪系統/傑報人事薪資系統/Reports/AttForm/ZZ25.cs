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
    public partial class ZZ25 : JBControls.JBForm
    {
        ZZ25_Report zz25_report;
        public ZZ25()
        {
            InitializeComponent();
        }

        private void ZZ25_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            job_b.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            job_e.DataSource = JBHR.Reports.ReportClass.GetJob(MainForm.COMPANY);
            job_e.SelectedIndex = job_e.Items.Count - 1;

            jobl_b.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            jobl_e.DataSource = JBHR.Reports.ReportClass.GetJobl(MainForm.COMPANY);
            //jobl_b.SelectedIndex = -1;
            jobl_e.SelectedIndex = jobl_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            string str_year = Convert.ToString(DateTime.Now.Year);
            date_b.Text = str_year + "/01/01";
            date_e.Text = str_year + "/12/31";
            date_n.Text = str_year + "/12/31";

            report_type.SelectedIndex = 0;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                if (zz25_report != null)
                {
                    zz25_report.Dispose();
                    zz25_report.Close();
                }

                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string jobb = (job_b.SelectedIndex == -1) ? "" : job_b.SelectedValue.ToString();
                string jobe = (job_e.SelectedIndex == -1) ? "" : job_e.SelectedValue.ToString();               
                string joblb = (jobl_b.SelectedIndex != -1) ? jobl_b.SelectedValue.ToString() : "";
                string joble = (jobl_e.SelectedIndex == -1) ? "" : jobl_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string salarb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string salare = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string daten = date_n.Text;
                string _reporttype = report_type.SelectedIndex.ToString();
                string _date = Convert.ToString((Convert.ToDateTime(date_b.Text)).Year) + "/01/01";
                bool _exportexcel = ExportExcel.Checked;
                string datetype = ""; string inout = "";
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");

                if (type_data2.Checked) typedata += " AND B.DI='I'  AND A.COUNT_MA=0";
                if (type_data3.Checked) typedata += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked) typedata += " AND A.COUNT_MA=1";
                if (!in_out.Checked) inout = " and b.ttscode in ('1','4','6')";
                if (date_type1.Checked) datetype = "1";
                if (date_type2.Checked) datetype = "2";
                string _username = MainForm.USER_NAME;                

                zz25_report = new ZZ25_Report(nobrb, nobre, deptb, depte, jobb, jobe, joblb, joble, workb, worke, compb, compe, salarb, salare, dateb, datee, daten, _reporttype, _date, typedata, inout, _exportexcel, datetype, _username,MainForm.COMPANY_NAME);
                zz25_report.Show();
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
