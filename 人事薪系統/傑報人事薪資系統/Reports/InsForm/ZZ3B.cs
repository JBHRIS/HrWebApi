using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.InsForm
{
    public partial class ZZ3B : JBControls.JBForm
    {
        ZZ3B_Report zz3b_report;
        public ZZ3B()
        {
            InitializeComponent();
        }

        private void ZZ3B_Load(object sender, EventArgs e)
        {
            insure_type.SelectedIndex = 3;
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_e.Text = JBHR.Reports.ReportClass.GetSalEDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
            date_k.Text = DateTime.Now.Date.ToString();
            sno_b.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.DataSource = JBHR.Reports.ReportClass.GetInscomp(MainForm.COMPANY);
            sno_e.SelectedIndex = sno_e.Items.Count - 1;
        }

        private void insure_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (insure_type.SelectedIndex != 3)
                date_b.Enabled = true;
            else
                date_b.Enabled = false;
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {                
                if (out_text.Checked)
                {
                    if (net_no.Text.Trim() == "")
                    {
                        MessageBox.Show("網路申報-單位保險證號,不可空白！", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (net_txt.Text.Trim() == "")
                    {
                        MessageBox.Show("網路申報檔案名稱,不可空白！", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (zz3b_report != null)
                {
                    zz3b_report.Dispose();
                    zz3b_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string dateb = date_b.Text;
                string datee = date_e.Text;
                string datek = date_k.Text;
                string netno = net_no.Text;
                string nettxt = net_txt.Text;
                string snob = (sno_b.SelectedIndex == -1) ? "" : sno_b.SelectedValue.ToString();
                string snoe = (sno_e.SelectedIndex == -1) ? "" : sno_e.SelectedValue.ToString();
                string insuretype = insure_type.SelectedIndex.ToString();
                string typedata = "";
                if (type_data2.Checked) typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                if (type_data4.Checked) typedata = " AND A.COUNT_MA=1 ";
                if (type_data5.Checked) typedata = " AND A.COUNT_MA=0 ";
                if (!MainForm.MANGSUPER) typedata += " and b.saladr='" + MainForm.WORKADR + "'";
                bool _excelexport = ExportExcel.Checked;
                bool _outtext = out_text.Checked;
                zz3b_report = new ZZ3B_Report(nobrb, nobre, deptb, depte, dateb, datee, datek, snob, snoe, nettxt, netno, insuretype, typedata, _excelexport, _outtext,MainForm.COMPANY);
                zz3b_report.Show();
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
