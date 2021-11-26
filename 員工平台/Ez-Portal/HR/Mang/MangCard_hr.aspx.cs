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
public partial class Mang_MangCard_hr : JBWebPage
{//joe
    private DEPT_REPO dept_repo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        //SelectEmpHr1.sHandler += new Templet_SelectEmpHr.SelectEmpEventHandler(UC_SelectEmp);
        if (!IsPostBack)
        {
            //SiteHelper.SetAllDeptTree(TreeView1);
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            Session[SessionName] = null;
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
    //    (SelectEmpHr1 as IUC).SetValue(TreeView1.SelectedNode.Value);
    //    (SelectEmpHr1 as IUC).BindData();
    //    lb_nobr.Text = "";
    //    GetData();
    //}
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        //if (GridView1.Rows.Count > 0)
        //{
        //    GridView1.SelectedIndex = 0;
        //    lb_nobr.Text = GridView1.SelectedValue.ToString();
        //}
    }
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridView gv = (GridView)sender;
    //    lb_nobr.Text = gv.SelectedValue.ToString();
    //    GetData();
    //}
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (HRDs.rv_cardDataTable)Session[SessionName];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    //protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable rv_null = new DataTable();
    //    GridView2.DataSource = rv_null;
    //    GridView2.DataBind();
    //    if (RBL_deptr.SelectedIndex == 0)
    //    {
    //        empMenu.Visible = true;
    //        (SelectEmpHr1 as IUC).BindData();
    //    }
    //    else
    //    {
    //        empMenu.Visible = false;
    //    }
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();        
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (HRDs.rv_cardDataTable)Session[SessionName], "MangCard");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
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


        HRDsTableAdapters.rv_cardTableAdapter rv_card = new HRDsTableAdapters.rv_cardTableAdapter();
        HRDs.rv_cardDataTable rv_cardDs = new HRDs.rv_cardDataTable();
        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key, ""));
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            foreach (var item in obj.DeptList)
            {
                rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", item));
            }
        }
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    List<TreeNode> nodeList= SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    foreach (var d in nodeList)
        //        rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", d.Value));
        //}
        //else
        //{
        //    (SelectEmpHr1 as IUC).BindData();
        //}
        //SiteHelper siteHelper = new SiteHelper();
        //rv_cardDs = siteHelper.GetSelectedEmpData(rv_cardDs, "NOBR", Juser.SalaDrNobrList) as HRDs.rv_cardDataTable;

        Session[SessionName] = rv_cardDs;
        GridView2.DataSource = rv_cardDs;

        GridView2.DataBind(); 
    }
}
