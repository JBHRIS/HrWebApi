using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Staff_KnotTeaches1 : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoHelper doHelper = new DoHelper();
            doHelper.setCbYear(cbxYear);

            int tab = 0;
            if (Request["tab"] != null)
            {
                Int32.TryParse(Request["tab"], out tab);
            }

            RadTabStrip1.SelectedIndex = tab;
            RadMultiPage1.SelectedIndex = tab;
        }
    }

    protected void cbxYear_SelectedIndexChanged(object sender , Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }
    protected void sdsReport_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = User.Identity.Name;
    }
    protected void gvReport_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;

            if (item != null)
            {
                if (item["dNote2KeyDate"].Text.Trim().Length > 0)
                {
                    HyperLink hl = item["hlFill"].Controls[0] as HyperLink;
                    if(hl!=null)
                        hl.Text = "已填寫";
                }
            }
        }
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;

            if (item != null)
            {
                if (item["WriteDate"].Text.Trim().Length > 0)
                {
                    LinkButton lb = item["column"].Controls[0] as LinkButton;
                    if (lb != null)
                        lb.Text = "已填寫";
                }
            }
        }
    }
    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        QAMaster_Repo mRepo = new QAMaster_Repo();
        var list = mRepo.GetByYearNobr_Dlo(Convert.ToInt32(cbxYear.SelectedValue.ToString()), Juser.Nobr);
        gv.DataSource = (from c in list
                         select new
                         {
                             Id = c.Id,
                             CourseName = c.trTrainingDetailM.trCourse.sName,
                             ClassSession = c.trTrainingDetailM.iSession,
                             Qname = c.QTpl.Name,
                             WriteDate = c.WriteDate,
                             FillFormDatetimeB = c.FillFormDatetimeB,
                             FillFormDatetimeE = c.FillFormDatetimeE,
                             TotalScore = c.TotalScore
                         }).ToList();
    }

    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if (e.Item is GridDataItem)
            item = e.Item as GridDataItem;

        string url = @"~/eTraining/Questionary/QFillInQuestionary.aspx?Code=";
        if (e.CommandName.Equals("Write"))
        {
            win.NavigateUrl = url + item["Id"].Text;
            win.VisibleOnPageLoad = true;
        }
    }
    protected void RadAjaxPanel1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            gv.Rebind();
            win.VisibleOnPageLoad = false;
        }
    }
}