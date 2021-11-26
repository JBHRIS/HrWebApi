using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using System.Web.Security;
using Telerik.Web.UI;
using System.IO;
using System.Text;
using Bll.Tools;
using System.Data.SqlClient;
using System.Configuration;
using Dal;
using Dal.Dao.Share;
using Dal.Dao;
using Bll.Share.Vdb;
using Portal;

/// <summary>
/// WebPage 的摘要描述
/// </summary>
public class WebPageBase : System.Web.UI.Page
{
    public string _SessionName1 { get; set; }
    public string _SessionName2 { get; set; }
    public string _SessionName3 { get; set; }
    public CompanySettingRow CompanySetting { get; set; }

    public User _User;

    public ShareValidateDao oValidateDao = new ShareValidateDao();
    public MainDao oMainDao = new MainDao();

    public AuthManager _AuthManager = new AuthManager();

    public dcHrDataContext dcHr = new dcHrDataContext();
    public dcShareDataContext dcShare = new dcShareDataContext();
    public dcPerformanceDataContext dcMain = new dcPerformanceDataContext();
    protected string LoginToken;



    string MasterPage = ConfigurationManager.AppSettings["MasterPage"].ToString();
    string MasterPageDB = ConfigurationManager.AppSettings["MasterPageDB"].ToString();



    public WebPageBase()
    {
    }

    protected override void InitializeCulture()
    {
        String selectedLanguage = "en-US";
        //if (Request.Cookies["lang"] != null)
        //    selectedLanguage = Request.Cookies["lang"].Value;
        //else
        //    selectedLanguage = "zh-TW";

        selectedLanguage = "zh-TW";
        UICulture = selectedLanguage;
        Culture = selectedLanguage;

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

        
        base.InitializeCulture();
        
    }

    public void ShowMessage(string message)
    {
        // Gets the executing web page
        Page page = HttpContext.Current.CurrentHandler as Page;

        ScriptManager sm = RadScriptManager.GetCurrent(page);
        if (sm == null)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered(page.GetType().ToString()))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), page.GetType().ToString(), Page.ResolveUrl("~/Scripts/MyTools.js"));

            page.ClientScript.RegisterStartupScript(typeof(Page), page.GetType().ToString(), "OpenAlert('" + message + "');", true);
        }
        else
        {
            RadScriptManager.RegisterStartupScript(this, typeof(Page), this.GetType().ToString(), "OpenAlert('" + message + "');", true);
        }
    }

    public void RegisterStartupScript(Type type, string key, string script, bool addScriptTags)
    {
        Page page = HttpContext.Current.CurrentHandler as Page;
        ScriptManager sm = RadScriptManager.GetCurrent(page);
        if (sm == null)
        {
            page.ClientScript.RegisterStartupScript(type, page.GetType().ToString(), script, addScriptTags);
        }
        else
        {
            RadScriptManager.RegisterStartupScript(this, typeof(Page), this.GetType().ToString(), script, addScriptTags);
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
        {
            if (UnobtrusiveSession.Session["CompanySetting"] != null)
            {
                var CompanySstting = UnobtrusiveSession.Session["CompanySetting"] as CompanySettingRow;
                this.CompanySetting = CompanySstting;
            }
            else
            { 
                var CompanyId = Request.Cookies["CompanyId"].Value;
                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);
                if (CompanySetting != null)
                {
                    this.CompanySetting = CompanySetting;
                }
            }
        }
        // 若有在內容頁面中有定義 Page_PreInit 事件的話會先在 base.OnPreInit(e) 執行！
        base.OnPreInit(e);

        if (WebPage.DataDb)
        {
            if (this.MasterPageFile == MasterPage)
                this.MasterPageFile = MasterPageDB;

            if (Master != null)
            {
                if (Master.MasterPageFile == MasterPage)
                    Master.MasterPageFile = MasterPageDB;

                if (Master.Master != null)
                {
                    if (Master.Master.MasterPageFile == MasterPage)
                        Master.Master.MasterPageFile = MasterPageDB;

                    if (Master.Master.Master != null)
                    {
                        if (Master.Master.Master.MasterPageFile == MasterPage)
                            Master.Master.Master.MasterPageFile = MasterPageDB;
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.PageLoad);
        this.Error += new System.EventHandler(this.PageError);

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        if (Context.User.Identity.IsAuthenticated)
        {
            _User = _AuthManager.GetCacheUser(Context.User.Identity.Name);

            string ApplicationPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
            string Path = Request.Url.AbsolutePath.Substring(ApplicationPath.Length, Request.Url.AbsolutePath.Length - ApplicationPath.Length);

            if (Path.IndexOf("Manage") >= 0)
            {
                //if (!(Context.User is JBPrincipal))
                //{
                //    // ASP.NET's regular forms authentication picked up our cookie, but we
                //    // haven't replaced the default context user with our own. Let's do that
                //    // now. We know that the previous context.user.identity.name is the e-mail
                //    // address (because we forced it to be as such in the login.aspx page)

                //    JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);

                //    Context.User = newUser;
                //}
            }
        }
        else
        {
            //非會員者 暫定一個Guid 
            _User = new User(); 

            //_AuthManager.SignIn(_User, "");
        }

        base.OnInit(e);
        _SessionName1 = this.GetType().ToString() + "-" + "1";
        _SessionName2 = this.GetType().ToString() + "-" + "2";
        _SessionName3 = this.GetType().ToString() + "-" + "3";

        ScriptManager sm = RadScriptManager.GetCurrent(this);
        if (sm == null)
        {
            if (!this.ClientScript.IsClientScriptIncludeRegistered(this.GetType().ToString()))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), this.GetType().ToString(), Page.ResolveUrl("~/Scripts/MyTools.js"));
        }
        else
        {
            RadScriptManager.RegisterClientScriptInclude(this, typeof(Page), this.GetType().ToString(), Page.ResolveUrl("~/Scripts/MyTools.js"));
        }
    }

    private void PageLoad(object sender, System.EventArgs e)
    {
        // TODO: Place any code that will take place BEFORE the Page_Load event
        // in the regular page, e.g. cache management, authentication verification,
        // etc.
        if (!IsPostBack)
        {

            //var controls = ObjectQueryExt.GetPageAllControls(this.Controls);
            //setTelerikControlCulture(controls);
        }
        
    }

    protected void PageError(object sender, System.EventArgs e)
    {
        //string errMsg;
        Exception currentError = Server.GetLastError();

        var Contents = "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + Server.GetLastError().StackTrace;
        var SystemContents = currentError.Message.ToString();
        var AppName = Request.Url.ToString();
        var Ip = WebPage.GetClientIP(Context);
        oMainDao.MessageLog("4", Contents, SystemContents, AppName, Ip, _User.UserCode);
        //logger.Error(Request.Url.ToString() + currentError.Message.ToString());
        //errMsg = "";
        //errMsg += " <div i class=\"warning\" style=\"height:30px;width:95%;\">" +
        //  "The error occurred in: " + Request.Url.ToString() + "<br/>" +
        //    "Error Message: <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
        //    "</div>";

        //if (!(currentError is AppException))
        //{
        //    // It is not one of ours, so we cannot guarantee that it has been logged
        //    // into the event log.
        //    //  LogEvent(currentError.ToString(), EventLogEntryType.Error);
        //}
        //Console.WriteLine(currentError);
        //Response.Write(currentError);
        Response.Redirect("Message500.aspx");
        Server.ClearError();
    }

    protected void LogEvent(string message, EventLogEntryType entryType)
    {
        //new AppException(message);
    }

    public override void VerifyRenderingInServerForm(Control control) { }
}