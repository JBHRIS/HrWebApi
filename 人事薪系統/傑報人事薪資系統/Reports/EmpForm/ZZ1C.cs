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
    public partial class ZZ1C : JBControls.JBForm
    {
        ZZ1C_Report zz1c_report;
        public ZZ1C()
        {
            InitializeComponent();
        }

        private void ZZ1C_Load(object sender, EventArgs e)
        {
            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            edu_b.DataSource = JBHR.Reports.ReportClass.GetEducode();
            edu_e.DataSource = JBHR.Reports.ReportClass.GetEducode();            
            edu_e.SelectedIndex = edu_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            { 

                if (zz1c_report != null)
                {
                    zz1c_report.Dispose();
                    zz1c_report.Close();
                }
                string dateb = date_b.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string edub = (edu_b.SelectedIndex != -1) ? edu_b.SelectedValue.ToString() : "";
                string edue = (edu_e.SelectedIndex == -1) ? "" : edu_e.SelectedValue.ToString();
                string datet = DateTime.Now.ToString("yyyy/MM/dd");
                bool _exportexcel = ExportExcel.Checked;
                string datareport = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string onlyschl = ""; string reporttype = "";
               
                if (type_data2.Checked)
                    datareport += " AND B.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked)
                    datareport += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked)
                    datareport += " AND A.COUNT_MA=1 ";

                if (only_schl.Checked)
                    onlyschl = " AND  C.NOBR+STR(G.SORT ) IN (SELECT E.NOBR+MAX(STR(F.SORT)) FROM SCHL E,EDUCODE F WHERE E.EDUCCODE=F.CODE AND E.EDUCCODE BETWEEN '" + edub + "' AND '" + edue + "' GROUP BY NOBR)";
                else
                {
                    //only_schl = " AND C.EDUCCODE BETWEEN '" + edu_b + "' AND '" + edu_e + "' AND C.OK=1 ";
                    onlyschl = " AND C.EDUCCODE BETWEEN '" + edub + "' AND '" + edue + "'";
                }

                if (report_type1.Checked)
                    reporttype = "1";
                if (report_type2.Checked)
                    reporttype = "2";
                string _username = MainForm.USER_NAME;
                zz1c_report = new ZZ1C_Report(dateb, nobrb, nobre, deptb, depte, empb, empe, compb, compe, edub, edue, datet, onlyschl, reporttype, datareport, _exportexcel, _username,MainForm.COMPANY_NAME);
                zz1c_report.Show();
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
