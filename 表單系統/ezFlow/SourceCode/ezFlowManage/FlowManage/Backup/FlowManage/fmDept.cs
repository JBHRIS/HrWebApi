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
    public partial class fmDept : Form 
    {
        private dsBaseTableAdapters.DeptTableAdapter taDept = new FlowManage.dsBaseTableAdapters.DeptTableAdapter();
        private dsBase odsBase = new dsBase();
        private TreeNode tn;

        public fmDept()
        {
            InitializeComponent();
        }

        private void fmDept_Load(object sender, EventArgs e)
        {
            taDept.Fill(odsBase.Dept);

            var rows = odsBase.Dept.Where(p => p.idParent.Trim() == "");
            foreach (dsBase.DeptRow r in rows)
            {
                tn = new TreeNode();
                tn.Text = r.name;
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
                tn.Text = r.name;
                tn.Tag = r.id;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                nodeParent.Nodes.Add(tn);
                CreateDept(r.id, tn);
            }
        }

        private void btnYorN_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            if (tv.SelectedNode == null && btn.Tag.ToString() == "Yes")
            {
                MessageBox.Show("請選取一個部門", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.AccessibleDescription = tv.SelectedNode.Tag.ToString();
            this.AccessibleName = tv.SelectedNode.Text;
            DialogResult = (btn.Tag.ToString() == "Yes") ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }
    }
}