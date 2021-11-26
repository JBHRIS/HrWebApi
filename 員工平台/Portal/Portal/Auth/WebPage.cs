using Dal;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

public class WebPage : System.Web.UI.Page
{
    public static string _SystemCode = "Portal";
    public static string _Language = "zh-TW";

    private static string ShareConnectionStrings
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["Dal.Properties.Settings.ShareConnectionString"].ConnectionString;
        }
    }

    /// <summary>
    /// 保持同一個連線
    /// </summary>
    public static dcShareDataContext dcShare
    {
        get
        {
            if (DataCache && UnobtrusiveSession.Session["dcShare"] != null)
            {
                return (dcShareDataContext)UnobtrusiveSession.Session["dcShare"];
            }
            else
            {
                var dc = new dcShareDataContext(ShareConnectionStrings);
                UnobtrusiveSession.Session["dcShare"] = dc;
                return dc;
            }

            //return new dcShareDataContext(ConnectionStrings);
        }
    }

    /// <summary>
    /// 連線字串
    /// </summary>
    public static bool DataCache
    {
        get
        {
            return ConfigurationManager.AppSettings["DataCache"] == "1";
        }
    }

    /// <summary>
    /// 連線字串
    /// </summary>
    public static bool DataDb
    {
        get
        {
            return ConfigurationManager.AppSettings["DataDb"] == "1";
        }
    }

    public static string GetActivePage
    {
        get
        {
            string ApplicationPath = HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath;
            string Path = HttpContext.Current.Request.Url.AbsolutePath.Substring(ApplicationPath.Length + 1);

            return Path;
        }
    }

    /// <summary>
    /// 取得 目前正在執行的 Function Info 資訊
    /// </summary>
    /// <returns></returns>
    public static String GetCurrentMethodInfo()
    {
        string showString = "";
        //取得當前方法類別命名空間名稱
        showString += "Namespace:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "\n";
        //取得當前類別名稱
        showString += "class Name:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "\n";
        //取得當前所使用的方法
        showString += "Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n";

        return showString;
    }

    /// <summary>
    /// 取得父類別的相關資訊(共用的Functiond可用)
    /// </summary>
    /// <returns></returns>
    public static String GetParentInfo()
    {
        String showString = "";
        StackTrace ss = new StackTrace(true);
        //取得呼叫當前方法之上一層類別(GetFrame(1))的屬性
        MethodBase mb = ss.GetFrame(1).GetMethod();

        //取得呼叫當前方法之上一層類別(父方)的命名空間名稱
        showString += mb.DeclaringType.Namespace + "\n";

        //取得呼叫當前方法之上一層類別(父方)的function 所屬class Name
        showString += mb.DeclaringType.Name + "\n";

        //取得呼叫當前方法之上一層類別(父方)的Full class Name
        showString += mb.DeclaringType.FullName + "\n";

        //取得呼叫當前方法之上一層類別(父方)的Function Name
        showString += mb.Name + "\n";

        return showString;
    }

    public static string GetClientIP(HttpContext context)
    {
        string strIPAddr;
        string strHttpXForwardedFor = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(strHttpXForwardedFor) ||
            (strHttpXForwardedFor.IndexOf("unknown") >= 0))
        {
            strIPAddr = context.Request.ServerVariables["REMOTE_ADDR"];
        }
        else if (strHttpXForwardedFor.IndexOf(",") >= 0)
        {
            strIPAddr = strHttpXForwardedFor.Substring(0, strHttpXForwardedFor.IndexOf(","));
        }
        else if (strHttpXForwardedFor.IndexOf(";") >= 0)
        {
            strIPAddr = strHttpXForwardedFor.Substring(0, strHttpXForwardedFor.IndexOf(";"));
        }
        else
        {
            strIPAddr = strHttpXForwardedFor;
        }
        return strIPAddr.Trim();
    }
}