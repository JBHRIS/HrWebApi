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
    public partial class ZZ28 : JBControls.JBForm
    {
        ZZ28_Report zz28_report;
        public ZZ28()
        {
            InitializeComponent();
        }

        private void ZZ28_Load(object sender, EventArgs e)
        {
            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;
            yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            otyymm_b.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year);
            otyymm_e.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year);
            otmonth_b.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            otmonth_e.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            //if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains("DateTimeFormat"))
            //{
            //    if (System.Configuration.ConfigurationManager.AppSettings["DateTimeFormat"].ToLower() == "taiwan")
            //    {
            //        yymm_b.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(4, '0') + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //        yymm_e.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(4, '0') + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //        otyymm_b.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year - 1911).PadLeft(4, '0') + Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            //        otyymm_e.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year - 1911).PadLeft(4, '0') + Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            //    }
            //    else
            //    {
            //        yymm_b.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //        yymm_e.Text = Convert.ToString(DateTime.Now.Year ) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //        otyymm_b.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year ) + Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            //        otyymm_e.Text = Convert.ToString(DateTime.Now.AddMonths(-1).Year) + Convert.ToString(DateTime.Now.AddMonths(-1).Month).PadLeft(2, '0');
            //    }
            //}           
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz28_report != null)
                {
                    zz28_report.Dispose();
                    zz28_report.Close();
                }
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                string _username = MainForm.USER_NAME;
                
                zz28_report = new ZZ28_Report(comp_b.SelectedValue.ToString(), comp_e.SelectedValue.ToString(), yymm_b.Text + month_b.Text, yymm_e.Text + month_e.Text, otyymm_b.Text + otmonth_b.Text, otyymm_e.Text + otmonth_e.Text, ExportExcel.Checked, typedata, _username,MainForm.USER_ID,MainForm.COMPANY_NAME,MainForm.COMPANY);
                zz28_report.Show();
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

        private void month_b_Validated(object sender, EventArgs e)
        {
            try
            {
                month_b.Text = month_b.Text.PadLeft(2, '0');

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

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void otmonth_b_Validated(object sender, EventArgs e)
        {
            try
            {
                otmonth_b.Text = otmonth_b.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void otmonth_e_Validated(object sender, EventArgs e)
        {
            try
            {
                otmonth_e.Text = otmonth_e.Text.PadLeft(2, '0');

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.MonthError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
