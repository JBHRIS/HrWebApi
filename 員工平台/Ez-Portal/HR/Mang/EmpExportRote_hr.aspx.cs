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
using BL;
using JBHRModel;
public partial class Mang_EmpOtSelect_hr : JBWebPage {
    private DEPT_REPO dept_repo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) 
        {
            Session["rv_ot"] = null;
            SiteHelper.SetAllDeptTree(TreeView1);
            //adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            //ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e) 
    {
        IUC uc = DeptUserShift1 as IUC;
        uc.SetValue(TreeView1.SelectedNode.Value);
        uc.BindData();

        //lb_dept.Text = TreeView1.SelectedNode.Value;
        //GetData();
    }

    protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable rv_null = new DataTable();
        //GridView2.DataSource = rv_null;
        //GridView2.DataBind();
        if (RBL_deptr.SelectedIndex == 0)
        {
            //empMenu.Visible = true;
            //GridView1.DataBind();
        }
        else
        {
            //empMenu.Visible = false;
        }
    }

}
