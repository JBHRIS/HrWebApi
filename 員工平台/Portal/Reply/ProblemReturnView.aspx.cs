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
    public partial class ProblemReturnView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    SetUserInfo();
                    SetDefault();
                }

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
                    GetQuestionMainCond.Code = Request.QueryString["Code"];
                    var rsGQM = oGetQuestionMain.GetData(GetQuestionMainCond);
                    var Data = (rsGQM.Data as List<ShareGetQuestionMainByCodeRow>).FirstOrDefault();
                    lblName.Text = Data.InsertMan;
                    lblDate.Text = Data.InsertDate.Value.ToString("yyyy/MM/dd");
                    lblTime.Text = Data.InsertDate.Value.ToString("HH:ss");
                    lblTitle.Text = Data.TitleContent;
                    lblQuestionCategory.Text = Data.QuestionCategoryCode;
                    lblContent.Text = Data.Content;

                    var oGetQuestionReply = new ShareGetQuestionReplyByCodeDao();
                    var GetQuestionReplyCond = new ShareGetQuestionReplyByCodeConditions();
                    GetQuestionReplyCond.AccessToken = _User.AccessToken;
                    GetQuestionReplyCond.RefreshToken = _User.RefreshToken;
                    GetQuestionReplyCond.CompanySetting = CompanySetting;
                    GetQuestionReplyCond.Code = Request.QueryString["Code"];
                    var rsGQR = oGetQuestionReply.GetData(GetQuestionReplyCond);
                    var rsQM = rsGQR.Data as List<ShareGetQuestionReplyByCodeRow>;
                    QuestionReplyData.DataSource = rsQM;
                    QuestionReplyData.DataBind();
                   
                }
                catch (Exception ex)
                { 
                
                }
                


            }
           


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
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
                InsertQuestionReplyCond.UpdateMan = lblEmpName.Text;
                InsertQuestionReplyCond.UpdateDate = DateTime.Now;

                oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                QuestionReplyData.Rebind();

            }
            catch (Exception ex)
            { 
            
            }
                
            

        }
    }
}