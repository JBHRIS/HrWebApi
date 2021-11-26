using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.TraForm
{
    public partial class ZZ93 : JBControls.JBForm
    {
        ZZ93_Report zz93_report;
        public ZZ93()
        {
            InitializeComponent();
        }

        private void ZZ93_Load(object sender, EventArgs e)
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

            subcode_b.DataSource = JBHR.Reports.ReportClass.GetTrtype();
            subcode_e.DataSource = JBHR.Reports.ReportClass.GetTrtype();
            subcode_e.SelectedIndex = subcode_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyy/MM") + "/01";
            date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz93_report != null)
                {
                    zz93_report.Dispose();
                    zz93_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;               
                string deptb = dept_b.SelectedValue.ToString();
                string depte = dept_e.SelectedValue.ToString();              
                string compb = comp_b.SelectedValue.ToString();
                string compe = comp_e.SelectedValue.ToString();
                string sub_b = subcode_b.SelectedValue.ToString();
                string sub_e = subcode_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string type_data = "";
                if (!MainForm.MANGSUPER) type_data += " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                zz93_report = new ZZ93_Report(nobrb, nobre, compb, compe, deptb, depte, sub_b, sub_e, dateb, datee, type_data, ExportExcel.Checked,MainForm.COMPANY_NAME);
                zz93_report.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void bnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
