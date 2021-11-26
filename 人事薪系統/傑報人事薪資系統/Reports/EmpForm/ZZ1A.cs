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
    public partial class ZZ1A : JBControls.JBForm
    {
        ZZ1A_Report zz1a_report;
        public ZZ1A()
        {
            InitializeComponent();
        }

        private void ZZ1A_Load(object sender, EventArgs e)
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
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz1a_report != null)
                {
                    zz1a_report.Dispose();
                    zz1a_report.Close();
                }
                string dateb = date_b.Text;
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                bool _exportexcel = ExportExcel.Checked;
                string str_comp = ""; string str_desc = ""; 

                if (comp_u.Text.Trim() != "")
                    str_comp = " AND B.COMP LIKE '%" + comp_u.Text + "%'";

                if (desc.Text.Trim() != "")
                    str_desc = " AND B.DESCS LIKE '%" + desc.Text + "%'";

                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("d.saladr");
                if (type_data2.Checked)
                    type_data += " AND D.DI='I'  AND A.COUNT_MA=0 ";
                if (type_data3.Checked)
                    type_data += " AND D.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked)
                    type_data += " AND A.COUNT_MA=1 ";
               
                string _username = MainForm.USER_NAME;
                zz1a_report = new ZZ1A_Report(dateb, nobrb, nobre, deptb, depte, compb, compe, type_data, str_comp, str_desc, _exportexcel, _username, MainForm.COMPANY_NAME);
                //zz1a_report.MdiParent = this.MdiParent;
                zz1a_report.Show();
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
