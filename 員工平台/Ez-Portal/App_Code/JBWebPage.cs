using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BL;
using JB.WebModules;
using JB.WebModules.Authentication;
using NLog;
using Telerik.Web.UI;

/// <summary>
/// JBWebPage 的摘要描述
/// </summary>
public class JBWebPage : System.Web.UI.Page
{
    public NLog.Logger logger = LogManager.GetCurrentClassLogger();

    public string NoticeContent { get; set; }

    public string NoticeTitle { get; set; }

    public bool DisplayNotice { get; set; }

    public string SessionName { get; set; }

    public string SessionName2 { get; set; }

    public string SessionName3
    {
        get;
        set;
    }

    public bool CanCopy { get; set; }

    public JBWebPage()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    protected override void InitializeCulture()
    {
        String selectedLanguage = "en-US";
        if (Request.Cookies["lang"] != null)
            selectedLanguage = Request.Cookies["lang"].Value;
        else
            selectedLanguage = "zh-TW";

        UICulture = selectedLanguage;
        Culture = selectedLanguage;

        Thread.CurrentThread.CurrentCulture =
    CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new
        CultureInfo(selectedLanguage);

        base.InitializeCulture();
    }

    public void Show(string message)
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
            //RadScriptManager.RegisterStartupScript(this , typeof(Page) , this.GetType().ToString() , "alert('test');" , true);
        }
    }

    public void JB_RegisterStartupScript(Type type, string key, string script, bool addScriptTags)
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

    protected void JB_LoadComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var controls = ObjectQueryExt.GetPageAllControls(this.Controls);//AllControls(Page);//= ObjectQueryExt.GetPageAllControls(this.Controls);
            setTelerikControlCulture(controls);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.JBPage_Load);
        this.Error += new System.EventHandler(this.JBPage_Error);
        this.LoadComplete += new System.EventHandler(JB_LoadComplete);

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        string ApplicationPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
        string path = Request.Url.AbsolutePath.Substring(ApplicationPath.Length, Request.Url.AbsolutePath.Length - ApplicationPath.Length);

        FileStructure_Repo fsRepo = new FileStructure_Repo();
        var fsList = fsRepo.GetByPathFromCache(path);

        if (fsList.Count > 0)
        {
            this.NoticeContent = fsList[0].NoticeContent;
            this.NoticeTitle = fsList[0].NoticeTitle;
            this.DisplayNotice = fsList[0].DisplayNotice;
        }

        //if (!FileStructure_Repo.CheckPagePermissions(Juser.RoleList, path))
        if (!FileStructure_Repo.CheckPagePermissions(Juser.RoleList, fsList))
        {
            throw new ApplicationException("Access denied!!");
        }

        if (Context.User.Identity.IsAuthenticated)
        {
            if (!(Context.User is JBPrincipal))
            {
                // ASP.NET's regular forms authentication picked up our cookie, but we
                // haven't replaced the default context user with our own. Let's do that
                // now. We know that the previous context.user.identity.name is the e-mail
                // address (because we forced it to be as such in the login.aspx page)

                JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);

                Context.User = newUser;
            }
        }
        else
            Response.Redirect(BaseUrl + "login.aspx", true);

        base.OnInit(e);
        SessionName = this.GetType().ToString();
        SessionName2 = this.GetType().ToString() + "2";
        SessionName3 = this.GetType().ToString() + "3";

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

    protected void JBPage_Error(object sender, System.EventArgs e)
    {
        string errMsg;
        Exception currentError = Server.GetLastError();
        logger.Error(Request.Url.ToString() + currentError.Message.ToString());
        errMsg = "";
        errMsg += " <div i class=\"warning\" style=\"height:30px;width:95%;\">" +
          "The error occurred in: " + Request.Url.ToString() + "<br/>" +
            "Error Message: <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
            "</div>";

        if (!(currentError is AppException))
        {
            // It is not one of ours, so we cannot guarantee that it has been logged
            // into the event log.
            //  LogEvent(currentError.ToString(), EventLogEntryType.Error);
        }

        Response.Write(errMsg);
        Server.ClearError();
    }

    protected void LogEvent(string message, EventLogEntryType entryType)
    {
        new AppException(message);
    }

    private void JBPage_Load(object sender, System.EventArgs e)
    {
        // TODO: Place any code that will take place BEFORE the Page_Load event
        // in the regular page, e.g. cache management, authentication verification,
        // etc.
        //if (!IsPostBack)
        //{
        //    var controls = AllControls(Page);//= ObjectQueryExt.GetPageAllControls(this.Controls);
        //    setTelerikControlCulture(controls);
        //}

        if (!CanCopy)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            ScriptManager sm = RadScriptManager.GetCurrent(page);

            if (sm == null)
            {
                if (!page.ClientScript.IsClientScriptIncludeRegistered("DisableCopy"))
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "DisableCopy", Page.ResolveUrl("~/Scripts/Disable.js"));
            }
            else
            {
                RadScriptManager.RegisterClientScriptInclude(this, typeof(Page), "DisableCopy", Page.ResolveUrl("~/Scripts/Disable.js"));

                //RadScriptManager.RegisterStartupScript(this, typeof(Page), this.GetType().ToString(), "OpenAlert('" + message + "');", true);
                //RadScriptManager.RegisterStartupScript(this , typeof(Page) , this.GetType().ToString() , "alert('test');" , true);
            }
        }
        //addHeaderControl();
    }

    private void setTelerikControlCulture(IEnumerable<Control> list)
    {
        var cList = (from c in list where c is RadDatePicker select c).ToList();
        foreach (var l in cList)
        {
            RadDatePicker control = l as RadDatePicker;

            if (control is Telerik.Web.UI.RadDateTimePicker)
                continue;

            control.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.CultureName.Equals("zh-TW"))
            {
                control.DateInput.DateFormat = "yyyy/MM/dd"; //"MM/dd/yyyy"
                control.DateInput.DisplayDateFormat = "yyyy/MM/dd";
            }
            else
            {
                control.DateInput.DateFormat = "MM/dd/yyyy";
                control.DateInput.DisplayDateFormat = "MM/dd/yyyy";
            }
        }
    }

    public JB.WebModules.Accounts.User JbUser
    {
        get
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                Context.User = newUser;

                return ((SiteIdentity)Context.User.Identity).JbUser;
            }
            else
            {
                Response.Redirect(BaseUrl + "login.aspx", true);
            }
            return null;
        }
    }

    public JUser Juser
    {
        get
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                return JUser.GetCacheUser(Context.User.Identity.Name);
            }
            else
            {
                Response.Redirect(BaseUrl + "login.aspx", true);
                //FormsAuthentication.RedirectToLoginPage();
                return null;
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }

    public string FullBaseUrl
    {
        get
        {
            return this.Request.Url.AbsoluteUri.Replace(
               this.Request.Url.PathAndQuery, "") + this.BaseUrl;
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (writer is System.Web.UI.Html32TextWriter)
        {
            writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
        }
        else
        {
            writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
        }
        base.Render(writer);
    }

    private void addHeaderControl()
    {
        HtmlGenericControl objjQuery = new HtmlGenericControl("script");
        objjQuery.Attributes.Add("language", "javascript");
        //src="<%= ResolveUrl("~/Scripts/jQuery/jquery-1.4.4.min.js") %>"
        objjQuery.Attributes.Add("src", "../Scripts/Disable.js");

        string path = @"Disable.css";
        HtmlGenericControl objLink = new HtmlGenericControl("link");
        objLink.Attributes.Add("rel", "stylesheet");
        objLink.Attributes.Add("href", path);
        objLink.Attributes.Add("type", "text/css");
        this.Page.Header.Controls.Add(objLink);

        //HtmlGenericControl body = Master.FindControl("MasterBody") as HtmlGenericControl;
        //if (body != null)
        //    body.Attributes.Add("onload", "OnLoad();");
    }

    public IEnumerable<Control> AllControls(Control root)
    {
        if (root != null)
        {
            if (root is System.Web.UI.WebControls.FormView || root.HasControls())
            {
                yield return root;
            }
            foreach (Control c in root.Controls)
            {
                if (c is System.Web.UI.WebControls.FormView || c.HasControls())
                {
                    yield return c;
                }
                else
                {
                    foreach (var control in AllControls(c))
                    {
                        yield return control;
                    }
                }
            }
        }
    }

    public string GetEncryptQueryString(string key)
    {
        //
        if (!this.Request.QueryString.HasKeys() && Request.QueryString.Count == 1)
        {
            string qs = Encrypt.DecryptInformation(Request.QueryString.ToString());
            string[] arr = qs.Split('&');
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var i in arr)
            {
                string[] arr2 = i.Split('=');
                if (arr2.Length == 2)
                {
                    dic.Add(arr2[0], arr2[1]);
                }
            }

            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
        }

        return string.Empty;
    }
}

internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter
{
    private string _url; // 假的URL

    internal FormFixerHtml32TextWriter(TextWriter writer)
        : base(writer)
    {
        _url = HttpContext.Current.Request.RawUrl;
    }

    public override void WriteAttribute(string name, string value, bool encode)
    {
        if (_url != null && string.Compare(name, "action", true) == 0)
        {
            value = _url;
        }
        base.WriteAttribute(name, value, encode);
    }
}

internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
{
    private string _url;

    internal FormFixerHtmlTextWriter(TextWriter writer)
        : base(writer)
    {
        _url = HttpContext.Current.Request.RawUrl;
    }

    public override void WriteAttribute(string name, string value, bool encode)
    {
        if (_url != null && string.Compare(name, "action", true) == 0)
        {
            value = _url;
        }
        base.WriteAttribute(name, value, encode);
    }
}