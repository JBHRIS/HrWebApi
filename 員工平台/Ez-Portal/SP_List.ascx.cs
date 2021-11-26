using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SP_List :JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (JbUser.NOBR.Trim().Equals("902852") )
        {
            FIELDSET1.Visible = true;
        }
        else
        {
            FIELDSET1.Visible = false;
        }



    }
}
