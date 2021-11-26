using System;
using System.Linq;
using Telerik.Web.UI;

public partial class Employee_LeaveRecord : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false; ;
        if (!IsPostBack)
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;
            siteHelper.SetDateRangeForThisYear(out startDatetime, out endDatetime);

            adate.SelectedDate = DateTime.Now.Date;
            ddate.SelectedDate = endDatetime;

            rblCat_SelectedIndexChanged(this, null);
            bind_cbxHoliType();
        }
    }

    private void bind_cbxHoliType()
    {
        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        var list = sc.GetHoliType();
        foreach (var i in list)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Text = i.Value;
            item.Value = i.Key;
            item.Checked = true;
            cbxHoliType.Items.Add(item);
        }
    }

    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        //   JB.WebModules.Data.Export.Excel.WebResponseExcel(
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (gvPositiveTotal_.Visible)
        {
            gvPositiveTotal_.Rebind();
        }
        else if (gvPositive.Visible)
        {
            gvPositive.Rebind();
        }
        else
        {
            gvNegative.Rebind();
        }
    }

    protected void gvPositiveDetail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == Telerik.Web.UI.GridRebindReason.ExplicitRebind)
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            var list = sc.GetAbsTakenByEntitleGuid(gvPositive.SelectedValue.ToString()).OrderByDescending(p => p.Adate);
            gvPositiveDetail.DataSource = list;
        }
    }

    protected void rblCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblCat.SelectedValue.Equals("2"))
        {
            gvPositive.Visible = false;
            gvNegative.Visible = false;
            gvPositiveTotal_.Visible = true;
            gvPositiveTotal_.Rebind();
        }
        else
            if (rblCat.SelectedValue.Equals("0"))
            {
                gvPositive.Visible = true;
                gvNegative.Visible = false;
                gvPositiveTotal_.Visible = false;
                gvPositive.Rebind();
            }
            else
            {
                gvPositive.Visible = false;
                gvNegative.Visible = true;
                gvPositiveTotal_.Visible = false;
                gvNegative.Rebind();
            }
    }

    protected void gvPositive_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        var list = sc.GetAbsEntitleByEmployeeIdListHcodeType(adate.SelectedDate.Value, ddate.SelectedDate.Value, true, new string[] { Juser.Nobr }, cbxHoliType.CheckedItems.Select(p => p.Value).ToArray()).OrderByDescending(p => p.BeginDate);
        gvPositive.DataSource = list;
    }

    protected void gvPositive_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvNegativeDetail.Visible = false;
        gvPositiveDetail.Visible = true;
        gvPositiveDetail.Rebind();
        win.VisibleOnPageLoad = true;
    }

    protected void gvNegative_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == Telerik.Web.UI.GridRebindReason.ExplicitRebind)
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            var list = sc.GetAbsTakenByByEmployeeIdListHcodeType(adate.SelectedDate.Value, ddate.SelectedDate.Value, true, new string[] { Juser.Nobr }, cbxHoliType.CheckedItems.Select(p => p.Value).ToArray()).OrderByDescending(p => p.Adate);
            gvNegative.DataSource = list;
        }
    }

    protected void gvNegative_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvNegativeDetail.Rebind();
        gvNegativeDetail.Visible = true;
        gvPositiveDetail.Visible = false;
        win.VisibleOnPageLoad = true;
    }

    protected void gvNegativeDetail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == Telerik.Web.UI.GridRebindReason.ExplicitRebind)
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            var list = sc.GetAbsEntitleByTakenGuid(gvNegative.SelectedValue.ToString()).OrderByDescending(p => p.BeginDate);
            gvNegativeDetail.DataSource = list;
        }
    }

    protected void gvPositiveTotal_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        var list = sc.GetAbsEntitleByEmployeeIdListHcodeType(adate.SelectedDate.Value, ddate.SelectedDate.Value, true, new string[] { Juser.Nobr }, cbxHoliType.CheckedItems.Select(p => p.Value).ToArray()).OrderByDescending(p => p.BeginDate);
        var totalList = (from p in list
                         group p by new
                         {
                             p.Nobr
                          ,
                             p.NameC
                          ,
                             p.HName
                          ,
                             p.HCode
                          ,
                             p.HCodeDisp
                          ,
                             p.Unit
                         } into g
                         select new
                         {
                             Nobr = g.Key.Nobr
                          ,
                             NameC = g.Key.NameC
                          ,
                             HCodeDisp = g.Key.HCodeDisp
                          ,
                             HName = g.Key.HName
                          ,
                             Unit = g.Key.Unit
                          ,
                             EntitledTotal = g.Sum(p => p.Entitled)
                          ,
                             TakenTotal = g.Sum(p => p.Taken)
                          ,
                             BalanceTotal = g.Sum(p => p.Balance)
                         });
        gvPositiveTotal_.DataSource = totalList;
    }
}