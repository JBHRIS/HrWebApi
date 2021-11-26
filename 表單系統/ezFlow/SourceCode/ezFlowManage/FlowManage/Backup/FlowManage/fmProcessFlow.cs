using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlowManage
{
    public partial class fmProcessFlow : Form
    {
        public fmProcessFlow()
        {
            InitializeComponent();
        }

        private void fmProcessFlow_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ctrl = (CheckBox)sender;
            if (ctrl.Checked && ctrl.Tag.ToString().Length > 0)
            {
                Form form = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("FlowManage." + ctrl.Tag.ToString(), true) as Form;
                form.Text = ctrl.Text;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ctrl.AccessibleName = form.AccessibleName;
                    ctrl.AccessibleDescription = form.AccessibleDescription;
                }
                else
                    ctrl.Checked = false;
            }

            lblSelectMsg.Text = "";
            lblSelectMsg.Text += ckCancel.Checked ? ckCancel.Text + "&&" : "";
            lblSelectMsg.Text += ckFlow.Checked ? ckFlow.Text + "(" + ckFlow.AccessibleName + ")&&" : "";
            lblSelectMsg.Text += ckDept.Checked ? ckDept.Text + "(" + ckDept.AccessibleName + ")&&" : "";
            lblSelectMsg.Text += ckStarter.Checked ? ckStarter.Text + "(" + ckStarter.AccessibleName + ")&&" : "";
            lblSelectMsg.Text += ckDate.Checked ? ckDate.Text + "(" + ckDate.AccessibleName + ")" : "";
            lblSelectMsg.Text = lblSelectMsg.Text.Length == 0 ? "目前無任何篩選條件" : lblSelectMsg.Text;

            BindGrid();
        }

        private void BindGrid()
        {
            this.vProcessFlowTableAdapter.Fill(this.dsFlow.vProcessFlow);

            string Filter = "1 = 1";

            Filter += (ckCancel.Checked) ? " AND isCancel = 1" : " AND isCancel = 0";
            Filter += (ckFlow.Checked) ? " AND FlowTree_id = '" + ckFlow.AccessibleDescription + "'" : "";
            Filter += (ckDept.Checked) ? " AND Dept_path LIKE '" + ckDept.AccessibleDescription + "%'" : "";
            Filter += (ckStarter.Checked) ? " AND Emp_id = '" + ckStarter.AccessibleDescription + "'" : "";
            Filter += (ckDate.Checked) ? " AND adate >= #" + ckDate.AccessibleDescription + "#" : "";

            vProcessFlowBindingSource.Filter = Filter;
        }

        private dsFlowTableAdapters.vProcessFlowTableAdapter tavProcessFlow = new FlowManage.dsFlowTableAdapters.vProcessFlowTableAdapter();
        private dsFlowTableAdapters.ProcessCheckTableAdapter taProcessCheck = new FlowManage.dsFlowTableAdapters.ProcessCheckTableAdapter();

        //中止、恢復、完成(駁回)
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (MessageBox.Show("選取的流程將會" + btn.Text + "，確定嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow grdRow in dgv.SelectedRows)
                {
                    dsFlow.vProcessFlowDataTable dtProcessFlow = tavProcessFlow.GetDataById(Convert.ToInt32(grdRow.Cells[0].Value));
                    foreach (dsFlow.vProcessFlowRow rp in dtProcessFlow.Rows)
                    {
                        rp.isCancel = btn.Name == "btnCancel" || btn.Name == "btnFinish";
                        rp.isFinish = btn.Name == "btnFinish";
                        tavProcessFlow.Update(rp);
                    }
                }

                BindGrid();
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            fmEmp dlgEmpSelector = new fmEmp();
            if (dlgEmpSelector.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("選取的流程將會更改簽核者為" + dlgEmpSelector.AccessibleName + "，確定嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow grdRow in dgv.SelectedRows)
                    {
                        dsFlow.ProcessCheckDataTable dtProcessCheck = taProcessCheck.GetDataByAuto(Convert.ToInt32(grdRow.Cells[0].Value));
                        foreach (dsFlow.ProcessCheckRow rp in dtProcessCheck.Rows)
                        {
                            rp.Role_idDefault = dlgEmpSelector.Tag.ToString();
                            rp.Emp_idDefault = dlgEmpSelector.AccessibleDescription;
                            taProcessCheck.Update(rp);
                        }
                    }

                    BindGrid();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}