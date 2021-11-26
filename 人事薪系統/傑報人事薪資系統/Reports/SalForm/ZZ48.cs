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
    public partial class ZZ48 : JBControls.JBForm
    {
        ZZ48_Report zz48_report;
        public ZZ48()
        {
            InitializeComponent();
        }

        private void ZZ48_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq.Text = "2";

            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
            attdate_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year.Text, month.Text);
            attdate_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year.Text, month.Text);
        }

        private void year_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
                attdate_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year.Text, month.Text);
                attdate_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year.Text, month.Text);
                month.Focus();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void month_Validated(object sender, EventArgs e)
        {
            try
            {
                month.Text = month.Text.PadLeft(2, '0');

                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
                attdate_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year.Text, month.Text);
                attdate_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year.Text, month.Text);
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz48_report != null)
                {
                    zz48_report.Dispose();
                    zz48_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string saladrb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string saladre = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string _year = year.Text;
                string _month = month.Text;
                string _seq = seq.Text;
                string dateb = date_b.Text;
                string attdateb = attdate_b.Text;
                string attdatee = attdate_e.Text;
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                string type_data = "";
                //if (type_data1.Checked) type_data += " ";
                if (type_data2.Checked) type_data += " AND B.DI='I'  AND A.COUNT_MA=0";
                if (type_data3.Checked) type_data += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked) type_data += " AND A.COUNT_MA=1";
                if (type_data5.Checked) type_data += " AND A.COUNT_MA=0";
                bool _exportexcel = ExportExcel.Checked;
                zz48_report = new ZZ48_Report(nobrb, nobre, deptb, depte, saladrb, saladre,empb,empe,attdateb,attdatee, dateb, _year, _month, _seq, workadr, type_data, MainForm.COMPANY_NAME, MainForm.COMPANY, _exportexcel);
                zz48_report.Show();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
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
