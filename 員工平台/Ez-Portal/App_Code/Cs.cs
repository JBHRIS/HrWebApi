using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;

/// <summary>
/// Cs 的摘要描述
/// </summary>
public class Cs
{
	public Cs()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    static public string encode(String strData)
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

    static public string decode(String strData)
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

    private static int Asc(String S)
    {
        return (int)Encoding.ASCII.GetBytes(S)[0];
    }

    private static char Chr(int i)
    {
        return Convert.ToChar(i);
    }
    public static string stringReplace(string s)
    {
        s = s.Replace("[", " ");
        s = s.Replace("]", " ");
        s = s.Replace("{", " ");
        s = s.Replace("}", " ");
        s = s.Replace(";", " ");
        s = s.Replace("&", " ");
        s = s.Replace(",", " ");
        s = s.Replace("<", " ");
        s = s.Replace(">", " ");
        s = s.Replace("'", " ");
        s = s.Replace("*", " ");
        return s;
    }

    static public Hashtable QueryValue(string _do)
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
}
