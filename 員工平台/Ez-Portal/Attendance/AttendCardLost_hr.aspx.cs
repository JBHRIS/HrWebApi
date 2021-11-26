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

public partial class Mang_MangCard_hr : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // string dept = "ZZ";// JbUser.DepartmentCode;
            Session[SessionName] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

    }
    /*
    private void checkDate()
    {
        if (adate.SelectedDate.Value > DateTime.Now)
        {
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            JB.WebModules.Message.Show("查詢日期不得超過今日！");
            return;
        }

        if (adate.SelectedDate.Value.Year == ddate.SelectedDate.Value.Year && adate.SelectedDate.Value.Month == ddate.SelectedDate.Value.Month)
        { }
        else
        {
            ddate.SelectedDate = DateTime.Parse(adate.SelectedDate.Value.Year.ToString() + "/" + adate.SelectedDate.Value.Month.ToString() + "/" + DateTime.DaysInMonth(adate.SelectedDate.Value.Year,adate.SelectedDate.Value.Month));         
        }
    }
     */ 

    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();   
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (AttendDs.AttendCardLostDataTable)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        AttendDsTableAdapters.AttendCardLostTableAdapter attendCardLost_adapter= new AttendDsTableAdapters.AttendCardLostTableAdapter();       
        AttendDs.AttendCardLostDataTable attendCardLost_dt = attendCardLost_adapter.GetAttendCardLostBTWDate(adate.SelectedDate.Value,ddate.SelectedDate.Value);

        //過濾資料群組
        SiteHelper siteHelper = new SiteHelper();
        attendCardLost_dt = siteHelper.GetSelectedEmpData(attendCardLost_dt, "NOBR", Juser.SalaDrNobrList) as AttendDs.AttendCardLostDataTable;

        Session[SessionName] = attendCardLost_dt;
        GridView2.DataSource = attendCardLost_dt;
        GridView2.DataBind(); 
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (AttendDs.AttendCardLostDataTable)Session[SessionName];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
}
