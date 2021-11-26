using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class mpCourse : System.Web.UI.MasterPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title += "v1.0 by Krystal";
            SetRootValues("Root");
        }
    }

    //功能向下展開(起點)
    public void SetRootValues(string Root)
    {
        var ls = (from c in dcTraining.sysFileStructure
                  where c.sParentKey == Root
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            var mi = new RadMenuItem();
            mi.Text = r.sFileTitle;
            mi.Value = r.sKey;
            //mi.ToolTip = r.sDescription;
            if (r.sFileName != null)
                mi.NavigateUrl = "~/" + r.sPath + r.sFileName;

            SetNodeValues(mi);
            mu.Items.Add(mi);
        }
    }

    //功能向下展開
    public void SetNodeValues(RadMenuItem NodeP)
    {
        var ls = (from c in dcTraining.sysFileStructure
                  where c.sParentKey == NodeP.Value
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            var mi = new RadMenuItem();
            mi.Text = r.sFileTitle;
            mi.Value = r.sKey;
            // mi.ToolTip = r.sDescription;
            if (r.sFileName != null)
                mi.NavigateUrl = "~/" + r.sPath + r.sFileName;

            SetNodeValues(mi);
            NodeP.Items.Add(mi);
        }
    }
}
