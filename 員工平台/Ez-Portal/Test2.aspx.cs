using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Test2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ShowWindow.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ShowWindow.Visible = true;
        //HtmlControl iframe1 = (HtmlControl)this.FindControl("ifm1");

        ifm1.Attributes["src"] = "http://www.jbjob.com.tw";
    }
}
