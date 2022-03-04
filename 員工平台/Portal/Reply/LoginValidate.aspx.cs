﻿using Dal.Dao.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Tools;

namespace Reply
{
    public partial class LoginValidate : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oEncryptHepler = new EncryptHepler();
                var AccessToken = "";
                var RefreshToken = "";
                var CompanyId = "";
                var EmpId = "";
                var EmpName = "未登入";
                var Role = 64;
                var Email = "";
                //以上值用資料帶入
                if (Request.QueryString["Param"] != null && Request.QueryString["Param"] != "")
                {
                    var Parameter = oEncryptHepler.Decrypt(Request.QueryString["Param"]);
                    var UserData = JsonConvert.DeserializeObject<List<string>>(Parameter);
                    AccessToken = UserData[0];
                    RefreshToken = UserData[1];
                    CompanyId = UserData[2];
                    EmpId = UserData[3];
                    EmpName = UserData[4];
                    Role = Convert.ToInt32(UserData[5]);
                    UnobtrusiveSession.Session["FormGuidCode"] = UserData[6];
                    Email = UserData[7];
                }

                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);

                var oUser = new User();
                oUser.AccessToken = AccessToken;
                oUser.RefreshToken = RefreshToken;
                oUser.UserCode = CompanyId + EmpId;
                oUser.EmpId = EmpId;
                oUser.CompanyId = CompanyId;
                oUser.EmpName = EmpName;
                oUser.RoleKey = Role;
                var oQuestionUserInfo = new ShareQuestionUserInfoDao();
                oQuestionUserInfo.InsertQuestionUserInfo(CompanyId, EmpId, EmpId, Role, EmpName, Email);

                _AuthManager.SignIn(oUser, oUser.UserCode, CompanySetting,false);
                Response.Redirect("ProblemReturn.aspx");
            }
        }
    }
}