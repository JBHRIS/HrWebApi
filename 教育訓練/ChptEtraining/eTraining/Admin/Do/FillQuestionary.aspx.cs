using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eTraining_Admin_Do_FillQuestionary : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoHelper doHelper = new DoHelper();
            doHelper.setCbYear(cbxYear);
        }

    }
    protected void sdsGv_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        //e.Command.Parameters["@nobr"].Value = User.Identity.Name;
    }
    protected void cbxYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item != null)
            {
                HyperLink hl = item["Write"].Controls[0] as HyperLink;
                if (hl != null)
                {
                    if (item["dWriteDate"].Text.Trim().Length > 0)
                    {
                        hl.Text = "已填寫";
                    }
                }
            }
        }
        //Write
    }
}