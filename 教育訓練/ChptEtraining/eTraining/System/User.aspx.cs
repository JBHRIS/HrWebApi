using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_System_User : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private const string SESSION_NAME = "eTraining_System_User";
    private BASE_Repo baseRepo = new BASE_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNobr);
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
            gvNobr.MasterTableView.SortExpressions.Clear();
            gvNobr.MasterTableView.GroupByExpressions.Clear();
            gvNobr.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            gvNobr.MasterTableView.SortExpressions.Clear();
            gvNobr.MasterTableView.GroupByExpressions.Clear();
            gvNobr.MasterTableView.CurrentPageIndex = gvNobr.MasterTableView.PageCount - 1;
            gvNobr.Rebind();
        }
    }

    protected void gvNobr_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvUserRole.SelectedIndexes.Clear();
        sysUserRole_Repo urRepo = new sysUserRole_Repo();
        List<sysUserRole> urList= urRepo.GetByNobr(gvNobr.SelectedValue.ToString());

        foreach (GridDataItem item in gvUserRole.Items)
        {
            if (urList.Any(p => p.iRoleKey.ToString().Equals(item["iKey"].Text)))
            {
                item.Selected = true;
            }
        }

        //gvUserRole.Visible = true;
    }
    protected void gvUserRole_ItemDataBound(object sender, GridItemEventArgs e)
    {        
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = (GridDataItem)e.Item;

            if (itm["NOBR"].Text.Trim().Length == 0)
            {
                itm.Selected = false;
            }
            else
            {
                itm.Selected = true;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gvNobr.SelectedItems.Count == 0)
        {
            RadAjaxPanel1.Alert("未選擇員工");
            return;
        }

        string nobr = gvNobr.SelectedValue.ToString();

        GridItemCollection items = gvUserRole.SelectedItems;

        var dataList = (from c in dcTraining.sysUserRole
                        where c.NOBR == nobr
                        select c).ToList();

        dcTraining.sysUserRole.DeleteAllOnSubmit(dataList);

        foreach (GridItem item in items)
        {
            GridDataItem itm = (GridDataItem)item;

            sysUserRole obj = new sysUserRole();
            obj.iRoleAutoKey = Convert.ToInt32(itm["iAutoKey"].Text);
            obj.iRoleKey = Convert.ToInt32(itm["iKey"].Text);
            obj.NOBR = nobr;
            dcTraining.sysUserRole.InsertOnSubmit(obj);           
        }

        dcTraining.SubmitChanges();
        setCache();
        gvUserRole.Rebind();

        RadAjaxPanel1.Alert("完成");
        gvUserRole.SelectedIndexes.Clear();

    }
    protected void gvNobr_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (Session[SESSION_NAME] == null)
            setCache();

        List<BASE> list = Session[SESSION_NAME] as List<BASE>;

        gvNobr.DataSource = (from c in list
                             select new { c.NOBR, c.NAME_C, c.BASETTS[0].DEPT1.D_NAME, c.BASETTS[0].JOB1.JOB_NAME }).ToList();
    }

    private void setCache()
    {
        List<BASE> list = baseRepo.GetEmpHiredByDate_Dlo(DateTime.Now.Date);
        Session[SESSION_NAME] = list;
    }

    protected void gvUserRole_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.InitialLoad)
        {
            sysRole_Repo roleRepo = new sysRole_Repo();
            //if (Juser.IsInRole("1"))
            //    gvUserRole.DataSource = roleRepo.GetAll();
            //else
                gvUserRole.DataSource = roleRepo.GetVisibleRole();
        }
    }
}