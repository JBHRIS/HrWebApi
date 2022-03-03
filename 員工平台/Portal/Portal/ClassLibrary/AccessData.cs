using Bll;
using Bll.Employee.Vdb;
using Bll.Menu.Vdb;
using Bll.ApiVoid.Vdb;
using Bll.Role.Vdb;
using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Dal.Dao.Employee;
using Dal.Dao.ApiVoid;
using Dal.Dao.Menu;
using Dal.Dao.Role;
using Dal.Dao.Share;
using Dal.Dao.Token;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

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
    public static List<TextValueRow> GetDeptListEmp(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<TextValueRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["DeptListEmp"] != null)
        {
            Value = (List<TextValueRow>)UnobtrusiveSession.Session["DeptListEmp"];
        }

        //取得部門人員名單
        var rsPeopleByDept = new List<PeopleByDeptRow>();
        {
            var oPeopleByDept = new PeopleByDeptDao();
            var PeopleByDeptCond = new PeopleByDeptConditions();
            PeopleByDeptCond.AccessToken = _User.AccessToken;
            PeopleByDeptCond.RefreshToken = _User.RefreshToken;
            PeopleByDeptCond.CompanySetting = CompanySetting;
            PeopleByDeptCond.checkDate = DateTime.Now.Date;
            PeopleByDeptCond.deptList = _User.EmpDeptCode;
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
            EmployeeViewCond.CompanySetting = CompanySetting;
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
        UnobtrusiveSession.Session["DeptListEmp"] = rs;
        return rs;
    }
    /// <summary>
    /// 取得兼任部門及其向下
    /// </summary>
    /// <param name="_User"></param>
    /// <param name="CompanySetting"></param>
    /// <returns></returns>
    public static List<TextValueRow> GetPeopleByDepartmentExtraTree(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<TextValueRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["DepartmentExtraEmp"] != null)
        {
            Value = (List<TextValueRow>)UnobtrusiveSession.Session["DepartmentExtraEmp"];
        }
        else
        {
            var rsEmployeeView = new List<EmployeeViewRow>();
            var oPeopleByDepartmentExtraTree = new PeopleByDepartmentExtraTreeDao();
            var PeopleByDepartmentExtraTreeCond = new PeopleByDepartmentExtraTreeConditions();
            PeopleByDepartmentExtraTreeCond.AccessToken = _User.AccessToken;
            PeopleByDepartmentExtraTreeCond.RefreshToken = _User.RefreshToken;
            PeopleByDepartmentExtraTreeCond.checkDate = DateTime.Now.Date;
            PeopleByDepartmentExtraTreeCond.inCludeManager = true;
            var Result = oPeopleByDepartmentExtraTree.GetData(PeopleByDepartmentExtraTreeCond);
            if (Result.Status && Result.Data != null)
            {
                var rs = Result.Data as List<PeopleByDepartmentExtraTreeRow>;
                if (rs != null)
                {
                    var ListEmpId = rs.Select(p => p.EmpId).ToList();
                    var oEmployeeView = new EmployeeViewDao();
                    var EmployeeViewCond = new EmployeeViewConditions();
                    EmployeeViewCond.AccessToken = _User.AccessToken;
                    EmployeeViewCond.RefreshToken = _User.RefreshToken;
                    EmployeeViewCond.CompanySetting = CompanySetting;
                    EmployeeViewCond.ListEmpId = ListEmpId;
                    var EmployeeViewResult = oEmployeeView.GetData(EmployeeViewCond);
                    
                    if (EmployeeViewResult.Status)
                    {
                        if (EmployeeViewResult.Data != null)
                        {
                            rsEmployeeView = EmployeeViewResult.Data as List<EmployeeViewRow>;
                        }
                    }
                }
            }
            
            if (rsEmployeeView != null)
            {
                foreach (var rEmployeeView in rsEmployeeView)
                {
                    var r = new TextValueRow();
                    r.Text = rEmployeeView.EmpName + "," + rEmployeeView.EmpId;
                    r.Value = rEmployeeView.EmpId;
                    Value.Add(r);
                }
            }
            Value = Value.OrderBy(p => p.Value).ToList();
            UnobtrusiveSession.Session["DepartmentExtraEmp"] = Value;
        }
        return Value;
    }

    /// <summary>
    /// 取得查詢頁面人員名單:員工只查自己，主管查本部門及其向下，助理查有權限的其他部門及其向下
    /// </summary>
    /// <param name="_User"></param>
    /// <returns>List TextValueRow</returns>
    public static List<TextValueRow> GetSearchListEmp(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<TextValueRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["SearchListEmp"] != null)
        {
            Value = (List<TextValueRow>)UnobtrusiveSession.Session["SearchListEmp"];
        }
        
        var rsEmployeeView = new List<EmployeeViewRow>();
        var result = new List<TextValueRow>();
        if (_User.Role != null && _User.Role.Contains("Manager"))
        {
            var rs = GetPeopleByDeptTree(_User, CompanySetting);

            var Dept = new List<string>();
            Dept.Add(_User.Dept);
            var rsPeopleByDept = new List<PeopleByDeptRow>();
            var oPeopleByDept = new PeopleByDeptDao();
            var PeopleByDeptCond = new PeopleByDeptConditions();
            PeopleByDeptCond.AccessToken = _User.AccessToken;
            PeopleByDeptCond.RefreshToken = _User.RefreshToken;
            PeopleByDeptCond.CompanySetting = CompanySetting;
            PeopleByDeptCond.checkDate = DateTime.Now.Date;
            PeopleByDeptCond.deptList = Dept;
            var Result = oPeopleByDept.GetData(PeopleByDeptCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rsPeopleByDept = Result.Data as List<PeopleByDeptRow>;
                }
            }

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
            EmployeeViewCond.CompanySetting = CompanySetting;
            EmployeeViewCond.ListEmpId = ListEmpId;
            var EmployeeViewResult = oEmployeeView.GetData(EmployeeViewCond);

            if (EmployeeViewResult.Status)
            {
                if (EmployeeViewResult.Data != null)
                {
                    rsEmployeeView = EmployeeViewResult.Data as List<EmployeeViewRow>;
                }
            }
            var rs1 = new List<TextValueRow>();
            if (rsEmployeeView != null)
            {
                foreach (var rEmployeeView in rsEmployeeView)
                {
                    var r = new TextValueRow();
                    r.Text = rEmployeeView.EmpName + "," + rEmployeeView.EmpId;
                    r.Value = rEmployeeView.EmpId;
                    rs1.Add(r);
                }
            }
            rs1 = rs1.OrderBy(p => p.Value).ToList();

            result = rs.Union(rs1).ToList();
            
        }
        if (_User.Role != null && _User.Role.Contains("Coordinator"))
        {
            var rs = GetDeptListEmp(_User, CompanySetting);
            var rs1 = GetPeopleByDepartmentExtraTree(_User, CompanySetting);
            rs = rs.Union(rs1).ToList();

            if (result.Count==0)
            {
                result = rs;
            }
            else
            { 
                result = result.Union(rs).ToList();
            }

        }

        if (result.Count == 0)
        {
            var Data = new TextValueRow();
            Data.Text = _User.EmpName + "," + _User.EmpId;
            Data.Value = _User.EmpId;
            result.Add(Data);
        }

        var key = new Dictionary<string, string>();
        foreach (var r in result.ToArray())
        {
            if (key.ContainsKey(r.Value))
            {
                result.Remove(r);
            }
            else
            {
                key.Add(r.Value, r.Value);
            }
        }

        result = result.OrderBy(p => p.Value).ToList();
        UnobtrusiveSession.Session["SearchListEmp"] = result;
        return result;
    }
    /// <summary>
    /// 取得部門人員名單及其向下
    /// </summary>
    /// <param name="_User"></param>
    /// <returns>List TextValueRow</returns>
    public static List<TextValueRow> GetPeopleByDeptTree(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<TextValueRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["PeopleByDeptTree"] != null)
        {
            Value = (List<TextValueRow>)UnobtrusiveSession.Session["PeopleByDeptTree"];
        }
        //取得部門人員名單
        var rsPeopleByDept = new List<PeopleByDeptTreeRow>();
        {
            var oPeopleByDept = new PeopleByDeptTreeDao();
            var PeopleByDeptCond = new PeopleByDeptTreeConditions();
            PeopleByDeptCond.AccessToken = _User.AccessToken;
            PeopleByDeptCond.RefreshToken = _User.RefreshToken;
            PeopleByDeptCond.CompanySetting = CompanySetting;
            PeopleByDeptCond.checkDate = DateTime.Now.Date;
            PeopleByDeptCond.inCludeManager = true;
            var Result = oPeopleByDept.GetData(PeopleByDeptCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rsPeopleByDept = Result.Data as List<PeopleByDeptTreeRow>;
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
            EmployeeViewCond.CompanySetting = CompanySetting;
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
        UnobtrusiveSession.Session["PeopleByDeptTree"] = rs;
        return rs;
    }
    
    public static List<TextValueRow> GetPeopleByDeptaTree(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<TextValueRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["PeopleByDeptATree"] != null)
        {
            Value = (List<TextValueRow>)UnobtrusiveSession.Session["PeopleByDeptATree"];
        }
        //取得部門人員名單
        var rsPeopleByDept = new List<PeopleByDeptaTreeRow>();
        {
            var oPeopleByDept = new PeopleByDeptaTreeDao();
            var PeopleByDeptaCond = new PeopleByDeptaTreeConditions();
            PeopleByDeptaCond.AccessToken = _User.AccessToken;
            PeopleByDeptaCond.RefreshToken = _User.RefreshToken;
            PeopleByDeptaCond.CompanySetting = CompanySetting;
            PeopleByDeptaCond.checkDate = DateTime.Now.Date;
            PeopleByDeptaCond.inCludeManager = true;
            var Result = oPeopleByDept.GetData(PeopleByDeptaCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rsPeopleByDept = Result.Data as List<PeopleByDeptaTreeRow>;
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
            EmployeeViewCond.CompanySetting = CompanySetting;
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
        UnobtrusiveSession.Session["PeopleByDeptATree"] = rs;
        return rs;
    }

    public static List<TextValueRow> GetPeopleList(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<TextValueRow>();
        //if (UnobtrusiveSession.Session["PeopleList"] != null && UnobtrusiveSession.Session["PeopleList"] != "")
        //{
        //    Value = (List<TextValueRow>)UnobtrusiveSession.Session["PeopleList"];
        //}
        //else
        {
            var rsData = new List<PeopleRow>();
            var oPeople = new PeopleDao();
            var PeopleCond = new PeopleConditions();
            PeopleCond.AccessToken = _User.AccessToken;
            PeopleCond.RefreshToken = _User.RefreshToken;
            PeopleCond.CompanySetting = CompanySetting;
            var Result = oPeople.GetData(PeopleCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                    rsData = Result.Data as List<PeopleRow>;

            }
            Value = new List<TextValueRow>();
            if (rsData != null)
            {
                foreach (var rData in rsData)
                {
                    var r = new TextValueRow();
                    r.Text = r.Text = rData.EmpName + "," + rData.EmpId;
                    r.Value = rData.EmpId;
                    Value.Add(r);
                }
            }
        }

        UnobtrusiveSession.Session["PeopleList"] = Value;
        return Value;
    }
    public static List<ApiVoidRow> GetApiList(User _User, CompanySettingRow CompanySetting)
    {
        var oApiVoid = new ApiVoidDao();
        var ApiVoidCond = new ApiVoidConditions();
        ApiVoidCond.AccessToken = _User.AccessToken;
        ApiVoidCond.RefreshToken = _User.RefreshToken;
        ApiVoidCond.CompanySetting = CompanySetting;
        var rs = new List<ApiVoidRow>();

        var Result = oApiVoid.GetData(ApiVoidCond);
        if (Result.Status)
        {
            if (Result.Data != null)
            {
                rs = Result.Data as List<ApiVoidRow>;
            }
        }
        return rs;
    }

    public static List<SystemPageRow> GetMenuList(User _User, CompanySettingRow CompanySetting,string MenuCode="Root")
    {
        var Value = new List<SystemPageRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["MenuRow"] != null)
        {
            Value = (List<SystemPageRow>)UnobtrusiveSession.Session["MenuRow"];
            return Value;
        }
        var oAllMenu = new AllMenuDao();
        var AllMenuCond = new AllMenuConditions();
        AllMenuCond.AccessToken = _User.AccessToken;
        AllMenuCond.RefreshToken = _User.RefreshToken;
        AllMenuCond.CompanySetting = CompanySetting;
        AllMenuCond.code = MenuCode;
        var rs = new List<AllMenuRow>();

        var Result = oAllMenu.GetData(AllMenuCond);
        if (Result.Status)
        {
            if (Result.Data != null)
            {
                rs = Result.Data as List<AllMenuRow>;
            }
        }

        foreach (var rTarget in rs)
        {
            var rSystemPage = new SystemPageRow();
            rSystemPage.TypeCode = rTarget.TypeCode;
            rSystemPage.TypeName = rTarget.TypeName;
            rSystemPage.Code = rTarget.Code;
            rSystemPage.FilePath = rTarget.FilePath;
            rSystemPage.FileName = rTarget.FileName;
            rSystemPage.FileTitle = rTarget.FileTitle;
            rSystemPage.RoleKey = rTarget.RoleKey;
            rSystemPage.ParentCode = rTarget.ParentCode;
            rSystemPage.PathCode = rTarget.PathCode;
            rSystemPage.PathName = rTarget.PathName;
            rSystemPage.Tag = rTarget.tag;
            rSystemPage.IsAuth = rTarget.IsAuth;
            rSystemPage.Order = rTarget.Order;
            rSystemPage.OpenWindow = rTarget.OpenNewWin;
            Value.Add(rSystemPage);
        }
        UnobtrusiveSession.Session["MenuRow"] = Value;
        return Value;

    }
    public static List<SystemPageRow> GetListSystemPage(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<SystemPageRow>();

        if (WebPage.DataCache && UnobtrusiveSession.Session["SystemPage"] != null)
        {
            Value = (List<SystemPageRow>)UnobtrusiveSession.Session["SystemPage"];
        }
        else
        {

            var oMenu = new MenuDao();
            var MenuCond = new MenuConditions();
            MenuCond.AccessToken = _User.AccessToken;
            MenuCond.RefreshToken = _User.RefreshToken;
            MenuCond.CompanySetting = CompanySetting;
            MenuCond.code = "Menu";
            var rs = new List<MenuRow>();

            var Result = oMenu.GetData(MenuCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<MenuRow>;
                }
            }
            rs = rs.OrderBy(p => p.Order).ToList();
            foreach (var rTarget in rs)
            {
                var rSystemPage = new SystemPageRow();
                rSystemPage.TypeCode = rTarget.TypeCode;
                rSystemPage.TypeName = rTarget.TypeName;
                rSystemPage.Code = rTarget.Code;
                rSystemPage.FilePath = rTarget.FilePath;
                rSystemPage.FileName = rTarget.FileName;
                rSystemPage.FileTitle = rTarget.FileTitle;
                rSystemPage.RoleKey = rTarget.RoleKey;
                if (rTarget.ParentCode == MenuCond.code) rSystemPage.ParentCode = "";
                else rSystemPage.ParentCode = rTarget.ParentCode;
                rSystemPage.PathCode = rTarget.PathCode;
                rSystemPage.PathName = rTarget.PathName;
                rSystemPage.Icon = rTarget.TypeName;
                rSystemPage.IsAuth = rTarget.IsAuth;
                rSystemPage.OpenWindow = rTarget.OpenNewWin;
                Value.Add(rSystemPage);
            }

            UnobtrusiveSession.Session["SystemPage"] = Value;
        }

        return Value;

    }

    /// <summary>
    /// 取得權限列表
    /// </summary>
    /// <param name="_User"></param>
    /// <returns></returns>
    public static List<RoleRow> GetRoleList(User _User, CompanySettingRow CompanySetting)
    {
        var Value = new List<RoleRow>();
        if (WebPage.DataCache && UnobtrusiveSession.Session["RoleList"] != null)
        {
            Value = UnobtrusiveSession.Session["RoleList"] as List<RoleRow>;
        }
        else
        {
            var oNews = new RoleDao();
            var NewsCond = new RoleConditions();
            NewsCond.AccessToken = _User.AccessToken;
            NewsCond.RefreshToken = _User.RefreshToken;
            NewsCond.CompanySetting = CompanySetting;
            var Result = oNews.GetData(NewsCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    Value = Result.Data as List<RoleRow>;
                }
            }
        }

        return Value;
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
    /// DES加密
    /// </summary>
    /// <param name="data">加密資料</param>
    /// <param name="key">8位字元的金鑰字串</param>
    /// <param name="iv">8位字元的初始化向量字串</param>
    /// <returns></returns>
    public static string DESEncrypt(string data, string key, string iv)
    {
        byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
        byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        int i = cryptoProvider.KeySize;
        MemoryStream ms = new MemoryStream();
        CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

        StreamWriter sw = new StreamWriter(cst);
        sw.Write(data);
        sw.Flush();
        cst.FlushFinalBlock();
        sw.Flush();
        return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
    }

    /// <summary>
    /// DES解密
    /// </summary>
    /// <param name="data">解密資料</param>
    /// <param name="key">8位字元的金鑰字串(需要和加密時相同)</param>
    /// <param name="iv">8位字元的初始化向量字串(需要和加密時相同)</param>
    /// <returns></returns>
    public static string DESDecrypt(string data, string key, string iv)
    {
        byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
        byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

        byte[] byEnc;
        try
        {
            byEnc = Convert.FromBase64String(data);
        }
        catch
        {
            return null;
        }

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream ms = new MemoryStream(byEnc);
        CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
        StreamReader sr = new StreamReader(cst);
        return sr.ReadToEnd();
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

    /// <summary>
    /// OAuth2Google
    /// </summary>
    public static DefaultOAuth2GoogleRow DefaultOAuth2Google
    {
        get
        {
            var Value = new DefaultOAuth2GoogleRow();

            if (AccessData.DefaultSystem.DataCache && UnobtrusiveSession.Session["DefaultOAuth2Google"] != null)
            {
                Value = (DefaultOAuth2GoogleRow)UnobtrusiveSession.Session["DefaultOAuth2Google"];
            }
            else
            {
                var oShareDefault = new ShareDefaultDao();
                Value = oShareDefault.DefaultOAuth2Google;

                //本網站認證網頁 http處理 如果是絕對路徑 則不需要改變 如果是相對路徑 就要加上網站http
                if (Value.RedirectUrl.IndexOf("http") == -1)
                {
                    string ApplicationPath = HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath;
                    string Path = HttpContext.Current.Request.Url.AbsolutePath.Substring(ApplicationPath.Length, HttpContext.Current.Request.Url.AbsolutePath.Length - ApplicationPath.Length);

                    Value.RedirectUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(Path, "/" + Value.RedirectUrl);
                }

                UnobtrusiveSession.Session["DefaultOAuth2Google"] = Value;
            }


            return Value;
        }
    }

    /// <summary>
    /// 系統共用參數
    /// </summary>
    public static DefaultSystemRow DefaultSystem
    {
        get
        {
            var Value = new DefaultSystemRow();

            if (UnobtrusiveSession.Session["DefaultSystem"] != null)
            {
                Value = (DefaultSystemRow)UnobtrusiveSession.Session["DefaultSystem"];
            }
            else
            {
                var oShareDefault = new ShareDefaultDao();
                Value = oShareDefault.DefaultSystem;

                UnobtrusiveSession.Session["DefaultSystem"] = Value;
            }

            return Value;
        }
    }

    /// <summary>
    /// OAuth2Facebook
    /// </summary>
    public static DefaultOAuth2FacebookRow DefaultOAuth2Facebook
    {
        get
        {
            var Value = new DefaultOAuth2FacebookRow();

            if (AccessData.DefaultSystem.DataCache && UnobtrusiveSession.Session["DefaultOAuth2Facebook"] != null)
            {
                Value = (DefaultOAuth2FacebookRow)UnobtrusiveSession.Session["DefaultOAuth2Facebook"];
            }
            else
            {
                var oShareDefault = new ShareDefaultDao();
                Value = oShareDefault.DefaultOAuth2Facebook;

                //本網站認證網頁 http處理 如果是絕對路徑 則不需要改變 如果是相對路徑 就要加上網站http
                if (Value.RedirectUrl.IndexOf("http") == -1)
                {
                    string ApplicationPath = HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath;
                    string Path = HttpContext.Current.Request.Url.AbsolutePath.Substring(ApplicationPath.Length, HttpContext.Current.Request.Url.AbsolutePath.Length - ApplicationPath.Length);

                    Value.RedirectUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(Path, "/" + Value.RedirectUrl);
                }

                UnobtrusiveSession.Session["DefaultOAuth2Facebook"] = Value;
            }


            return Value;
        }
    }

    /// <summary>
    /// OAuth2Line
    /// </summary>
    public static DefaultOAuth2LineRow DefaultOAuth2Line
    {
        get
        {
            var Value = new DefaultOAuth2LineRow();

            if (AccessData.DefaultSystem.DataCache && UnobtrusiveSession.Session["DefaultOAuth2Line"] != null)
            {
                Value = (DefaultOAuth2LineRow)UnobtrusiveSession.Session["DefaultOAuth2Line"];
            }
            else
            {
                var oShareDefault = new ShareDefaultDao();
                Value = oShareDefault.DefaultOAuth2Line;

                //本網站認證網頁 http處理 如果是絕對路徑 則不需要改變 如果是相對路徑 就要加上網站http
                if (Value.RedirectUrl.IndexOf("http") == -1)
                {
                    string ApplicationPath = HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath;
                    string Path = HttpContext.Current.Request.Url.AbsolutePath.Substring(ApplicationPath.Length, HttpContext.Current.Request.Url.AbsolutePath.Length - ApplicationPath.Length);

                    Value.RedirectUrl = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(Path, "/" + Value.RedirectUrl);
                }

                UnobtrusiveSession.Session["DefaultOAuth2Line"] = Value;
            }


            return Value;
        }
    }
}