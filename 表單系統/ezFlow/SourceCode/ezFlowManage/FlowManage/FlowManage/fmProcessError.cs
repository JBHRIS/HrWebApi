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
    public partial class fmProcessError : Form
    {
        public fmProcessError()
        {
            InitializeComponent();
        }

        private void fmProcessError_Load(object sender, EventArgs e)
        {
            this.vProcessExceptionTableAdapter.Fill(this.dsFlow.vProcessException);
        }

        private dsFlowTableAdapters.vProcessFlowTableAdapter tavProcessFlow = new FlowManage.dsFlowTableAdapters.vProcessFlowTableAdapter();

        private void bnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("問題確實已解決了？(被標示為已解決的例外，將不再顯示。)", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<int> lstProcessFlow = new List<int>();
                List<string> lstErrorType = new List<string>();

                foreach (DataGridViewRow grdRow in dgv.SelectedRows)
                {
                    int auto = Convert.ToInt32(grdRow.Cells[0].Value);
                    vProcessExceptionTableAdapter.FillByAuto(dsFlow.vProcessException, auto);
                    foreach (dsFlow.vProcessExceptionRow r in dsFlow.vProcessException.Rows)
                    {
                        r.isOK = true;
                        vProcessExceptionTableAdapter.Update(r);

                        lstProcessFlow.Add(r.ProcessFlow_id);
                        lstErrorType.Add(r.IserrorTypeNull() ? "" : r.errorType);
                    }
                }
                this.vProcessExceptionTableAdapter.Fill(this.dsFlow.vProcessException);

                for (int i = 0; i < lstProcessFlow.Count; i++)
                {
                    if (lstErrorType[i] == "1")
                    {
                        bool isAllOK = true;
                        foreach (dsFlow.ProcessExceptionRow r in dsFlow.ProcessException.Rows)
                        {
                            if (lstProcessFlow[i] == r.ProcessFlow_id)
                            {
                                isAllOK = false;
                                break;
                            }
                        }
                        if (isAllOK)
                        {
                            tavProcessFlow.FillById(dsFlow.vProcessFlow, lstProcessFlow[i]);
                            foreach (dsFlow.vProcessFlowRow r in dsFlow.vProcessFlow.Rows)
                            {
                                r.isError = false;
                                tavProcessFlow.Update(r);
                            }
                        }
                    }
                }

                this.vProcessExceptionTableAdapter.Fill(this.dsFlow.vProcessException);
            }
        }
    }
}