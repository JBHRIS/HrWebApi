using Bll.System.Vdb;
using Bll.Tools;
using Dal.Dao.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class Main : WebPageMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var ActivePage = Request.Url;

                //var LocalPath = System.IO.Path.GetFileName(Request.PhysicalPath);
                //if (LocalPath == "Index.aspx")
                //    plSiteMap.Visible = false;

                UnobtrusiveSession.Session["ReturnUrl"] = WebPage.GetActivePage;

                if (Request.Cookies[FormsAuthentication.FormsCookieName] == null || Request.Cookies[FormsAuthentication.FormsCookieName].Value == "")
                {
                    Response.Redirect("Login.aspx?param=Logout");
                    return;    
                }

                if (_User.EmpName == "未登入")
                {
                    Response.Redirect("Login.aspx?ReturnUrl=" + ActivePage);
                }

                if (_User.LoginStatus != "1")
                    Response.Redirect("Login.aspx?ReturnUrl=" + ActivePage);
                UnobtrusiveSession.Session["SystemPage"] = null;

                LoadData();
            }

            SetRootValues();
        }

        public void _DataBind()
        {
        }

        public void LoadData(string Key = "")
        {
            //取得使用者資訊
            lblUserName.Text = _User.EmpName;
            lblUserUserGroupName.Text = _User.EmpJobName;

            //取得大頭照圖片
        }

        /// <summary>
        /// Menu層級
        /// </summary>
        /// <summary>
        /// Menu層級
        /// </summary>
        public Dictionary<int, string> MenuItemLevel
        {
            get
            {
                var ListLevel = new Dictionary<int, string>();

                var Level = "nav-second-level";
                ListLevel.Add(2, Level);

                Level = "nav-third-level";
                ListLevel.Add(3, Level);

                return ListLevel;
            }
        }

        public List<SystemPageRow> ListSystemPage
        {
            get
            {
                var Value = new List<SystemPageRow>();

                if (WebPage.DataCache && UnobtrusiveSession.Session["SystemPage"] != null)
                {
                    Value = (List<SystemPageRow>)UnobtrusiveSession.Session["SystemPage"];
                }
                else
                {
                    var oSystemPage = new SystemPageDao(WebPage.dcShare);
                    var SystemPageCond = new SystemPageConditions();
                    SystemPageCond.TypeCode = "02"; //取後台的頁面
                    var rsSystemPage = oSystemPage.GetSystemPage(SystemPageCond);
                    rsSystemPage = rsSystemPage.Where(p => p.SystemCode == "Share" || p.SystemCode == WebPage._SystemCode).ToList();

                    //調整權限
                    var ListRoleKey = Security.GetRoleKeyToBinaryKey(_User.RoleKey);

                    foreach (var rSystemPage in rsSystemPage)
                    {
                        var RoleKey = rSystemPage.RoleKey;

                        rSystemPage.IsAuth = RoleKey == 0 || Security.IsRoleValid(RoleKey, ListRoleKey);
                    }

                    Value = rsSystemPage;

                    UnobtrusiveSession.Session["SystemPage"] = Value;
                }

                return Value;
            }
        }

        public object ListUserCode { get; private set; }

        //功能向下展開(起點)
        public void SetRootValues()
        {
            var UserCode = _User.UserCode;

            var ActivePage = WebPage.GetActivePage;

            //取得頁面
            var rsSystemPage = ListSystemPage;

            //取得有權限的頁面
            rsSystemPage = rsSystemPage.Where(p => p.IsAuth).ToList();

            //清除控制項的內容
            phMenu.Controls.Clear();

            Literal ltMenu = new Literal();
            var HtmlMenu = "";

            //項目層級-數值
            int ItemLevel = 2;

            //作用頁面代碼
            var ListActivePageCode = new List<string>();
            var ActivePageCode = "";
            var rSystemPage = rsSystemPage.FirstOrDefault(p => p.FileName == ActivePage);
            if (rSystemPage != null)
            {
                ListActivePageCode = rSystemPage.PathCode.Split('/').ToList();
                ActivePageCode = rSystemPage.Code;

                lblSiteMapName.Text = rSystemPage.FileTitle;
            }

            SetNodeValues(rsSystemPage, "", ItemLevel, ListActivePageCode, ref HtmlMenu);

            //顯示 SiteMap
            smBreadcrumb_DataBind(ListSystemPage, ActivePageCode);

            ltMenu.Text = HtmlMenu;
            phMenu.Controls.Add(ltMenu);
        }

        public void smBreadcrumb_DataBind(List<SystemPageRow> ListSystemPage, string ActivePageCode)
        {
            var ListItem = new List<RadMenuItem>();
            var Item = new RadMenuItem();

            var Code = ActivePageCode;
            do
            {
                var rSystemPage = ListSystemPage.FirstOrDefault(p => p.Code == Code);
                if (rSystemPage == null)
                    break;

                Item = new RadMenuItem();
                Item.Text = rSystemPage.FileTitle;
                Item.Value = rSystemPage.Code;

                var FilePath = rSystemPage.FilePath;
                var FileName = rSystemPage.FileName;
                var LinkUrl = FilePath + FileName;

                Item.NavigateUrl = LinkUrl;

                ListItem.Insert(0, Item);

                Code = rSystemPage.ParentCode;

            } while (true);

            smBreadcrumb.DataSource = ListItem;
            smBreadcrumb.DataBind();
        }

        /// <summary>
        /// 功能向下展開
        /// </summary>
        /// <param name="ListSystemPage"></param>
        /// <param name="ParentCode">上層代碼</param>
        /// <param name="ItemLevel">層級</param>
        /// <param name="ListActivePageParentCode">作用頁面代碼</param>
        /// <param name="HtmlMenu"></param>
        private void SetNodeValues(List<SystemPageRow> ListSystemPage, string ParentCode, int ItemLevel, List<string> ListActivePageCode, ref string HtmlMenu)
        {
            var rsSystemPage = ListSystemPage.Where(p => p.ParentCode == ParentCode).OrderBy(p => p.Sort).ToList();
            foreach (var rSystemPage in rsSystemPage)
            {
                var Code = rSystemPage.Code;
                var Href = rSystemPage.Href;
                var OpenWindows = rSystemPage.OpenWindow;
                var Icon = rSystemPage.Icon;

                var RoleKey = rSystemPage.RoleKey;

                var FilePath = rSystemPage.FilePath;
                var FileName = rSystemPage.FileName;
                var LinkUrl = FilePath + FileName;
                if (!Href)
                    continue;

                var PathCode = rSystemPage.PathCode;
                var FileTitle = rSystemPage.FileTitle;

                var SubItem = ListSystemPage.Any(p => p.ParentCode == Code);

                //項目層級-轉換成文字
                var Level = "nav-second-level";
                if (MenuItemLevel.ContainsKey(ItemLevel))
                    Level = MenuItemLevel[ItemLevel];

                //作用的頁面
                var Active = "";
                var Expanded = "false";
                if (ListActivePageCode.Contains(Code))
                {
                    Active = "active";
                    Expanded = "true";
                }

                //要不要閉合功能
                var Collapse = "collapse";

                //項目的小圖案
                var ItemIcon = ItemLevel == 2 ? "fa " +Icon : "";

                if (Code != ParentCode)
                {
                    HtmlMenu += $"<li class=\"{Active}\">";

                    //有子層級 就需要繼續展開 並且超連結無法點擊
                    if (SubItem)
                    {
                        HtmlMenu += $"<a href=\"{LinkUrl}\" aria-expanded=\"{Expanded}\"><i class=\"{ItemIcon}\"></i> <span class=\"nav-label\">{FileTitle}</span><span class=\"fa arrow\"></span></a>";
                        HtmlMenu += $"<ul class=\"nav {Level} {Collapse}\" aria-expanded=\"{Expanded}\">";

                        SetNodeValues(ListSystemPage, Code, (ItemLevel + 1), ListActivePageCode, ref HtmlMenu);

                        HtmlMenu += "</ul>";
                    }
                    else
                    {
                        if (ItemLevel == 2) //只有第二層與其它層不太一樣
                            HtmlMenu += $"<a href=\"{LinkUrl}\"><i class=\"{ItemIcon}\"></i> <span class=\"nav-label\">{FileTitle}</span></a>";
                        else
                            HtmlMenu += $"<a href=\"{LinkUrl}\"><i class=\"{ItemIcon}\"></i>{FileTitle}</a>";
                    }
                    HtmlMenu += "</li>";
                }
            }
        }
    }
}