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

public partial class AutoLogin : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        //if (Request.QueryString["do"]!=null) 
        //{
        //    string en = Request.QueryString["do"].ToString();

        //    HRDsTableAdapters.TmpNobrTableAdapter tmpad = new HRDsTableAdapters.TmpNobrTableAdapter();
        //    HRDs.TmpNobrDataTable tmpdt = tmpad.GetData(en);
        //    if (tmpdt.Rows.Count > 0) 
        //    {
        //        JBPrincipal newUser = new JBPrincipal(tmpdt[0].Nobr.Trim());
        //        if (newUser != null) {
                    
        //            Context.User = newUser;
        //            FormsAuthentication.SetAuthCookie(tmpdt[0].Nobr.Trim(), true);
        //            Response.Redirect("~/Default.aspx");
        //        }
        //    }
        //}
        string AutoLoginAuthStr = System.Web.Configuration.WebConfigurationManager.AppSettings["AutoLoginAuth"];

        //if (Request.Form["id"] != null && Request.Form["AutoLoginAuth"] != null && Request.Form["AutoLoginAuth"].Equals(AutoLoginAuthStr))
        if (Request.Form["id"] != null && Request.Form[AutoLoginAuthStr] != null && Request.Form[AutoLoginAuthStr].Equals(@"!@#$qwer"))
        {
            string userId=Request.Form["id"];
            JBPrincipal newUser = new JBPrincipal(userId);
            if (newUser != null && newUser.Identity.Name !=null&& newUser.Identity.Name.Trim().Length>0)
            {
                Context.User = newUser;
                FormsAuthentication.SetAuthCookie(userId, true);
                AppUser.login(this, userId);
                HRDs.rv_sysDefaultDataTable dt = new HRDsTableAdapters.rv_sysDefaultTableAdapter().GetData_sysDefault();
                HRDs.sysLoginPWDataTable dt1 = new HRDsTableAdapters.sysLoginPWTableAdapter().GetData_sysLoginPW(userId);
                foreach (DataRow Row1 in dt.Rows)
                {
                    if (Row1["sKey"].ToString().Trim() == "bFirstChange")
                    {
                        if (bool.Parse(Row1["sValue"].ToString().Trim()) && dt1.Rows.Count < 1)
                        {
                            Message.Show(GetLocalResourceObject("MsgNotifyChangePwd").ToString());
                            Response.Redirect("~/Account/ChangPWD.aspx",true);
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
                                Response.Redirect("~/Account/ChangPWD.aspx",true);
                            }
                        }
                    }
                }
                
                Response.Redirect("~/Default.aspx",true);
            }
        }
        Response.Redirect("Login.aspx",true);
    }
}
