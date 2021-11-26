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
public partial class Mang_MangAward_hr : JBWebPage
{
    private DEPTA_REPO depta_repo = new DEPTA_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            //List<DEPTA> depta_list = depta_repo.GetRoot();
            //foreach (DEPTA d in depta_list)
            //{
            //    lb_dept.Text = d.D_NO;
            //    SiteHelper sh = new SiteHelper();sh.InitManagerDeptTreeView(TreeView1, Juser.ManageDeptRootNodeList);
            //}
            Session["rv_award"] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }



   
    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    lb_dept.Text = TreeView1.SelectedNode.Value;
    //    GetData();
    //}

    //protected void GridView1_DataBound(object sender, EventArgs e)
    //{
    //    if (GridView1.Rows.Count > 0)
    //    {
    //        GridView1.SelectedIndex = 0;
    //        lb_nobr.Text = GridView1.SelectedValue.ToString();
    //    }
    //}

    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridView gv = (GridView)sender;
    //    lb_nobr.Text = gv.SelectedValue.ToString();
    //    GetData();
    //}

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["rv_award"] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (HRDs.rv_awardDataTable)Session["rv_award"];
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
    //        GridView1.DataBind();
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
        if (Session["rv_award"] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (HRDs.rv_awardDataTable)Session["rv_award"], "MangAward");
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


        HRDsTableAdapters.rv_awardTableAdapter rv_award = new HRDsTableAdapters.rv_awardTableAdapter();
        HRDs.rv_awardDataTable rv_awardDs = new HRDs.rv_awardDataTable();
        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            rv_awardDs.Merge(rv_award.GetData_rv_award(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key));            
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {

            foreach (var d in obj.DeptList)
            {
                rv_awardDs.Merge(rv_award.GetDataBy_dept(adate.SelectedDate.Value, ddate.SelectedDate.Value, d));
            }
            //rv_awardDs.Merge(rv_award.GetDataBy_dept(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_dept.Text)); 

        }
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    //GridView2.DataSource = depts;
        //    //GridView2.DataBind();
        //    foreach (var d in nodeList)
        //    {
        //        rv_awardDs.Merge(rv_award.GetDataBy_dept(adate.SelectedDate.Value, ddate.SelectedDate.Value, d.Value));
        //    }
        //}
        //else
        //{
        //    GridView1.DataBind();
        //}
        Session["rv_award"] = rv_awardDs;
        GridView2.DataSource = rv_awardDs;
        GridView2.DataBind(); 
    }
    
}
