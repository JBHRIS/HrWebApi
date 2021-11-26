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
    public partial class fmDeptView : Form
    {
        private dsBaseTableAdapters.DeptTableAdapter taDept = new FlowManage.dsBaseTableAdapters.DeptTableAdapter();
        private dsBase odsBase = new dsBase();
        private TreeNode tn;

        public fmDeptView()
        {
            InitializeComponent();
        }

        private void fmDeptView_Load(object sender, EventArgs e)
        {
            taDept.Fill(odsBase.Dept);
            var rows = odsBase.Dept.Where(p => p.idParent.Trim() == "");
            foreach (dsBase.DeptRow r in rows)
            {
                tn = new TreeNode();
                tn.Text = r.name + "(" + r.id + ")";
                tn.ToolTipText = r.name;
                tn.Tag = r.id;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                tv.Nodes.Add(tn);
                CreateDept(r.id, tn);
                tn.Expand();
            }
        }

        //新增子節點
        private void CreateDept(string idParent, TreeNode nodeParent)
        {
            var rows = odsBase.Dept.Where(p => p.idParent.Trim() == idParent);
            foreach (dsBase.DeptRow r in rows)
            {
                tn = new TreeNode();
                tn.Text = r.name + "(" + r.id + ")";
                tn.ToolTipText = r.name;
                tn.Tag = r.id;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                nodeParent.Nodes.Add(tn);
                CreateDept(r.id, tn);
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.dsBase.vEmp.Rows.Count == 0)
                this.vEmpTableAdapter.Fill(this.dsBase.vEmp);

            vEmpBindingSource.Filter = ckDept.Checked ? "DeptPath Like '%" + tv.SelectedNode.ToolTipText + "%'": "DeptID  = '" + tv.SelectedNode.Tag.ToString() + "'";
            vEmpBindingSource.Sort = "id";

            foreach (DataGridViewRow grdRow in dgv.Rows)
            {
                bool Mang = Convert.ToBoolean(grdRow.Cells[5].Value);
                if (Mang)
                    foreach (DataGridViewCell grdCell in grdRow.Cells)
                        grdCell.Style.BackColor = Color.Red;
            }
        }

        private void ckDept_CheckedChanged(object sender, EventArgs e)
        {
            tv_AfterSelect(null, null);
        }
    }
}