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
    public partial class ZZ18 : JBControls.JBForm
    {
        ZZ18_Report zz18_report;
        public ZZ18()
        {
            InitializeComponent();
        }

        private void ZZ18_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            ttscd_b.DataSource = JBHR.Reports.ReportClass.GetTtscd();
            ttscd_e.DataSource = JBHR.Reports.ReportClass.GetTtscd();
            ttscd_e.SelectedIndex = ttscd_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));
            date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month).PadLeft(2, '0'));         
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {   
                if (zz18_report != null)
                {
                    zz18_report.Dispose();
                    zz18_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string empcdb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empcde = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string ttscdb = (ttscd_b.SelectedIndex == -1) ? "" : ttscd_b.SelectedValue.ToString();
                string ttscde = (ttscd_e.SelectedIndex == -1) ? "" : ttscd_e.SelectedValue.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string datareport = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                zz18_report = new ZZ18_Report(dateb, datee, nobrb, nobre, empcdb, empcde, ttscdb, ttscde, _exportexcel, datareport, MainForm.COMPANY_NAME);
                zz18_report.Show();
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
