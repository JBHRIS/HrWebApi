using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageMailTpl : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlKey1_DataBind();
            }
        }

        public void ddlKey1_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("SystemCate");

            ddlKey1.DataSource = rs;
            ddlKey1.DataTextField = "Text";
            ddlKey1.DataValueField = "Value";
            ddlKey1.DataBind();
        }

        protected void ddlKey1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            lvMain.Rebind();
        }

        public void _DataBind()
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ddlKey1.SelectedItem == null)
                return;

            var Key1 = ddlKey1.SelectedItem.Value;

            var rs = (from c in dcShare.ShareMailTpl
                      where c.SystemCode == Key1 || c.SystemCode == "Share"
                      select c).ToList();

            //處理html
            foreach (var r in rs)
            {
                r.Subject = HtmlToText.ConvertHtml(r.Subject);
                r.Body = HtmlToText.ConvertHtml(r.Body);
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ShareMailTpl");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = Guid.NewGuid().ToString() + ".xls";

            Byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));
            stream.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            var Key1 = ddlKey1.SelectedItem.Value;

            var rs = (from c in dcShare.ShareMailTpl
                      where c.Key1 == Key1
                      select c).ToList();

            //命名主鍵名稱 以數字增加
            string FieldKey = "Code";
            int Key = 1;
            int KeyTemp = 1;
            var rsTemp = rs.Where(p => p.Code.IndexOf(FieldKey) >= 0).ToList();
            if (rsTemp.Count > 0)
            {
                foreach (var rTemp in rsTemp)
                {
                    int.TryParse(rTemp.Code.Replace(FieldKey, ""), out KeyTemp);
                    if (KeyTemp >= Key)
                        Key = KeyTemp + 1;
                }
            }

            int Sort = 5;
            if (rs.Count > 0)
                Sort = rs.Max(p => p.Sort) + 5;

            FieldKey += Key.ToString();

            var r = new ShareMailTpl();
            r.SystemCode = WebPage._SystemCode;
            r.Key1 = Key1;
            r.Key2 = "";
            r.Key3 = "";
            r.Code = FieldKey;
            r.Name = "名稱";
            r.Statement = "";
            r.Subject = "主旨";
            r.Body = "內容";
            r.Note = "";
            r.Sort = Sort;
            r.Status = "1";
            r.InsertMan = _User.UserCode;
            r.InsertDate = DateTime.Now;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;
            dcShare.ShareMailTpl.InsertOnSubmit(r);

            dcShare.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-新增信件樣版", "", _User.UserCode);

            lvMain.Rebind();
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (ddlKey1.SelectedItem == null)
                return;

            var Key1 = ddlKey1.SelectedItem.Value;

            var rs = (from c in dcShare.ShareMailTpl
                      where c.SystemCode == Key1 || c.SystemCode == "Share"
                      select c).ToList();

            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            var Key1 = ddlKey1.SelectedItem.Value;

            if (cn == "Save")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var txtCode = item.FindControl("txtCode") as RadTextBox;
                var txtName = item.FindControl("txtName") as RadTextBox;

                var r = (from c in dcShare.ShareMailTpl
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                if (r != null)
                {
                    var rs = (from c in dcShare.ShareMailTpl
                              where c.Key1 == Key1
                              select c).ToList();

                    var Code = txtCode.Text.Trim();

                    if (Code.Length == 0)
                    {
                        lblMsg.Text = "代碼空白";
                        return;
                    }

                    if (rs.Any(p => p.AutoKey != AutoKey && p.Code == Code))
                    {
                        lblMsg.Text = "代碼重覆";
                        return;
                    }

                    r.Code = Code;
                    r.Name = txtName.Text;
                    r.UpdateMan = _User.UserCode;
                    r.UpdateDate = DateTime.Now;

                    dcShare.SubmitChanges();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存信件樣版", "", _User.UserCode);

                    lblMsg.Text = "修改成功";

                    lvMain.Rebind();
                }
            }
            else if (cn == "Statement")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageMailTplStatement.aspx?AutoKey=" + AutoKey);
            }
            else if (cn == "Body")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageMailTplBody.aspx?AutoKey=" + AutoKey);
            }
            else if (cn == "View")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageMailTplView.aspx?AutoKey=" + AutoKey);
            }
            else if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcShare.ShareMailTpl
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcShare.ShareMailTpl.DeleteOnSubmit(r);
                dcShare.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-刪除信件樣版", "", _User.UserCode);

                lblMsg.Text = "刪除成功";

                lvMain.Rebind();
            }

        }
    }
}