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
using BL;
using JBHRModel;
 
using System.Collections.Generic;
using System.Linq;

public partial class Employee_EmpOtSelect1 : JBWebPage
{
    const string SESSION_SUMMURY_TABLE = "Employee_EmpOtSelect1_Summury";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session[SessionName] = null;

            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;
            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView2.DataBind();
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (List<EmpAttendLateDto>)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        OT_REPO otRepo = new OT_REPO();
        List<EmpOtSummury> dataList = new List<EmpOtSummury>();

        //員工
        dataList = otRepo.GetEmpOtSummuryByNobrDateRange(Juser.Nobr, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value);

        Session[SessionName] = dataList;
        GridView2.DataSource = dataList;
        GridView2.DataBind(); 
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        if (Session[SessionName] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = Session[SessionName] as List<EmpAttendLateDto>; //dataview;
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }



}
