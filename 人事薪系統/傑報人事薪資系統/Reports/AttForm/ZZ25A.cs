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
    public partial class ZZ25A : JBControls.JBForm
    {
        ZZ25A_Report zz25a_report;
        public ZZ25A()
        {
            InitializeComponent();
        }

        private void ZZ25A_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts();
            depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts();
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            date_b.Text = Convert.ToString(DateTime.Now.Year) + "/01/01";
            date_e.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz25a_report != null)
                {
                    zz25a_report.Dispose();
                    zz25a_report.Close();
                }

                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptsb = depts_b.SelectedValue.ToString();
                string deptse = depts_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string typedata = "";
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1";
                string _username = MainForm.USER_NAME;
                if (!MainForm.MANGSUPER) typedata += " and b.saladr='" + MainForm.WORKADR + "'";
                bool _exportexcel = ExportExcel.Checked;
                zz25a_report = new ZZ25A_Report(nobrb, nobre, deptsb, deptse, dateb, datee, _username, typedata, _exportexcel);
                zz25a_report.Show();
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
