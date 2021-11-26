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
            Session["mealMoney"] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();        
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session["mealMoney"] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (HRDs.MealMoneyRptDataTable)Session["mealMoney"], "MealMoney");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {

        HRDsTableAdapters.MealMoneyRptTableAdapter adapter = new HRDsTableAdapters.MealMoneyRptTableAdapter();
        HRDs.MealMoneyRptDataTable dt = adapter.GetDataMealMoneyRpt(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddl_company.SelectedValue);
   
      Session["mealMoney"] = dt;
      GridView2.DataSource = dt;
      GridView2.DataBind(); 
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["mealMoney"] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (HRDs.MealMoneyRptDataTable)Session["mealMoney"];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
}
