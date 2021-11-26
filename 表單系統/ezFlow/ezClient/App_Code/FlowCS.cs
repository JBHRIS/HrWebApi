using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Collections;
using System.Text;

/// <summary>
/// FlowCS 的摘要描述
/// </summary>
public class FlowCS
{
    public FlowCS()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    //編碼
    public static string encode(String strData)
    {
        try
        {
            return System.Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(strData));
        }
        catch
        {
            return "";
        }
    }

    //解碼
    public static string decode(String strData)
    {
        try
        {
            return System.Text.UTF8Encoding.UTF8.GetString(System.Convert.FromBase64String(strData));
        }
        catch
        {
            return "";
        }
    }

    //解碼後編成Hashtable
    public static Hashtable QueryValue(string _do)
    {
        string[] s = _do.Split('&');
        Hashtable ht = new Hashtable();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].IndexOf("=") > 0)
            {
                string key = "";
                string values = "";
                key = s[i].Substring(0, s[i].IndexOf("="));
                values = s[i].Substring(s[i].IndexOf("=") + 1);
                ht.Add(key, values);
            }
        }
        return ht;
    }

    //轉換表單時間為分鐘數
    public static int GetMinutes(string s)
    {
        s = (s.Trim().Length < 4) ? "0000" : s;
        return int.Parse(s.Substring(0, 2)) * 60 + int.Parse(s.Substring(2, 2));
    }

    //轉換表單時間為分鐘數
    public static int GetMinutes(string s, bool cat)
    {
        s = (s.Trim().Length < 4) ? cat ? "0000" : "2400" : s;
        return int.Parse(s.Substring(0, 2)) * 60 + int.Parse(s.Substring(2, 2));
    }

    //分割時間字串為小時或分鐘
    public static string GetTimeSplit(string s, string hm)
    {
        s = (s.Trim().Length < 4) ? s.PadLeft(4, char.Parse("0")) : s;
        return (hm == "h") ? s.Substring(0, 2) : s.Substring(2, 2);
    }

    //分割時間字串為標準時間ex: 12 : 30 : 00
    public static string GetTimeSplit(string s)
    {
        s = (s.Trim().Length < 4) ? s.PadLeft(4, char.Parse("0")) : s;
        return s.Substring(0, 2) + ":" + s.Substring(2, 2) + ":00";
    }

    //將時間轉成MMDD
    public static string GetTimeSplit(DateTime d)
    {
        return d.Hour.ToString().PadLeft(2, char.Parse("0")) + d.Minute.ToString().PadLeft(2, char.Parse("0"));
    }

    public static void SendMail(string to, string subject, string body)
    {
        string mailServerName = "192.168.33.5";
        string from = "liang_hsiao@tmt-mems.com";
        bool isUseDefaultCredentials = true;
        string strFrom = "";
        string strFromPass = "";

        mailServerName = "nt1.jbjob.com.tw";
        from = "ming@jbjob.com.tw";
        isUseDefaultCredentials = false;
        strFrom = "ming";
        strFromPass = "4820";

        try
        {
            using (MailMessage message =
                new MailMessage(from, to, subject, body))
            {
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                message.BodyEncoding = System.Text.Encoding.Default;
                message.SubjectEncoding = System.Text.Encoding.Default;

                SmtpClient mailClient = new SmtpClient(mailServerName);
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
                else
                {
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
                }

                mailClient.Send(message);
            }
        }
        catch (Exception ex)
        {
        }
    }
}