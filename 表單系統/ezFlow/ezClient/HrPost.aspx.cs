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

public partial class HrPost : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		ezClientDS.HrPostDataTable dtHrPost = Module.adHrPost.GetDataByAuto(Convert.ToInt32(Request["auto"]));
		if(dtHrPost.Count > 0) {
			lbDate.Text = dtHrPost[0].adate.ToString("yyyy-MM-dd HH:mm");
			lbSubject.Text = dtHrPost[0].caption;
			lbContent.Text = dtHrPost[0].content;
		}
    }
}
