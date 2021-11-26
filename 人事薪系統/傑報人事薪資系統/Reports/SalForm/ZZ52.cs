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
    public partial class ZZ52 : JBControls.JBForm
    {
        ZZ52_Report zz52_report;
        public ZZ52()
        {
            InitializeComponent();
        }

        private void ZZ52_Load(object sender, EventArgs e)
        {
            //year.Text = Convert.ToString(DateTime.Now.Year-1);
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;
            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.SelectedIndex = dept_e.Items.Count - 1;

            format_b.DataSource = JBHR.Reports.ReportClass.GetYRFormat();
            format_e.DataSource = JBHR.Reports.ReportClass.GetYRFormat();
            format_e.SelectedIndex = format_e.Items.Count - 1;

            tcode_b.DataSource = JBHR.Reports.ReportClass.GetTcode();
            tcode_e.DataSource = JBHR.Reports.ReportClass.GetTcode();
            tcode_e.SelectedIndex = tcode_e.Items.Count - 1;

            reporttype.SelectedIndex = 0;

        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {               
                if (zz52_report != null)
                {
                    zz52_report.Dispose();
                    zz52_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                //string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                //string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();

                string yearb = year_b.Text;
                string yeare = year_e.Text;

                string monthb = month_b.Text;
                string monthe = month_e.Text;

                string seqb = seq_b.Text;
                string seqe = seq_e.Text;

                string formatb = (format_b.SelectedIndex == -1) ? "" : format_b.SelectedValue.ToString(); 
                string formate = (format_e.SelectedIndex == -1) ? "" : format_e.SelectedValue.ToString();

                string tcodeb = (tcode_b.SelectedIndex == -1) ? "" : tcode_b.SelectedValue.ToString();
                string tcodee = (tcode_e.SelectedIndex == -1) ? "" : tcode_e.SelectedValue.ToString();

                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("c.saladr");

                string order_type = "";

                string report_type = reporttype.SelectedIndex.ToString();

                zz52_report = new ZZ52_Report(nobrb, nobre
                    //, deptb, depte
                    , yearb, yeare
                    , monthb, monthe
                    , seqb, seqe
                    , formatb, formate
                    , tcodeb, tcodee
                    , typedata, order_type, report_type
                    , MainForm.USER_NAME, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz52_report.Show();
                
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
