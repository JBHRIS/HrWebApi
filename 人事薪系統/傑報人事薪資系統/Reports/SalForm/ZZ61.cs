﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ61 : JBControls.JBForm
    {
        ZZ61_Report zz61_report;
        public ZZ61()
        {
            InitializeComponent();
        }

        private void ZZ61_Load(object sender, EventArgs e)
        {
            year.Text = Convert.ToString(DateTime.Now.Year - 1);
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;
            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            reporttype.SelectedIndex = 0;
            ordertype.SelectedIndex = 0;

            ser_nob.Text = "A000000";
            ser_noe.Text = "Z999999";
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz61_report != null)
                {
                    zz61_report.Dispose();
                    zz61_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string _year = year.Text;
                string sernob = ser_nob.Text;
                string sernoe = ser_noe.Text;
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("c.saladr");
                if (type_tr2.Checked) typedata += " AND C.T_OK=0";
                if (type_tr3.Checked) typedata += " AND C.T_OK=1";
                string order_type = "";
                if (ordertype.SelectedIndex == 0)
                    order_type = " ORDER BY E.D_NO_DISP,C.NOBR";
                else if (ordertype.SelectedIndex == 1)
                    order_type = " ORDER BY C.ID DESC";               
                string report_type = reporttype.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                bool _zone = zone.Checked;
                zz61_report = new ZZ61_Report(nobrb, nobre, deptb, depte, _year, sernob, sernoe, typedata, order_type, report_type, _exportexcel, _zone, MainForm.USER_NAME, MainForm.COMPANY_NAME, MainForm.COMPANY);
                zz61_report.Show();
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
