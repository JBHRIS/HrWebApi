using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM4R : JBControls.JBForm
    {
        Att.Controller.EmployeeLeaveSettlementController controller = null;
        Att.Vdb.EmployeeLeaveSettlementVdb vdb = null;
        Att.Dao.EmployeeLeaveSettlementDao dao = null;

        public FRM4R()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxGenType.SelectedIndex)
            {
                case 0:
                    SetVisible(tableLayoutPanel2);
                    break;
                case 1:
                    SetVisible(tableLayoutPanel3);
                    break;
            }
        }
        void SetVisible(Panel pnl)
        {
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel3.Visible = false;
            pnl.Visible = true;
        }

        private void FRM4R_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            cbxGenType.SelectedIndex = 0;
            init();
        }
        void init()
        {
            ptxNobrBegin.Text = this.basDS.V_BASE.Min(P => P.NOBR);
            ptxNobrEnd.Text = this.basDS.V_BASE.Max(P => P.NOBR);
            Core.SalaryDate sd = new Core.SalaryDate(DateTime.Today);
            txtOutDateBegin.Text = Function.GetDate(sd.FirstDayOfMonth);
            txtOutDateEnd.Text = Function.GetDate(sd.LastDayOfMonth);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            List<string> selectedEmps = new List<string>();
            foreach (DataGridViewRow rr in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(rr.Cells[0].Value))
                    selectedEmps.Add(rr.Cells[1].Value.ToString());
            }
            FRM4RA frm = new FRM4RA();
            frm.vdb = vdb;
            frm.selectedEmps = selectedEmps;
            frm.controller = controller;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                controller._vdb.OutEmployeeInfoList = new List<Att.Vdb.OutEmployeeInfo>();
                dataGridView1.DataSource = null;
                btnCalc.Enabled = vdb.OutEmployeeInfoList.Count() > 0;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            controller = new Att.Controller.EmployeeLeaveSettlementController();
            vdb = new Att.Vdb.EmployeeLeaveSettlementVdb();
            dao = new Att.Dao.EmployeeLeaveSettlementDao();
            vdb.Condition = new Att.Vdb.EmployeeLeaveSettlementCondition();
            vdb.Condition.EmployeeIdBegin = ptxNobrBegin.Text;
            vdb.Condition.EmployeeIdEnd = ptxNobrEnd.Text;
            vdb.Condition.OutDateBegin = Convert.ToDateTime(txtOutDateBegin.Text);
            vdb.Condition.OutDateEnd = Convert.ToDateTime(txtOutDateEnd.Text);
            vdb.OutEmployeeInfoList = controller.GetOutEmployeeList(vdb.Condition);
            dataGridView1.DataSource = vdb.OutEmployeeInfoList.Select(p => new { 員工編號 = p.EmployeeId, 員工姓名 = p.EmployeeName, 離職日期 = p.OutDate }).CopyToDataTable();
            CheckAll(true);
            btnCalc.Enabled = vdb.OutEmployeeInfoList.Count() > 0;
        }
        void CheckAll(bool chk)
        {
            foreach (DataGridViewRow rr in dataGridView1.Rows)
            {
                rr.Cells[0].Value = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigManager frm = new ConfigManager();
            frm.Category = "test";
            frm.ShowDialog();
        }
    }
}
