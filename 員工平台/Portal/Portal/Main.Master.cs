using Bll.Menu.Vdb;
using Bll.System.Vdb;
using Bll.Token.Vdb;
using Dal.Dao.Menu;
using Dal.Dao.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Security;
using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Web.UI.HtmlControls;
using Bll.Share.Vdb;
using Dal.Dao.Share;
using Bll.Tools;
using System.Web.Services;

namespace Portal
{
    public partial class Main : WebPageMasterPage
    {
        public string FormTitle
        {
            get { return lblSiteMapName.Text; }
        }
        private CompanySettingRow CompanySetting;

        //public override rad

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
            {
                if (UnobtrusiveSession.Session["CompanySetting"] != null)
                {
                    var CompanySetting = UnobtrusiveSession.Session["CompanySetting"] as CompanySettingRow;
                    this.CompanySetting = CompanySetting;
                    dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
                }
                else
                {
                    var CompanyId = Request.Cookies["CompanyId"].Value;
                    var oShareCompany = new ShareCompanyDao();
                    var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);
                    this.CompanySetting = CompanySetting;
                    imgMenuTopIcon.ImageUrl = CompanySetting.FileNameMenuTop;
                    dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
                }
            }

            DateTime Begin = DateTime.Now;
            Page.SaveStateComplete += Page_DataBinding;
            if (!this.IsPostBack)
            {
                Page.PreRenderComplete += Page_PreRenderComplete;
                
                var LocalPath = System.IO.Path.GetFileName(Request.PhysicalPath);
                if (LocalPath == "Index.aspx")
                    plSiteMap.Visible = false;

                UnobtrusiveSession.Session["ReturnUrl"] = WebPage.GetActivePage;
                if (Request.Cookies[FormsAuthentication.FormsCookieName] == null || Request.Cookies[FormsAuthentication.FormsCookieName].Value == "")
                {
                    Response.Redirect("Login.aspx?param=Logout");
                    return;
                }
                //if (_User.AccessToken == "")
                //{
                //    if (UnobtrusiveSession.Session["AccessToken"] != null)
                //        _User.AccessToken = UnobtrusiveSession.Session["AccessToken"].ToString();
                //}
                if (_User.EmpName == "未登入")
                {
                    var userData = Request.Cookies[FormsAuthentication.FormsCookieName];
                    var userTicket = FormsAuthentication.Decrypt(userData.Value);
                    UserToken user = JsonConvert.DeserializeObject<UserToken>(userTicket.UserData);
                    var LoginByAD = (from c in dcFlow.FormsExtend
                                     where c.FormsCode == "Common" && c.Code == "LoginByAD" && c.Active == true
                                     select c).FirstOrDefault();

                    if (user.RefreshToken != null || user.RefreshToken != "")
                    {
                        if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
                        {
                            var oShareCompany = new ShareCompanyDao();
                            var CompanySetting = oShareCompany.GetCompanySetting(Request.Cookies["CompanyId"].Value);

                            this.CompanySetting = CompanySetting;
                            var oConnection = new ConnectionDao();
                            var ConnectionCondition = new ConnectionConditions();
                            ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                            var LoginTokenResult = oConnection.GetData(ConnectionCondition);
                            var LoginToken = LoginTokenResult.Payload.ToString();

                            var oRefreshToken = new RefreshTokenDao();
                            var RefreshTokenCond = new RefreshTokenConditions();
                            RefreshTokenCond.AccessToken = LoginToken;
                            RefreshTokenCond.RefreshToken = user.RefreshToken;
                            RefreshTokenCond.refreshToken = user.RefreshToken;
                            var rs = oRefreshToken.GetData(RefreshTokenCond);
                            if (rs.Status)
                            {
                                if (rs.Data != null)
                                {
                                    var rSignin = rs.Data as SigninRow;
                                    _User.AccessToken = rSignin.AccessToken;
                                    _User.RefreshToken = rSignin.RefreshToken;
                                }
                            }
                            _AuthManager.SignIn(_User, _User.UserCode, CompanySetting);
                        }

                        else
                        {
                            var oRefreshToken = new RefreshTokenDao();
                            var RefreshTokenCond = new RefreshTokenConditions();
                            RefreshTokenCond.RefreshToken = user.RefreshToken;
                            RefreshTokenCond.refreshToken = user.RefreshToken;
                            var rs = oRefreshToken.GetData(RefreshTokenCond);
                            if (rs.Status)
                            {
                                if (rs.Data != null)
                                {
                                    var rSignin = rs.Data as SigninRow;
                                    _User.AccessToken = rSignin.AccessToken;
                                    _User.RefreshToken = rSignin.RefreshToken;
                                }
                            }
                            _AuthManager.SignIn(_User, _User.UserCode, CompanySetting);
                        }
                    }

                    if (_User.EmpName == "未登入" && Request.Cookies["LoginMethod"] != null && Request.Cookies["LoginMethod"].Value == "HR") //驗證還是失敗則回登入頁
                        Response.Redirect("Login.aspx?param=Logout");
                    else if (_User.EmpName == "未登入" && LoginByAD != null)
                        Response.Redirect("LoginADDirect.aspx?param=Logout");
                    AuthManager.SetCacheUser(_User);
                    base.OnInit(e);
                    Response.Redirect(Request.PhysicalPath);
                }
                
                var IsShowExport = (from c in dcFlow.FormsExtend
                                    where c.FormsCode == "Common" && c.Active == true && c.Code == "IsShowExport"
                                    select c).FirstOrDefault();
                if (IsShowExport != null)
                {
                    btnExport.Visible = true;
                }
                var ReplyRedirect = (from c in dcFlow.FormsExtend
                                     where c.FormsCode == "Common" && c.Active == true && c.Code == "ReplyRedirect"
                                     select c).FirstOrDefault();
                if (ReplyRedirect != null)
                    btnReply.Visible = true;

                var ActivePage = Request.Url;
                if (_User.LoginStatus != "1")
                    Response.Redirect("Login.aspx?ReturnUrl=" + ActivePage);
                UnobtrusiveSession.Session["SystemPage"] = null;
                LoadData();
                var Language = (from c in dcFlow.FormsExtend
                                where c.FormsCode == "Common" && c.Active == true && c.Code == "Language"
                                select c).FirstOrDefault();
                if (Language != null)
                {
                    plLanguage.Visible = true;
                    ChangeLanguage();
                }
                SetRootValues();

            }
            var TimeCountDown = (from c in dcFlow.FormsExtend
                                 where c.FormsCode == "Common" && c.Code == "TimeCountDown" && c.Active == true
                                 select c).FirstOrDefault();
            if (TimeCountDown != null)
            {
                CountDown();
                if(TimeCountDown.Column1 != "1")
                    plCountDown.Visible = true;
            }
            
            if (FormTitle != "")
                Page.Title = FormTitle;
            RadClientExportManager1.PdfSettings.Fonts.Add("Arial Unicode MS", "Fonts/Arial-Unicode-MS.ttf");

            RadClientExportManager1.PdfSettings.FileName = FormTitle + ".pdf";

            if (UnobtrusiveSession.Session["App"] != null)
            {
                var LoginByApp = (bool)UnobtrusiveSession.Session["App"];
                if (LoginByApp)
                    plLogOut.Visible = false;
            }
        }

        private void Page_DataBinding(object sender, EventArgs e)
        {
            ChangeLanguage();
        }

        private void Page_PreRenderComplete(object sender, EventArgs e)
        {
            //將css檔放在最後不然沒有效果
            var CSS = new HtmlGenericControl();
            CSS.TagName = "link";
            //CSS.Attributes.Add("type", "text/css");
            CSS.Attributes.Add("rel", "stylesheet");
            CSS.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("styles/redcontrol_form.css")));
            this.Page.Header.Controls.Add(CSS);
        }


        public void _DataBind()
        {
        }

        public void CountDown()
        {
            DateTime BalanceTime = new DateTime();
            int CountDownMin = 20;
            var TimeCountDown = (from c in dcFlow.FormsExtend
                                 where c.FormsCode == "Common" && c.Code == "TimeCountDown" && c.Active == true
                                 select c).FirstOrDefault();
            if (!this.IsPostBack)
            {
                BalanceTime = DateTime.Now.AddMinutes(CountDownMin);
                UnobtrusiveSession.Session["BalanceTime"] = BalanceTime;
            }
            else
            {
                if (UnobtrusiveSession.Session["BalanceTime"] != null)
                {
                    BalanceTime = Convert.ToDateTime(UnobtrusiveSession.Session["BalanceTime"]);
                }
                else
                    BalanceTime = DateTime.Now.AddMinutes(CountDownMin);
            }
            if (DateTime.Now < BalanceTime)
            {
                lblTime.Text = (BalanceTime - DateTime.Now).ToString(@"mm\:ss");
            }
            else
            {
                if (TimeCountDown.Column1 != "1")
                {
                    string strMsg = "權限已到期，是否繼續?", strUrl_Yes = "", strUrl_No = "../Portal?Param=Logout";
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel, typeof(UpdatePanel), "test", "if ( window.confirm('" + strMsg + "')) { } else {window.location.href='" + strUrl_No + "' };", true);
                }
                //Response.Write("<script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) { window.location.href='" + strUrl_Yes +
                //                        "' } else {window.location.href='" + strUrl_No + "' };</script>");
                var userData = Request.Cookies[FormsAuthentication.FormsCookieName];
                var userTicket = FormsAuthentication.Decrypt(userData.Value);
                UserToken user = JsonConvert.DeserializeObject<UserToken>(userTicket.UserData);
                if (user.RefreshToken != null && user.RefreshToken != "")
                {
                    if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
                    {


                        var oShareCompany = new ShareCompanyDao();
                        var CompanySetting = oShareCompany.GetCompanySetting(Request.Cookies["CompanyId"].Value);

                        this.CompanySetting = CompanySetting;
                        var oConnection = new ConnectionDao();
                        var ConnectionCondition = new ConnectionConditions();
                        ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                        var LoginTokenResult = oConnection.GetData(ConnectionCondition);
                        var LoginToken = LoginTokenResult.Payload.ToString();

                        var oRefreshToken = new RefreshTokenDao();
                        var RefreshTokenCond = new RefreshTokenConditions();
                        RefreshTokenCond.AccessToken = LoginToken;
                        RefreshTokenCond.RefreshToken = user.RefreshToken;
                        RefreshTokenCond.refreshToken = user.RefreshToken;
                        var rs = oRefreshToken.GetData(RefreshTokenCond);
                        if (rs.Status)
                        {
                            if (rs.Data != null)
                            {
                                var rSignin = rs.Data as SigninRow;
                                _User.AccessToken = rSignin.AccessToken;
                                _User.RefreshToken = rSignin.RefreshToken;
                            }
                        }
                        else
                        {
                            Response.Redirect("../Portal?Param=Logout");
                        }
                        _AuthManager.SignIn(_User, _User.UserCode, CompanySetting);
                        BalanceTime = DateTime.Now.AddMinutes(CountDownMin);
                        UnobtrusiveSession.Session["BalanceTime"] = BalanceTime;
                    }

                    else
                    {
                        var oRefreshToken = new RefreshTokenDao();
                        var RefreshTokenCond = new RefreshTokenConditions();
                        RefreshTokenCond.RefreshToken = user.RefreshToken;
                        RefreshTokenCond.refreshToken = user.RefreshToken;
                        var rs = oRefreshToken.GetData(RefreshTokenCond);
                        if (rs.Status)
                        {
                            if (rs.Data != null)
                            {
                                var rSignin = rs.Data as SigninRow;
                                _User.AccessToken = rSignin.AccessToken;
                                _User.RefreshToken = rSignin.RefreshToken;
                            }
                        }
                        else
                            Response.Redirect("../Portal?Param=Logout");
                        _AuthManager.SignIn(_User, _User.UserCode, CompanySetting);
                        BalanceTime = DateTime.Now.AddMinutes(CountDownMin);
                        UnobtrusiveSession.Session["BalanceTime"] = BalanceTime;
                    }
                }
                else
                    Response.Redirect("../Portal?Param=Logout");
            }
        }

        public void LoadData(string Key = "")
        {
            //取得使用者資訊
            lblUserName.Text = _User.EmpName;
            lblUserUserGroupName.Text = _User.EmpDeptName + "-" + _User.EmpJobName;
            //取得大頭照圖片
        }

        //public EmployeeViewRow ListEmployeeView
        //{
        //    get
        //    {
        //        var Value = new EmployeeViewRow();
        //        EmployeeViewDto oEmployeeView = new EmployeeViewDto();
        //        EmployeeViewCondition EmployeeViewCond = new EmployeeViewCondition();
        //        EmployeeViewCond.employeeList = new List<string>();
        //        EmployeeViewCond.employeeList.Add(_User.UserCode);
        //        var Result = oEmployeeView.GetData(EmployeeViewCond);
        //        if (Result.Status)
        //        {
        //            if (Result.Data != null)
        //            {
        //                Value = Result.Data as EmployeeViewRow;
        //            }
        //        }
        //        return Value;
        //    }
        //}

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

                    var oMenu = new MenuDao();
                    var MenuCond = new MenuConditions();
                    MenuCond.AccessToken = _User.AccessToken;
                    MenuCond.RefreshToken = _User.RefreshToken;
                    MenuCond.CompanySetting = CompanySetting;
                    MenuCond.code = "Menu";
                    var rs = new List<MenuRow>();

                    var Result = oMenu.GetData(MenuCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            rs = Result.Data as List<MenuRow>;
                        }
                    }
                    rs = rs.OrderBy(p => p.Order).ToList();
                    foreach (var rTarget in rs)
                    {
                        var rSystemPage = new SystemPageRow();
                        rSystemPage.TypeCode = rTarget.TypeCode;
                        rSystemPage.TypeName = rTarget.TypeName;
                        rSystemPage.Code = rTarget.Code;
                        rSystemPage.FilePath = rTarget.FilePath;
                        rSystemPage.FileName = rTarget.FileName;
                        rSystemPage.FileTitle = rTarget.FileTitle;
                        rSystemPage.RoleKey = rTarget.RoleKey;
                        if (rTarget.ParentCode == MenuCond.code) rSystemPage.ParentCode = "";
                        else rSystemPage.ParentCode = rTarget.ParentCode;
                        rSystemPage.PathCode = rTarget.PathCode;
                        rSystemPage.PathName = rTarget.PathName;
                        rSystemPage.Icon = rTarget.TypeName;
                        rSystemPage.IsAuth = rTarget.IsAuth;
                        rSystemPage.OpenWindow = rTarget.OpenNewWin;
                        Value.Add(rSystemPage);
                    }

                    UnobtrusiveSession.Session["SystemPage"] = Value;
                }
                SetPath(Value);
                return Value;
            }
        }

        /// <summary>
        /// 設定檔案結構管理組織
        /// </summary>
        /// <param name="ListSystemPage">檔案結構管理料表</param>
        public void SetPath(List<SystemPageRow> ListSystemPage)
        {
            string Code;
            SystemPageRow rSystemPage;
            int i;

            foreach (var rowSystemPage in ListSystemPage)
            {
                i = 0;
                Code = rowSystemPage.Code;

                do
                {
                    rSystemPage = ListSystemPage.FirstOrDefault(p => p.Code == Code);
                    if (rSystemPage != null)
                    {
                        rowSystemPage.PathCode = "/" + rSystemPage.Code + rowSystemPage.PathCode;
                        rowSystemPage.PathName = "/" + rSystemPage.Name + rowSystemPage.PathName;

                        if (Code == rSystemPage.ParentCode)
                            break;

                        Code = rSystemPage.ParentCode;
                    }

                    i++;
                } while (rSystemPage != null && Code.Length > 0 && i <= ListSystemPage.Count);

                rowSystemPage.PathCode += "/";
                rowSystemPage.PathName += "/";
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
                var Language = (from c in dcFlow.FormsExtend
                                where c.FormsCode == "Common" && c.Active == true && c.Code == "Language"
                                select c).FirstOrDefault();
                var oShareDictionary = new ShareDictionaryDao();
                if (Language != null)
                {
                    if (Request.Cookies["Language"] != null && Request.Cookies["Language"].Value != "")
                    {
                        var LanguageCookie = Request.Cookies["Language"].Value;
                        var TextChange = oShareDictionary.TextTranslate("Portal", rSystemPage.Code, "1", LanguageCookie);
                        if (TextChange != null && TextChange != "")
                            lblSiteMapName.Text = TextChange;
                    }
                }
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
                Item = new RadMenuItem();
                if (rSystemPage == null)
                {
                    break;
                }
                Item.Text = rSystemPage.FileTitle;
                Item.Value = rSystemPage.Code;

                var Language = (from c in dcFlow.FormsExtend
                                where c.FormsCode == "Common" && c.Active == true && c.Code == "Language"
                                select c).FirstOrDefault();
                var oShareDictionary = new ShareDictionaryDao();
                if (Language != null)
                {
                    if (Request.Cookies["Language"] != null && Request.Cookies["Language"].Value != "")
                    {
                        var LanguageCookie = Request.Cookies["Language"].Value;
                        var TextChange = oShareDictionary.TextTranslate("Portal", Code, "1", LanguageCookie);
                        if (TextChange != null && TextChange != "")
                            Item.Text = TextChange;
                    }
                }
                

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
        /// <param name="ListActivePageCode">作用頁面代碼</param>
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
                string OpenNewWin = "";
                if (!Href)
                    continue;
                if (OpenWindows)
                {
                    OpenNewWin = "target=\"_blank\"";
                }

                var PathCode = rSystemPage.PathCode;
                var FileTitle = rSystemPage.FileTitle;

                var Language = (from c in dcFlow.FormsExtend
                                where c.FormsCode == "Common" && c.Active == true && c.Code == "Language"
                                select c).FirstOrDefault();
                var oShareDictionary = new ShareDictionaryDao();
                if (Language != null)
                {
                    if (Request.Cookies["Language"] != null && Request.Cookies["Language"].Value != "")
                    {
                        var LanguageCookie = Request.Cookies["Language"].Value;

                        var TextChange = oShareDictionary.TextTranslate("Portal", Code, "1", LanguageCookie);
                        if (TextChange != null && TextChange != "")
                            FileTitle = TextChange;
                    }
                }

                var SubItem = ListSystemPage.Any(p => (p.ParentCode == Code && p.FileName != ""));
                //var AllSubItem = ListSystemPage.Where(p => p.ParentCode == Code).ToList();

                //項目層級-轉換成文字
                var Level = "nav-second-level";
                if (MenuItemLevel.ContainsKey(ItemLevel))
                    Level = MenuItemLevel[ItemLevel];

                //作用的頁面
                var Active = "";
                var Expanded = "false";
                if (ListActivePageCode.Contains(Code) || ListActivePageCode.Contains(Code + Code))
                {
                    Active = "active";
                    Expanded = "true";
                }

                //要不要閉合功能
                var Collapse = "collapse";

                //項目的小圖案
                var ItemIcon = ItemLevel == 2 ? "fa " + Icon : "";

                if (Code != ParentCode)
                {
                    HtmlMenu += $"<li class=\"{Active}\">";

                    //有子層級 就需要繼續展開 並且超連結無法點擊
                    if (SubItem)
                    {
                        HtmlMenu += $"<a href=\"{LinkUrl}\" {OpenNewWin} aria-expanded=\"{Expanded}\"><i class=\"{ItemIcon}\"></i> <span class=\"nav-label\">{FileTitle}</span><span class=\"fa arrow\"></span></a>";
                        HtmlMenu += $"<ul class=\"nav {Level} {Collapse}\" aria-expanded=\"{Expanded}\">";

                        SetNodeValues(ListSystemPage, Code, (ItemLevel + 1), ListActivePageCode, ref HtmlMenu);

                        HtmlMenu += "</ul>";
                    }
                    else
                    {
                        if (ItemLevel == 2) //只有第二層與其它層不太一樣
                            HtmlMenu += $"<a href=\"{LinkUrl}\" {OpenNewWin}><i class=\"{ItemIcon}\"></i> <span class=\"nav-label\">{FileTitle}</span></a>";
                        else
                            HtmlMenu += $"<a href=\"{LinkUrl}\" {OpenNewWin}><i class=\"{ItemIcon}\"></i>{FileTitle}</a>";
                    }
                    HtmlMenu += "</li>";
                }
            }
        }

        //private void SetNodeValues(List<SystemPageRow> ListSystemPage, string ParentCode, int ItemLevel, List<string> ListActivePageCode, ref string HtmlMenu)
        //{
        //    var rsSystemPage = ListSystemPage.Where(p => p.ParentCode == ParentCode).OrderBy(p => p.Sort).ToList();
        //    foreach (var rSystemPage in rsSystemPage)
        //    {
        //        var Code = rSystemPage.Code;

        //        var RoleKey = rSystemPage.RoleKey;

        //        var FilePath = rSystemPage.FilePath;
        //        var FileName = rSystemPage.FileName;
        //        var LinkUrl = FilePath + FileName;

        //        var PathCode = rSystemPage.PathCode;
        //        var FileTitle = rSystemPage.FileTitle;

        //        var SubItem = ListSystemPage.Any(p => p.ParentCode == Code);

        //        //項目層級-轉換成文字
        //        var Level = "nav-second-level";
        //        if (MenuItemLevel.ContainsKey(ItemLevel))
        //            Level = MenuItemLevel[ItemLevel];

        //        //作用的頁面
        //        var Active = "";
        //        var Expanded = "false";
        //        if (ListActivePageCode.Contains(Code))
        //        {
        //            Active = "active";
        //            Expanded = "true";
        //        }

        //        //要不要閉合功能
        //        var Collapse = "collapse";

        //        //項目的小圖案
        //        var ItemIcon = ItemLevel == 2 ? "fa fa-th-large" : "";

        //        if (Code != ParentCode)
        //        {
        //            HtmlMenu += $"<li class=\"{Active}\">";

        //            //有子層級 就需要繼續展開 並且超連結無法點擊
        //            if (SubItem)
        //            {
        //                HtmlMenu += $"<a href=\"{LinkUrl}\" aria-expanded=\"{Expanded}\"><i class=\"fa  fa-th-large\"></i> <span class=\"nav-label\">{FileTitle}</span><span class=\"fa arrow\"></span></a>";
        //                HtmlMenu += $"<ul class=\"nav {Level} {Collapse}\" aria-expanded=\"{Expanded}\">";

        //                SetNodeValues(ListSystemPage, Code, (ItemLevel + 1), ListActivePageCode, ref HtmlMenu);

        //                HtmlMenu += "</ul>";
        //            }
        //            else
        //            {
        //                if (ItemLevel == 2) //只有第二層與其它層不太一樣
        //                    HtmlMenu += $"<a href=\"{LinkUrl}\"><i class=\"{ItemIcon}\"></i> <span class=\"nav-label\">{FileTitle}</span></a>";
        //                else
        //                    HtmlMenu += $"<a href=\"{LinkUrl}\"><i class=\"{ItemIcon}\"></i>{FileTitle}</a>";
        //            }
        //            HtmlMenu += "</li>";
        //        }
        //    }
        //}

        protected void TopSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            if(search != null && search != "")
                Response.Redirect("SearchResult.aspx?Search=" + search);
        }
        //protected void Reply_Click()
        //{
        //    var oEncryptHepler = new EncryptHepler();
        //    var fileContents = UnobtrusiveSession.Session["FileContents"] as byte[];
        //    var ReplySite = System.Web.Configuration.WebConfigurationManager.AppSettings["ReplySite"];
        //    var AccessToken = _User.AccessToken;
        //    var RefreshToken = _User.RefreshToken;
        //    var CompanyId = CompanySetting.AccountCode;
        //    var EmpId = _User.EmpId;
        //    var EmpName = _User.EmpName;
        //    var Role = 64;
        //    if (_User.Role != null && (_User.Role.Contains("HR") || _User.Role.Contains("Hr")))
        //    {
        //        Role = 8;
        //        var UserData = new List<string>();
        //        UserData.Add(AccessToken);
        //        UserData.Add(RefreshToken);
        //        UserData.Add(CompanyId);
        //        UserData.Add(EmpId);
        //        UserData.Add(EmpName);
        //        UserData.Add(Role.ToString());
        //        UserData.Add(fileContents.ToString());
        //        var Parameter = JsonConvert.SerializeObject(UserData);
        //        Response.Redirect(ReplySite + "?Param=" + Server.UrlEncode(oEncryptHepler.Encrypt(Parameter)));
        //    }
        //    else
        //    {
        //        var UserData = new List<string>();
        //        UserData.Add(AccessToken);
        //        UserData.Add(RefreshToken);
        //        UserData.Add(CompanyId);
        //        UserData.Add(EmpId);
        //        UserData.Add(EmpName);
        //        UserData.Add(Role.ToString());
        //        UserData.Add(fileContents.ToString());
        //        var Parameter = JsonConvert.SerializeObject(UserData);
        //        Response.Redirect(ReplySite + "?Param=" + Server.UrlEncode(oEncryptHepler.Encrypt(Parameter)));
        //    }
        //}

        private void ChangeLanguage()
        {
            foreach (Control Ctl in this.Controls)
            {
                FindSubControl(Ctl);
            }
        }


        public void FindSubControl(Control Ctl)
        {
            //判斷是否有子控制項
            if (Ctl.Controls.Count > 0)
            {
                if (Ctl is RadListView)
                {
                    var ListView = Ctl as RadListView;
                    if (ListView.Items.Count > 0)
                        foreach (var item in ListView.Items)
                            FindSubControl(item);
                    else
                    {
                        var ListViewData = ListView.Controls[0];
                        if (ListViewData != null)
                            FindSubControl(ListViewData);
                    }
                }
                else
                    foreach (Control Ctl1 in Ctl.Controls)
                        //繼續往下找(遞迴)
                        FindSubControl(Ctl1);

            }
            else
            {
                var oShareDictionary = new ShareDictionaryDao();

                if (Request.Cookies["Language"] != null && Request.Cookies["Language"].Value != "")
                {
                    var LanguageCookie = Request.Cookies["Language"].Value;
                
                    if (Ctl is RadLabel)
                    {
                        var Label = Ctl as RadLabel;
                        var TransText = oShareDictionary.TextTranslate("Portal", Label.ID, "1", LanguageCookie);
                        if (TransText != "" && TransText != null)
                            Label.Text = TransText;


                    }

                    if (Ctl is RadButton)
                    {
                        var Button = Ctl as RadButton;
                        var TransText = oShareDictionary.TextTranslate("Portal", Button.ID, "1", LanguageCookie);
                        if (TransText != "" && TransText != null)
                            Button.Text = TransText;
                    }

                    if (Ctl is RadTextBox)
                    {
                        var TextBox = Ctl as RadTextBox;
                        var TransText = oShareDictionary.TextTranslate("Portal", TextBox.EmptyMessage, "", LanguageCookie);
                        if (TransText != "" && TransText != null)
                            TextBox.EmptyMessage = TransText;
                    }
                    if (Ctl is CheckBox)
                    {
                        var CheckBox = Ctl as CheckBox;
                        var TransText = oShareDictionary.TextTranslate("Portal", CheckBox.ID, "1", LanguageCookie);
                        if (TransText != "" && TransText != null)
                            CheckBox.Text = TransText;
                    }
                    if (Ctl is RadCheckBox)
                    {
                        var RadCheckBox = Ctl as RadCheckBox;
                        var TransText = oShareDictionary.TextTranslate("Portal", RadCheckBox.ID, "1", LanguageCookie);
                        if (TransText != "" && TransText != null)
                            RadCheckBox.Text = TransText;
                    }
                    if (Ctl is RadRadioButtonList)
                    {
                        var RadioButtonList = Ctl as RadRadioButtonList;
                        foreach (var r in RadioButtonList.Items)
                        {
                            var RadioButton = r as ButtonListItem;
                            var TransText = oShareDictionary.TextTranslate("Portal", RadioButton.Text, "", LanguageCookie);
                            if (TransText != "" && TransText != null)
                                RadioButton.Text = TransText;
                        }

                    }
                }
            }
        }

        protected void Language(object sender, EventArgs e)
        {
            var btn = sender as RadButton;
            var lan = btn.CommandName;
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("Language", lan));
            Response.Redirect(Path.GetFileName(Request.PhysicalPath));
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            UnobtrusiveSession.Session["UserData"] = _User;
            UnobtrusiveSession.Session["CompanySetting"] = CompanySetting;
            UseScript();
            //var _Pic = new WebsitesScreenshot.WebsitesScreenshot();
            //var content = phPdf.FindControl("Content2") as Content;            
            //WebsitesScreenshot.WebsitesScreenshot.Result _Result = _Pic.CaptureHTML(phPdf.h);
            //if (_Result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured)
            //{
            //    _Pic.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.JPG;

            //    _Pic.GetImage();
            //}
            //Reply_Click();
        }
        public void UseScript()
        {
            string strMsg = "將前往回報系統，是否繼續?", strUrl_No = "";
            var Script = "Sys.Application.add_load(storeOnServer);";
            //ScriptManager.RegisterClientScriptBlock(this.UpdatePanel, typeof(UpdatePanel), "test", "if ( window.confirm('" + strMsg + "')) {'"+ Script +"' } else {window.location.href='" + strUrl_No + "' };", true);
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "storeOnServer", Script, true);
        }
    }
}