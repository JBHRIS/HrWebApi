<%@ Application Language="C#" %>
<%@ Import Namespace="System.Timers" %>
<%@ Import Namespace="Repo" %>

<script runat="server">

    protected NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    private DateTime lastExcuteDateTime2400 = DateTime.MinValue;
    private DateTime lastExcuteDateTime0700 = DateTime.MinValue;
    
    void Application_Start(object sender, EventArgs e) 
    {
        // 應用程式啟動時執行的程式碼
        System.Timers.Timer dailyTimer = new System.Timers.Timer();
        dailyTimer.Interval = 3590000;//3600000; 
       
        dailyTimer.Enabled = true;
        dailyTimer.Elapsed += new ElapsedEventHandler(dailyTimer_Elapsed);
    }

    void dailyTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        try
        {
            logger.Info("dailyTimer excute");
            DateTime datetime = DateTime.Now;

            if (datetime.Hour == 0 && lastExcuteDateTime2400.Date.CompareTo(datetime.Date) < 0)
            {
                trOJTStudentM_Repo ojtSmRepo = new trOJTStudentM_Repo();
                BASE_Repo baseRepo = new BASE_Repo();
                List<BASE> baseList = baseRepo.GetEmpHiredByDate_Dlo(datetime.Date);
                foreach (var b in baseList)
                {
                    ojtSmRepo.CheckEmpOjtCard(b.NOBR);
                }
                
                lastExcuteDateTime2400 = datetime;
            }

            if (datetime.Hour == 7 && lastExcuteDateTime0700.Date.CompareTo(datetime.Date) < 0)
            {
                trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
                tsmRepo.NotifyClassReportNeedToFillOut(datetime);

                qBaseM_Repo bmRepo = new qBaseM_Repo();
                bmRepo.NotifyQANeedToFillOut(datetime);
            }
            
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  應用程式關閉時執行的程式碼
        System.Threading.Thread.Sleep(1000);
        string url = @"http://127.0.0.1/";
        System.Net.HttpWebRequest myHttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        System.Net.HttpWebResponse myHttpWebResponse = (System.Net.HttpWebResponse)myHttpWebRequest.GetResponse();
        System.IO.Stream receiveStream = myHttpWebResponse.GetResponseStream();

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 發生未處理錯誤時執行的程式碼
        Exception LastException = Server.GetLastError();
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        logger.Fatal(LastException);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 啟動新工作階段時執行的程式碼

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 工作階段結束時執行的程式碼。 
        // 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        // 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        // 或 SQLServer，就不會引發這個事件。

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        /* Fix for the Flash Player Cookie bug in Non-IE browsers.
         * Since Flash Player always sends the IE cookies even in FireFox
         * we have to bypass the cookies by sending the values as part of the POST or GET
         * and overwrite the cookies with the passed in values.
         * 
         * The theory is that at this point (BeginRequest) the cookies have not been read by
         * the Session and Authentication logic and if we update the cookies here we'll get our
         * Session and Authentication restored correctly
         */

    }

    
</script>
