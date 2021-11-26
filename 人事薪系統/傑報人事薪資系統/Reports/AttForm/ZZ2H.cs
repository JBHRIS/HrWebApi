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
    public partial class ZZ2H : JBControls.JBForm
    {
        ZZ2H_Report zz2h_report; ZZ2H2_Report zz2h2_report; ZZ2H4_Report zz2h4_report; ZZ2H5_Report zz2h5_report;
        ZZ2H7_Report zz2h7_report; ZZ2H8_Report zz2h8_report;
        public ZZ2H()
        {
            InitializeComponent();
        }

        private void ZZ2H_Load(object sender, EventArgs e)
        {
            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;


            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            report_type.SelectedIndex = 0;
        }

        private void date_b_Validated(object sender, EventArgs e)
        {
            //DateTime dt;
            //if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
            //{
            //    date_b.Focus();
            //    return;
            //}
            //else
            //    date_e.Text = date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");            
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                string _nobrb = nobr_b.Text;
                string _nobre = nobr_e.Text;
                string _deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string _depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string _dateb = date_b.Text;
                string _datee = date_e.Text;
                string _compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string _compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string reporttype = report_type.SelectedIndex.ToString();

                if (type_data2.Checked) type_data += " and b.di='I'  and a.count_ma=0 ";
                if (type_data3.Checked) type_data += " and b.di='D'  and a.count_ma=0 ";
                if (type_data4.Checked) type_data += " and a.count_ma=1 ";
                bool _exportexcel = ExportExcel.Checked;
                if (reporttype == "0" || reporttype == "4")
                {
                    if (zz2h_report != null)
                    {
                        zz2h_report.Dispose();
                        zz2h_report.Close();
                    }

                    zz2h_report = new ZZ2H_Report(_nobrb, _nobre, _deptb, _depte, _compb, _compe, _dateb, _datee, type_data, _exportexcel, reporttype,MainForm.COMPANY_NAME);
                    zz2h_report.Show();
                }
                else if (reporttype == "1" || reporttype == "2")
                {
                    if (zz2h2_report != null)
                    {
                        zz2h2_report.Dispose();
                        zz2h2_report.Close();
                    }
                    zz2h2_report = new ZZ2H2_Report(_nobrb, _nobre, _deptb, _depte, _compb, _compe, _dateb, _datee, type_data, _exportexcel, reporttype, MainForm.COMPANY_NAME);
                    zz2h2_report.Show();
                }
                else if (reporttype == "3")
                {
                    if (zz2h4_report != null)
                    {
                        zz2h4_report.Dispose();
                        zz2h4_report.Close();
                    }

                    zz2h4_report = new ZZ2H4_Report(_nobrb, _nobre, _deptb, _depte, _compb, _compe, _dateb, _datee, type_data, _exportexcel, MainForm.COMPANY_NAME);
                    zz2h4_report.Show();
                }

                else if (reporttype == "5")
                {
                    if (zz2h5_report != null)
                    {
                        zz2h5_report.Dispose();
                        zz2h5_report.Close();
                    }

                    zz2h5_report = new ZZ2H5_Report(_nobrb, _nobre, _deptb, _depte, _compb, _compe, _dateb, _datee, type_data, _exportexcel, MainForm.COMPANY_NAME);
                    zz2h5_report.Show();
                }
                else if (reporttype == "6")
                {
                    if (zz2h7_report != null)
                    {
                        zz2h7_report.Dispose();
                        zz2h7_report.Close();
                    }

                    zz2h7_report = new ZZ2H7_Report(_nobrb, _nobre, _deptb, _depte, _compb, _compe, _dateb, _datee, type_data, _exportexcel, MainForm.COMPANY_NAME);
                    zz2h7_report.Show();
                }
                else if (reporttype == "7")
                {
                    if (zz2h8_report != null)
                    {
                        zz2h8_report.Dispose();
                        zz2h8_report.Close();
                    }

                    zz2h8_report = new ZZ2H8_Report(_nobrb, _nobre, _deptb, _depte, _compb, _compe, _dateb, _datee, type_data, _exportexcel, MainForm.COMPANY_NAME);
                    zz2h8_report.Show();
                }
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
