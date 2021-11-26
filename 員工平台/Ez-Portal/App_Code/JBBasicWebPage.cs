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
using JB.WebModules;
using JB.WebModules.Authentication;
using System.Threading;
using System.Globalization;
using BL;
using Telerik.Web.UI;

/// <summary>
/// JBWebPage 的摘要描述
/// </summary>
public class JBBasicWebPage :System.Web.UI.Page {
    public string SessionName { get; set; }
    public string SessionName2 { get; set; }
    public string SessionName3
    {
        get;
        set;
    }

    public JBBasicWebPage()
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
            RadScriptManager.RegisterStartupScript(this, typeof(Page), this.GetType().ToString(), "alert('" + message + "');", true);
        }
    }

    protected override void OnInit(EventArgs e) 
    {
        this.Load += new System.EventHandler(this.JBPage_Load);
        this.Error += new System.EventHandler(this.JBPage_Error);

        base.OnInit(e);
        SessionName = this.GetType().ToString();
        SessionName2 = this.GetType().ToString()+"2";
        SessionName3 = this.GetType().ToString() + "3";
    }

    protected void JBPage_Error(object sender, System.EventArgs e) {
        string errMsg;
        Exception currentError = Server.GetLastError();

        errMsg = "";
        errMsg += " <div i class=\"warning\" style=\"height:30px;width:95%;\">" +
          "The error occurred in: " + Request.Url.ToString() + "<br/>" +
            "Error Message: <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
            "</div>";


        if (!(currentError is AppException)) {
            // It is not one of ours, so we cannot guarantee that it has been logged
            // into the event log.
          //  LogEvent(currentError.ToString(), EventLogEntryType.Error);
        }

        Response.Write(errMsg);
        Server.ClearError();
    }
    protected void LogEvent(string message, EventLogEntryType entryType) {
        new AppException(message);
    }


    private void JBPage_Load(object sender, System.EventArgs e) {
        // TODO: Place any code that will take place BEFORE the Page_Load event
        // in the regular page, e.g. cache management, authentication verification,
        // etc.											

    }

    public override void VerifyRenderingInServerForm(Control control) {
    }



    public string BaseUrl {
        get {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }

    public string FullBaseUrl {
        get {
            return this.Request.Url.AbsoluteUri.Replace(
               this.Request.Url.PathAndQuery, "") + this.BaseUrl;
        }
    }
}