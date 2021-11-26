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
        //SelectEmpHr1.sHandler += new Templet_SelectEmpHr.SelectEmpEventHandler(UC_SelectEmp);
        if (!IsPostBack) 
        {

            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);


            Session[SessionName] = null;
            //SiteHelper.SetAllDeptTree(TreeView1);
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());

            //if (TreeView1.Nodes.Count > 0)
            //{
            //    TreeView1.Nodes[0].Selected = true;
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0], null);
            //}
        }
    }

    private void UC_SelectEmp(string nobr)
    {
        lb_nobr.Text = nobr;
        GetData();
    }

    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e) 
    //{
    //    lb_dept.Text = TreeView1.SelectedNode.Value;
    //    (SelectEmpHr1 as IUC).SetValue(lb_dept.Text);
    //    (SelectEmpHr1 as IUC).BindData();        
    //}

    protected void Button1_Click(object sender, EventArgs e) {
        GridView2.DataBind();
        GetData();
    }
    //protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable rv_null = new DataTable();
    //    GridView2.DataSource = rv_null;
    //    GridView2.DataBind();
    //    if (RBL_deptr.SelectedIndex == 0)
    //    {
    //        empMenu.Visible = true;            
    //    }
    //    else
    //    {
    //        empMenu.Visible = false;
    //    }
    //}


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = Session[SessionName];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    void GetData()
    {



        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }


        HRDsTableAdapters.HR_Portal_OtTableAdapter rv_ot = new HRDsTableAdapters.HR_Portal_OtTableAdapter();
        HRDs.HR_Portal_OtDataTable rv_otDs = new HRDs.HR_Portal_OtDataTable();
        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            rv_otDs.Merge(rv_ot.GetDataBy_rv_ot1(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key, ""));
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            foreach (var item in obj.DeptList)
            {
                rv_otDs.Merge(rv_ot.GetDataBy_rv_ot1(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", item));
            }
        }
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    List<TreeNode> list= SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    foreach(TreeNode n in list)
        //    {
        //        rv_otDs.Merge(rv_ot.GetDataBy_rv_ot1(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", n.Value));
        //    }
        //}
        //SiteHelper siteHelper = new SiteHelper();
        //HRDs.HR_Portal_OtDataTable dt = siteHelper.GetSelectedEmpData(rv_otDs, "NOBR", Juser.SalaDrNobrList) as HRDs.HR_Portal_OtDataTable;

        Session[SessionName] = rv_otDs;
        GridView2.DataSource = rv_otDs;
        GridView2.DataBind(); 
    }
}
