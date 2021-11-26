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

public partial class PostMain : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		switch(rbnSearchType.SelectedValue) {
			case "1":
				if(grdMain.DataSourceID != "ObjectDataSource1") grdMain.DataSourceID = "ObjectDataSource1";
				break;
			case "2":
				if(grdMain.DataSourceID != "ObjectDataSource2") grdMain.DataSourceID = "ObjectDataSource2";
				break;
			default:
				if(grdMain.DataSourceID != "ObjectDataSource3") grdMain.DataSourceID = "ObjectDataSource3";
				break;
		}
		grdMain.DataBind();
    }

	protected void grdMain_RowDataBound(object sender, GridViewRowEventArgs e) {
		if(e.Row.DataItem != null) {
			ezClientDS.PostMainRow rowPostMain = (ezClientDS.PostMainRow)((DataRowView)e.Row.DataItem).Row;
			Control ctrl = null;
			ctrl = e.Row.FindControl("imgFlag");
			if(ctrl != null) {
				Image imgFlag = (Image)ctrl;
				if(rowPostMain.isTop) imgFlag.ImageUrl = "images/i7.gif";
				else imgFlag.ImageUrl = "images/i1.gif";
			}

			ctrl = e.Row.FindControl("lbAuthor");
			if(ctrl != null) {
				Label lbAuthor = (Label)ctrl;
				ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowPostMain.Emp_id);
				if(dtEmp.Count > 0) {
					lbAuthor.Text = "by " + dtEmp[0].name + "<br>" + rowPostMain.adate.ToString("yyyy-MM-dd HH:mm");
					if(!dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
						lbAuthor.Text = "<a href='mailto:" + dtEmp[0].email + "'>" + lbAuthor.Text + "</a>";
					}
				}
			}

			ctrl = e.Row.FindControl("lbCount");
			if(ctrl != null) {
				Label lbCount = (Label)ctrl;
				object Count = Module.adPostDetail.CountQuery(rowPostMain.auto);
				if(Count == null || Convert.ToInt32(Count) == 0) Count = 0;
				else Count = Convert.ToInt32(Count) - 1;
				lbCount.Text = Count.ToString();
			}

			ezClientDS.PostDetailDataTable dtPostDetail = Module.adPostDetail.GetDataByPostMain(rowPostMain.auto);
			if(dtPostDetail.Count > 1) {
				ctrl = e.Row.FindControl("lbReply");
				if(ctrl != null) {
					Label lbReply = (Label)ctrl;
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtPostDetail[dtPostDetail.Count - 1].Emp_id);
					if(dtEmp.Count > 0) {
						lbReply.Text = "by " + dtEmp[0].name + "<BR>" + dtPostDetail[dtPostDetail.Count - 1].adate.ToString("yyyy-MM-dd HH:mm");
						if(!dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
							lbReply.Text = "<a href='mailto:" + dtEmp[0].email + "'>" + lbReply.Text + "</a>";
						}
					}
				}
			}
		}
	}
	
	protected void bnNewPost_Click(object sender, EventArgs e) {
		Response.Redirect("Post.aspx?Flag=New&BoardList_auto=" + Request["BoardList_auto"] + "&PostDetail_auto=0");
	}
}
