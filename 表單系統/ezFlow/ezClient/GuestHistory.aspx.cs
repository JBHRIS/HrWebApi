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
using System.Drawing;

public partial class GuestHistory : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!this.IsPostBack) {
			if(Request["Flag"] == "All") DataList1.DataSourceID = "ObjectDataSource1";
			if(Request["Flag"] == "NotRead") DataList1.DataSourceID = "ObjectDataSource2";

			DataList1.DataBind();
		}
    }
	protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e) {
		if(e.Item.DataItem != null) {
			Control ctrl = null;
			ezClientDS.GuestMsgRow rowGuestMsg = (ezClientDS.GuestMsgRow)((DataRowView)e.Item.DataItem).Row;

			ctrl = e.Item.FindControl("lbName");
			if(ctrl != null) {
				ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowGuestMsg.Emp_idFrom);
				if(dtEmp.Count > 0) ((Label)ctrl).Text = dtEmp[0].name;
			}

			ctrl = e.Item.FindControl("lbFlag");
			if(ctrl != null) {
				if(rowGuestMsg.isRead) {
					((Label)ctrl).Text = "已閱讀";
					((Label)ctrl).ForeColor = Color.Teal;
				}
				else {
					((Label)ctrl).Text = "未閱讀";
					((Label)ctrl).ForeColor = Color.Red;
				}
			}
			ctrl = e.Item.FindControl("bnRead");
			if(ctrl != null) {
				if(rowGuestMsg.isRead) ((Button)ctrl).Enabled = false;
			}
		}
	}
	protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
		if(e.CommandName == "MsgRead") {
			ezClientDS.GuestMsgDataTable dtGuestMsg = Module.adGuestMsg.GetDataByAuto(Convert.ToInt32(e.CommandArgument));
			if(dtGuestMsg.Count > 0) {
				dtGuestMsg[0].isRead = true;
			}
			Module.adGuestMsg.Update(dtGuestMsg);
		}
		if(e.CommandName == "MsgDel") {
			ezClientDS.GuestMsgDataTable dtGuestMsg = Module.adGuestMsg.GetDataByAuto(Convert.ToInt32(e.CommandArgument));
			if(dtGuestMsg.Count > 0) {
				dtGuestMsg[0].Delete();
			}
			Module.adGuestMsg.Update(dtGuestMsg);
		}

		DataList1.DataBind();
	}
}
