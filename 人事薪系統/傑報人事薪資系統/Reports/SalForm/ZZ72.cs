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
    public partial class ZZ72 : JBControls.JBForm
    {
        ZZ72_Report zz72_report;
        public ZZ72()
        {
            InitializeComponent();
        }

        private void ZZ72_Load(object sender, EventArgs e)
        {
            year.Text = Convert.ToString(DateTime.Now.Year - 1);
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;
            
            reporttype.SelectedIndex = 0;
            ordertype.SelectedIndex = 0;

            ser_nob.Text = "A000000";
            ser_noe.Text = "Z999999";
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                //if (year.Text.Trim() == "")
                //{
                //    year.Focus();
                //    return;
                //}
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
                //if (ser_nob.Text.Trim() == "")
                //{
                //    ser_nob.Focus();
                //    return;
                //}
                //if (ser_noe.Text.Trim() == "")
                //{
                //    ser_noe.Focus();
                //    return;
                //}
                if (zz72_report != null)
                {
                    zz72_report.Dispose();
                    zz72_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;               
                string _year = year.Text;
                string sernob = ser_nob.Text;
                string sernoe = ser_noe.Text;              
                string order_type = "";
                if (ordertype.SelectedIndex == 0)
                    order_type = " ORDER BY NOBR";
                else if (ordertype.SelectedIndex == 1)
                    order_type = " ORDER BY ID DESC";                
                string report_type = reporttype.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                zz72_report = new ZZ72_Report(nobrb, nobre, _year, sernob, sernoe, order_type, report_type, _exportexcel, MainForm.USER_NAME);
                zz72_report.Show();

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
