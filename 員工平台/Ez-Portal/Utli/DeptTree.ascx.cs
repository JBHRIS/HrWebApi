using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BL;

public partial class Utli_DeptTree : JBUserControl {
    DEPT_REPO deptRepo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e) {
       
        if (!IsPostBack) 
        {
            string dept = JbUser.DepartmentCode;
            TreeNode treenode = new TreeNode();

            DEPT department = deptRepo.GetByID(dept);
            treenode.Text = department.D_NAME;
            treenode.Value = department.D_NO;
            TreeView1.Nodes.Add(treenode);
            setDept(treenode, department);
               
        }
    }

    void setDept(TreeNode cnode, DEPT dept) {
        List<DEPT> depts = deptRepo.GetChildByID(dept.D_NO);
        for (int i = 0; i < depts.Count; i++) 
        {
            TreeNode treenode = new TreeNode();
            treenode.Text = depts[i].D_NAME;
            treenode.Value = depts[i].D_NO;
            cnode.ChildNodes.Add(treenode);
            setDept(treenode, depts[i]);
        }
        

    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e) {
        ViewState["dept"] = TreeView1.SelectedNode.Value;
    }
}
