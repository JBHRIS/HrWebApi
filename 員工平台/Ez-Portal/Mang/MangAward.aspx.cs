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
public partial class Mang_MangAward : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            Session[SessionName]  = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());

            adate.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            ddate.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
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
        if (Session[SessionName]  != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (HRDs.rv_awardDataTable)Session[SessionName] ;
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
        if (Session[SessionName]  != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (HRDs.rv_awardDataTable)Session[SessionName] , "MangAward");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        HRDsTableAdapters.rv_awardTableAdapter rv_award = new HRDsTableAdapters.rv_awardTableAdapter();
        HRDs.rv_awardDataTable rv_awardDs = new HRDs.rv_awardDataTable();
        //if (RBL_deptr.SelectedIndex == 0)
        //{
        //    rv_awardDs.Merge(rv_award.GetData_rv_award(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text));            
        //}
        //else if (RBL_deptr.SelectedIndex == 1)
        //{
        //    rv_awardDs.Merge(rv_award.GetDataBy_dept(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_dept.Text)); 

        //}
        //else if ( RBL_deptr.SelectedIndex == 2 )
        //{
        //    TreeNode node = TreeView1.SelectedNode;
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(node);
        //    foreach ( var n in nodeList )
        //    {
        //        rv_awardDs.Merge(rv_award.GetDataBy_dept(adate.SelectedDate.Value , ddate.SelectedDate.Value , n.Value));
        //    }
        //}
        //else
        //{
        //    GridView1.DataBind();
        //}
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp) {
            rv_awardDs.Merge(rv_award.GetData_rv_award(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key));
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept) {

            foreach (var n in obj.DeptList)
            {
                rv_awardDs.Merge(rv_award.GetDataBy_dept(adate.SelectedDate.Value , ddate.SelectedDate.Value , n));
            }
        
        }


        //SiteHelper siteHelper = new SiteHelper();
        //rv_awardDs = siteHelper.RemoveSelectedEmpData(rv_awardDs , "NOBR" , Juser.ManagerExeptEmpList) as HRDs.rv_awardDataTable;

        Session[SessionName]  = rv_awardDs;
        GridView2.DataSource = rv_awardDs;
        GridView2.DataBind(); 
    }
    
}
