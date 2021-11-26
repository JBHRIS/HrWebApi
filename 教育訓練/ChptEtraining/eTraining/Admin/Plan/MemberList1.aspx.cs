using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class eTraining_Admin_Plan_MemberList1 : System.Web.UI.Page
{
    private dcTrainingDataContext trainingDC = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            PlanHelper trainingPlan = new PlanHelper();
            trainingPlan.setCbYear(cbYear);

            bindWindow();
            setGv();
            RadButton3.Attributes["onclick"] = String.Format("return ShowInsertForm();");
        }
        this.Title = "調查人員清單";
    }

    //private void setCbYear()
    //{
    //        Dictionary<string, string> yearDic = new Dictionary<string, string>();

    //        var data = (from c in trainingDC.trTrainingQuest select c.iYear).Distinct();

    //        //先找資料庫有的年度
    //        foreach (var row in data)
    //        {
    //            if(!yearDic.ContainsKey(row.ToString()))
    //                yearDic.Add(row.ToString(), row.ToString());
    //        }

    //        //從今年度往後推顯示兩年
    //        int year = DateTime.Now.Year;
    //        for(int i = 0 ; i<3; i++,year++)
    //        {
    //            if (!yearDic.ContainsKey(year.ToString()))
    //                yearDic.Add(year.ToString(), year.ToString());                
    //        }
            
    //        //排序一下
    //        Dictionary<string,string> list = (from c in yearDic
    //                   orderby c.Key ascending
    //                   select c).ToDictionary(d=>d.Key,d=>d.Value);

    //        cbYear.DataSource = list;
    //        cbYear.DataTextField = "value";
    //        cbYear.DataValueField = "key";           
    //        cbYear.DataBind();

    //        foreach (Telerik.Web.UI.RadComboBoxItem item in cbYear.Items)
    //        {
    //            if(item.Value ==DateTime.Now.Year.ToString())
    //            {
    //                item.Selected = true;
    //            }
    //        }
    //}

    private void bindWindow()
    {
        RadWindowManager1.Windows[0].Title = cbYear.SelectedValue + " 年度";
    }

    private void setGv()
    {
        gv.DataBind();

    }
    protected void cbYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.DataBind();
        bindWindow();
    }

    protected void RadAjaxManager1_AjaxRequest1(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.MasterTableView.CurrentPageIndex = gv.MasterTableView.PageCount - 1;
            gv.Rebind();
        }
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            item["D_NAME"].Text = item["D_NO"].Text +" " + item["D_NAME"].Text;

        }
    }
}