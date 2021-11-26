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
    public partial class ZZ2A : JBControls.JBForm
    {
        ZZ2A_Report zz2a_report;
        public ZZ2A()
        {
            InitializeComponent();
        }

        private void ZZ2A_Load(object sender, EventArgs e)
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
            yy.Text = Convert.ToString(DateTime.Now.Year);
            //if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("DateTimeFormat"))
            //{
            //    if (System.Configuration.ConfigurationManager.AppSettings["DateTimeFormat"].ToLower() == "taiwan")
            //    {
            //        yy.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(3, '0');
            //    }
            //    else
            //    {
            //        yy.Text = Convert.ToString(DateTime.Now.Year);
            //    }
            //}         

           
            date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
            date_e.Text = DateTime.Now.ToString("yyyy/MM/dd");
            indt.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void date_b_Validated(object sender, EventArgs e)
        {
            //DateTime dt;
            //if (DateTime.TryParseExact(date_b.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt) == false)
            //{
            //    date_b.Focus();
            //    return;
            //}
            //else
            //    date_e.Text = DateTime.Parse(date_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");            

        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {              
                if (zz2a_report != null)
                {
                    zz2a_report.Dispose();
                    zz2a_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string _indt = indt.Text;
                string _yy = yy.Text;
                string data_report = "";

                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                if (type_data2.Checked)
                    typedata += " AND B.DI='I'  AND A.COUNT_MA=0";

                if (type_data3.Checked)
                    typedata += " AND B.DI='D'  AND A.COUNT_MA=0";

                if (type_data4.Checked)
                    typedata += " AND A.COUNT_MA=1";

                zz2a_report = new ZZ2A_Report(nobrb, nobre, deptb, depte, dateb, datee, empb, empe, _indt, typedata, _yy, data_report,MainForm.COMPANY_NAME);
                zz2a_report.Show();
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
