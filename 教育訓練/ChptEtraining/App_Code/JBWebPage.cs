using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Telerik.Web.UI;
using Repo;
//using JB.WebModules;
//using JB.WebModules.Authentication;

/// <summary>
/// JBWebPage 的摘要描述
/// </summary>
public class JBWebPage : System.Web.UI.Page
{
    protected NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public string SessionName { get; set; }
    public string SessionName2 { get; set; }

    public JBWebPage()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
        this.PreRender += new EventHandler(Page_PreRender);
        IsVerifyRender = false;
    }

    public void AlertMsg(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");
        string script = @"alert('" + cleanMessage + "');";

        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;

        ScriptManager sm = RadScriptManager.GetCurrent(page);
        if (sm == null)
        {
            page.ClientScript.RegisterStartupScript(typeof(Page), "AlertMsg", script);
        }
        else
            RadScriptManager.RegisterStartupScript(page, typeof(Page), "AlertMsg", script, true);
    }

    private string ParserMessage(string Message)
    {
        string sMessage = null;

        sMessage = Message.Replace("'", "\\'");
        //處理單引號 
        sMessage = sMessage.Replace("\n", "\\n");
        //處理換行 
        return Message;
    }

    /// <summary> 
    /// 取得訊問視窗的用戶端指令碼。 
    /// </summary> 
    /// <param name="Message">訊息文字。</param> 
    public string GetConfirmScript(string Message)
    {
        string sMessage = null;
        string sScript = null;

        sMessage = ParserMessage(Message);
        sScript = string.Format("if (confirm('{0}')==false) {{return false;}}", sMessage);
        return sScript;
    }


    /// <summary> 
    /// 取得訊問視窗的用戶端指令碼。 
    /// </summary> 
    /// <param name="Message">訊息文字。</param> 
    /// <param name="TrueScript">回應 true 時要執行的用戶端指令碼。</param> 
    /// <param name="FalseScript">回應 false 時要執行的用戶端指令碼。</param> 
    public string GetConfirmScript(string Message, string TrueScript, string FalseScript)
    {
        string sMessage = null;
        string sScript = null;

        sMessage = ParserMessage(Message);
        sScript = string.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }}", sMessage, TrueScript, FalseScript);
        return sScript;
    }

    /// <summary> 
    /// 詢問視窗。 
    /// </summary> 
    /// <param name="Message">訊息文字。</param> 
    /// <param name="TrueScript">回應 true 時要執行的用戶端指令碼。</param> 
    /// <param name="FalseScript">回應 false 時要執行的用戶端指令碼。</param> 
    public void ConfirmShow(string Message, string TrueScript, string FalseScript)
    {
        string sScript = null;
        Page page = HttpContext.Current.CurrentHandler as Page;
        sScript = GetConfirmScript(Message, TrueScript, FalseScript);
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("Confirm"))
        {
            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Confirm", sScript);
        }
    }

    public static void radShow(string message, Page my_page)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\'");
        string radalertscript = @"<script language='javascript'>function f(){radalert('" + cleanMessage + "', 330, 210); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
        // Gets the executing web page 
        Page page = HttpContext.Current.CurrentHandler as Page;
        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("radalert"))
        {
            page.ClientScript.RegisterStartupScript(my_page.GetType(), "radalert", radalertscript);
        }

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
        }
    }


    void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack) SetActionStamp();

        ScriptManager sm = RadScriptManager.GetCurrent(Page);
        if (sm == null) ClientScript.RegisterHiddenField("actionStamp", Session["actionStamp"].ToString());
        else RadScriptManager.RegisterHiddenField(this, "actionStamp", Session["actionStamp"].ToString());
    }

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
    }

    protected override void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.JBPage_Load);
        this.Error += new System.EventHandler(this.JBPage_Error);

         //int role = ((CustomSecurity.CustomIdentity)User.Identity).UserRole;

        string ApplicationPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
        string AbsolutePath = Request.Url.AbsolutePath;
        string path = AbsolutePath.Substring(ApplicationPath.Length, AbsolutePath.Length - ApplicationPath.Length);
                
        if (!sysFileStructure_Repo.CheckPagePermissions(Juser.IntRoleList, path))
        {
            throw new ApplicationException("無權限瀏覽此網頁，請洽管理者");
        }
        else
        {
            InitPageTitle();
        }

        SessionName = this.GetType().ToString();
        SessionName2 = this.GetType().ToString() + "2";
        base.OnInit(e);

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

    public void InitPageTitle()
    {
        sysFileStructure_Repo fsRepo = new sysFileStructure_Repo();
        sysFileStructure obj = fsRepo.GetByFileNameFromCache(Request.FilePath, Request.ApplicationPath);
        if (obj != null)            this.Title = obj.sFileTitle;
    }

    protected void JBPage_Error(object sender, System.EventArgs e)
    {

        string errMsg;
        Exception currentError = Server.GetLastError();

        //errMsg = "<link rel=\"stylesheet\" href=\"/App_Themes/Default/a.CSS\">";
        //errMsg += "<h1>Page Error</h1><hr/>An unexpected error has occurred on this page. The system " +
        //    "administrators have been notified. Please feel free to contact us with the information " +
        //    "surrounding this error.<br/>" +
        //    "The error occurred in: " + Request.Url.ToString() + "<br/>" +
        //    "Error Message: <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
        //    "<b>Stack Trace:</b><br/>" +
        //    currentError.ToString();

        //if (!(currentError is AppException)) {
        //    // It is not one of ours, so we cannot guarantee that it has been logged
        //    // into the event log.
        //    LogEvent(currentError.ToString(), EventLogEntryType.Error);
        //}

        //Response.Write(errMsg);
        //Session["errorMsg"] = errMsg;
        errMsg = "<h1>Page Error</h1><hr/>程式發生異常錯誤，請聯絡資訊人員!!<br/>" +
            "The error occurred in: " + Request.Url.ToString() + "<br/>" +
            "Error Message: <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
            "<b>Stack Trace:</b><br/>" +
            currentError.ToString();

        logger.Fatal(errMsg);

        //string msg = Request.Url.ToString() + "程式發生異常錯誤，請聯絡資訊人員!!";
        string msg = Request.Url.ToString() + currentError.Message.ToString();
        Session["errorMsg"] = msg;
        Server.ClearError();

        ScriptManager sm = ScriptManager.GetCurrent(this);
        if (sm == null) Response.Redirect("~/error.aspx", true);
        else Server.Transfer("~/error.aspx");

    }

    protected void LogEvent(string message, EventLogEntryType entryType)
    {
        //new AppException(message);
    }

    private void JBPage_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (Request.UrlReferrer != null) ViewState["URL"] = Request.UrlReferrer.ToString();

        }
        // TODO: Place any code that will take place BEFORE the Page_Load event
        // in the regular page, e.g. cache management, authentication verification,
        // etc.		
        /*							
        if (Context.User.Identity.IsAuthenticated) {
            if (!(Context.User is JBPrincipal)) {
                // ASP.NET's regular forms authentication picked up our cookie, but we
                // haven't replaced the default context user with our own. Let's do that
                // now. We know that the previous context.user.identity.name is the e-mail
                // address (because we forced it to be as such in the login.aspx page)	
            
                JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                Context.User = newUser;
            }
        }
        else {
            Response.Redirect(BaseUrl+"login.aspx", true);
        }
         * 
         */
    }
   
    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/")) return url;
            else return url + "/";
        }
    }

    public string FullBaseUrl
    {
        get
        {
            return this.Request.Url.AbsoluteUri.Replace(this.Request.Url.PathAndQuery, "") + this.BaseUrl;
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

    // 抓取Request.QueryString的值，null時，則傳回空字串
    public string GetRequestQueryStringValue(string param)
    {
        if (Request.QueryString[param] != null)
            return Request.QueryString[param];
        else
            return "";
    }

    // 設置戳記
    private void SetActionStamp()
    {
        Session["actionStamp"] = Server.UrlEncode(DateTime.Now.ToString());
    }

    // 取得值，指出網頁是否經由重新整理動作回傳 (PostBack)
    protected bool IsRefresh
    {
        get
        {
            if ((HttpContext.Current.Request["actionStamp"] as string).Equals(Session["actionStamp"] as string))
            {
                SetActionStamp();
                return false;
            }
            return true;
        }
    }

    public static string ControlToHTML(System.Web.UI.Control Control)
    {
        string sHTML = string.Empty;
        System.IO.StringWriter oTextWriter = new StringWriter();
        System.Web.UI.HtmlTextWriter oHTMLWriter = new HtmlTextWriter(oTextWriter);

        if (Control.Page != null)
        {
            if (Control.Page is JBWebPage)
                (Control.Page as JBWebPage).IsVerifyRender = false;
        }

        Control.RenderControl(oHTMLWriter);
        sHTML = oTextWriter.ToString();
        return sHTML;
    }

    public bool IsVerifyRender { get; set; }

    public override bool EnableEventValidation
    {
        get
        {
            if (this.IsVerifyRender) return base.EnableEventValidation;
            else return false;
        }
        set { base.EnableEventValidation = value; }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        if (this.IsVerifyRender)
            base.VerifyRenderingInServerForm(control);
    }

    public JUser Juser
    {
        get
        {
            if (Context.User.Identity.IsAuthenticated) return JUser.GetCacheUser(Context.User.Identity.Name);
            else
            {
                FormsAuthentication.RedirectToLoginPage();
                return null;
            }
        }
    }
}

internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter
{
    private string _url; // 假的URL 
    internal FormFixerHtml32TextWriter(TextWriter writer) : base(writer) { _url = HttpContext.Current.Request.RawUrl; }
    public override void WriteAttribute(string name, string value, bool encode)
    {
        if (_url != null && string.Compare(name, "action", true) == 0) value = _url;
        base.WriteAttribute(name, value, encode);
    }
}

internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
{
    private string _url;
    internal FormFixerHtmlTextWriter(TextWriter writer) : base(writer) { _url = HttpContext.Current.Request.RawUrl; }
    public override void WriteAttribute(string name, string value, bool encode)
    {
        if (_url != null && string.Compare(name, "action", true) == 0) value = _url;
        base.WriteAttribute(name, value, encode);
    }
}