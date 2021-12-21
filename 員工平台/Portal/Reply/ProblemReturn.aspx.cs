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
    public partial class ProblemReturn : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                txtReturnS_DataBind();
                SetUserInfo();
            }
            

        }
       
        private void SetUserInfo()
        {
            lblUserCode.Text = _User.UserCode;
            lblCompanyId.Text = _User.CompanyId;
            lblEmpID.Text = _User.EmpId;
            lblEmpName.Text = _User.EmpName;
            lblRoleKey.Text = _User.RoleKey.ToString();
            lblIP.Text = WebPage.GetClientIP(Context);

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
                txtReturnS.SelectedIndex = 0;
            }
           
           
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == ""||txtContent.Text=="")
            {
                lblAddStatus.InnerText = "未輸入標題或回報內容";
                return;
            }
            var oQuestionMain = new ShareInsertQuestionMainDao();
            var InsertQuestionCond = new ShareInsertQuestionMainConditions();
          
            InsertQuestionCond.AutoKey = 0;
            InsertQuestionCond.CompanyId = _User.CompanyId;
            InsertQuestionCond.Code = Guid.NewGuid().ToString();
            InsertQuestionCond.SystemCategoryCode = "1";          
            InsertQuestionCond.Key1 = lblEmpID.Text;
            InsertQuestionCond.Key2 = lblEmpID.Text;
            InsertQuestionCond.Key3 = lblEmpID.Text;
            InsertQuestionCond.Name = lblEmpName.Text;
            InsertQuestionCond.TitleContent = txtTitle.Text;
            InsertQuestionCond.Content = txtContent.Text;
            InsertQuestionCond.QuestionCategoryCode = txtReturnS.SelectedValue;
            InsertQuestionCond.IpAddress = lblIP.Text;          
            InsertQuestionCond.DateE = DateTime.Now;
            InsertQuestionCond.Complete = false;
            InsertQuestionCond.Note = "1";                                
            InsertQuestionCond.Status = "1";
            InsertQuestionCond.InsertMan = _User.EmpName;
            InsertQuestionCond.InsertDate = DateTime.Now;
            InsertQuestionCond.UpdateMan = "";
            InsertQuestionCond.UpdateDate = DateTime.Now;

            var result = oQuestionMain.GetData(InsertQuestionCond);
            if (result.Status)
            {
                lblAddStatus.InnerText = "送出成功!";
            }
        
            

        }

        //public void ApiTest()
        //{
        //    var oGetQuestionMainByCompanyDao = new ShareInsertQuestionMainDao();
        //    var IQMCD = new ShareInsertQuestionMainConditions();
        //    IQMCD.AutoKey = 0;
        //    IQMCD.Code = "1";
        //    IQMCD.CompanyId = "1";
        //    IQMCD.Complete = false;
        //    IQMCD.Content = "1";
        //    IQMCD.DateE = DateTime.Now;
        //    IQMCD.InsertDate = DateTime.Now;
        //    IQMCD.InsertMan = "1";
        //    IQMCD.IpAddress = "1";
        //    IQMCD.Key1 = "1";
        //    IQMCD.Key2 = "2";
        //    IQMCD.Key3 = "3";
        //    IQMCD.Name = "1";
        //    IQMCD.Note = "1";
        //    IQMCD.QuestionCategoryCode = "1";
        //    IQMCD.Status = "1";
        //    IQMCD.SystemCategoryCode = "1";
        //    IQMCD.TitleContent = "1";
        //    IQMCD.UpdateDate = DateTime.Now;
        //    IQMCD.UpdateMan = "1";
        //    var Result = oGetQuestionMainByCompanyDao.GetData(IQMCD);



        //    #region InsertQuestionMain
        //    IQMCD.AutoKey = 0;
        //    IQMCD.Code = "1";
        //    IQMCD.CompanyId = "1";
        //    IQMCD.Complete = false;
        //    IQMCD.Content = "1";
        //    IQMCD.DateE = DateTime.Now;
        //    IQMCD.InsertDate = DateTime.Now;
        //    IQMCD.InsertMan = "1";
        //    IQMCD.IpAddress = "1";
        //    IQMCD.Key1 = "1";
        //    IQMCD.Key2 = "2";
        //    IQMCD.Key3 = "3";
        //    IQMCD.Name = "1";
        //    IQMCD.Note = "1";
        //    IQMCD.QuestionCategoryCode = "1";
        //    IQMCD.Status = "1";
        //    IQMCD.SystemCategoryCode = "1";
        //    IQMCD.TitleContent = "1";
        //    IQMCD.UpdateDate = DateTime.Now;
        //    IQMCD.UpdateMan = "1";
        //    #endregion

        //    #region InsertQuestionReply
        //    IQMCD.AutoKey = 0;
        //    IQMCD.Code = "1";
        //    IQMCD.QuestionMainCode = "1";
        //    IQMCD.Content = "1";
        //    IQMCD.RoleKey = 1;
        //    IQMCD.InsertDate = DateTime.Now;
        //    IQMCD.InsertMan = "1";
        //    IQMCD.IpAddress = "1";
        //    IQMCD.Key1 = "1";
        //    IQMCD.Key2 = "2";
        //    IQMCD.Key3 = "3";
        //    IQMCD.Name = "1";
        //    IQMCD.Note = "1";
        //    IQMCD.ParentCode = "1";

        //    IQMCD.ReplyToCode = "1";
        //    IQMCD.Send = false;
        //    IQMCD.Status = "1";
        //    IQMCD.UpdateDate = DateTime.Now;
        //    IQMCD.UpdateMan = "1";
        //    #endregion

        //    #region InsertQuestionDefaultMessage
        //    IQMCD.AutoKey = 1;
        //    IQMCD.CompanyId = "測試";
        //    IQMCD.Code = "4";
        //    IQMCD.Name = "測試";
        //    IQMCD.Contents = "測試";
        //    IQMCD.RoleKey = 1;
        //    IQMCD.Note = "測試";
        //    IQMCD.Status = "測試";
        //    IQMCD.InsertMan = "測試";
        //    IQMCD.InsertDate = DateTime.Now;
        //    IQMCD.UpdateMan = "測試";
        //    IQMCD.UpdateDate = DateTime.Now;
        //    #endregion

        //    if (Result.Status)
        //    {

        //    }

        //}
    }
}