using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ13 : JBControls.JBForm
    {
        ZZ13_Report zz13_report;
        public ZZ13()
        {
            InitializeComponent();
        }

        private void ZZ13_Load(object sender, EventArgs e)
        {
            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            date_e.Text = DateTime.Now.ToString("yyyyMMdd");
            date_b.Text = DateTime.Now.ToString("yyyyMMdd");    
            report_type.SelectedIndex = 0;

            date_e.Enabled = false;

            grp1_1.Text = "0";
            grp1_2.Text = "1";
            grp2_1.Text = "1";
            grp2_2.Text = "3";
            grp3_1.Text = "3";
            grp3_2.Text = "5";
            grp4_1.Text = "5";
            grp4_2.Text = "10";
            grp5_1.Text = "10";
            grp5_2.Text = "15";
            grp6_1.Text = "15";
            grp6_2.Text = "20";
            grp7_1.Text = "20";
            grp7_2.Text = "25";
            grp8_1.Text = "25";
            grp8_2.Text = "50";
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz13_report != null)
                {
                    zz13_report.Dispose();
                    zz13_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string reporttype = report_type.SelectedIndex.ToString();
                string grp11 = grp1_1.Text;
                string grp12 = grp1_2.Text;
                string grp21 = grp2_1.Text;
                string grp22 = grp2_2.Text;
                string grp31 = grp3_1.Text;
                string grp32 = grp3_2.Text;
                string grp41 = grp4_1.Text;
                string grp42 = grp4_2.Text;
                string grp51 = grp5_1.Text;
                string grp52 = grp5_2.Text;
                string grp61 = grp6_1.Text;
                string grp62 = grp6_2.Text;
                string grp71 = grp7_1.Text;
                string grp72 = grp7_2.Text;
                string grp81 = grp8_1.Text;
                string grp82 = grp8_2.Text;
                string datet = DateTime.Now.ToShortDateString();
                bool _exportexcel = ExportExcel.Checked;
                string data_report =  " AND " + Sal.Function.GetFilterCmdByDataGroup("c.saladr"); 
               
                string _username = MainForm.USER_NAME;
                zz13_report = new ZZ13_Report(dateb, datee, deptb, depte, empb, empe, compb, compe, reporttype,MainForm.COMPANY_NAME, datet, grp11, grp12, grp21, grp22, grp31, grp32, grp41, grp42, grp51, grp52, grp61, grp62, grp71, grp72, grp81, grp82, data_report, _exportexcel);
                zz13_report.Show();
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void Leave_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        
    }
}
