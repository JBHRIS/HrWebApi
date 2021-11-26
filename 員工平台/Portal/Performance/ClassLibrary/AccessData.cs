using Bll;
using Bll.Employee.Vdb;
using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Dal.Dao.Employee;
using Dal.Dao.Share;
using Dal.Dao.Token;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class AccessData
{
    /// <summary>
    /// 設定Cookie
    /// </summary>
    /// <param name="CookieName">Cookie名稱</param>
    /// <param name="Param">參數</param>
    /// <param name="ExpiresMinutes">有效分鐘</param>
    public static void SetCookie(string CookieName, string Param, int ExpiresMinutes = 20)
    {
        HttpCookie cookie = new HttpCookie(CookieName);
        cookie.Value = Security.Encrypt(Param);
        cookie.Expires = DateTime.Now.AddHours(ExpiresMinutes);
        HttpContext.Current.Response.Cookies.Add(cookie);
    }

    /// <summary>
    /// 取得Cookie
    /// </summary>
    /// <param name="CookieName">Cookie名稱</param>
    /// <returns>HttpCookie</returns>
    public static HttpCookie GetCookie(string CookieName)
    {
        HttpCookie cookie = null;
        if (HttpContext.Current.Request.Cookies[CookieName] != null)
        {
            cookie = HttpContext.Current.Request.Cookies[CookieName];
        }

        return cookie;
    }

    /// <summary>
    /// 清除Cookie
    /// </summary>
    /// <param name="CookieName">Cookie名稱</param>
    public static void RemoveCookie(string CookieName)
    {
        HttpCookie cookie = new HttpCookie(CookieName);
        cookie.Expires = DateTime.Now.AddDays(-1);
        cookie.Values.Clear();
        HttpContext.Current.Response.Cookies.Add(cookie);
    }

    /// <summary>
    /// 取得Cookie並轉為Dictionary
    /// </summary>
    /// <param name="CookieName">Cookie名稱</param>
    /// <returns>Dictionary</returns>
    public static Dictionary<string, string> GetCookieToDictionary(string CookieName)
    {

        var dc = new Dictionary<string, string>();
        if (HttpContext.Current.Request.Cookies[CookieName] != null)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            string RequestQueryString = Security.Decrypt(cookie.Value);
            dc = DataTrans.QueryStringToDictionary(RequestQueryString);
        }

        return dc;
    }

    /// <summary>
    /// 取得Cookie並轉為T
    /// </summary>
    /// <param name="CookieName">Cookie名稱</param>
    /// <returns>Dictionary</returns>
    public static T GetCookieToJsonObject<T>(string CookieName) where T : new()
    {
        if (HttpContext.Current.Request.Cookies[CookieName] != null)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            string RequestQueryString = Security.Decrypt(cookie.Value);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(RequestQueryString);
            return obj;
        }
        else
        {
            return new T();
        }
    }

    /// <summary>
    /// 取得部門人員名單
    /// </summary>
    /// <param name="_User"></param>
    /// <returns>List TextValueRow</returns>
    public static List<TextValueRow> GetDeptListEmp(User _User)
    {
        //取得部門人員名單
        var rsPeopleByDept = new List<PeopleByDeptRow>();
        {
            var oPeopleByDept = new PeopleByDeptDao();
            var PeopleByDeptCond = new PeopleByDeptConditions();
            PeopleByDeptCond.AccessToken = _User.AccessToken;
            PeopleByDeptCond.RefreshToken = _User.RefreshToken;
            PeopleByDeptCond.checkDate = DateTime.Now.Date;
            PeopleByDeptCond.deptList = new List<string>();
            PeopleByDeptCond.deptList.Add(_User.EmpDeptCode);
            var Result = oPeopleByDept.GetData(PeopleByDeptCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rsPeopleByDept = Result.Data as List<PeopleByDeptRow>;
                }
            }
        }

        //從部門代碼取得人員資訊
        var rsEmployeeView = new List<EmployeeViewRow>();
        {
            var ListEmpId = new List<string>();
            if (rsPeopleByDept != null)
            {
                ListEmpId = rsPeopleByDept.Select(p => p.EmpId).ToList();
            }
            else
            {
                ListEmpId.Add(_User.EmpId);
            }
            var oEmployeeView = new EmployeeViewDao();
            var EmployeeViewCond = new EmployeeViewConditions();
            EmployeeViewCond.AccessToken = _User.AccessToken;
            EmployeeViewCond.RefreshToken = _User.RefreshToken;
            EmployeeViewCond.ListEmpId = ListEmpId;
            var Result = oEmployeeView.GetData(EmployeeViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rsEmployeeView = Result.Data as List<EmployeeViewRow>;
                }
            }
        }

        var rs = new List<TextValueRow>();
        if (rsEmployeeView != null)
        {
            foreach (var rEmployeeView in rsEmployeeView)
            {
                var r = new TextValueRow();
                r.Text = rEmployeeView.EmpName + "," + rEmployeeView.EmpId;
                r.Value = rEmployeeView.EmpId;
                rs.Add(r);
            }
        }
        rs = rs.OrderBy(p => p.Value).ToList();

        return rs;
    }

    /// <summary>
    /// 取得字典檔
    /// </summary>
    public static List<ShareDictionaryRow> ListShareDictionary
    {
        get
        {
            var Value = new List<ShareDictionaryRow>();
            if (WebPage.DataCache && UnobtrusiveSession.Session["ShareDictionary"] != null)
            {
                Value = (List<ShareDictionaryRow>)UnobtrusiveSession.Session["ShareDictionary"];
            }
            else
            {
                var oShareDictionary = new ShareDictionaryDao();
                var ShareDictionaryCond = new ShareDictionaryConditions();
                ShareDictionaryCond.SystemCode = WebPage._SystemCode;
                Value = oShareDictionary.GetShareDictionary(ShareDictionaryCond);

                UnobtrusiveSession.Session["ShareDictionary"] = Value;
            }

            return Value;
        }
    }

    /// <summary>
    /// 設定將字典檔裡的欄位名稱寫回dt
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="ListGroupCode"></param>
    public static void SetColumnsName(DataTable dt, List<string> ListGroupCode = null)
    {
        var rs = ListShareDictionary.Where(p => p.GroupCode == "Share" || ListGroupCode.Contains(p.GroupCode)).ToList();
        var ListColumns = dt.Columns.Cast<DataColumn>().ToList();

        foreach (DataColumn col in ListColumns)
        {
            var ColumnName = col.ColumnName;

            var rsTemp = rs.Where(p => p.Code == ColumnName).ToList();
            if (rsTemp.Count > 0)
            {
                var r = rsTemp.OrderBy(p => p.Sort).First();
                if (r != null)
                    switch (WebPage._Language)
                    {
                        case "zh-TW":
                            dt.Columns[ColumnName].ColumnName = r.Name1;
                            break;
                        case "2":
                            dt.Columns[ColumnName].ColumnName = r.Name2;
                            break;
                        case "3":
                            dt.Columns[ColumnName].ColumnName = r.Name2;
                            break;
                    }
            }
        }
    }
}