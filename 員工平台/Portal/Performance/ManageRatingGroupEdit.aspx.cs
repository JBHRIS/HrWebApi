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
    public partial class ManageRatingGroupEdit : WebPageBase
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

                _DataBind();

                LoadData(lblAutoKey.Text);
            }
        }

        public void _DataBind()
        {

        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceRatingGroup
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                txtName.Text = r.Name;
                txtNumPerMax.Text = r.NumPerMax.ToString();
                txtNumPerMin.Text = r.NumPerMin.ToString();
                txtNumPer.Text = r.NumPer.ToString();
                txtSort.Text = r.Sort.ToString();
                txtNote.Text = r.Note;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceRatingGroup
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var Name = txtName.Text;
            var NumPerMax = txtNumPerMax.Text.ParseInt(94);
            var NumPerMin = txtNumPerMin.Text.ParseInt(65);
            var NumPer = txtNumPer.Text.ParseInt(90);
            var Sort = txtSort.Text.ParseInt(99);
            var Note = txtNote.Text;

            if (Name.Trim().Length == 0)
            {
                lblMsg.Text = "名稱為必填欄位";
                return;
            }

            if (r == null)
            {
                r = new PerformanceRatingGroup();
                r.Code = Guid.NewGuid().ToString();
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;
                dcMain.PerformanceRatingGroup.InsertOnSubmit(r);
            }

            r.Name = txtName.Text;
            r.NumPerMax = NumPerMax;
            r.NumPerMin = NumPerMin;
            r.NumPer = NumPer;
            r.Sort = txtSort.Text.ParseInt(9);
            r.Note = txtNote.Text;
            r.Num = 0;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存評等群組", "", _User.UserCode);

            Response.Redirect("ManageRatingGroup.aspx");
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