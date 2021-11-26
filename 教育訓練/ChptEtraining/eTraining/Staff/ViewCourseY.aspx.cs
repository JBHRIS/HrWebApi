using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eTraining_Staff_ViewCourseY : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !IsPostBack )
        {
            DoHelper doHelper = new DoHelper();
            doHelper.setCbYear(cbxYear);
        }
    }
    protected void sdsGv_Selecting(object sender , SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = User.Identity.Name;
    }
    protected void cbxYear_SelectedIndexChanged(object sender , Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }
    protected void gv_SelectedIndexChanged(object sender , EventArgs e)
    {
        GridDataItem item = gv.SelectedItems[0] as GridDataItem;
        lblClassID.Text = item["ClassID"].Text;
        gvMaterial.Rebind();
    }
}