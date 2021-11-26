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
    public partial class ZZ19 : JBControls.JBForm
    {
        ZZ19_Report zz19_report;
        public ZZ19()
        {
            InitializeComponent();
        }
        
        private void ZZ19_Load(object sender, EventArgs e)
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

            date_b.Text = DateTime.Now.ToString("yyyyMMdd");
            date_e.Text = DateTime.Now.ToString("yyyyMMdd");
           
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz19_report != null)
                {
                    zz19_report.Dispose();
                    zz19_report.Close();
                }

                string dateb = date_b.Text;
                string datee = date_e.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string datareport = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");               

                zz19_report = new ZZ19_Report(dateb, datee, nobrb, nobre, deptb, depte, compb, compe, _exportexcel, datareport,MainForm.COMPANY_NAME);
                zz19_report.Show();
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
