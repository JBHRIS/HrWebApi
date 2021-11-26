using Bll.PageApiVoid.Vdb;
using Dal.Dao.PageApiVoid;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;


namespace Portal
{
    public partial class AuthMenuWithApi : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                ddlPage_DataBind();
                ddlApi_DataBind();
            }
            lblMsg.Text = "";
        }
        public void LoadData(string Key = "")
        {

        }

        protected void ddlPage_DataBind()
        {
            var Value = AccessData.GetMenuList(_User,CompanySetting);

            var ListId = new Dictionary<string, int>();
            //處理代碼資料
            int i = 1;
            foreach (var rVdb in Value)
            {
                //產生id
                ListId.Add(rVdb.Code, i);
                rVdb.CodeId = i;

                i++;
            }

            foreach (var r in Value)
            {
                //將上層的代碼轉換為id
                if (ListId.ContainsKey(r.ParentCode))
                    r.ParentId = ListId[r.ParentCode];
                else
                    r.ParentId = 0;  //如果沒有找到 就以0取代
            }

            ddlPage.DataSource = Value;
            ddlPage.DataValueField = "Code";
            ddlPage.DataTextField = "FileTitle";
            ddlPage.DataFieldID = "CodeId";
            ddlPage.DataFieldParentID = "ParentId";
            ddlPage.DataBind();
        }

        protected void ddlApi_DataBind()
        {
            var rs = AccessData.GetApiList(_User,CompanySetting);
            foreach(var r in rs)
            {
                r.Name += "(" + r.Code + ")";
            }
            ddlApi.DataSource = rs;
            ddlApi.DataTextField = "Name";
            ddlApi.DataValueField = "Code";
            ddlApi.DataBind();

            //tvApi.DataSource = rs;
            //tvApi.DataTextField = "Name";
            //tvApi.DataValueField = "Code";
            //tvApi.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var Node = ddlApi.EmbeddedTree.Nodes;
            int i = 0;
            foreach (RadTreeNode r in Node)
            {
                if (r.Checked)
                {
                    var oInsertPageApiVoid = new InsertPageApiVoidDao();
                    var InsertPageApiVoidCond = new InsertPageApiVoidConditions();
                    InsertPageApiVoidCond.AccessToken = _User.AccessToken;
                    InsertPageApiVoidCond.RefreshToken = _User.RefreshToken;
                    InsertPageApiVoidCond.CompanySetting = CompanySetting;
                    InsertPageApiVoidCond.pageCode = ddlPage.SelectedValue;
                    InsertPageApiVoidCond.apiVoidCode = r.Value;
                    var Result = oInsertPageApiVoid.GetData(InsertPageApiVoidCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var rs = Result.Data as InsertPageApiVoidRow;
                            if (rs.Result)
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    var oDeletePageApiVoid = new DeletePageApiVoidDao();
                    var DeletePageApiVoidCond = new DeletePageApiVoidConditions();
                    DeletePageApiVoidCond.AccessToken = _User.AccessToken;
                    DeletePageApiVoidCond.RefreshToken = _User.RefreshToken;
                    DeletePageApiVoidCond.CompanySetting = CompanySetting;
                    DeletePageApiVoidCond.pageCode = ddlPage.SelectedValue;
                    DeletePageApiVoidCond.apiVoidCode = r.Value;
                    var Result = oDeletePageApiVoid.GetData(DeletePageApiVoidCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var rs = Result.Data as DeletePageApiVoidRow;
                            if (rs.Result)
                            {
                                i++;
                            }
                        }
                    }
                }
            }
            if (i > 0)
            {
                lblMsg.CssClass = "badge badge-primary animated shake";
                lblMsg.Text = "更新成功";
            }
            else
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "更新失敗";
            }
        }
        protected void ddlPage_EntryAdded(object sender, DropDownTreeEntryEventArgs e)
        {
            var rs = new List<PageToApiVoidViewRow>();

            ddlApi.Entries.Clear();
            var oPageToApiVoidView = new PageToApiVoidViewDao();
            var PageToApiVoidCond = new PageToApiVoidViewConditions();
            PageToApiVoidCond.AccessToken = _User.AccessToken;
            PageToApiVoidCond.RefreshToken = _User.RefreshToken;
            PageToApiVoidCond.CompanySetting = CompanySetting;
            var Result = oPageToApiVoidView.GetData(PageToApiVoidCond);
            if (Result.Status)
            { 
                if(Result.Data!=null)
                {
                    rs = Result.Data as List<PageToApiVoidViewRow>;
                    string Value = "";
                    foreach (var r in rs)
                    {
                        if (r.PageCode == ddlPage.SelectedValue)
                        {
                            foreach (var rApi in r.HaveApi)
                            {
                                Value += rApi + ",";
                            }
                        }
                    }
                    ddlApi.SelectedValue = Value;
                }
            }

            //string selectedList = "";
            //var rApiList = (from c in rs
            //               where c.Code == MenuData
            //                select c).ToList();
            //foreach (var rApi in rApiList)
            //{
            //    selectedList += rApi.Code;
            //}
            //ddlApi.SelectedValue = selectedList;
        }
    } 
}