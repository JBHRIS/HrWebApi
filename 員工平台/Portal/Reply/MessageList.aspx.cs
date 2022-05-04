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
    public partial class MessageList : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SetUserInfo();
                
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
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oGetDefaultMessage = new ShareGetQuestionDefaultMessageByCompanyIdDao();
            var GetQuestionDefaultCond = new ShareGetQuestionDefaultMessageByCompanyIdConditions();
            GetQuestionDefaultCond.AccessToken = _User.AccessToken;
            GetQuestionDefaultCond.RefreshToken = _User.RefreshToken;
            GetQuestionDefaultCond.CompanySetting = CompanySetting;
            GetQuestionDefaultCond.CompanyId = _User.CompanyId.ToString();
            var rsGetQuestionMain = oGetDefaultMessage.GetData(GetQuestionDefaultCond);

            try
            {
                if (rsGetQuestionMain.Status)
                {
                    if (rsGetQuestionMain.Data != null)
                    {

                        var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionDefaultMessageByCompanyIdRow>;
                        lvMain.DataSource = rsQM.OrderByDescending(x => x.InsertDate);
                        var Script = "$(document).ready(function() {$('.footable').footable();});";
                        ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("MessageNew.aspx");

        }

        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {


            var CN = e.CommandName;
            var CA = e.CommandArgument;
            if (CN == "Update")
            {
                 Response.Redirect("MessageNew.aspx?Active=Update&&Code="+ CA.ToString());
            }
            else if (CN == "Delete")
            {
              
                var oDeleteDefaultMessage = new ShareDeleteQuestionDefaultMessageDao();
                var DeleteDefaultMessageCond = new ShareDeleteQuestionDefaultMessageConditions();
                DeleteDefaultMessageCond.Code = CA.ToString();
                var rsDeleteDefaultMessage = oDeleteDefaultMessage.GetData(DeleteDefaultMessageCond);
                try
                {
                    if (rsDeleteDefaultMessage.Status)
                    {

                        lvMain.Rebind();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{

        //        RadButton button = sender as RadButton;
        //        var oDeleteDefaultMessage = new ShareDeleteQuestionDefaultMessageDao();
        //        var DeleteDefaultMessageCond = new ShareDeleteQuestionDefaultMessageConditions();
        //         DeleteDefaultMessageCond.Code = button.CommandArgument.ToString();
        //        var rsDeleteDefaultMessage = oDeleteDefaultMessage.GetData(DeleteDefaultMessageCond);
        //        try
        //        {
        //            if (rsDeleteDefaultMessage.Status)
        //            {

        //             lvMain.Rebind();
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
            
            


        //}
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            RadButton button = sender as RadButton;
            

            Response.Redirect("MessageNew.aspx?Active=Update&&Code="+button.CommandArgument);
        }

        public void btnPage_Click(object sender, EventArgs e)
        {

            Response.Redirect("ProblemReturnListM.aspx");

        }
    }
}