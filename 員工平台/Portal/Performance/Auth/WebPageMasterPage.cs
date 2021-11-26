using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// JMasterPage 的摘要描述
/// </summary>
public class WebPageMasterPage : System.Web.UI.MasterPage
{
    public string _SessionName1 { get; set; }
    public string _SessionName2 { get; set; }
    public string _SessionName3 { get; set; }

    public User _User;

    public ShareValidateDao oValidateDao = new ShareValidateDao();
    public MainDao oMainDao = new MainDao();

    public AuthManager _AuthManager = new AuthManager();

    public dcHrDataContext dcHr = new dcHrDataContext();
    public dcShareDataContext dcShare = new dcShareDataContext();
    public dcPerformanceDataContext dcMain = new dcPerformanceDataContext();

    public WebPageMasterPage()
    {
    }

    protected override void OnInit(EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            _User = new User();
            //Response.Redirect("Login.aspx", true);
            ////FormsAuthentication.RedirectToLoginPage();
            //HttpContext.Current.Response.End();
        }
        else
        {
            _User = _AuthManager.GetCacheUser(Context.User.Identity.Name);
        }

        base.OnInit(e);
    }

    protected void PageError(object sender, System.EventArgs e)
    {
        //string errMsg;
        Exception currentError = Server.GetLastError();

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

        //Response.Write(errMsg);
        Server.ClearError();
    }

    protected void LogEvent(string message, EventLogEntryType entryType)
    {
        //new AppException(message);
    }
}