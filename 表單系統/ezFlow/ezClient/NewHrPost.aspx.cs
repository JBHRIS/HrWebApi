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

public partial class NewHrPost : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		txtContent.UseBROnCarriageReturn = true;
    }
	protected void bnSend_Click(object sender, EventArgs e) {
		if(txtCaption.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('請填寫主旨');", true);
			}
			return;
		}
		if(txtContent.Value.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "ErrorMsg")) {
				Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('請填寫內容');", true);
			}
			return;
		}

		ezClientDS.HrPostDataTable dtHrPost = new ezClientDS.HrPostDataTable();
		ezClientDS.HrPostRow rowHrPost = dtHrPost.NewHrPostRow();
		rowHrPost.caption = txtCaption.Text;
		rowHrPost.content = txtContent.Value;
		rowHrPost.adate = DateTime.Now;
		rowHrPost.Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
		dtHrPost.AddHrPostRow(rowHrPost);
		Module.adHrPost.Update(dtHrPost);

		txtCaption.Text = "";
		txtContent.Value = "";

		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "SuccessMsg")) {
			Page.ClientScript.RegisterStartupScript(typeof(string), "ErrorMsg", "alert('張貼完成');", true);
		}
		return;
	}
}
