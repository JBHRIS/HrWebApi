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
    public partial class ManageShareCodeEdit : WebPageBase
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

                ddlGroup_DataBind();
                _DataBind();

                LoadData(lblAutoKey.Text);
            }
        }

        public void ddlGroup_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("ShareCode");
            ddlGroup.DataSource = rs;
            ddlGroup.DataTextField = "Text";
            ddlGroup.DataValueField = "Value";
            ddlGroup.DataBind();
        }


        public void _DataBind()
        {

        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcShare.ShareCode
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                ControlGetSet.SetDropDownList(ddlGroup, r.GroupCode);
                txtKey1.Text = r.Key1;
                txtCode.Text = r.Code;
                txtName.Text = r.Name;
                txtSort.Text = r.Sort.ToString();
                txtColumn1.Text = r.Column1;
                txtNote.Text = r.Note;

                txtCode.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcShare.ShareCode
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var GroupCode = ddlGroup.SelectedItem.Value;
            var Key1 = txtKey1.Text;
            var Code = txtCode.Text;
            var Name = txtName.Text;
            var Column1 = txtColumn1.Text;
            var Note = txtNote.Text;
            var SystemUse = false;
            var Sort = txtSort.Text.ParseInt(99);

            if (Code.Length == 0)
            {
                lblMsg.Text = "代碼為必填欄位";
                return;
            }

            if (Name.Length == 0)
            {
                lblMsg.Text = "名稱為必填欄位";
                return;
            }

            if (AutoKey == -1)
            {
                if (dcShare.ShareCode.Any(c => c.Code == Code))
                {
                    lblMsg.Text = "資料重複，請重新輸入";
                    return;
                }
            }

            if (r == null)
            {
                r = new ShareCode();
                r.SystemCode = oMainDao._SystemCode;
                r.Code = Code;
                r.SystemUse = SystemUse;
                r.Status = "1";
                r.Sort = Sort;
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;

                r.Key2 = "";
                r.Key3 = "";
                r.Column2 = "";
                r.Column3 = "";
                dcShare.ShareCode.InsertOnSubmit(r);
            }

            r.GroupCode = GroupCode;
            r.Name = Name;
            r.Key1 = Key1;
            r.Column1 = Column1;
            r.Note = txtNote.Text;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcShare.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存系統共用代碼", "", _User.UserCode);

            Response.Redirect("ManageShareCode.aspx");
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