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
 
using System.Collections.Generic;

public partial class Templet_TRContral : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _month = DateTime.Now.Month;
            if (_month < 4)
                lb_datee.Text = Convert.ToString(DateTime.Now.Year) + "/3/31";
            else if (_month < 7)
                lb_datee.Text = Convert.ToString(DateTime.Now.Year) + "/6/30";
            else if (_month < 10)
                lb_datee.Text = Convert.ToString(DateTime.Now.Year) + "/9/30";
            else
                lb_datee.Text = Convert.ToString(DateTime.Now.Year) + "/12/31";
        }
    }
}
