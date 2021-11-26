using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BL;
public partial class System_User:JBWebPage
{
    private BASE_REPO baseRepo = new BASE_REPO();
    protected void Page_Load(object sender , EventArgs e)
    {
        SiteHelper.ConverToChinese(gvNobr);
    }



    protected void gvNobr_SelectedIndexChanged(object sender , EventArgs e)
    {
        gvUserRole.SelectedIndexes.Clear();
        sysUserRole_Repo urRepo = new sysUserRole_Repo();
        List<sysUserRole> urList = urRepo.GetByNobr(gvNobr.SelectedValue.ToString());

        foreach ( GridDataItem item in gvUserRole.Items )
        {
            if ( urList.Any(p => p.RoleCode.ToString().Equals(item["Code"].Text)) )
            {
                item.Selected = true;
            }
        }

    }
    protected void gvUserRole_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        if ( gvNobr.SelectedItems.Count == 0 )
        {
            RadAjaxPanel1.Alert("未選擇員工");
            return;
        }

        string nobr = gvNobr.SelectedValue.ToString();

        GridItemCollection items = gvUserRole.SelectedItems;

        sysUserRole_Repo urRepo = new sysUserRole_Repo();
        List<sysUserRole> urList= urRepo.GetByNobr(nobr);
        urRepo.Delete(urList);

        foreach ( GridItem item in items )
        {
            GridDataItem itm = (GridDataItem) item;

            sysUserRole obj = new sysUserRole();
            obj.NOBR = nobr;
            obj.RoleCode = itm["Code"].Text;
            urRepo.Add(obj);        
        }

        urRepo.Save();
       
        setCache();
        gvUserRole.Rebind();

        RadAjaxPanel1.Alert("完成");
        gvUserRole.SelectedIndexes.Clear();
    }
    protected void gvNobr_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        if ( Session[SessionName] == null )
            setCache();

        List<BASE> list = Session[SessionName] as List<BASE>;

        gvNobr.DataSource = (from c in list
                             select new
                             {
                                 c.NOBR ,
                                 c.NAME_C ,
                                 c.BASETTS[0].DEPT1.D_NAME ,
                                 c.BASETTS[0].JOB1.JOB_NAME
                             }).ToList();
    }

    private void setCache()
    {
        List<BASE> list = baseRepo.GetHiredEmp_Dlo(DateTime.Now.Date);
        Session[SessionName] = list;
    }

    protected void gvUserRole_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.InitialLoad)
        {
            sysRole_Repo roleRepo = new sysRole_Repo();
            if (Juser.IsInRole("1"))
                gvUserRole.DataSource = roleRepo.GetAll();
            else
                gvUserRole.DataSource = roleRepo.GetVisibleRole();
        }
    }
}