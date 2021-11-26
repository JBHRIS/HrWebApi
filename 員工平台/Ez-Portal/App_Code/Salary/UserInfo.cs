using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Management;


/// <summary>
/// UserInfo 的摘要描述
/// </summary>
namespace sa
{
    public class UserInfo
    {
        private string macAddress;
        private string ipAddress;

       

        //取得Client端的IP位址
        public static string GetClientIP()
        {
            string strIpAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null || HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf("unknown") > 0)
            {
                strIpAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") > 0)
            {
                strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") - 1);
            }
            else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") > 0)
            {
                strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") - 1);
            }
            else
            {
                strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

            return strIpAddr;
        }

        //取得Server端的IP位址
        public static IPAddress[] GetServerIP()
        {
            return Dns.GetHostByName(Dns.GetHostName()).AddressList;
        }        

        public static string GetCurrentExecutionFileName()
        {
            return System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.Substring(System.Web.HttpContext.Current.Request.CurrentExecutionFilePath.LastIndexOf("/") + 1);
        }

        public string ServerMAC
        {
            get
            {
                return this.macAddress;
            }
        }

        public string ServerIP
        {
            get
            {
                return this.ipAddress;
            }
        }
    }
}