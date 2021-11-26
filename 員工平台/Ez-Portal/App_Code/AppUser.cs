using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// AppUser 的摘要描述
/// </summary>
public class AppUser
{
	public AppUser()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    static public void login(Page page, string userID)
    {
        ArrayList al = (ArrayList)page.Application["UserSessionID"];
        if(al.Contains(page.Session.SessionID))
            al.Remove(page.Session.SessionID);        
        al.Add(page.Session.SessionID);
        Hashtable ht = (Hashtable)page.Application["UserList"];
        if(ht.Contains(page.Session.SessionID))
            ht.Remove(page.Session.SessionID);
        ht.Add(page.Session.SessionID, userID);
    }

    static public void Logout(Page page) 
    {
        try
        {
            page.Session.Abandon();
            page.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
        catch (Exception e)
        {
            string _dd = e.Message;
        }
    }
  
    static public DataTable getUserList(Page page) 
    {        
            Hashtable ht = (Hashtable)page.Application["UserList"];
            ArrayList al = (ArrayList)page.Application["UserSessionID"];
            ArrayList alUserList = new ArrayList();
            DataTable dt = new DataTable();
            dt.Columns.Add("員工編號");

            for (int i = 0; i < al.Count; i++)
            {
                if (!alUserList.Contains(ht[al[i]].ToString()))
                {
                    DataRow row = dt.NewRow();
                    row[0] = ht[al[i]].ToString();
                    alUserList.Add(ht[al[i]].ToString());
                    dt.Rows.Add(row);
                }
            }
            return dt;
        
       
    }

}
