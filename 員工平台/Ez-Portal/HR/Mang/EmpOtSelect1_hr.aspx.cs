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

public partial class HR_Mang_EmpOtSelect1_hr : JBWebPage {
    public const string SessionName = "HR_Mang_EmpOtSelect1_hr";
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) 
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());

            Session[SessionName] = null;
        }
    }

    
   
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
    //        GridView1.DataBind();
    //    }
    //    else
    //    {
    //        empMenu.Visible = false;
    //    }
    //}

    
    //protected void GridView1_DataBound(object sender, EventArgs e)
    //{
    //    if (GridView1.Rows.Count > 0)
    //    {
    //        GridView1.SelectedIndex = 0;
    //        lb_nobr.Text = GridView1.SelectedValue.ToString();
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

        OT_REPO otRepo = new OT_REPO();
        List<EmpOtSummury> dataList = new List<EmpOtSummury>();

        //員工
        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            dataList = otRepo.GetEmpOtSummuryByNobrDateRange(obj.Key, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        }
            //部門
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            foreach (var item in obj.DeptList)
            {
                dataList.AddRange(otRepo.GetEmpOtSummuryByDeptDateRange(item, adate.SelectedDate.Value, ddate.SelectedDate.Value));
            }
        }
            //含子部門
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);
        //    foreach (TreeNode n in nodeList)
        //        dataList.AddRange(otRepo.GetEmpOtSummuryByDeptDateRange(n.Value, adate.SelectedDate.Value, ddate.SelectedDate.Value));
        //}

        var bindDataList = dataList.FindAll(p => Juser.SalaDrNobrList.Contains(p.Nobr));

        Session[SessionName] = bindDataList;
        GridView2.DataSource = bindDataList;
        GridView2.DataBind(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (List<EmpOtSummury>)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[5].Text);
        //    e.Row.Cells[6].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[6].Text);
        //}

    }
}
