using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Performance
{
    public partial class ManageShareIssueEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAutoKey.Text = "";
                if (Request.QueryString["AutoKey"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                }
                else
                    lblAutoKey.Text = (string)UnobtrusiveSession.Session["AutoKey"];

                ddlIssueType_DataBind();
                _DataBind();

                LoadData(lblAutoKey.Text);
            }
        }

        public void ddlIssueType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("IssueType");
            ddlIssueType.DataSource = rs;
            ddlIssueType.DataTextField = "Text";
            ddlIssueType.DataValueField = "Value";
            ddlIssueType.DataBind();
        }

        public void _DataBind()
        {

        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcShare.ShareIssue
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                ControlGetSet.SetDropDownList(ddlIssueType, r.IssueTypeCode);
                txtSerial.Text = r.Serial;
                txtIssueContent.Content = r.IssueContent;
                txtNote.Text = r.Note;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcShare.ShareIssue
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var IssueTypeCode = ddlIssueType.SelectedItem.Value;
            var Serial = txtSerial.Text;
            var IssueContent = txtIssueContent.Content;
            var Note = txtNote.Text;
            var Sort = 9;


            if (AutoKey == -1)
            {

            }

            if (r == null)
            {
                r = new ShareIssue();
                r.Code = Guid.NewGuid().ToString();

                r.Status = "1";
                r.Sort = Sort;
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;
                dcShare.ShareIssue.InsertOnSubmit(r);
            }

            r.IssueTypeCode = IssueTypeCode;
            r.Serial = Serial;
            r.IssueContent = IssueContent;
            r.Note = Note;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcShare.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存Issue", "", _User.UserCode);

            Response.Redirect("ManageShareIssue.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }
    }
}