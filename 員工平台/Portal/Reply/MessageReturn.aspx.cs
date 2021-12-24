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
              
            }
            SetDefault();
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
            if (_User.RoleKey == 8)
            {
                RadioSecond.Text = "系統商";
                RadioSecond.Value = "10"; //HR(8)與系統商(2)
                RadioThird.Text = "提問者及系統商";
                RadioThird.Value = "74"; //提問者(64)HR(8)系統商(2)
            }
            else if (_User.RoleKey == 2)
            {
                RadioSecond.Text = "HR";
                RadioSecond.Value = "10";//HR(8)與系統商(2)
                RadioThird.Text = "提問者及HR";
                RadioSecond.Value = "74";//提問者(64)HR(8)系統商(2)
            }


        }

        private void SetDraft()
        { 
        
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
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
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            
           
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

             

       

        

        protected void RadioFirst_CheckedChanged(object sender, EventArgs e)
        {
            RadioSecond.Checked = false;
            RadioThird.Checked = false;
        }

        protected void RadioSecond_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioThird.Checked = false;
        }

        protected void RadioThird_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioSecond.Checked = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Code"] != null)
            {
                RadButton button = sender as RadButton;
                var CN = button.CommandName;
                
                var oInsertQuestionReply = new ShareInsertQuestionReplyDao();
                var InsertQuestionReplyCond = new ShareInsertQuestionReplyConditions();
                InsertQuestionReplyCond.AccessToken = _User.AccessToken;
                InsertQuestionReplyCond.RefreshToken = _User.RefreshToken;
                InsertQuestionReplyCond.CompanySetting = CompanySetting;
                InsertQuestionReplyCond.AutoKey = 0;
                InsertQuestionReplyCond.Code = Guid.NewGuid().ToString();
                InsertQuestionReplyCond.QuestionMainCode = Request.QueryString["Code"];
                InsertQuestionReplyCond.Key1 = lblEmpID.Text;
                InsertQuestionReplyCond.Key2 = lblEmpID.Text;
                InsertQuestionReplyCond.Key3 = lblEmpID.Text;
                InsertQuestionReplyCond.Name = lblEmpName.Text;
                InsertQuestionReplyCond.Content = txtContent.Text;
                InsertQuestionReplyCond.RoleKey = Int32.Parse(lblRoleKey.Text);
                InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                InsertQuestionReplyCond.ReplyToCode = "";
                InsertQuestionReplyCond.ParentCode = Request.QueryString["Code"];
                InsertQuestionReplyCond.Send = true;
                InsertQuestionReplyCond.Status = "1";
                InsertQuestionReplyCond.Note = "";
                InsertQuestionReplyCond.InsertMan = lblEmpName.Text;
                InsertQuestionReplyCond.InsertDate = DateTime.Now;
                if (RadioFirst.Checked.Value)
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioFirst.Value);
                }
                else if (RadioSecond.Checked.Value)
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioSecond.Value);
                }
                else
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioThird.Value);
                }

                if (CN == "Draft")
                {
                    InsertQuestionReplyCond.Send = false;
                }
                else
                {
                    InsertQuestionReplyCond.Send = true;
                }

                oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                Response.Redirect("ProblemReturnListM");
            }
        }
    }
}