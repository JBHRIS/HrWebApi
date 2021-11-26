using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_Admin_Plan_Notify : System.Web.UI.Page
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    bool isExport = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNotify);
        //取日期就好
        lblMonth.Text = DateTime.Now.AddMonths(1).ToString().Substring(0, 9); 
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        isExport = true;
        hideCol();
        gvNotify.ExportSettings.ExportOnlyData = true;
        gvNotify.ExportSettings.HideStructureColumns = true;        
        gvNotify.ExportSettings.IgnorePaging = true;
        gvNotify.ExportSettings.OpenInNewWindow = false;        
        gvNotify.ExportSettings.FileName = "待辦事項";
        gvNotify.MasterTableView.ExportToExcel();
    }

    private void showCol()
    {
        gvNotify.Columns.FindByUniqueName("Done").Visible = true;
    }

    private void hideCol()
    {
        gvNotify.Columns.FindByUniqueName("Done").Visible = false;
    }

    protected void gvNotify_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "Done")
        {
            GridDataItem item = (GridDataItem)e.Item;
            int autoKey = Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());

            var data = (from c in dcTraining.trClassNotify
                        where c.iAutoKey == autoKey
                        select c).FirstOrDefault();

            if (data != null)
            {
                data.dCompletedDate = DateTime.Now;
                data.sCompletedMan = Page.User.Identity.Name;
                dcTraining.SubmitChanges();
                gvNotify.Rebind();
            }
        }
    }
    protected void gvNotify_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
            e.Item.Visible = false;
    }
}