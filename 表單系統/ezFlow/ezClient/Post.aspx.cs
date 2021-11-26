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

public partial class Post : System.Web.UI.Page
{
	int BoardList_auto, PostDetail_auto;
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		BoardList_auto = Convert.ToInt32(Request["BoardList_auto"]);
		PostDetail_auto = Convert.ToInt32(Request["PostDetail_auto"]);
		txtContent.UseBROnCarriageReturn = true;		

		if(!this.IsPostBack) {
			ViewState["PostMain_auto"] = 0;
			ViewState["GoBack"] = Request.UrlReferrer.OriginalString;

			txtSubject.Enabled = true;

			if(PostDetail_auto != 0) {
				ezClientDS.PostDetailDataTable dtPostDetail = Module.adPostDetail.GetDataByAuto(PostDetail_auto);
				if(dtPostDetail.Count > 0) {
					ViewState["PostMain_auto"] = dtPostDetail[0].PostMain_auto;
					ezClientDS.PostMainDataTable dtPostMain = Module.adPostMain.GetDataByAuto(dtPostDetail[0].PostMain_auto);
					if(dtPostMain.Count > 0) {
						txtSubject.Text = "RE:" + dtPostMain[0].subject;
						txtSubject.Enabled = false;						

						if(Request["Flag"] == "Reply") {
							ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtPostDetail[0].Emp_id);
							string EmpName = "";
							if(dtEmp.Count > 0) EmpName = dtEmp[0].name;
							txtContent.Value = "<br><center><table border='0' cellpadding='0' cellspacing='0' width='90%' bgcolor='#ffeeeb' style='border-right: #ff99cc 1px solid; border-top: #ff99cc 1px solid; border-left: #ff99cc 1px solid; border-bottom: #ff99cc 1px solid; font-size: 10pt;'><tr><td>" +
								"<strong>" + EmpName + "&nbsp;寫到：</strong><br>" +
								dtPostDetail[0].content +
								"</td></tr></table></center><br>";
						}
						else {							
							txtContent.Value = "";
						}
					}
				}
			}			
		}
    }

	protected void bnCancel_Click(object sender, EventArgs e) {
		Response.Redirect(ViewState["GoBack"].ToString());
	}

	protected void bnSave_Click(object sender, EventArgs e) {
		DateTime adate = DateTime.Now;
		if(txtSubject.Enabled) {
			ezClientDS.PostMainDataTable dtPostMain = new ezClientDS.PostMainDataTable();
			ezClientDS.PostMainRow rowPostMain = dtPostMain.NewPostMainRow();
			rowPostMain.BoardList_auto = BoardList_auto;
			rowPostMain.subject = txtSubject.Text;
			rowPostMain.Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
			rowPostMain.adate = adate;
			rowPostMain.isTop = false;
			if(RadioButton1.Checked) rowPostMain.moodType = 1;
			if(RadioButton2.Checked) rowPostMain.moodType = 2;
			if(RadioButton3.Checked) rowPostMain.moodType = 3;
			if(RadioButton4.Checked) rowPostMain.moodType = 4;
			if(RadioButton5.Checked) rowPostMain.moodType = 5;
			if(RadioButton6.Checked) rowPostMain.moodType = 6;
			dtPostMain.AddPostMainRow(rowPostMain);
			Module.adPostMain.Update(dtPostMain);
			ViewState["PostMain_auto"] = rowPostMain.auto;
		}
		if(Request["Flag"] == "New" || Request["Flag"] == "Reply" || Request["Flag"] == "ReplyEmpty") {
			ezClientDS.PostDetailDataTable dtPostDetail = new ezClientDS.PostDetailDataTable();
			ezClientDS.PostDetailRow rowPostDetail = dtPostDetail.NewPostDetailRow();
			rowPostDetail.PostMain_auto = Convert.ToInt32(ViewState["PostMain_auto"]);
			rowPostDetail.content = txtContent.Value;
			rowPostDetail.Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
			rowPostDetail.adate = adate;
			if(RadioButton1.Checked) rowPostDetail.moodType = 1;
			if(RadioButton2.Checked) rowPostDetail.moodType = 2;
			if(RadioButton3.Checked) rowPostDetail.moodType = 3;
			if(RadioButton4.Checked) rowPostDetail.moodType = 4;
			if(RadioButton5.Checked) rowPostDetail.moodType = 5;
			if(RadioButton6.Checked) rowPostDetail.moodType = 6;
			dtPostDetail.AddPostDetailRow(rowPostDetail);
			Module.adPostDetail.Update(dtPostDetail);
		}
		if(Request["Flag"] == "Edit") {
			ezClientDS.PostDetailDataTable dtPostDetail = Module.adPostDetail.GetDataByAuto(Convert.ToInt32(Request["PostDetail_auto"]));
			ezClientDS.PostDetailRow rowPostDetail = dtPostDetail[0];
			rowPostDetail.PostMain_auto = Convert.ToInt32(ViewState["PostMain_auto"]);
			if(Request.Cookies["ezFlow"]["Emp_id"].ToString() == rowPostDetail.Emp_id) rowPostDetail.content = txtContent.Value;
			else {
				rowPostDetail.content = "<B>板主於 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + " 做以下發言：</B><BR>" +
					"<Table Width='90%' border='0' cellpadding='0' cellspacing='0'>" +
					"<TR><TD style='border-top: #000000 1px solid; border-bottom: #000000 1px solid;" +
					"border-right: #000000 1px solid; border-left: #000000 1px solid'>" +
					txtContent.Value + "</TD></TR></Table><BR><BR>(以下為原文)<HR>" + rowPostDetail.content;
			}			
			if(RadioButton1.Checked) rowPostDetail.moodType = 1;
			if(RadioButton2.Checked) rowPostDetail.moodType = 2;
			if(RadioButton3.Checked) rowPostDetail.moodType = 3;
			if(RadioButton4.Checked) rowPostDetail.moodType = 4;
			if(RadioButton5.Checked) rowPostDetail.moodType = 5;
			if(RadioButton6.Checked) rowPostDetail.moodType = 6;			
			Module.adPostDetail.Update(dtPostDetail);
		}

		if(Request["PostDetail_auto"] == "0") Response.Redirect("PostDetail.aspx?PostMain_auto=" + ViewState["PostMain_auto"].ToString());
		else Response.Redirect(ViewState["GoBack"].ToString());
	}
}
