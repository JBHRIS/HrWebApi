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
using System.Net.Mail;
using Bll.Flow.Vdb;
using Bll.Token.Vdb;

namespace Portal
{
    public partial class ProblemReturn : WebPageBase
    {
        List<FileListByCodeRow> UMR = new List<FileListByCodeRow>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UnobtrusiveSession.Session["FormGuidCode"] == null)
                {
                    UnobtrusiveSession.Session["FormGuidCode"] = Guid.NewGuid().ToString();
                }

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
            try 
            {
                if (_User.EmpName == "未登入")
                {
                    string strUrl_No = "../Reply/LoginBind.aspx";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                    return;
                }
                if (txtTitle.Text == "" || txtContent.Text == "")
                {
                    lblAddStatus.InnerText = "未輸入標題或回報內容";
                    return;
                }
                if (txtTitle.Text.Length > 30 || txtContent.Text.Length > 200)
                {
                    lblAddStatus.InnerText = "標題或內容長度過長";
                    return;
                }
                if (txtReturnS.SelectedValue == "")
                {
                    lblAddStatus.InnerText = "選擇的回報類型發生錯誤";
                    return;

                }
                var oQuestionMain = new ShareInsertQuestionMainDao();
                var InsertQuestionCond = new ShareInsertQuestionMainConditions();

                InsertQuestionCond.AutoKey = 0;
                InsertQuestionCond.CompanyId = _User.CompanyId;
                InsertQuestionCond.Code = UnobtrusiveSession.Session["FormGuidCode"].ToString();
                InsertQuestionCond.SystemCategoryCode = "1";
                InsertQuestionCond.Key1 = _User.EmpId;
                if (_User.RoleKey == 2)
                {
                    InsertQuestionCond.Key2 = "Admin";
                }
                else if (_User.RoleKey == 8)
                {
                    InsertQuestionCond.Key2 = "Hr";
                }
                else if (_User.RoleKey == 64)
                {
                    InsertQuestionCond.Key2 = "User";
                }

                InsertQuestionCond.Key3 = _User.EmpId;
                InsertQuestionCond.Name = _User.EmpName;
                InsertQuestionCond.TitleContent = txtTitle.Text;
                InsertQuestionCond.Content = txtContent.Text;
                InsertQuestionCond.QuestionCategoryCode = txtReturnS.SelectedValue;
                InsertQuestionCond.IpAddress = lblIP.Text;
                InsertQuestionCond.DateE = DateTime.Now.AddDays(7);
                InsertQuestionCond.Complete = false;
                InsertQuestionCond.Note = "1";
                InsertQuestionCond.Status = "1";
                InsertQuestionCond.InsertMan = _User.EmpName;
                InsertQuestionCond.InsertDate = DateTime.Now;
                InsertQuestionCond.UpdateMan = "";
                InsertQuestionCond.UpdateDate = null;

                var result = oQuestionMain.GetData(InsertQuestionCond);
                if (result.Status)
                {
                    lblAddStatus.InnerText = "送出成功!";
                    var oSendMail = new ShareSendQueueDao();
                    if (_User.EmpEmail != "" && _User.EmpEmail != null)
                    {
                        MailAddress address = new MailAddress(_User.EmpEmail);

                        var Subject = "";
                        var Body = "";
                        var oShareMail = new ShareMailDao();
                        var dcParameter = new Dictionary<string, string>();
                        dcParameter.Add("MainCode", UnobtrusiveSession.Session["FormGuidCode"].ToString());
                        oShareMail.OutMailContent(out Subject, out Body, "01", 0, true, dcParameter);
                        oSendMail.SendMail(address, Subject, Body, true);
                    }

                }

                Response.Redirect("ProblemReturnList.aspx");
            }
            catch (Exception ex)
            { 
            
            }
           

        }
        public void btnUpload_Click(object sender, EventArgs e)
        {
            try 
            {
                if (_User.EmpName == "未登入")
                {
                    string strUrl_No = "../Reply/LoginBind.aspx";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                    return;
                }

                if (UnobtrusiveSession.Session["Files"] != null)
                {

                    var Files = (HttpFileCollection)UnobtrusiveSession.Session["Files"];

                    string dirFullPath = HttpContext.Current.Server.MapPath("~/Upload/");


                    if (Files != null)
                    {
                        var oSaveDao = new SaveDao();
                        var SaveCond = new SaveConditions();
                        SaveCond.AccessToken = _User.AccessToken;
                        SaveCond.RefreshToken = _User.RefreshToken;
                        SaveCond.CompanySetting = CompanySetting;
                        SaveCond.Company = _User.CompanyId;
                        SaveCond.InsertMan = _User.EmpId;
                        if (UnobtrusiveSession.Session["FormGuidCode"] != null && UnobtrusiveSession.Session["FormGuidCode"].ToString() != "")
                            SaveCond.Code = UnobtrusiveSession.Session["FormGuidCode"].ToString();
                        SaveCond.files = Files;
                         var Result = oSaveDao.GetData(SaveCond);
                        
                       
                       

                        if (Result.Status)
                        {
                            if (Result.Data != null)
                            {
                                //成功
                            


                                lblMsg.CssClass = "badge badge-primary animated shake";
                                lblMsg.Text = "上傳成功";
                                DataUpload.Rebind();
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
            catch (Exception ex)
            { 
            
            }
           

        }
        protected void DataUpload_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            try
            {
                var oFileListByCode = new FileListByCodeDao();
                var FileListByCodeCond = new FileListByCodeConditions();
                var result = new List<FileListByCodeRow>();
                FileListByCodeCond.AccessToken = _User.AccessToken;
                FileListByCodeCond.RefreshToken = _User.RefreshToken;
                FileListByCodeCond.CompanySetting = CompanySetting;
                FileListByCodeCond.Code = UnobtrusiveSession.Session["FormGuidCode"].ToString();
                var Result = oFileListByCode.GetData(FileListByCodeCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        result = Result.Data as List<FileListByCodeRow>;
                        DataUpload.DataSource = result;
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
          

        }
        protected void DataUpload_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

        }
    }
}