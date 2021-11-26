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
    public partial class ZZ17 : JBControls.JBForm
    {
        ZZ17_Report zz17_report;
        public ZZ17()
        {
            InitializeComponent();
        }

        private void ZZ17_Load(object sender, EventArgs e)
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

            report_type.SelectedIndex = 0;
            sextype.SelectedIndex = 0;
            date_b.Text = DateTime.Now.ToString("yyyyMMdd");

            grp1_1.Text = "0";
            grp1_2.Text = "20";
            grp2_1.Text = "20";
            grp2_2.Text = "25";
            grp3_1.Text = "25";
            grp3_2.Text = "30";
            grp4_1.Text = "30";
            grp4_2.Text = "35";
            grp5_1.Text = "35";
            grp5_2.Text = "40";
            grp6_1.Text = "40";
            grp6_2.Text = "45";
            grp7_1.Text = "45";
            grp7_2.Text = "50";
            grp8_1.Text = "50";
            grp8_2.Text = "55";
            grp9_1.Text = "55";
            grp9_2.Text = "60";
            grp10_1.Text = "60";
            grp10_2.Text = "99";          
        }        

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz17_report != null)
                {
                    zz17_report.Dispose();
                    zz17_report.Close();
                }

                string dateb = date_b.Text;
                string _sextype = sextype.SelectedIndex.ToString();
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
                string grp91 = grp9_1.Text;
                string grp92 = grp9_2.Text;
                string grp101 = grp10_1.Text;
                string grp102 = grp10_2.Text;
                bool _exportexcel = ExportExcel.Checked;
                string str_field = ""; string str_sex = "";
                if (reporttype == "0")
                    str_field = "編制部門";
                else if (reporttype == "1")
                    str_field = "職稱年齡";
                else if (reporttype == "2")
                    str_field = "成本部門";
                else if (reporttype == "3")
                    str_field = "職稱與成本";

                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");   
                if (type_data2.Checked)
                    type_data += " AND B.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked)
                    type_data += " AND B.DI='D'  AND A.COUNT_MA=0";

                if (type_data4.Checked)
                    type_data += " AND A.COUNT_MA=1 ";
                
                if (_sextype == "1")
                    str_sex = "AND A.SEX='M' ";
                if (_sextype == "2")
                    str_sex = "AND A.SEX='F' ";
                string _username = MainForm.USER_NAME;                
                zz17_report = new ZZ17_Report(dateb, deptb, depte, empb, empe, compb, compe, reporttype, grp11, grp12, grp21, grp22, grp31, grp32, grp41, grp42, grp51, grp52, grp61, grp62, grp71, grp72, grp81, grp82, grp91, grp92, grp101, grp102, type_data, str_sex, str_field, _exportexcel, _sextype, _username,MainForm.COMPANY_NAME);
                zz17_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
        }

        private void LeaveFrom_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}
