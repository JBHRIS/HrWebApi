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
    public partial class ZZ71 : JBControls.JBForm
    {
        ZZ71_Report zz71_report;
        public ZZ71()
        {
            InitializeComponent();
        }

        private void ZZ71_Load(object sender, EventArgs e)
        {
            yymm_b.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            yymm_e.Text = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq_b.Text = "1";
            seq_e.Text = "z";
            tcode_b.DataSource = JBHR.Reports.ReportClass.GetTcode();
            tcode_e.DataSource = JBHR.Reports.ReportClass.GetTcode();
            tcode_e.SelectedIndex = tcode_e.Items.Count - 1;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                //if (nobr_b.Text.Trim() == "")
                //{
                //    nobr_b.Focus();
                //    return;
                //}
                //if (nobr_e.Text.Trim() == "")
                //{
                //    nobr_e.Focus();
                //    return;
                //}
                //if (yymm_b.Text.Trim() == "")
                //{
                //    yymm_b.Focus();
                //    return;
                //}
                //if (yymm_e.Text.Trim() == "")
                //{
                //    yymm_e.Focus();
                //    return;
                //}
                //if (seq_b.Text.Trim() == "")
                //{
                //    seq_b.Focus();
                //    return;
                //}
                //if (seq_e.Text.Trim() == "")
                //{
                //    seq_e.Focus();
                //    return;
                //}
                if (zz71_report != null)
                {
                    zz71_report.Dispose();
                    zz71_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string yymmb = yymm_b.Text;
                string yymme = yymm_e.Text;
                string seqb = seq_b.Text;
                string seqe = seq_e.Text;
                string tcodeb = (tcode_b.SelectedIndex == -1) ? "" : tcode_b.SelectedValue.ToString();
                string tcodee = (tcode_e.SelectedIndex == -1) ? "" : tcode_e.SelectedValue.ToString();
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                bool _exportexcel = ExportExcel.Checked;
                zz71_report = new ZZ71_Report(nobrb, nobre, yymmb, yymme, seqb, seqe, tcodeb, tcodee, workadr, _exportexcel); ;
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
