using Bll.RolePage.Vdb;
using Bll.Menu.Vdb;
using Bll.System.Vdb;
using Dal.Dao.RolePage;
using Dal.Dao.Menu;
using Bll.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design;
using Telerik.Web.UI;
using System.Text;


namespace Portal
{
    public partial class AuthRoleWithMenu : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["MenuRow"] = null;
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                ddlPage_DataBind();
                ddlRole_DataBind();

            }
        }
        public void LoadData(string Key = "")
        {

        }

        protected void ddlPage_DataBind()
        {
            var Value = AccessData.GetMenuList(_User, CompanySetting,"Menu");

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

        protected void ddlRole_DataBind()
        {
            var rs = AccessData.GetRoleList(_User, CompanySetting);

            ddlRole.DataSource = rs;
            ddlRole.DataTextField = "Name";
            ddlRole.DataValueField = "Code";
            ddlRole.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var Node = ddlPage.EmbeddedTree.Nodes;
            int i = 0;
            foreach (RadTreeNode r in Node)
            {
                //if (r.GetAllNodes().Count == 0)//如果沒下方節點
                //{
                if (r.Checked)
                {
                    var oInsertRolePage = new InsertRolePageDao();
                    var InsertRolePageCond = new InsertRolePageConditions();
                    InsertRolePageCond.AccessToken = _User.AccessToken;
                    InsertRolePageCond.RefreshToken = _User.RefreshToken;
                    InsertRolePageCond.CompanySetting = CompanySetting;
                    InsertRolePageCond.roleCode = ddlRole.SelectedValue;
                    InsertRolePageCond.pageCode = r.Value;
                    var Result = oInsertRolePage.GetData(InsertRolePageCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var rs = Result.Data as InsertRolePageRow;
                            if (rs.Result)
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    var oDeleteRolePage = new DeleteRolePageDao();
                    var DeleteRolePageCond = new DeleteRolePageConditions();
                    DeleteRolePageCond.AccessToken = _User.AccessToken;
                    DeleteRolePageCond.RefreshToken = _User.RefreshToken;
                    DeleteRolePageCond.CompanySetting = CompanySetting;
                    DeleteRolePageCond.roleCode = ddlRole.SelectedValue;
                    DeleteRolePageCond.pageCode = r.Value;
                    var Result = oDeleteRolePage.GetData(DeleteRolePageCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var rs = Result.Data as DeleteRolePageRow;
                            if (rs.Result)
                            {
                                i++;
                            }
                        }
                    }
                }
                //}
                //else
                //{
                foreach (var rsNode in r.GetAllNodes())//取得內容下方節點
                {

                    if (rsNode.Checked)
                    {
                        var oInsertRolePage = new InsertRolePageDao();
                        var InsertRolePageCond = new InsertRolePageConditions();
                        InsertRolePageCond.AccessToken = _User.AccessToken;
                        InsertRolePageCond.RefreshToken = _User.RefreshToken;
                        InsertRolePageCond.CompanySetting = CompanySetting;
                        InsertRolePageCond.roleCode = ddlRole.SelectedValue;
                        InsertRolePageCond.pageCode = rsNode.Value;
                        var Result = oInsertRolePage.GetData(InsertRolePageCond);
                        if (Result.Status)
                        {
                            if (Result.Data != null)
                            {
                                var rs = Result.Data as InsertRolePageRow;
                                if (rs.Result)
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        var oDeleteRolePage = new DeleteRolePageDao();
                        var DeleteRolePageCond = new DeleteRolePageConditions();
                        DeleteRolePageCond.AccessToken = _User.AccessToken;
                        DeleteRolePageCond.RefreshToken = _User.RefreshToken;
                        DeleteRolePageCond.roleCode = ddlRole.SelectedValue;
                        DeleteRolePageCond.pageCode = rsNode.Value;
                        var Result = oDeleteRolePage.GetData(DeleteRolePageCond);
                        if (Result.Status)
                        {
                            if (Result.Data != null)
                            {
                                var rs = Result.Data as DeleteRolePageRow;
                                if (rs.Result)
                                {
                                    i++;
                                }
                            }
                        }
                    }

                }
                //}
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
            UnobtrusiveSession.Session["MenuRow"] = null;
        }
        /// <summary>
        /// 如果將下方有節點的勾選會不管是否有權限就將下方節點勾選，此方法可避免這問題
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        protected string NodeSelect(RadTreeNode Node, List<RoleToPageViewRow> rs)
        {
            string Value = "";
            if (Node.GetAllNodes().Count == 0)//如果下方沒結點才勾選
            {
                foreach (var rsData in rs)
                {
                    var Res = (from c in rsData.HavePage
                               where c == Node.Value && rsData.RoleCode == ddlRole.SelectedValue
                               select c).FirstOrDefault();
                    Value += Res + ",";
                }
            }
            else
            {
                foreach (var rsNode in Node.GetAllNodes())//有節點將下方所有節點繼續進行
                {
                    Value += NodeSelect(rsNode, rs);
                }
            }
            return Value;
        }

        protected void ddlRole_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ddlPage.Entries.Clear();
            var oRolePage = new RoleToPageViewDao();
            var RolePageCond = new RoleToPageViewConditions();
            RolePageCond.AccessToken = _User.AccessToken;
            RolePageCond.RefreshToken = _User.RefreshToken;
            RolePageCond.CompanySetting = CompanySetting;
            var Result = oRolePage.GetData(RolePageCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var rs = Result.Data as List<RoleToPageViewRow>;
                    string Value = "";
                    var Node = ddlPage.EmbeddedTree.Nodes;

                    foreach (RadTreeNode r in Node)
                    {
                        Value = NodeSelect(r, rs);
                        //if (r.GetAllNodes().Count == 0)//如果下方沒結點才勾選
                        //{
                        //    foreach (var rsData in rs)
                        //    {
                        //        var Res = (from c in rsData.HavePage
                        //                   where c == r.Value && rsData.RoleCode == ddlRole.SelectedValue
                        //                   select c).FirstOrDefault();
                        //        Value += Res + ",";
                        //    }
                        //}
                        //else
                        //{
                        //    foreach (var rsNode in r.GetAllNodes())//第二層
                        //    {
                        //        if (rsNode.GetAllNodes().Count == 0)
                        //        {
                        //            foreach (var rsData in rs)
                        //            {
                        //                var Res = (from c in rsData.HavePage
                        //                           where c == rsNode.Value && rsData.RoleCode == ddlRole.SelectedValue
                        //                           select c).FirstOrDefault();
                        //                Value += Res + ",";
                        //            }
                        //        }
                        //        else
                        //        {
                        //            foreach (var rsNodeNode in rsNode.GetAllNodes())//第三層
                        //            {
                        //                if (rsNodeNode.GetAllNodes().Count == 0)
                        //                {
                        //                    foreach (var rsData in rs)
                        //                    {
                        //                        var Res = (from c in rsData.HavePage
                        //                                   where c == rsNode.Value && rsData.RoleCode == ddlRole.SelectedValue
                        //                                   select c).FirstOrDefault();
                        //                        Value += Res + ",";
                        //                    }
                        //                }
                        //                else
                        //                {
                        //                    foreach (var rsNodeNodeNode in rsNodeNode.GetAllNodes())//第四層
                        //                    {
                        //                        foreach (var rsData in rs)
                        //                        {
                        //                            var Res = (from c in rsData.HavePage
                        //                                       where c == rsNodeNodeNode.Value && rsData.RoleCode == ddlRole.SelectedValue
                        //                                       select c).FirstOrDefault();
                        //                            Value += Res + ",";
                        //                        }
                        //                    }

                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    //foreach (var r in rs)
                    //{
                    //    if (r.RoleCode == ddlRole.SelectedValue)
                    //    {
                    //        foreach (var rPage in r.HavePage)
                    //        {
                    //            Value += rPage + ",";
                    //            //var Node =  ddlPage.FindControl(rPage);
                    //            //if (Node != null)
                    //            //{
                    //            //    if (Node.GetAllNodes().Count == 0)
                    //            //    {
                    //            //        Node.Checked = true;
                    //            //    }
                    //            //}
                    //        }
                    //    }
                    //}
                    ddlPage.SelectedValue = Value;
                }
            }
        }
    }
}