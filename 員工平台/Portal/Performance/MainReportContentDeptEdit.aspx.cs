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
    public partial class MainReportContentDeptEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAutoKey.Text = "";
                if (Request.QueryString["AutoKey"] == null || Request.QueryString["ColumnName"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                }
                else
                {
                    lblAutoKey.Text = (string)UnobtrusiveSession.Session["AutoKey"];
                    lblColumnName.Text = Request.QueryString["ColumnName"].ToString();

                    lblTitle.Text = lblColumnName.Text == "Type" ? "指標" : "參考指標";
                }

                LoadData(lblAutoKey.Text);
            }
        }

        public void LoadData(string Key)
        {
            var AutoKey = Key.Length > 0 ? Convert.ToInt32(Key) : 0;
            var r = dcMain.PerformanceReportContentDept.FirstOrDefault(p => p.AutoKey == AutoKey);

            if (r != null)
            {
                txtBody.Content = lblColumnName.Text == "Type" ? r.ContentTargetType : r.ContentTargetRef;
                txtSort.Text = r.Sort.ToString();
            }
            else
                btnSave.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var AutoKey = Convert.ToInt32(lblAutoKey.Text);

            string Body = txtBody.Content;
            var Sort = txtSort.Text.ParseInt(99);

            var r = (from c in dcMain.PerformanceReportContentDept
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                if (lblColumnName.Text == "Type")
                    r.ContentTargetType = Body;
                if (lblColumnName.Text == "Ref")
                    r.ContentTargetRef = Body;

                r.Sort = Sort;
                r.UpdateMan = _User.UserCode;
                r.UpdateDate = DateTime.Now;

                dcMain.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存部門報表內容", "", _User.UserCode);

                Response.Redirect("ManageReportContent.aspx");
            }
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