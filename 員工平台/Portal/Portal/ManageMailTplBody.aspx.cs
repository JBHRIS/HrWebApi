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
    public partial class ManageMailTplBody : WebPageBase
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

                DropdownColumn();
                LoadData(lblAutoKey.Text);
            }
        }

        private void DropdownColumn()
        {
            //add a new Toolbar dynamically
            EditorToolGroup dynamicToolbar = new EditorToolGroup();
            txtBody.Tools.Add(dynamicToolbar);
            txtSubject.Tools.Add(dynamicToolbar);
            //add a custom dropdown and set its items and dimension attributes
            EditorDropDown ddn = new EditorDropDown("Columns");
            ddn.Text = "插入欄位...";

            //Set the popup width and height
            ddn.Attributes["width"] = "110px";
            ddn.Attributes["popupwidth"] = "240px";
            ddn.Attributes["popupheight"] = "100px";
            //Add items
            var AutoKey = lblAutoKey.Text.Length > 0 ? Convert.ToInt32(lblAutoKey.Text) : 0;

            var r = dcShare.ShareMailTpl.FirstOrDefault(p => p.AutoKey == AutoKey);
            if (r != null)
            {
                string sqlString = r.Statement.Trim();
                if (sqlString.Length > 0)
                {
                    List<SqlParameter> ListParameter = new List<SqlParameter>();

                    var arr = sqlString.Split(' ').Where(p => p.IndexOf("@") >= 0).ToList();
                    foreach (var s in arr)
                    {
                        var ss = s.Replace("(", "");
                        ss = ss.Replace(")", "");
                        //sqlString = sqlString.Replace(ss, "''");
                        ListParameter.Add(new SqlParameter(ss, ""));
                    }

                    SqlConnection conn = new SqlConnection(dcMain.Connection.ConnectionString);
                    var dt = SqlTools.GetSqlDataTableColumn(conn, sqlString, ListParameter);

                    foreach (DataColumn dc in dt.Columns)
                        ddn.Items.Add(dc.ColumnName, dc.ColumnName);
                }
            }

            //載入系統預設的定義
            var rs = oMainDao.ShareCodeTextValue("MailVarDefine");
            foreach (var r1 in rs)
                ddn.Items.Add(r1.Text, r1.Value);

            //Add tool to toolbar
            dynamicToolbar.Tools.Add(ddn);
        }

        public void LoadData(string Key)
        {
            var AutoKey = Key.Length > 0 ? Convert.ToInt32(Key) : 0;
            var r = dcShare.ShareMailTpl.FirstOrDefault(p => p.AutoKey == AutoKey);

            if (r != null)
            {
                txtSubject.Content = r.Subject;
                txtBody.Content = r.Body;
            }
            else
                btnSave.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var AutoKey = Convert.ToInt32(lblAutoKey.Text);

            string Subject = txtSubject.Text;
            string Body = txtBody.Content;

            if (Subject.Length == 0)
            {
                lblMsg.Text = "主旨不可以空白";
                return;
            }

            var r = (from c in dcShare.ShareMailTpl
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            r.Subject = Subject;
            r.Body = Body;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcShare.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存樣版內容", "", _User.UserCode);

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