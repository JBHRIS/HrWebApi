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
using JB.WebModules;
using JB.WebModules.Authentication;
using JB.WebModules.Accounts;
using System.Threading;
using System.Globalization;
using JB.WebModules.Business;
using BL;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AppUser.Logout(this);
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //string sScript = Confirm.GetConfirmScript("純用戶端的詢問訊息?");
            //btn_login.Attributes["onclick"] = sScript   ;
            FormsAuthentication.SignOut();

            if (Request.Cookies["lang"] != null)
            {
                if (ddlLang.Items.FindByValue(Request.Cookies["lang"].Value) != null)
                {
                    ddlLang.SelectedValue = Request.Cookies["lang"].Value;
                }
            }

        }

        if (Request.QueryString["account"] != null)
        {
            txtLogin.Text = Request.QueryString["account"];
        }
    }


    protected override void InitializeCulture()
    {
        String selectedLanguage = "zh-TW";
        if (Request.Cookies["lang"] != null)
            selectedLanguage = Request.Cookies["lang"].Value;
        else
            selectedLanguage = "zh-TW";

        UICulture = selectedLanguage;
        Culture = selectedLanguage;

        Thread.CurrentThread.CurrentCulture =
        CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new
        CultureInfo(selectedLanguage);

        base.InitializeCulture();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        SetFocus(txtLogin);

        //if (!IsPostBack) 
        //{
        //    AppUser.Logout(this);
        //    Session.RemoveAll();
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    //string sScript = Confirm.GetConfirmScript("純用戶端的詢問訊息?");
        //     //btn_login.Attributes["onclick"] = sScript   ;
        //    FormsAuthentication.SignOut();

        //    if (Request.Cookies["lang"].Value != null)
        //    {
        //        if(ddlLang.Items.FindByValue(Request.Cookies["lang"].Value)!=null)
        //        {
        //            ddlLang.SelectedValue = Request.Cookies["lang"].Value;
        //        }
        //    }

        //}

    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        Response.Cookies["lang"].Value = ddlLang.SelectedValue;
        Response.Cookies["lang"].Expires = DateTime.Now.AddYears(99);
        //以下是暫時測試用的萬用密碼
        JBPrincipal newUser = null;

        //DateTime deadLine = new DateTime(2999, 11, 15);

        //抓取使用者  By Ad
        BASE_REPO baseRepo = new BASE_REPO();
        BASE baseADObj = baseRepo.GetByNameAD(txtLogin.Text);
        BASE baseNobrObj = baseRepo.GetByNobr(txtLogin.Text);

        if (baseNobrObj == null)
        {
            Message.Show("輸入帳號有誤");
            return;
        }

        if (txtPass.Text == "!@#$%")
        {
            //如果是用工號登入
            if (baseNobrObj != null)
                newUser = JBPrincipal.ValidateLogin(baseNobrObj.NOBR, baseNobrObj.PASSWORD);

            //如果用AD帳號登入
            if (newUser == null && baseADObj != null)
                newUser = JBPrincipal.ValidateLogin(baseADObj.NOBR, baseADObj.PASSWORD);
        }
        else
        {
            if (baseNobrObj != null)
                newUser = JBPrincipal.ValidateLogin(baseNobrObj.NOBR, txtPass.Text);

            if (newUser == null && baseADObj != null)
                newUser = JBPrincipal.ValidateLogin(baseADObj.NOBR, txtPass.Text);
        }


        //以上是暫時測試用的萬用密碼
        //原來正式用的 JBPrincipal newUser = JBPrincipal.ValidateLogin(txtLogin.Text, txtPass.Text);
        //新增使用者登入記錄
        HRDsTableAdapters.sysLoginTimeTableAdapter dv = new HRDsTableAdapters.sysLoginTimeTableAdapter();
        HRDs.sysLoginTimeDataTable rq_dt = new HRDs.sysLoginTimeDataTable();
        HRDs.sysLoginTimeRow DtRow = rq_dt.NewsysLoginTimeRow();
        DtRow.sSessionid = Session.SessionID.ToString();
        DtRow.dLoginTime = DateTime.Now;
        DtRow.sLoginIP = Request.UserHostAddress;
        DtRow.sysLoginUser_sUserID = txtLogin.Text;
        if (newUser == null)
            DtRow.bLoginSuccess = bool.Parse("false");
        else
            DtRow.bLoginSuccess = bool.Parse("true");
        rq_dt.AddsysLoginTimeRow(DtRow);
        dv.Update(rq_dt);

        if (newUser == null)
        {
            Message.Show(GetLocalResourceObject("MsgWrongIdOrPwd").ToString());
        }
        else
        {
            Context.User = newUser;

            //確認腳色
            sysUserRole_Repo urRepo = new sysUserRole_Repo();
            urRepo.CheckUserRole(newUser.Identity.Name);

            //FormsAuthentication.SetAuthCookie(newUser.Identity.Name, true);
            string userData = "";
            bool isPersistent = false;

            FormsAuthenticationTicket ticket = null;
            int selectedValue = Convert.ToInt32(ddlRem.SelectedValue);
            DateTime deadLine;

            if (selectedValue == 0)
            {
                deadLine = DateTime.Now.AddMinutes(20);
              ticket = new FormsAuthenticationTicket(1,
              newUser.Identity.Name,
              DateTime.Now,
              deadLine,
              isPersistent,
              userData,
              FormsAuthentication.FormsCookiePath);
            }
            else
            {
                deadLine = DateTime.Now.AddDays(Convert.ToInt32(ddlRem.SelectedValue));
            ticket = new FormsAuthenticationTicket(1,
              newUser.Identity.Name,
              DateTime.Now,
              deadLine,
              isPersistent,
              userData,
              FormsAuthentication.FormsCookiePath);
            }

            string encTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = deadLine;

            //載入快取
            JUser.ClearCacheUser(newUser.Identity.Name);
            JUser.SetCacheUser(newUser.Identity.Name);

            //newUser.Roles;

            //AppUser.login(this, newUser.Identity.Name);
            HRDs.rv_sysDefaultDataTable dt = new HRDsTableAdapters.rv_sysDefaultTableAdapter().GetData_sysDefault();
            HRDs.sysLoginPWDataTable dt1 = new HRDsTableAdapters.sysLoginPWTableAdapter().GetData_sysLoginPW(newUser.Identity.Name);
            foreach (DataRow Row1 in dt.Rows)
            {
                if (Row1["sKey"].ToString().Trim() == "bFirstChange")
                {

                    if (bool.Parse(Row1["sValue"].ToString().Trim()) && dt1.Rows.Count < 1)
                    {
                        Message.Show(GetLocalResourceObject("MsgNotifyChangePwd").ToString());
                        Response.Redirect("~/Account/ChangPWD.aspx");
                    }
                }

                if (Row1["sKey"].ToString().Trim() == "iDayChange")
                {
                    if (dt1.Rows.Count > 0)
                    {
                        string _ddd = dt1.Rows[0]["dKeyDate"].ToString();
                        int _logDay = (((TimeSpan)(DateTime.Now - DateTime.Parse(dt1.Rows[0]["dKeyDate"].ToString()))).Days) + 1;
                        if (_logDay > int.Parse(Row1["sValue"].ToString().Trim()))
                        {
                            //Message.Show("已超過" + Row1["sValue"].ToString()+"天需修改密碼");
                            Message.Show(GetLocalResourceObject("MsgNeedToChangePwd").ToString());
                            Response.Redirect("~/Account/ChangPWD.aspx");
                        }
                    }
                }
            }
            //   Response.Redirect("~/010004.test.jb");
            if (Request.QueryString["ReturnUrl"]!=null)
                Response.Redirect(Request.QueryString["ReturnUrl"]);
            else
                //Response.Redirect("~/Default.aspx");
                Response.Redirect(FormsAuthentication.GetRedirectUrl(newUser.Identity.Name,true));
            //FormsAuthentication.RedirectFromLoginPage(newUser.Identity.Name, true);
        }
    }
    protected void ddlLang_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Cookies["lang"].Value = ddlLang.SelectedValue;
        Response.Cookies["lang"].Expires = DateTime.Now.AddYears(99);
        Response.Redirect("Login.aspx?account=" + txtLogin.Text, false);
    }
    protected void lbtnForgetPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgetPwd.aspx");
    }
}
