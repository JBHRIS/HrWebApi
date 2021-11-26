using Bll.Token.Vdb;
using Bll.Tools;
using Dal;
using Dal.Dao.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class AuthManager
{
    public dcHrDataContext dcHr = new dcHrDataContext();

    public static string CacheKey = "Performance";

    public void SetCacheUser(User user)
    {
        HttpContext.Current.Cache.Insert(CacheKey + user.UserCode, user, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(120), System.Web.Caching.CacheItemPriority.High, null);
    }

    public void ClearCacheUser(string Id)
    {
        HttpContext.Current.Cache.Remove(CacheKey + Id);
    }

    public User GetCacheUser(string Id)
    {
        string key = CacheKey + Id;
        if (HttpContext.Current.Cache[key] != null)
        {
            User oUserData = HttpContext.Current.Cache[key] as User;
            if (oUserData != null)
                return oUserData;
            else
            {
                var user = GetUser(Id);
                SetCacheUser(user);
                return GetCacheUser(user.UserCode);
            }
        }
        else
        {
            var user = GetUser(Id);
            SetCacheUser(user);
            return GetCacheUser(user.UserCode);
        }
    }

    //登入
    public void SignIn(User user, string OldId)
    {
        SignOut();

        //填入使用者資訊
        var rEmp = (from emp in dcHr.ViewEmp
                    join j in dcHr.ViewJob on emp.JobCode equals j.Code
                    where emp.Code == user.UserCode
                    select new
                    {
                        JobName = j.Name,
                        Email = emp.Email,
                    }).FirstOrDefault();

        if (rEmp != null)
        {
            user.EmpJobName = rEmp.JobName;
            user.EmpEmail = rEmp.Email;
        }

        user.IdentityName = HttpContext.Current.User.Identity.Name;

        DateTime deadLine = DateTime.Now.AddDays(1);

        //新增表單驗證用的票證
        var ticket = new FormsAuthenticationTicket(1,   //版本
                                                        //使用者名稱(名稱不可以太長 否則會存不進去)
            user.UserCode,
            //發行時間
            DateTime.Now,
            //有效期限
            deadLine,
            //是否將 Cookie 設定成 Session Cookie，如果是則會在瀏覽器關閉後移除
            false,
            //將要記錄的使用者資訊轉換為 JSON 字串
            JsonConvert.SerializeObject(user),
            //儲存 Cookie 的路徑
            FormsAuthentication.FormsCookiePath);

        //將 Ticket 加密
        var encTicket = FormsAuthentication.Encrypt(ticket);

        //將 Ticket 寫入 Cookie
        HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = deadLine;

        ClearCacheUser(OldId);
        SetCacheUser(user);
    }

    //登出
    public void SignOut()
    {
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();

        UnobtrusiveSession.Session["ReturnUrl"] = null;

        //移除瀏覽器的表單驗證
        FormsAuthentication.SignOut();
    }

    //取得使用者資訊
    public User GetUser()
    {
        //取得 ASP.NET 使用者
        var user = HttpContext.Current.User;

        //是否通過驗證
        if (user?.Identity?.IsAuthenticated == true)
        {
            //取得 FormsIdentity
            var identity = (FormsIdentity)user.Identity;

            //取得 FormsAuthenticationTicket
            var ticket = identity.Ticket;

            //將 Ticket 內的 UserData 解析回 User 物件
            return JsonConvert.DeserializeObject<User>(ticket.UserData);
        }
        return null;
    }

    /// <summary>
    /// 取得使用者資訊
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public User GetUser(string Id)
    {
        var oUser = new User();
        oUser.UserCode = Id;
        oUser.UserCodeOriginal = Id;
        oUser.RoleKey = 0;
        oUser.LoginStatus = "1";
        oUser.AccessToken = "";
        oUser.RefreshToken = "";

        oUser.EmpId = "";
        oUser.EmpName = "未登入";
        oUser.EmpEmail = "";
        oUser.EmpDeptCode = "";
        oUser.EmpJobName = "";
        oUser.EmpCompanyCode = "";
        oUser.ListDataGroupsCode = new List<string>();

        return oUser;
    }
}

public class User
{
    /// <summary>
    /// UserCode
    /// </summary>
    public string UserCode { set; get; }
    /// <summary>
    /// UserCodeOriginal
    /// </summary>
    public string UserCodeOriginal { set; get; }
    /// <summary>
    /// <summary>
    /// RoleKey
    /// </summary>
    public int RoleKey { set; get; }
    /// <summary>
    /// 登入狀態
    /// </summary>
    public string LoginStatus { set; get; }
    /// <summary>
    /// AccessToken
    /// </summary>
    public string AccessToken { set; get; }
    /// <summary>
    /// RefreshToken
    /// </summary>
    public string RefreshToken { set; get; }
    /// <summary>
    /// UserName
    /// </summary>
    public string EmpId { set; get; }
    /// <summary>
    /// UserName
    /// </summary>
    public string EmpName { set; get; }
    /// <summary>
    /// UserEmail
    /// </summary>
    public string EmpEmail { set; get; }
    /// <summary>
    /// UserDeptCode
    /// </summary>
    public string EmpDeptCode { set; get; }
    /// <summary>
    /// EmpJobName
    /// </summary>
    public string EmpJobName { set; get; }
    /// <summary>
    /// CompanyCode
    /// </summary>
    public string EmpCompanyCode { set; get; }
    /// <summary>
    /// ListDataGroups
    /// </summary>
    public List< string> ListDataGroupsCode { set; get; }
    /// <summary>
    /// IdentityName
    /// </summary>
    public string IdentityName { set; get; }
    /// <summary>
    /// 
    /// </summary>
    public User()
    {
        UserCode = Guid.NewGuid().ToString();
        UserCodeOriginal = UserCode;
        RoleKey = 0;
        LoginStatus = "0";
        AccessToken = "";
        RefreshToken = "";

        EmpId = "";
        EmpName = "未登入";
        EmpEmail = "";
        EmpDeptCode = "";
        EmpCompanyCode = "";
        ListDataGroupsCode = new List<string>();
        IdentityName =  HttpContext.Current.User.Identity.Name;
    }
}