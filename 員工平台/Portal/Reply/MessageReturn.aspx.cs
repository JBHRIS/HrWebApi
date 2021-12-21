using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using Dal;
using Telerik.Web.UI;
using Dal.Dao.Flow;
using System.Windows;

namespace Portal
{
    public partial class MessageReturn : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetUserInfo();
                SetDefault();
            }
                
        }

        private void SetUserInfo()
        {
            
            lblUserCode.Text = _User.UserCode;
            lblCompanyId.Text = _User.CompanyId;
            lblEmpID.Text = _User.EmpId;
            lblEmpName.Text = _User.EmpName;
            lblRoleKey.Text = _User.RoleKey.ToString();


        }
        private void SetDefault()
        {
            if (Request.QueryString["Code"] != null)
            {
                try
                {
                    var oGetQuestionMain = new ShareGetQuestionMainByCodeDao();
                    var GetQuestionMainCond = new ShareGetQuestionMainByCodeConditions();
                    GetQuestionMainCond.AccessToken = _User.AccessToken;
                    GetQuestionMainCond.RefreshToken = _User.RefreshToken;
                    GetQuestionMainCond.CompanySetting = CompanySetting;
                    GetQuestionMainCond.Code = Request.QueryString["Code"];
                    var rsGQM = oGetQuestionMain.GetData(GetQuestionMainCond);
                    var Data = (rsGQM.Data as List<ShareGetQuestionMainByCodeRow>).FirstOrDefault();
                    lblName.Text = Data.InsertMan;
                    lblDate.Text = Data.InsertDate.Value.ToString("yyyy/MM/dd");
                    lblTime.Text = Data.InsertDate.Value.ToString("HH:ss");
                    lblTitle.Text = Data.TitleContent;
                    lblQuestionCategory.Text = Data.QuestionCategoryCode;
                    lblContent.Text = Data.Content;

                    var oGetQuestionDefaultMessage = new ShareGetQuestionDefaultMessageByRoleKeyDao();
                    var GetQuestionDefaultMessageCond = new ShareGetQuestionDefaultMessageByRoleKeyConditions();
                    GetQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
                    GetQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
                    GetQuestionDefaultMessageCond.CompanySetting = CompanySetting;
                    GetQuestionDefaultMessageCond.RoleKey = _User.RoleKey.ToString();
                    var rsGQDM = oGetQuestionDefaultMessage.GetData(GetQuestionDefaultMessageCond).Data as List<ShareGetQuestionDefaultMessageByRoleKeyRow>;
                    lvMain.DataSource = rsGQDM;
                    var Script = "$(document).ready(function() {$('.footable').footable();});";
                    ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

                }
                catch (Exception ex)
                {

                }



            }



        }
        public void btnSet_Click(object sender, EventArgs e)
        {
            var Script = "$(document).ready(function() {$('.footable').footable();});";
                        ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Response.Redirect("MessageList.aspx");

        }

        public void SetDefaultMessage(object sender, EventArgs e)
        {
            try
            {
                RadButton button = sender as RadButton;
                txtContent.Text = button.CommandArgument;
                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

            }
            catch (Exception ex)
            {

            }
        }
    }
}