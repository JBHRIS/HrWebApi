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
    public partial class ZZ22 : JBControls.JBForm
    {
        ZZ22_Report zz22_report;
        public ZZ22()
        {
            InitializeComponent();
        }

        private void ZZ22_Load(object sender, EventArgs e)
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

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            //rote_b.DataSource = JBHR.Reports.ReportClass.GetRote(MainForm.COMPANY);
            //rote_e.DataSource = JBHR.Reports.ReportClass.GetRote(MainForm.COMPANY);
            //rote_e.SelectedIndex = rote_e.Items.Count - 1;

            //if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("DateTimeFormat"))
            //{
            //    if (System.Configuration.ConfigurationManager.AppSettings["DateTimeFormat"].ToLower() == "taiwan")
            //    {
            //        yymm_b.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(3, '0') + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //        yymm_e.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(3, '0') + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //    }
            //    else
            //    {
            //        yymm_b.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //        yymm_e.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //    }
            //}

            yymm_b.Text = Convert.ToString(DateTime.Now.Year) ;
            yymm_e.Text = Convert.ToString(DateTime.Now.Year) ;
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_b.Text, month_b.Text);
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            indt.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);

            report_type.SelectedIndex = 0;

            date_b.Enabled = false;
            date_e.Enabled = false;
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
                indt.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
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
                indt.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }       

        private void date_e_Validated(object sender, EventArgs e)
        {
            indt.Text = date_e.Text;
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

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {   
                if (zz22_report != null)
                {
                    zz22_report.Dispose();
                    zz22_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string workb = (work_b.SelectedIndex == -1) ? "" : work_b.SelectedValue.ToString();
                string worke = (work_e.SelectedIndex == -1) ? "" : work_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string salarb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string salare = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();

                //string roteb = (rote_b.SelectedIndex == -1) ? "" : rote_b.SelectedValue.ToString();
                //string rotee = (rote_e.SelectedIndex == -1) ? "" : rote_e.SelectedValue.ToString();
                string yymmb = yymm_b.Text + month_b.Text;
                string yymme = yymm_e.Text + month_e.Text;
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string _indt = indt.Text;
                string reporttype = report_type.SelectedIndex.ToString();
                string _noen = "";
                string datetype = ""; string ottype = ""; string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (date_type1.Checked) datetype = "1";
                if (date_type2.Checked) datetype = "2";
                if (type_data2.Checked) type_data += " AND B.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked) type_data += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked) type_data += " AND A.COUNT_MA=1 ";
                if (noen.Checked) _noen = " and a.syscreat1=0 and a.syscreat=0 and a.sys_ot=0";
                bool _labcheck = LABCHECK.Checked;
                bool _exportexcel = ExportExcel.Checked;
                string _username = MainForm.USER_NAME;

                zz22_report = new ZZ22_Report(nobrb, nobre, empb, empe, deptb, depte, deptsb, deptse, workb, worke, compb, compe, yymmb, yymme, dateb, datee, salarb, salare, _indt, reporttype, type_data, datetype, _noen, _labcheck, _exportexcel, _username, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz22_report.Show();
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
