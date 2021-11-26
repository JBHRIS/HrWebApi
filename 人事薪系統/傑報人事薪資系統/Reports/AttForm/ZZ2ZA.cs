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
    public partial class ZZ2ZA : JBControls.JBForm
    {
        ZZ2ZA_Report zz2za_report;
        public ZZ2ZA()
        {
            InitializeComponent();
        }

        private void ZZ2ZA_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            yymm_b.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');

            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(yymm_e.Text, month_b.Text);
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(yymm_e.Text, month_e.Text);
            indt.Text = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Text, month_e.Text);

            date_b.Enabled = false;
            date_e.Enabled = false;
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

        private void date_b_Validated(object sender, EventArgs e)
        {
            date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                if (zz2za_report != null)
                {
                    zz2za_report.Dispose();
                    zz2za_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string yymmb = yymm_b.Text + month_b.Text;
                string yymme = yymm_e.Text + month_e.Text;
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string _indt = indt.Text;
                string _order = "";
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string _note1 = note1.Text;
                string datetype = "";
                if (order1.Checked) _order = "1";
                if (order2.Checked) _order = "2";
                if (type_data2.Checked) type_data += " and b.di='I' and a.count_ma=0 ";
                if (type_data3.Checked) type_data += " and b.di='D' and a.count_ma=0 ";
                if (type_data4.Checked) type_data += " and a.count_ma=1 ";
                if (type_data5.Checked) type_data += " and (b.di='D' or a.count_ma=1)";
                
                bool _exportexcel = ExportExcel.Checked;
                string username = MainForm.USER_NAME;
                if (date_type1.Checked) datetype = "1";
                if (date_type2.Checked) datetype = "2";

                zz2za_report = new ZZ2ZA_Report(nobrb, nobre, deptsb, deptse, dateb, datee, yymmb, yymme, compb, compe, _indt, type_data, _note1, _order, _exportexcel, datetype, username,MainForm.COMPANY_NAME);
                zz2za_report.Show();
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
