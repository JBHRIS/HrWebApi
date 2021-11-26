using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class test6 : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RadWindow1.VisibleOnPageLoad = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //AlertMsg("test");
        RadWindow1.VisibleOnPageLoad = true;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        NotifyMsgFacade nmf = new NotifyMsgFacade();
        var a=nmf.GetMsg(new DateTime(2013, 7, 23), new DateTime(2013, 7, 24), "0055211", NotifyTargetTypeEnum.Emp);


    }
}