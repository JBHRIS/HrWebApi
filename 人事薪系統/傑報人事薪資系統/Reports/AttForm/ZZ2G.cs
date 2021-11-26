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
    public partial class ZZ2G : JBControls.JBForm
    {
        ZZ2G_Report zz2g_report; ZZ2GA_Report zz2ga_report;
        public ZZ2G()
        {
            InitializeComponent();
        }

        private void ZZ2G_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            string y1 = Convert.ToString(DateTime.Now.Year);
            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            date_b.Text = ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            date_e.Text = ReportClass.GetAttEDate(yymm_b.Text, month_b.Text);
            report_type.SelectedIndex = 0;
           
        }

        private void date_type1_Click(object sender, EventArgs e)
        {
            date_b.Enabled = false;
            date_e.Enabled = false;
            yymm_b.Enabled = true;
            yymm_e.Enabled = true;
            month_b.Enabled = true;
            month_e.Enabled = true;
        }

        private void date_type2_Click(object sender, EventArgs e)
        {
            date_b.Enabled = true;
            date_e.Enabled = true;
            yymm_b.Enabled = false;
            yymm_e.Enabled = false;
            month_b.Enabled = false;
            month_e.Enabled = false;
        }


        private void yymm_b_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void yymm_e_Validated(object sender, EventArgs e)
        {
            try
            {
                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_e_Validated(object sender, EventArgs e)
        {
            try
            {
                month_e.Text = month_e.Text.PadLeft(2, '0');

                date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {  
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string yymmb = yymm_b.Text + month_b.Text;
                string yymme = yymm_e.Text + month_e.Text;
                bool _exportexcel = ExportExcel.Checked;
                bool _labcheck = labcheck.Checked;
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr"); 
                string datetype = "";
                if (type_data2.Checked) type_data += " and b.di='I'  and a.count_ma=0 ";
                if (type_data3.Checked) type_data += " and b.di='D'  and a.count_ma=0 ";
                if (type_data4.Checked) type_data += " and a.count_ma=1 ";
                if (date_type1.Checked)
                {
                    //dateb = Convert.ToDateTime(Convert.ToString(yymmb.Substring(0, 4)) + "/" + yymmb.Substring(4, 2) + "/01").ToString("yyyy/MM/dd");
                    //datee = DateTime.Parse(dateb).AddDays(1).AddMonths(-1).ToString("yyyy/MM/dd");
                    datetype = "1";
                }
                if (date_type2.Checked)
                    datetype = "2";
                string data_report = "";
                if (report_type.SelectedIndex.ToString() == "0")
                {
                    if (zz2g_report != null)
                    {
                        zz2g_report.Dispose();
                        zz2g_report.Close();
                    }
                    zz2g_report = new ZZ2G_Report(nobrb, nobre, deptb, depte, compb, compe, dateb, datee, yymmb, yymme, _labcheck, type_data, datetype, _exportexcel, data_report, MainForm.COMPANY_NAME);
                    zz2g_report.Show();
                }
                else
                {

                    if (zz2ga_report != null)
                    {
                        zz2ga_report.Dispose();
                        zz2ga_report.Close();
                    }
                    zz2ga_report = new ZZ2GA_Report(nobrb, nobre, deptb, depte, compb, compe, dateb, datee, yymmb, yymme, type_data, datetype, _exportexcel, data_report, MainForm.COMPANY_NAME);
                    zz2ga_report.Show();
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
