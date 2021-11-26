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

public partial class Mang_EmpOtSelect:JBWebPage
{
    protected void Page_Load(object sender , EventArgs e)
    {

        if ( !IsPostBack )
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;
            siteHelper.SetDateRange(out startDatetime , out endDatetime , DateTime.Now.Date , JbUser.SalaDr);
            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;

            adate.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            ddate.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);

            Session[SessionName] = null;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender , EventArgs e)
    {
        //lb_nobr.Text = GridView1.SelectedValue.ToString();
        GridView gv = (GridView) sender;
        lb_nobr.Text = gv.SelectedValue.ToString();
        GetData();
    }
    protected void Button1_Click(object sender , EventArgs e)
    {
        GridView2.DataBind();
        GetData();
    }


    protected void GridView2_PageIndexChanging(object sender , GridViewPageEventArgs e)
    {
        if ( Session[SessionName] != null )
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
        HRDsTableAdapters.HR_Portal_OtTableAdapter rv_ot = new HRDsTableAdapters.HR_Portal_OtTableAdapter();
        HRDs.HR_Portal_OtDataTable rv_otDs = new HRDs.HR_Portal_OtDataTable();


        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if ( obj == null )
        {
            Show("Select Unit or Team Member");
            return;
        }

        if ( obj.SelectedType == EnumUC_QS_SelectedType.Emp )
        {
            // rv_otDs.Merge(rv_ot.GetData_rv_ot(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));
            //GetData_rv_ot會去抓當時加班部門，GetDataBy_rv_ot1不會，只以目前人員部門往前抓全部資料
            rv_otDs.Merge(rv_ot.GetDataBy_rv_ot1(adate.SelectedDate.Value , ddate.SelectedDate.Value , obj.Key , ""));
        }
        else
        {
            foreach ( var n in obj.DeptList )
            {
                //rv_otDs.Merge(rv_ot.GetData_rv_ot(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", depts[i].D_NO));
                rv_otDs.Merge(rv_ot.GetDataBy_rv_ot1(adate.SelectedDate.Value , ddate.SelectedDate.Value , "" , n));
            }
        }


        //SiteHelper siteHelper = new SiteHelper();
        //rv_otDs = siteHelper.RemoveSelectedEmpData(rv_otDs , "NOBR" , Juser.ManagerExeptEmpList) as HRDs.HR_Portal_OtDataTable;
        rv_otDs.DefaultView.Sort = "BDATE desc";

        Session[SessionName] = rv_otDs;
        GridView2.DataSource = rv_otDs;
        GridView2.DataBind();
    }
    protected void Button2_Click(object sender , EventArgs e)
    {
        if ( Session[SessionName] != null )
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this , GridView2 , (HRDs.HR_Portal_OtDataTable) Session[SessionName] , "rv_ot");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    protected void GridView2_RowDataBound(object sender , GridViewRowEventArgs e)
    {
        if ( e.Row.RowType == DataControlRowType.DataRow )
        {
            e.Row.Cells[5].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[5].Text);
            e.Row.Cells[6].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[6].Text);
        }
    }
}
