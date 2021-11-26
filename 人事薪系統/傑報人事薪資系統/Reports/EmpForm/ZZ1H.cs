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
    public partial class ZZ1H : JBControls.JBForm
    {
        ZZ1H_Report zz1h_report;
        public ZZ1H()
        {
            InitializeComponent();
        }

        private void ZZ1H_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            date_b.Text = DateTime.Now.ToString("yyyyMMdd").PadLeft(8, '0');
            date_e.Text = DateTime.Now.ToString("yyyyMMdd").PadLeft(8, '0');
            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            contract_b.DataSource = JBHR.Reports.ReportClass.GetContract_Type();
            contract_e.DataSource = JBHR.Reports.ReportClass.GetContract_Type();
            contract_e.SelectedIndex = contract_e.Items.Count - 1;

            work_b.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.DataSource = JBHR.Reports.ReportClass.GetWorkcd(MainForm.COMPANY);
            work_e.SelectedIndex = work_e.Items.Count - 1;
            ttstype.SelectedIndex = 1;
        }

        private void ttstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ttstype.SelectedIndex.ToString()=="2")
                date_e.Enabled = true;
            else
                date_e.Enabled = false;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz1h_report != null)
                {
                    zz1h_report.Dispose();
                    zz1h_report.Close();
                }
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = dept_b.SelectedValue.ToString();
                string depte = dept_e.SelectedValue.ToString();
                string workb = work_b.SelectedValue.ToString();
                string worke = work_e.SelectedValue.ToString();
                string contractb = contract_b.SelectedValue.ToString();
                string contracte = contract_e.SelectedValue.ToString();

                bool _exportexcel = ExportExcel.Checked;
                string _ttstype = ttstype.SelectedIndex.ToString();

                string data_report = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                string _username = MainForm.USER_NAME;

                if (type_data2.Checked)
                    data_report += " AND B.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked)
                    data_report += " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked)
                    data_report += " AND A.COUNT_MA=1 ";
               
                zz1h_report = new ZZ1H_Report(dateb,datee, nobrb, nobre, deptb, depte, workb, worke, contractb, contracte, data_report,_ttstype, _username, _exportexcel,MainForm.COMPANY_NAME);
                zz1h_report.Show();
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
