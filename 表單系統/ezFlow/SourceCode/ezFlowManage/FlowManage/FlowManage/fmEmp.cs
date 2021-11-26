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
    public partial class fmEmp : Form
    {
        private dsBaseTableAdapters.EmpTableAdapter taEmp = new FlowManage.dsBaseTableAdapters.EmpTableAdapter();
        private dsBaseTableAdapters.DeptTableAdapter taDept = new FlowManage.dsBaseTableAdapters.DeptTableAdapter();
        private dsBaseTableAdapters.PosTableAdapter taPos = new FlowManage.dsBaseTableAdapters.PosTableAdapter();
        private dsBaseTableAdapters.RoleTableAdapter taRole = new FlowManage.dsBaseTableAdapters.RoleTableAdapter();

        private dsBase odsBase = new dsBase();
        private TreeNode tnDept, tnRole, tnEmp;

        public fmEmp() {
            InitializeComponent();

            taEmp.Fill(odsBase.Emp);
            taDept.Fill(odsBase.Dept);
            taPos.Fill(odsBase.Pos);
            taRole.Fill(odsBase.Role);
        }

        private void fmEmp_Load(object sender, EventArgs e) {
            var rows = odsBase.Dept.Where(p => p.idParent.Trim() == "");

            foreach (dsBase.DeptRow r in rows) {
                tnDept = new TreeNode();
                tnDept.Text = r.name;
                tnDept.Tag = r.id;
                tnDept.ImageIndex = 0;
                tnDept.SelectedImageIndex = 0;
                tv.Nodes.Add(tnDept);
                CreateRole(r.id, tnDept);
                CreateDept(r.id, tnDept);
                tnDept.Expand();
            }
        }

        //新增子部門
        private void CreateDept(string idParent, TreeNode nodeParent) {
            var rows = odsBase.Dept.Where(p => p.idParent.Trim() == idParent);

            foreach (dsBase.DeptRow r in rows)
            {
                tnDept = new TreeNode();
                tnDept.Text = r.name;
                tnDept.Tag = r.id;
                tnDept.ImageIndex = 0;
                tnDept.SelectedImageIndex = 0;
                nodeParent.Nodes.Add(tnDept);
                CreateRole(r.id, tnDept);
                CreateDept(r.id, tnDept);
            }
        }

        //新增角色
        private void CreateRole(string idParent, TreeNode nodeParent) {
            var dtRole = taRole.DeptMang_GetDataByDeptID(idParent);
            string oldRole = "";

            foreach (dsBase.RoleRow r in dtRole.Rows)
            {
                if (oldRole == r.id) continue;
                else oldRole = r.id;
                tnRole = new TreeNode();
                tnRole.Text = odsBase.Pos.FindByid(r.Pos_id).name;
                tnRole.Tag = r.id;
                tnRole.ImageIndex = 1;
                tnRole.SelectedImageIndex = 1;
                nodeParent.Nodes.Add(tnRole);
                CreateEmp(r.id, tnRole);
                CreateSubRole(r.id, r.Dept_id, tnRole);
            }
        }

        //新增副角色
        private void CreateSubRole(string idParent, string Dept_id, TreeNode nodeParent) {
           var dtRole = taRole.GetDataByParent(idParent, Dept_id);
            string oldRole = "";

            foreach (dsBase.RoleRow r in dtRole.Rows)
            {
                if (oldRole == r.id) continue;
                else oldRole = r.id;
                tnRole = new TreeNode();
                tnRole.Text = odsBase.Pos.FindByid(r.Pos_id).name;
                tnRole.Tag = r.id;
                tnRole.ImageIndex = 1;
                tnRole.SelectedImageIndex = 1;
                nodeParent.Nodes.Add(tnRole);
                CreateEmp(r.id, tnRole);
                CreateSubRole(r.id, r.Dept_id, tnRole);
            }
        }

        //新增人員
        void CreateEmp(string id, TreeNode nodeParent) {
            var rows = odsBase.Role.Where(p => p.id == id);

            foreach (dsBase.RoleRow r in rows)
            {
                if (r.Emp_id.Trim().Length > 0) {
                    tnEmp = new TreeNode();
                    tnEmp.Text = odsBase.Emp.FindByid(r.Emp_id).name;
                    tnEmp.ToolTipText = r.id;
                    tnEmp.Tag = r.Emp_id;
                    tnEmp.ImageIndex = 2;
                    tnEmp.SelectedImageIndex = 2;
                    nodeParent.Nodes.Add(tnEmp);
                }
            }
        }

        private void btnYorN_Click(object sender, EventArgs e) {
            Button btn = ((Button)sender);

            if (tv.SelectedNode == null && btn.Tag.ToString() == "Yes") {
                MessageBox.Show("請選取一個角色", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tv.SelectedNode.ImageIndex != 2 && btn.Tag.ToString() == "Yes") {
                MessageBox.Show("您選取的並非成員", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Tag = tv.SelectedNode.ToolTipText;
            this.AccessibleDescription = tv.SelectedNode.Tag.ToString();
            this.AccessibleName = tv.SelectedNode.Text;
            DialogResult = (btn.Tag.ToString() == "Yes") ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

    }
}
