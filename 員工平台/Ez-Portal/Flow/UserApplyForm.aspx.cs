using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class Flow_UserApplyForm:JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            DateTime startDatetime , endDatetime;
            SiteHelper sh = new SiteHelper();
            sh.SetDateRangeForThisYear(out startDatetime, out endDatetime);

            dpDateB.SelectedDate = startDatetime;
            dpDateE.SelectedDate = endDatetime;

        }
    }

    
    protected void gvHistory_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        gvHistory.DataSource = sc.GetFlowSearchComplete(Juser.Nobr , dpDateB.SelectedDate.Value , dpDateE.SelectedDate.Value).OrderByDescending(p=>p.AppDate);
    }
    protected void gvWorking_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        gvWorking.DataSource = sc.GetFlowSearchIng(Juser.Nobr);
    }
    protected void pvWorking_Load(object sender , EventArgs e)
    {
        gvWorking.Rebind();
    }
    protected void gvHistory_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName.Equals("View"))
            {
                win.NavigateUrl = item["ViewUrl"].Text;
                win.VisibleOnPageLoad = true;
            }
            else if (e.CommandName.Equals("FlowPath"))
            {
                win.NavigateUrl = item["HistoryUrl"].Text;
                win.VisibleOnPageLoad = true;
            }
        }
    }
    protected void gvWorking_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName.Equals("View"))
            {
                win.NavigateUrl = item["ViewUrl"].Text;
                win.VisibleOnPageLoad = true;
            }
            else if (e.CommandName.Equals("FlowPath"))
            {
                win.NavigateUrl = item["HistoryUrl"].Text;
                win.VisibleOnPageLoad = true;
            }
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        gvHistory.Rebind();
    }

}