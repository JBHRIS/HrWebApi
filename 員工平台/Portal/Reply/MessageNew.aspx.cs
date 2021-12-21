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
    public partial class MessageNew : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Active"]!= null)
                {
                    title.InnerText = "編輯預設訊息";
                    
                    GetDefaultMessageData();
                }

                SetUserInfo();
                SetDefaultMessage();
            }
           
           
        }
        private void SetUserInfo()
        {
            lblUserCode.Text = _User.UserCode;
            lblCompanyId.Text = _User.CompanyId;
            lblEmpID.Text = _User.EmpId;
            lblEmpName.Text = _User.EmpName;
            lblRoleKey.Text = _User.RoleKey.ToString();
            //lblIP.Text = WebPage.GetClientIP(Context);

        }
        private void SetDefaultMessage()
        {
            try
            {
                var oGetQuestionDefaultMessage = new ShareGetQuestionDefaultMessageDao();
                var GetQuestionDefaultMessageCond = new ShareGetQuestionDefaultMessageConditions();
                GetQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
                GetQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
                GetQuestionDefaultMessageCond.CompanySetting = CompanySetting;
                GetQuestionDefaultMessageCond.Code = "JB";
                var rsGQDM = oGetQuestionDefaultMessage.GetData(GetQuestionDefaultMessageCond);
                lvMain.DataSource = rsGQDM.Data as List<ShareGetQuestionDefaultMessageRow>;
            }
            catch (Exception ex)
            { 
            
            }
           

        }
        private void GetDefaultMessageData()
        {
            var oGetQuestionDefaultMessage = new ShareGetQuestionDefaultMessageDao();
            var GetQuestionDefaultMessageCond = new ShareGetQuestionDefaultMessageConditions();
            GetQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
            GetQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
            GetQuestionDefaultMessageCond.CompanySetting = CompanySetting;
            GetQuestionDefaultMessageCond.Code = Request.QueryString["Code"];
            var rsGQDM = (oGetQuestionDefaultMessage.GetData(GetQuestionDefaultMessageCond).Data as List<ShareGetQuestionDefaultMessageRow>).FirstOrDefault();
            txtTitle.Text = rsGQDM.Name;
            txtContent.Text = rsGQDM.Contents;
            

        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Active"] != null)
            {
                var oUpdateQuestionDefaultMessage = new ShareUpdateQuestionDefaultMessageDao();
                var UpdateQuestionDefaultMessageCond = new ShareUpdateQuestionDefaultMessageConditions();
                UpdateQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
                UpdateQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
                UpdateQuestionDefaultMessageCond.CompanySetting = CompanySetting;
                UpdateQuestionDefaultMessageCond.Code = Request.QueryString["Code"];
                UpdateQuestionDefaultMessageCond.Name = txtTitle.Text;
                UpdateQuestionDefaultMessageCond.Contents = txtContent.Text;
                UpdateQuestionDefaultMessageCond.UpdateMan = _User.EmpName;
                UpdateQuestionDefaultMessageCond.UpdateDate = DateTime.Now;
                oUpdateQuestionDefaultMessage.GetData(UpdateQuestionDefaultMessageCond);
                lblAddStatus.InnerText = "資料更新成功";
            }
            else
            {
                var oQuestionDefaultMessage = new ShareInsertQuestionDefaultMessageDao();
                var InsertQuestionDefaultMessageCond = new ShareInsertQuestionDefaultMessageConditions();
                InsertQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
                InsertQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
                InsertQuestionDefaultMessageCond.CompanySetting = CompanySetting;
                InsertQuestionDefaultMessageCond.AutoKey = 0;
                InsertQuestionDefaultMessageCond.CompanyId = _User.CompanyId;
                InsertQuestionDefaultMessageCond.Code = Guid.NewGuid().ToString();
                InsertQuestionDefaultMessageCond.Name = txtTitle.Text;
                InsertQuestionDefaultMessageCond.Contents = txtContent.Text;
                InsertQuestionDefaultMessageCond.RoleKey = _User.RoleKey;
                InsertQuestionDefaultMessageCond.Note = "";
                InsertQuestionDefaultMessageCond.Status = "1";
                InsertQuestionDefaultMessageCond.InsertMan = _User.EmpName;
                InsertQuestionDefaultMessageCond.InsertDate = DateTime.Now;
                InsertQuestionDefaultMessageCond.UpdateMan = "";
                InsertQuestionDefaultMessageCond.UpdateDate = DateTime.Now;

                oQuestionDefaultMessage.GetData(InsertQuestionDefaultMessageCond);
                lblAddStatus.InnerText = "新增成功";
            }

            
            Response.Redirect("MessageList.aspx");


        }

        public void btnPage_Click(object sender, EventArgs e)
        {

            Response.Redirect("MessageList.aspx");

        }
        public void SetDefaultMessage(object sender, EventArgs e)
        {
            RadButton button = sender as RadButton;
            txtTitle.Text = button.CommandName;
            txtContent.Text = button.CommandArgument;
            
        }

      
    }
}