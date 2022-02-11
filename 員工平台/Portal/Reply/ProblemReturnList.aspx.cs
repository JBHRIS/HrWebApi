﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Dal;
using Telerik.Web.UI;
using Dal.Dao.Flow;
using System.Windows;
using Telerik.Web.Data;

namespace Portal
{
    public partial class ProblemReturnList : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            txtReturnS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "回報類型", Value = "0" });
            txtReturnS.Items.Insert(1, new Telerik.Web.UI.RadComboBoxItem { Text = "所有類型", Value = "" });
            txtReturnS.SelectedIndex = 0;
            txtReturnX.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "結單狀態", Value = "0" });
            txtReturnX.Items.Insert(1, new Telerik.Web.UI.RadComboBoxItem { Text = "所有類型", Value = "" });
            txtReturnX.Items.Insert(2, new Telerik.Web.UI.RadComboBoxItem { Text = "已結單", Value = "已結單" });
            txtReturnX.Items.Insert(3, new Telerik.Web.UI.RadComboBoxItem { Text = "尚未結單", Value = "尚未結單" });
            txtReturnX.SelectedIndex = 0;

        }
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            APIResult rsGetQuestionMain = new APIResult();
            
            if (_User.RoleKey == 2)
            {
                var oGetQuestionMain = new ShareGetQuestionMainDao();
                var GetquestionMainCond = new ShareGetQuestionMainConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                rsGetQuestionMain=oGetQuestionMain.GetData(GetquestionMainCond);
               
            }
            else if (_User.RoleKey == 8)
            {
                var oGetQuestionMain = new ShareGetQuestionMainByCompanyDao();
                var GetquestionMainCond = new ShareGetQuestionMainByCompanyConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);

            }
            else if (_User.RoleKey == 64)
            {
                var oGetQuestionMain = new ShareGetQuestionMainByEmpIDDao();
                var GetquestionMainCond = new ShareGetQuestionMainByEmpIDConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                GetquestionMainCond.EmpId = _User.EmpId;
               rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);
            }

            
            try
            {
                if (rsGetQuestionMain.Status)
                {
                    if (rsGetQuestionMain.Data != null)
                    {
                        
                        if (_User.RoleKey == 2)
                        {
                            var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainRow>;
                          
                            lvMain.DataSource = rsQM.OrderByDescending(x => x.InsertDate);
                        }
                        else if (_User.RoleKey == 8)
                        {
                            var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainByCompanyRow>;
                            lvMain.DataSource = rsQM.OrderByDescending(x => x.InsertDate);
                        }
                        if (_User.RoleKey == 64)
                        {
                            var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainByEmpIDRow>;
                            lvMain.DataSource = rsQM.OrderByDescending(x => x.InsertDate);
                        }

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
            Response.Redirect("ProblemReturnView.aspx?Code=" + code);
        }

        protected void txtReturnS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var selectitem = sender as RadComboBox;
          
            if (txtReturnS.SelectedValue != "0")
            {
               
                RadListViewContainsFilterExpression expression1 = new RadListViewContainsFilterExpression("QuestionCategoryCode");                
                lvMain.FilterExpressions.Remove(expression1);
                if (txtReturnS.SelectedValue != "")
                {
                    expression1.CurrentValue = txtReturnS.SelectedValue;
                    lvMain.FilterExpressions.Add(expression1);
                }
                         
            }
            
            if (txtReturnX.SelectedValue != "0")
            {              
                RadListViewContainsFilterExpression expression2 = new RadListViewContainsFilterExpression("CompleteStatus");
                lvMain.FilterExpressions.Remove(expression2);
                if (txtReturnX.SelectedValue != "")
                {
                    expression2.CurrentValue = txtReturnX.SelectedValue;
                    lvMain.FilterExpressions.Add(expression2);
                }
               
            }
            lvMain.Rebind();
           
        }
      
    }

}