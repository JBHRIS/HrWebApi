using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
 
using System.Collections.Generic;
using JB.WebModules;
using JB.WebModules.Authentication;
using Newtonsoft.Json;

public partial class Templet_AbsDayControl : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string dept = JbUser.DepartmentCode;
            lb_dept.Text = dept;
            GetData();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }

    void GetData()
    {
        HRDsTableAdapters.rv_absdayTableAdapter rv_absday = new HRDsTableAdapters.rv_absdayTableAdapter();
        HRDs.rv_absdayDataTable rv_absdayDS = new HRDs.rv_absdayDataTable();
        List<TreeNode> nodeList = null;
        TreeView tv = new TreeView();

        JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
        if (newUser.Roles.Contains("HR"))
        {
            rv_absdayDS.Merge(rv_absday.GetDataByNotDept());
            
            SiteHelper.SetAllDeptTree(tv);
            nodeList = SiteHelper.GetTreeViewAllNodes(tv);
        }
        else
        {
            SiteHelper.SetDeptTreeByDeptDeptSupervisor(tv, JbUser.NOBR);
            nodeList = SiteHelper.GetTreeViewAllNodes(tv);

            foreach(TreeNode n in nodeList)
            {
                rv_absdayDS.Merge(rv_absday.GetData_rv_absday(n.Value));
            }
        }

       // rv_absdayDS.Merge(rv_absday.GetDataByNotDept());
        GridView1.DataSource = rv_absdayDS;
        GridView1.DataBind();
    }
}
