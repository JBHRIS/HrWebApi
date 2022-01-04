using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using Bll.Tools;
using Dal;
using Telerik.Web.UI;
using Dal.Dao.Flow;
using System.Windows;
using Bll.Files.Vdb;
using Dal.Dao.Files;

namespace Portal
{
    public partial class ProblemReturn : WebPageBase
    {
        List<UploadMultipleRow> result = new List<UploadMultipleRow>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnobtrusiveSession.Session["FormGuidCode"] = Guid.NewGuid().ToString();
                txtReturnS_DataBind();
                SetUserInfo();
                Security.GetRoleKeyToBinaryKey(72);
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
            if (txtTitle.Text.Length > 30 || txtContent.Text.Length > 80)
            {
                lblAddStatus.InnerText = "標題或內容長度過長";
                return;
            }
            var oQuestionMain = new ShareInsertQuestionMainDao();
            var InsertQuestionCond = new ShareInsertQuestionMainConditions();
          
            InsertQuestionCond.AutoKey = 0;
            InsertQuestionCond.CompanyId = _User.CompanyId;
            InsertQuestionCond.Code = UnobtrusiveSession.Session["FormGuidCode"].ToString();
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
           

            var result = oQuestionMain.GetData(InsertQuestionCond);
            if (result.Status)
            {
                lblAddStatus.InnerText = "送出成功!";
            }

            Response.Redirect("ProblemReturnList.aspx");

        }
        public void btnUpload_Click(object sender, EventArgs e)
        {
            
            if (UnobtrusiveSession.Session["Files"] != null)
            {
               
                var Files = (HttpFileCollection)UnobtrusiveSession.Session["Files"];

                string dirFullPath = HttpContext.Current.Server.MapPath("~/Upload/");
           

                if (Files != null)
                {
                    var oUploadMultipleDao = new UploadMultipleDao();
                    var UploadMultipleCond = new UploadMultipleConditions();
                    UploadMultipleCond.AccessToken = _User.AccessToken;
                    UploadMultipleCond.RefreshToken = _User.RefreshToken;
                    UploadMultipleCond.CompanySetting = CompanySetting;
                    if (UnobtrusiveSession.Session["FormGuidCode"] != null && UnobtrusiveSession.Session["FormGuidCode"].ToString() != "")
                        UploadMultipleCond.FileTicket = UnobtrusiveSession.Session["FormGuidCode"].ToString();
                    UploadMultipleCond.files = Files;
                    var Result = oUploadMultipleDao.GetData(UploadMultipleCond);

                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            //成功
                            var ResultData = Result.Data as List<UploadMultipleRow>;
                            foreach (var resultData in ResultData)
                            {
                                if (Request.Cookies["CompanyId"].Value != null)
                                    resultData.CompanyId = Request.Cookies["CompanyId"].Value;
                                resultData.AccessToken = _User.AccessToken;
                                result.Add(resultData);
                            }
                           
                            lblMsg.CssClass = "badge badge-primary animated shake";
                            lblMsg.Text = "上傳成功";
                            //dcFlow.SubmitChanges();
                        }
                        else
                        {
                            lblMsg.CssClass = "badge badge-danger animated shake";
                            lblMsg.Text = "上傳失敗";
                        }


                    }
                    else
                    {
                        //失敗
                        lblMsg.CssClass = "badge badge-danger animated shake";
                        lblMsg.Text = "上傳失敗";
                    }

                  
                }
                UnobtrusiveSession.Session["Files"] = null;
                //var Script = "Sys.Application.add_load(DropzoneInit);";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "DropzoneInit", Script, true);

            }
            else
            {             
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "上傳失敗";
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