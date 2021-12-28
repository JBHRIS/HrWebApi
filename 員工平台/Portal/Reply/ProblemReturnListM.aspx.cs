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
    public partial class ProblemReturnListM : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_User.RoleKey!=2&&_User.RoleKey!=8)
            {
                Response.Redirect("ProblemReturn.aspx");
            }
            if (!IsPostBack)
            {
                SetUserInfo();
               
                txtReturnS_DataBind();
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
     


        private void txtReturnS_DataBind()
        {
            var oGetQuestionCategoryDao = new ShareGetQuestionCategoryDao();
            var GetQuestionCategoryCond = new ShareGetQuestionCategoryConditions();
            var result = oGetQuestionCategoryDao.GetData(GetQuestionCategoryCond);
            var rsDataSource = result.Data as List<ShareGetQuestionCategoryRow>;

            if (rsDataSource != null)
            {
                txtReturnS.DataSource = rsDataSource;
                txtReturnS.DataTextField = "Name";
                txtReturnS.DataValueField = "Code";
                txtReturnS.DataBind();
                //txtReturnS.SelectedIndex = 0;
            }
            txtReturnS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "所有類型", Value = "0" });
            txtReturnS.SelectedIndex = 0;

        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oGetQuestionMain = new ShareGetQuestionMainByCompanyDao();
            var GetquestionMainCond = new ShareGetQuestionMainByCompanyConditions();
            GetquestionMainCond.AccessToken = _User.AccessToken;
            GetquestionMainCond.RefreshToken = _User.RefreshToken;
            GetquestionMainCond.CompanySetting = CompanySetting;
            GetquestionMainCond.CompanyID = _User.CompanyId;
            var rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);

            try
            {
                if (rsGetQuestionMain.Status)
                {
                    if (rsGetQuestionMain.Data != null)
                    {

                        var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainByCompanyRow>;
                        lvMain.DataSource = rsQM;
                        var Script = "$(document).ready(function() {$('.footable').footable();});";
                        ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);


                    }

                }
            }
            catch (Exception ex)
            {

            }



        }

        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            RadButton button = sender as RadButton;
            var code = button.CommandArgument.ToString();
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Response.Redirect("MessageReturn.aspx?Code=" + code);
        }
        public void btnSet_Click(object sender, EventArgs e)
        {
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Response.Redirect("MessageList.aspx");

        }

        protected void txtReturnS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var selectitem = sender as RadComboBox;
            lvMain.FilterExpressions.Clear();
            if (selectitem.SelectedValue != "0")
            {


                RadListViewContainsFilterExpression expression = new RadListViewContainsFilterExpression("QuestionCategoryCode");
                expression.CurrentValue = selectitem.SelectedValue;
                lvMain.FilterExpressions.Add(expression);

            }
            lvMain.Rebind();
        }
    }

}