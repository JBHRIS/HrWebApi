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
    public partial class ManageShareDefaultEdit : WebPageBase
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
            var rs = oMainDao.ShareCodeTextValue("ShareDefault");
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

            var r = (from c in dcShare.ShareDefault
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                ControlGetSet.SetDropDownList(ddlGroup, r.GroupCode);
                txtName.Text = r.Name;
                txtFieldKey.Text = r.FieldKey;
                txtFieldValue.Text = r.FieldValue;
                txtNote.Text = r.Note;

                txtFieldKey.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcShare.ShareDefault
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var GroupCode = ddlGroup.SelectedItem.Value;
            var Name = txtName.Text;
            var FieldKey = txtFieldKey.Text;
            var FieldValue = txtFieldValue.Text;
            var Note = txtNote.Text;
            var SystemUse = false;
            var Sort = 9;

            if (Name.Length == 0)
            {
                lblMsg.Text = "說明為必填欄位";
                return;
            }

            if (FieldKey.Length == 0)
            {
                lblMsg.Text = "程式對應名稱為必填欄位";
                return;
            }

            if (AutoKey == -1)
            {
                if (dcShare.ShareDefault.Any(c => c.FieldKey == FieldKey))
                {
                    lblMsg.Text = "資料重複，請重新輸入";
                    return;
                }
            }

            if (r == null)
            {
                r = new ShareDefault();
                r.SystemCode = oMainDao._SystemCode;
                r.Code = Guid.NewGuid().ToString();
                r.ColumnTypeCode = "System.String";
                r.FieldKey = FieldKey;
                r.FormTypeCode = "None";
                r.SystemUse = SystemUse;
                r.Status = "1";
                r.Sort = Sort;
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;
                dcShare.ShareDefault.InsertOnSubmit(r);
            }
         
            r.GroupCode = GroupCode;
            r.Name = Name;           
            r.FieldValue = FieldValue; 
            r.Note = txtNote.Text;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcShare.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存系統共用參數", "", _User.UserCode);

            Response.Redirect("ManageShareDefault.aspx");
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