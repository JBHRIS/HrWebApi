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

public partial class NewBoard : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e) {
		if(e.Item.ItemType == ListItemType.Header) {
			ezClientDS.BoardApplyDataTable dtBoardApply = Module.adBoardApply.GetData();
			if(dtBoardApply.Count > 0) ((Label)e.Item.FindControl("lbNon")).Visible = false;
		}

		if(e.Item.DataItem != null) {
			ezClientDS.SysAdminDataTable dtSysAdmin = Module.adSysAdmin.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
			if(dtSysAdmin.Count == 0) ((Button)e.Item.FindControl("bnCreate")).Visible = false;

			ezClientDS.BoardApplyRow rowBoardApply = (ezClientDS.BoardApplyRow)((DataRowView)e.Item.DataItem).Row;			
			if(!rowBoardApply.IsEmp_idAdmin1Null() && rowBoardApply.Emp_idAdmin1.Trim().Length > 0) {
				ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowBoardApply.Emp_idAdmin1);
				if(dtEmp.Count > 0) ((Label)e.Item.FindControl("lbAdmin")).Text = dtEmp[0].name;
				if(!rowBoardApply.IsEmp_idAdmin2Null() && rowBoardApply.Emp_idAdmin2.Trim().Length > 0) {
					dtEmp = Module.adEmp.GetDataById(rowBoardApply.Emp_idAdmin2);
					if(dtEmp.Count > 0) ((Label)e.Item.FindControl("lbAdmin")).Text += "," + dtEmp[0].name;
				}
			}

			ezClientDS.BoardApplySignDataTable dtBoardApplySign = Module.adBoardApplySign.GetDataByBoardApply(rowBoardApply.auto);
			for(int i = 0; i < dtBoardApplySign.Count; i++) {
				ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtBoardApplySign[i].Emp_id);
				if(dtEmp.Count > 0) {
					if(i > 0) ((Label)e.Item.FindControl("lbAll")).Text += ",";
					((Label)e.Item.FindControl("lbAll")).Text += dtEmp[0].name;
				}
			}
		}
	}
	
	protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
		ezClientDS.BoardApplyDataTable dtBoardApply = Module.adBoardApply.GetDataByAuto(Convert.ToInt32(e.CommandArgument));
		ezClientDS.BoardApplyRow rowBoardApply = dtBoardApply[0];

		if(e.CommandName == "Create") {
			ezClientDS.BoardListDataTable dtBoardList = new ezClientDS.BoardListDataTable();
			ezClientDS.BoardListRow rowBoardList = dtBoardList.NewBoardListRow();
			rowBoardList.caption = rowBoardApply.boardName;
			rowBoardList.note = rowBoardApply.boardNote;
			rowBoardList.Emp_idAdmin1 = rowBoardApply.Emp_idAdmin1;
			rowBoardList.Emp_idAdmin2 = rowBoardApply.Emp_idAdmin2;
			dtBoardList.AddBoardListRow(rowBoardList);
			Module.adBoardList.Update(dtBoardList);

			ezClientDS.BoardApplySignDataTable dtBoardApplySign = Module.adBoardApplySign.GetDataByBoardApply(rowBoardApply.auto);
			for(int i = 0; i < dtBoardApplySign.Count; i++) dtBoardApplySign[i].Delete();
			Module.adBoardApplySign.Update(dtBoardApplySign);

			rowBoardApply.Delete();
			Module.adBoardApply.Update(rowBoardApply);

			DataList1.DataBind();
		}

		if(e.CommandName == "Sign") {			
			ezClientDS.BoardApplySignDataTable dtBoardApplySign = Module.adBoardApplySign.GetDataByOne(rowBoardApply.auto, Request.Cookies["ezFlow"]["Emp_id"].ToString());
			if(dtBoardApplySign.Count > 0) {
				if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
					Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請勿重覆連署');", true);
				return;
			}

			ezClientDS.BoardApplySignRow rowBoardApplySign = dtBoardApplySign.NewBoardApplySignRow();
			rowBoardApplySign.BoardApply_auto = rowBoardApply.auto;
			rowBoardApplySign.Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
			dtBoardApplySign.AddBoardApplySignRow(rowBoardApplySign);
			Module.adBoardApplySign.Update(dtBoardApplySign);

			DataList1.DataBind();
		}
	}
}
