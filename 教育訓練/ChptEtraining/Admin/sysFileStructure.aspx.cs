using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

public partial class Admin_sysFileStructure : System.Web.UI.Page
{
    private dcTrainingDataContext dcTraining= new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem || e.Item is GridHeaderItem)
        {
            RadButton btnEdit = e.Item.FindControl("btnEdit") as RadButton;
            if (btnEdit != null)
                btnEdit.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"], e.Item.ItemIndex);

            RadButton btnAdd = e.Item.FindControl("btnAdd") as RadButton;
            if (btnAdd != null)
                btnAdd.Attributes["onclick"] = String.Format("return ShowInsertForm();");
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
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

    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        int iAutoKey = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("iAutoKey"));
        var r = dcTraining.sysFileStructure.Where(p => p.iAutoKey == iAutoKey).FirstOrDefault();
        dcTraining.sysFileStructure.DeleteOnSubmit(r);
        dcTraining.SubmitChanges();
    }
}