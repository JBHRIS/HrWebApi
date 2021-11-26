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
    public partial class fmSubWork : Form
    {
        private dcFlowDataContext dcFlow = new dcFlowDataContext();

        public fmSubWork()
        {
            InitializeComponent();
        }

        private void fmSubWork_Load(object sender, EventArgs e)
        {
            this.posTableAdapter.Fill(this.dsBase.Pos);
            this.deptTableAdapter.Fill(this.dsBase.Dept);
            this.empTableAdapter.Fill(this.dsBase.Emp);
            this.subWorkTableAdapter.Fill(this.dsBase.SubWork);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dtSubWork = from c in dcFlow.SubWork
                            where c.sNobr == txtNobr.Text
                            && c.sSubDept == txtDept.Text
                            && c.sSubJob ==txtJob.Text
                            select c;

            if (!dtSubWork.Any())
            {
                var r = new SubWork();
                r.sNobr = txtNobr.Text;
                r.sSubDept = txtDept.Text;
                r.sSubJob = txtJob.Text;
                r.sKeyMan = "System";
                r.iFlowAuth = Convert.ToInt32(cbFlowAuth.Text);
                r.bReplace = ckReplace.Checked;
                r.bSubMang = ckSubMang.Checked;
                r.dAdate = Convert.ToDateTime(dtpDateA.Text);
                r.dDdate =Convert.ToDateTime( dtpDateD.Text);
                r.dKeyDate = DateTime.Now;
                dcFlow.SubWork.InsertOnSubmit(r);

                dcFlow.SubmitChanges();

                this.subWorkTableAdapter.Fill(this.dsBase.SubWork);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您確定要修改嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int iAutoKey = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                var dtSubWork = from c in dcFlow.SubWork
                                where c.iAutoKey == iAutoKey
                                select c;

                if (dtSubWork.Any())
                {
                    var r = dtSubWork.First();
                    r.sNobr = txtNobr.Text;
                    r.sSubDept = txtDept.Text;
                    r.sSubJob = txtJob.Text;
                    r.sKeyMan = "System";
                    r.iFlowAuth = Convert.ToInt32(cbFlowAuth.Text);
                    r.bReplace = ckReplace.Checked;
                    r.bSubMang = ckSubMang.Checked;
                    r.dAdate = Convert.ToDateTime(dtpDateA.Text);
                    r.dDdate = Convert.ToDateTime(dtpDateD.Text);
                    r.dKeyDate = DateTime.Now;

                    dcFlow.SubmitChanges();

                    this.subWorkTableAdapter.Fill(this.dsBase.SubWork);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您確定要刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int iAutoKey = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                var dtSubWork = from c in dcFlow.SubWork
                                where c.iAutoKey == iAutoKey
                                select c;

                if (dtSubWork.Any())
                {
                    var r = dtSubWork.First();
                    dcFlow.SubWork.DeleteOnSubmit(r);
                    dcFlow.SubmitChanges();

                    this.subWorkTableAdapter.Fill(this.dsBase.SubWork);
                }
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
