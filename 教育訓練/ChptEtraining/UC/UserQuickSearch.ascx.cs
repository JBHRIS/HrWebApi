using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;

public partial class UC_UserQuickSearch : System.Web.UI.UserControl
{
    public delegate void SelectedEventHandler(string nobr, GridDataItem sItem);
    public event SelectedEventHandler sHandler;
    private BASE_Repo baseRepo = new BASE_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearchNobr_Click(object sender, EventArgs e)
    {
        gvNobr.Rebind();
        txtName.Focus();
    }
    protected void gvNobr_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sHandler != null)
        {
            sHandler(gvNobr.SelectedValue.ToString(), gvNobr.SelectedItems[0] as GridDataItem);
        }
    }
    protected void gvNobr_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {

        gvNobr.DataSource = (from c in baseRepo.GetHiredEmpBySeachKey_DLO(txtName.Text)
                             select new
                             {
                                 Nobr = c.NOBR 
                                 ,DeptName = c.BASETTS[0].DEPT1.D_NAME
                                 ,NAME_C = c.NOBR + c.NAME_C 
                                 ,JobName = c.BASETTS[0].JOB1.JOB_NAME
                             }
                             ).ToList();
    }
}