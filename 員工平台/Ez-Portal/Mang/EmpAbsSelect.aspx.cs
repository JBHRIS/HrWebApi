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

public partial class Mang_EmpAbsSelect:JBWebPage
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
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender , EventArgs e)
    {
        //   Session["nobr"] = GridView1.SelectedValue;
        GridView gv = (GridView) sender;
        lb_nobr.Text = gv.SelectedValue.ToString();
        GetData();
    }

    protected void Button1_Click(object sender , EventArgs e)
    {
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
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if ( obj == null )
        {
            Show("Select Unit or Team Member");
            return;
        }

        HRDsTableAdapters.rv_abs3TableAdapter rv_abs = new HRDsTableAdapters.rv_abs3TableAdapter();
        HRDs.rv_abs3DataTable rv_absDs = new HRDs.rv_abs3DataTable();

        if ( obj.SelectedType == EnumUC_QS_SelectedType.Emp )
        {
            rv_absDs.Merge(rv_abs.GetDataBy_rv_abs1(adate.SelectedDate.Value , ddate.SelectedDate.Value , obj.Key , ""));
        }
        else
        {
            foreach ( var d in obj.DeptList )
            {
                rv_absDs.Merge(rv_abs.GetDataBy_rv_abs1(adate.SelectedDate.Value , ddate.SelectedDate.Value , "" , d));
            }
        }


        //SiteHelper siteHelper = new SiteHelper();
        //rv_absDs = siteHelper.RemoveSelectedEmpData(rv_absDs , "NOBR" , Juser.ManagerExeptEmpList) as HRDs.rv_abs3DataTable;

        rv_absDs.DefaultView.Sort = "BDATE desc";
        Session[SessionName] = rv_absDs;
        GridView2.DataSource = rv_absDs;
        GridView2.DataBind();
    }


    protected void Button2_Click(object sender , EventArgs e)
    {
        if ( Session[SessionName] != null )
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this , GridView2 , (HRDs.rv_abs3DataTable) Session[SessionName] , "rv_abs");
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
