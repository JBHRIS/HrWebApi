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
    public partial class ZZ15 : JBControls.JBForm
    {
        ZZ15_Report zz15_report;
        ZZ151_Report zz151_report;
        ZZ152_Report zz152_report;
        ZZ153_Report zz153_report;
        public ZZ15()
        {
            InitializeComponent();
        }

        private void ZZ15_Load(object sender, EventArgs e)
        {
            report_type.SelectedIndex = 0;
            date_b.Text = DateTime.Now.ToString("yyyyMMdd");
            date_e.Text = DateTime.Now.ToString("yyyyMMdd");

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            outcode.DataSource = JBHR.Reports.ReportClass.GetOutcd();
            outcode.SelectedIndex = -1;
            out_day.Text = "30";
        }

        private void dept_type1_Click(object sender, EventArgs e)
        {
            dept_b.Enabled = true;
            dept_e.Enabled = true;
            depts_b.Enabled = false;
            depts_e.Enabled = false;
        }

        private void dept_type2_Click(object sender, EventArgs e)
        {
            dept_b.Enabled = false;
            dept_e.Enabled = false;
            depts_b.Enabled = true;
            depts_e.Enabled = true;
        }

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (report_type.SelectedIndex>0)
            {
                dept_type1.Checked = true;
                dept_b.Enabled = true;
                dept_e.Enabled = true;
                depts_b.Enabled = false;
                depts_e.Enabled = false;
            }
        }
       
        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt;
                //if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_b.Focus();
                //    return;
                //}
                //if (DateTime.TryParseExact(date_e.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
                //{
                //    date_e.Focus();
                //    return;
                //}
                //if (out_day.Text.Trim() == "")
                //{                    
                //    out_day.Focus();
                //    return;
                //}
                if (zz15_report != null)
                {
                    zz15_report.Dispose();
                    zz15_report.Close();
                }
                else if (zz151_report != null)
                {
                    zz151_report.Dispose();
                    zz151_report.Close();
                }
                else if (zz152_report != null)
                {
                    zz152_report.Dispose();
                    zz152_report.Close();
                }
                else if (zz153_report != null)
                {
                    zz153_report.Dispose();
                    zz153_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string _outcode = (outcode.SelectedIndex != -1) ? outcode.SelectedValue.ToString() : "";
                decimal outday = decimal.Parse(out_day.Text);
                string depttype = string.Empty;
                if (dept_type1.Checked) depttype = "1";
                if (dept_type2.Checked) depttype = "2";
                bool _exportexcel = ExportExcel.Checked;
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("a.saladr");
                string typedata1 = "";
                if (type_data2.Checked)  //間接
                {
                    typedata += " AND A.DI='I'  AND B.COUNT_MA=0 ";
                    typedata1 += " AND A.DI='I'  AND B.COUNT_MA=0 ";
                }
                else if (type_data3.Checked) //直接
                {
                    typedata += " AND A.DI='D'  AND B.COUNT_MA=0";
                    typedata1 += " AND A.DI='D'  AND B.COUNT_MA=0";
                }
                else if (type_data4.Checked)
                {
                    typedata += " AND B.COUNT_MA=1 ";
                    typedata1 += " AND B.COUNT_MA=1 ";
                }
                string _username = MainForm.USER_NAME;
                if (report_type.SelectedIndex.ToString() == "0")
                {
                    if (depttype == "2")
                    {
                        deptb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                        depte = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                    }
                    zz15_report = new ZZ15_Report(dateb, datee, deptb, depte, empb, empe, compb, compe, _outcode,depttype, outday, _exportexcel, typedata, typedata1, _username, MainForm.COMPANY_NAME);
                    zz15_report.Show();
                }
                else if (report_type.SelectedIndex.ToString() == "1")
                {
                    zz151_report = new ZZ151_Report(dateb, datee, deptb, depte, empb, empe, compb, compe, _outcode, outday, _exportexcel, typedata, _username, MainForm.COMPANY_NAME);
                    zz151_report.Show();
                }
                else if (report_type.SelectedIndex.ToString() == "2")
                {
                    zz152_report = new ZZ152_Report(dateb, datee, deptb, depte, empb, empe, compb, compe, _outcode, outday, _exportexcel, typedata, typedata1, _username, MainForm.COMPANY_NAME);
                    zz152_report.Show();
                }
                else if (report_type.SelectedIndex.ToString() == "3")
                {
                    zz153_report = new ZZ153_Report(dateb, datee, deptb, depte, empb, empe, compb, compe, _outcode, outday, _exportexcel, typedata, _username, MainForm.COMPANY_NAME);
                    zz153_report.Show();
                }
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
