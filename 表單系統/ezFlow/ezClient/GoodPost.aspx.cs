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

public partial class GoodPost : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		ezClientDS.GoodPostDataTable dtGoodPost = Module.adGoodPost.GetDataByAuto(Convert.ToInt32(Request["GoodPost_auto"]));
		if(dtGoodPost.Count > 0) {
			lbDate.Text = dtGoodPost[0].adate.ToString("yyyy-MM-dd HH:mm");
			lbSubject.Text = dtGoodPost[0].caption;
			lbContent.Text = dtGoodPost[0].content;
		}
    }
}
