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
    public partial class ManageMailTplStatement : WebPageBase
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

                LoadData(lblAutoKey.Text);
            }
        }

        public void LoadData(string Key)
        {
            var AutoKey = Key.Length > 0 ? Convert.ToInt32(Key) : 0;
            var r = dcShare.ShareMailTpl.FirstOrDefault(p => p.AutoKey == AutoKey);

            if (r != null)
            {
                txtStatement.Text = r.Statement;
            }
            else
                btnSave.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var AutoKey = Convert.ToInt32(lblAutoKey.Text);

            var Statement = txtStatement.Text;

            if (Statement.Length == 0)
            {
                lblMsg.Text = "語句不可以空白";
                return;
            }

            var r = (from c in dcShare.ShareMailTpl
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            r.Statement = Statement;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcShare.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存樣版陳述式", "", _User.UserCode);

            Response.Redirect("ManageMailTpl.aspx");
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