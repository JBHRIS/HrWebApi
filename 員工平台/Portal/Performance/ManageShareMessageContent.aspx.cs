using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageShareMessageContent : WebPageBase
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

                ddlHandleStatus_DataBind();
                LoadData(lblAutoKey.Text);
            }
        }

        public void ddlHandleStatus_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("HandleStatus");

            ddlHandleStatus.DataSource = rs;
            ddlHandleStatus.DataTextField = "Text";
            ddlHandleStatus.DataValueField = "Value";
            ddlHandleStatus.DataBind();
        }

        public void LoadData(string Key, int RowIndex = 0)
        {
            var AutoKey = Key.Length > 0 ? Convert.ToInt32(Key) : 0;


            var r = (from c in dcShare.ShareMessage
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                lblContents.Text = r.Contents;
                lblSystemContents.Text = r.SystemContents;
                lblAppName.Text = r.AppName;
                txtNote.Text = r.Note;
                ControlGetSet.SetDropDownList(ddlHandleStatus, r.HandleStatusCode);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var AutoKey = Convert.ToInt32(lblAutoKey.Text);

            var Note = txtNote.Text;
            var HandleStatus = ddlHandleStatus.SelectedItem.Value;

            var r = (from c in dcShare.ShareMessage
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                r.Note = Note;
                r.HandleStatusCode = HandleStatus;
                r.UpdateMan = _User.UserCode;
                r.UpdateDate = DateTime.Now;

                dcShare.SubmitChanges();
            }

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存訊息管理", "", _User.UserCode);

            Response.Redirect("ManageShareMessage.aspx");
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