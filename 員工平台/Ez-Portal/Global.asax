<%@ Application Language="C#" %>
<%@ Import Namespace="JB.WebModules.Authentication" %>
<%@ Import Namespace="BL" %>
<script runat="server">        
    
    void Application_Start(object sender, EventArgs e) 
    {
        // 應用程式啟動時執行的程式碼
        Application["ServerStart"] = DateTime.Now;
        
    }
    
    
    void Application_End(object sender, EventArgs e) 
    {
        //  應用程式關閉時執行的程式碼       

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Exception lastException = Server.GetLastError();
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        logger.Fatal(lastException);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 啟動新工作階段時執行的程式碼
//        'Session_OnStart is automatically called by the ASP Interpreter
//    'when a new session starts. (Probably a new visitor)

//    'TimeOut value determines the period in minutes when 
//    'the session is assumed to be abandoned
       
        //Session.Timeout = 10;
        // 工作階段結束時執行的程式碼。 
        // 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        // 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        // 或 SQLServer，就不會引發這個事件。
        // 啟動新工作階段時執行的程式碼
        //        'Session_OnStart is automatically called by the ASP Interpreter
        //    'when a new session starts. (Probably a new visitor)

        //    'TimeOut value determines the period in minutes when 
        //    'the session is assumed to be abandoned

        //Session.Timeout = 10;
        Application.Lock();

        Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"]) + 1;
        Application["Visitors"] = Convert.ToInt32(Application["Visitors"]) + 1;

        if (Application["TodaysDate"] == null)
        {
            Application["TodaysDate"] = DateTime.Now;
            Hashtable ht = new Hashtable();
            Application["UserList"] = ht;
            ArrayList al = new ArrayList();
            Application["UserSessionID"] = al;

        }
        else
        {
            if (DateTime.Parse(Application["TodaysDate"].ToString()).ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
            {
                Application["PageViewsToday"] = 0;
                Application["VisitorsToday"] = 0;
            }
        }

        Application["VisitorsToday"] = Convert.ToInt32(Application["VisitorsToday"]) + 1;
        Application["TodaysDate"] = DateTime.Now;
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 工作階段結束時執行的程式碼。 
        // 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        // 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        // 或 SQLServer，就不會引發這個事件。
        try
        {
            Application.Lock();
            Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"].ToString()) - 1;
            Hashtable ht = (Hashtable)Application["UserList"];
            ArrayList al = (ArrayList)Application["UserSessionID"];
            HRDsTableAdapters.sysLoginTimeTableAdapter vd = new HRDsTableAdapters.sysLoginTimeTableAdapter();
            HRDs.sysLoginTimeDataTable rq_sysLogin = vd.GetDataBy_User(ht[Session.SessionID].ToString(), Session.SessionID.ToString());
            if (rq_sysLogin.Rows.Count > 0)
            {
                rq_sysLogin.Rows[0]["dLogoutTime"] = DateTime.Now.AddMinutes(-20);
            }
            vd.Update(rq_sysLogin);
            ht.Remove(Session.SessionID);
            al.Remove(Session.SessionID);
            Application.UnLock();
        }
        catch
        {
            Application.UnLock();
        }
    }
    protected void Application_BeginRequest(Object sender, EventArgs e) 
    {        
        ThunderMain.URLRewriter.Rewriter.Process();
    }

    void Application_AuthenticateRequest(object sender , EventArgs e)
    {
        //if ( Request.IsAuthenticated )
        //{
        //    //// 先取得該使用者的 FormsIdentity
        //    //FormsIdentity id = (FormsIdentity) User.Identity;
        //    //// 再取出使用者的 FormsAuthenticationTicket
        //    //FormsAuthenticationTicket ticket = id.Ticket;
        //    //// 將儲存在 FormsAuthenticationTicket 中的角色定義取出，並轉成字串陣列
        //    //string[] roles = ticket.UserData.Split(new char[] { ',' });
        //    //// 指派角色到目前這個 HttpContext 的 User 物件去
        //    //Context.User = new GenericPrincipal(Context.User.Identity , roles);
    

        //}
    }
       
</script>
