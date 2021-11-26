using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Telerik.Web.UI;

public partial class System_Role : JBWebPage
{
    private BASE_REPO baseRepo = new BASE_REPO();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNobr);
    }

    protected void gvNobr_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gvRole.SelectedItems.Count == 0)
        {
            Show("未選擇角色");
            return;
        }

        string roleCode = gvRole.SelectedValue.ToString();

        sysRole_Repo rRepo = new sysRole_Repo();
        var role = rRepo.GetByPK(roleCode);

        sysUserRole_Repo suRepo = new sysUserRole_Repo();

        GridItemCollection items = gvNobr.Items;
        foreach (GridItem item in items)
        {
            GridDataItem itm = (GridDataItem)item;

            var data = suRepo.GetByNobrRoleCode(itm["NOBR"].Text.Trim(), roleCode);

            if (itm.Selected == true)
            {
                if (data == null)
                {
                    sysUserRole obj = new sysUserRole();
                    obj.NOBR = itm["NOBR"].Text.Trim();
                    obj.RoleCode = role.Code;
                    suRepo.Add(obj);
                    suRepo.Save();
                }
                else
                {
                    //do nothing
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
                    suRepo.Delete(data);
                    suRepo.Save();
                }
            }
        }

        gvNobr.Rebind();
        Show("完成");
    }

    protected void cbxPage_CheckedChanged(object sender, EventArgs e)
    {
        gvNobr.AllowPaging = cbxPage.Checked;
        gvNobr.Rebind();
    }

    protected void gvNobr_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = (GridDataItem)e.Item;
            if (itm["RoleCode"].Text.Trim().Length == 0)
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
        if (gvRole.SelectedItems.Count > 0)
        {
            string selectedRoleKey = gvRole.SelectedValue.ToString();
            List<BASE> list = new List<BASE>();
            if (e.RebindReason == GridRebindReason.ExplicitRebind)
            {
                list = baseRepo.GetHiredEmpRole_Dlo();

                Session[SessionName] = list;
            }
            else
            {
                if (Session[SessionName] == null)
                {
                    Show("Time out!! Query again plz!");
                    return;
                }
                else
                {
                    list = Session[SessionName] as List<BASE>;
                }
            }

            gvNobr.DataSource = (from c in list
                                 select new
                                 {
                                     NOBR = c.NOBR,
                                     NAME_C = c.NAME_C,
                                     D_NAME = c.BASETTS[0].DEPT1.D_NAME,
                                     JOB_NAME = c.BASETTS[0].JOB1.JOB_NAME,
                                     RoleCode = c.sysUserRole.Where(p => p.RoleCode.Equals(selectedRoleKey)).Select(p => p.RoleCode).FirstOrDefault(),
                                     RoleName = c.sysUserRole.Where(p => p.RoleCode.Equals(selectedRoleKey)).Select(p => p.sysRole.Name).FirstOrDefault()
                                 });
        }
    }

    protected void gvRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvNobr.Rebind();
    }

    protected void gvRole_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.InitialLoad)
        {
            sysRole_Repo roleRepo = new sysRole_Repo();

            gvRole.DataSource = roleRepo.GetAll();
        }
    }
}