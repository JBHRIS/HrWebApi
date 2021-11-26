using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_YearPlan : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMonth.Text = RadTabStrip1.SelectedTab.Value;
    }
    protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
    {
        lblMonth.Text = RadTabStrip1.SelectedTab.Value;
    }
}