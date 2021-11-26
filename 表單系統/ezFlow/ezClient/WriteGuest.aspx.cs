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

public partial class WriteGuest : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		txtContent.UseBROnCarriageReturn = true;

		if(!this.IsPostBack) {
			ViewState["Check"] = false;			
		}
    }

	protected void txtName_TextChanged(object sender, EventArgs e) {
		ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataBySearch(txtName.Text);
		if(dtEmp.Count == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "EmpCheck"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "EmpCheck", "alert('查無此人，請重新確認。');", true);
			ViewState["Check"] = false;
		}
		else {
			ViewState["Check"] = true;
			ViewState["Emp_idTo"] = dtEmp[0].id;
			txtName.Text = dtEmp[0].name;
		}
	}

	protected void bnSend_Click(object sender, EventArgs e) {
		if(Convert.ToBoolean(ViewState["Check"])) {
			if(Request.Cookies["ezFlow"]["Emp_id"].ToString() == ViewState["Emp_idTo"].ToString()) {
				if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "DontSend"))
					Page.ClientScript.RegisterStartupScript(typeof(string), "DontSend", "alert('不能留言給自己');", true);
				return;
			}
			ezClientDS.GuestMsgDataTable dtGuestMsg = new ezClientDS.GuestMsgDataTable();
			ezClientDS.GuestMsgRow rowGuestMsg = dtGuestMsg.NewGuestMsgRow();
			rowGuestMsg.Emp_idFrom = Request.Cookies["ezFlow"]["Emp_id"].ToString();
			rowGuestMsg.Emp_idTo = ViewState["Emp_idTo"].ToString();
			rowGuestMsg.adate = DateTime.Now;
			rowGuestMsg.note = txtContent.Value;
			rowGuestMsg.isRead = false;
			dtGuestMsg.AddGuestMsgRow(rowGuestMsg);
			Module.adGuestMsg.Update(dtGuestMsg);

			txtName.Text = "";
			txtContent.Value = "";

			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "Finish"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "Finish", "alert('留言已成功送出');", true);
		}
		else {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "Error"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "Error", "alert('查無此人，請重新確認。');", true);
		}
	}
}
