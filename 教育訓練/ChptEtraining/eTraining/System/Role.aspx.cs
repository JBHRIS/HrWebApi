using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;

public partial class eTraining_System_Role : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private BASE_Repo baseRepo = new BASE_Repo();
    private const string SESSION_NAME = "eTraining_System_Role";

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



    protected void gvNobr_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvUserRole.Visible = true;
    }
    protected void gvUserRole_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    GridDataItem itm = (GridDataItem)e.Item;

        //    if (itm["NOBR"].Text.Trim().Length == 0)
        //    {
        //        itm.Selected = false;
        //    }
        //    else
        //    {
        //        itm.Selected = true;
        //    }
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gvUserRole.SelectedItems.Count == 0)
        {
            RadAjaxPanel1.Alert("未選擇角色");
            return;
        }

        Int32 roleKey = Convert.ToInt32(gvUserRole.SelectedValue.ToString());

        var role = (from c in dcTraining.sysRole
                    where c.iKey == roleKey
                    select c).FirstOrDefault();


        GridItemCollection items = gvNobr.Items;
        foreach (GridItem item in items)
        {
            GridDataItem itm = (GridDataItem)item;

            var data = (from c in dcTraining.sysUserRole
                        where c.iRoleKey == roleKey && c.NOBR == itm["NOBR"].Text.Trim()
                        select c).FirstOrDefault();

            if (itm.Selected == true)
            {
                if (data == null)
                {
                    sysUserRole obj = new sysUserRole();
                    obj.NOBR = itm["NOBR"].Text.Trim();
                    obj.iRoleKey = role.iKey;
                    obj.iRoleAutoKey = role.iAutoKey;
                    dcTraining.sysUserRole.InsertOnSubmit(obj);
                    dcTraining.SubmitChanges();
                }
                else
                {

                }
            }
            else
            {
                if (data == null)
                {
                    //do nothing
                }
                else
                {
                    dcTraining.sysUserRole.DeleteOnSubmit(data);
                    dcTraining.SubmitChanges();
                }
            }
        }

        setCache();
        gvNobr.Rebind();

        RadAjaxPanel1.Alert("完成");

    }
    protected void cbxPage_CheckedChanged(object sender, EventArgs e)
    {
        gvNobr.AllowPaging = cbxPage.Checked;
        gvNobr.Rebind();
    }
    protected void gvNobr_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //sName
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = (GridDataItem)e.Item;
            if (itm["sName"].Text.Trim().Length == 0)
            {
                itm.Selected = false;
            }
            else
            {
                itm.Selected = true;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        gvNobr.Rebind();
    }
    protected void gvNobr_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        int selectedRoleKey = Convert.ToInt32(gvUserRole.SelectedValue);
        if (Session[SESSION_NAME] == null)
            setCache();

        List<BASE> list = Session[SESSION_NAME] as List<BASE>;

        gvNobr.DataSource = (from c in list
                             select new
                             {
                                 NOBR = c.NOBR,
                                 NAME_C = c.NAME_C,
                                 D_NAME = c.BASETTS[0].DEPT1.D_NAME,
                                 JOB_NAME = c.BASETTS[0].JOB1.JOB_NAME,
                                 iRoleKey = c.sysUserRole.Where(p => p.iRoleKey == selectedRoleKey).Select(p => p.iRoleKey).FirstOrDefault(),
                                 sName = c.sysUserRole.Where(p => p.iRoleKey == selectedRoleKey).Select(p => p.sysRole.sName).FirstOrDefault()
                             });
    }
    protected void gvUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvNobr.Rebind();
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