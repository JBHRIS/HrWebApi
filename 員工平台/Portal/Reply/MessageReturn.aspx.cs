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
using Bll.Tools;
using System.Net.Mail;
using System.IO;
using Bll.Token.Vdb;
using Dal.Dao.Files;
using Bll.Flow.Vdb;

namespace Portal
{
    public partial class MessageReturn : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                txtReturnS_DataBind();
               
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
                RadioFourth.Visible = true;
                txtReturnS.Visible = true;
            }


        }

        private void txtReturnS_DataBind()
        {
            var oGetGetSystemUserDao = new ShareGetSystemUserDao();
            var GetGetSystemUserCond = new ShareGetSystemUserConditions();
            var result = oGetGetSystemUserDao.GetData(GetGetSystemUserCond);
            var rsDataSource = result.Data as List<ShareGetSystemUserRow>;

            if (rsDataSource != null)
            {
                txtReturnS.DataSource = rsDataSource;
                txtReturnS.DataTextField = "UserName";
                txtReturnS.DataValueField = "Code";
                               
                txtReturnS.DataBind();
                txtReturnS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "", Value = "" });
                txtReturnS.SelectedIndex = 0;
                //txtReturnS.SelectedIndex = 0;
            }
           

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
                    lblTime.Text = Data.InsertDate.Value.ToString("HH:mm");
                    lblTitle.Text = Data.TitleContent;
                    lblQuestionCategory.Text = Data.QuestionCategoryCode;
                    lblContent.Text = Data.Content;

                    var oGetQuestionDefaultMessage = new ShareGetQuestionDefaultMessageByCompanyIdDao();
                    var GetQuestionDefaultMessageCond = new ShareGetQuestionDefaultMessageByCompanyIdConditions();
                    GetQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
                    GetQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
                    GetQuestionDefaultMessageCond.CompanySetting = CompanySetting;
                    GetQuestionDefaultMessageCond.CompanyId = _User.CompanyId.ToString();
                    var rsGQDM = oGetQuestionDefaultMessage.GetData(GetQuestionDefaultMessageCond).Data as List<ShareGetQuestionDefaultMessageByCompanyIdRow>;
                    lvMain.DataSource = rsGQDM;
                    //var Script = "$(document).ready(function() {$('.footable').footable();});";
                    //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

                }
                catch (Exception ex)
                {

                } 



            }
        }

        protected void QuestionReplyData_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {

            try
            {


                var oGetQuestionMain = new ShareGetQuestionMainByCodeDao();
                var GetQuestionMainCond = new ShareGetQuestionMainByCodeConditions();
                GetQuestionMainCond.AccessToken = _User.AccessToken;
                GetQuestionMainCond.RefreshToken = _User.RefreshToken;
                GetQuestionMainCond.CompanySetting = CompanySetting;
                GetQuestionMainCond.Code = Request.QueryString["Code"];
                var QuestionMain = (oGetQuestionMain.GetData(GetQuestionMainCond).Data as List<ShareGetQuestionMainByCodeRow>).FirstOrDefault();


                var oGetQuestionReply = new ShareGetQuestionReplyByQuestionMainCodeDao();
                var GetQuestionReplyCond = new ShareGetQuestionReplyByQuestionMainCodeConditions();
                GetQuestionReplyCond.AccessToken = _User.AccessToken;
                GetQuestionReplyCond.RefreshToken = _User.RefreshToken;
                GetQuestionReplyCond.CompanySetting = CompanySetting;
                GetQuestionReplyCond.Code = Request.QueryString["Code"];
                var rsGQR = oGetQuestionReply.GetData(GetQuestionReplyCond);
                var Draft = (rsGQR.Data as List<ShareGetQuestionReplyByQuestionMainCodeRow>).Where(x => x.Key1 == _User.EmpId).Where(x => x.Send == false).FirstOrDefault();
                var rsQM = rsGQR.Data as List<ShareGetQuestionReplyByQuestionMainCodeRow>;
                var Reply = rsQM.Where(data => data.ParentCode == Request.QueryString["Code"]);
                Reply = Reply.Where(x => x.Send == true);
                var rsViewrsQM = new List<ShareGetQuestionReplyByQuestionMainCodeRow>();

                if (Draft != null)
                {
                    txtContent.Text = Draft.Content;
                }
                //foreach (var select in rsQM)
                //{

                //    if (Security.GetRoleKeyToBinaryKey(select.RoleKey).Contains(_User.RoleKey))
                //    {
                //        rsViewrsQM.Add(select);
                //    }


                //}
                //var dataview = rsViewrsQM.GroupBy(x => x.ParentCode);
                Reply = Reply.Where(x => Security.GetRoleKeyToBinaryKey(x.RoleKey).Contains(_User.RoleKey));

            

                QuestionReplyData.DataSource = Reply;
                if (QuestionMain.Complete)
                {
                   

                    //foreach (var control in QuestionReplyData.Items)
                    //{
                    //    var target = control.FindControl("btnReplyAdd") as RadButton;
                    //    if (target != null)
                    //    {
                    //        target.Enabled = false;
                    //    }

                    //}
                    //var Script = "$('.btnReply').hide();";
                    //ScriptManager.RegisterStartupScript(this, typeof(Button), "btnhide", Script, true);
                }

            }
            catch (Exception ex)
            {

            }
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {


        }
        protected void QuestionReplyData_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            if (_User.EmpName == "未登入")
            {
                string strUrl_No = "../Reply/LoginBind.aspx";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                return;
            }
            try
            {
                APIResult Result = new APIResult();
                var button = e.EventSource as RadButton;
                var Action = button.ID;
                RadListView currListView = sender as RadListView;
                var oInsertQuestionReply = new ShareInsertQuestionReplyDao();
                var InsertQuestionReplyCond = new ShareInsertQuestionReplyConditions();
                var CN = e.CommandName;
                var CA = e.CommandArgument;
                if (Action == "btnReplyAdd")//留言回覆
                {

                    var oGetQuestionReplyByParentCode = new ShareGetQuestionReplyByCodeDao();
                    var GetQuestionReplyByParentCodeCond = new ShareGetQuestionReplyByCodeConditions();
                    GetQuestionReplyByParentCodeCond.AccessToken = _User.AccessToken;
                    GetQuestionReplyByParentCodeCond.RefreshToken = _User.RefreshToken;
                    GetQuestionReplyByParentCodeCond.Code = CA.ToString();
                    var rsQRBP = (oGetQuestionReplyByParentCode.GetData(GetQuestionReplyByParentCodeCond).Data as List<ShareGetQuestionReplyByCodeRow>).FirstOrDefault();

                    string content = "";
                    RadTextBox txt = new RadTextBox();
                    RadLabel lbl = new RadLabel();
                    foreach (var control in QuestionReplyData.Items)
                    {
                        if (e.ListViewItem.ClientID == control.ClientID)
                        {
                            txt = control.FindControl("txtReply") as RadTextBox;
                            lbl = control.FindControl("lblReplyStatus") as RadLabel;
                            if (txt.Text.Length == 0)
                            {
                                lbl.Text = "回覆不得為空白";
                                return;
                            }
                            content = txt.Text.Replace("\r\n", "<br/>");
                        }
                    }
                    InsertQuestionReplyCond.AccessToken = _User.AccessToken;
                    InsertQuestionReplyCond.RefreshToken = _User.RefreshToken;
                    InsertQuestionReplyCond.CompanySetting = CompanySetting;
                    InsertQuestionReplyCond.AutoKey = 0;
                    InsertQuestionReplyCond.Code = Guid.NewGuid().ToString();
                    InsertQuestionReplyCond.QuestionMainCode = Request.QueryString["Code"];
                    InsertQuestionReplyCond.Key1 = _User.EmpId;
                    if (_User.RoleKey == 2)
                    {
                        InsertQuestionReplyCond.Key2 = "Admin";
                    }
                    else if (_User.RoleKey == 8)
                    {
                        InsertQuestionReplyCond.Key2 = "Hr";
                    }
                    else if (_User.RoleKey == 64)
                    {
                        InsertQuestionReplyCond.Key2 = "User";
                    }
                    InsertQuestionReplyCond.Key3 = _User.EmpId;
                    InsertQuestionReplyCond.Name = _User.EmpName;
                    InsertQuestionReplyCond.Content = content;
                    InsertQuestionReplyCond.RoleKey = rsQRBP.RoleKey;
                    InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                    InsertQuestionReplyCond.ReplyToCode = CA.ToString();
                    InsertQuestionReplyCond.ParentCode = CN.ToString();
                    InsertQuestionReplyCond.Send = true;
                    InsertQuestionReplyCond.Status = "1";
                    InsertQuestionReplyCond.Note = "";
                    InsertQuestionReplyCond.InsertMan = _User.EmpName;
                    InsertQuestionReplyCond.InsertDate = DateTime.Now;
                    InsertQuestionReplyCond.UpdateMan = _User.EmpName;
                    InsertQuestionReplyCond.UpdateDate = DateTime.Now;

                    Result= oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                    if (Result.Status)
                    {
                        var oSendMail = new ShareSendQueueDao();
                        MailAddress address = new MailAddress("aron@jbjob.com.tw");
                        var Subject = "";
                        var Body = "";
                        var oShareMail = new ShareMailDao();
                        var dcParameter = new Dictionary<string, string>();
                        dcParameter.Add("MainCode", Request.QueryString["Code"]);
                        oShareMail.OutMailContent(out Subject, out Body, "02", 0, true, dcParameter);
                        oSendMail.SendMail(address, Subject, Body, true);
                        ViewState["ParentCode"] = CN.ToString();
                        QuestionReplyData.Rebind();
                    }
                    
                }
                else if (Action == "btnSubReplyAdd")
                {
                    var oGetQuestionReplyByParentCode = new ShareGetQuestionReplyByCodeDao();
                    var GetQuestionReplyByParentCodeCond = new ShareGetQuestionReplyByCodeConditions();
                    GetQuestionReplyByParentCodeCond.Code = CA.ToString();
                    var rsQRBP = (oGetQuestionReplyByParentCode.GetData(GetQuestionReplyByParentCodeCond).Data as List<ShareGetQuestionReplyByCodeRow>).FirstOrDefault();

                    string content = "";
                    RadTextBox txt = new RadTextBox();
                    RadLabel lbl = new RadLabel();

                    foreach (var control in currListView.Items)
                    {
                        if (e.ListViewItem.ClientID == control.ClientID)
                        {
                            txt = control.FindControl("txtReply") as RadTextBox;
                            lbl = control.FindControl("lblReplyStatus") as RadLabel;
                            if (txt.Text.Length == 0)
                            {
                                lbl.Text = "回覆不得為空白";
                                return;
                            }
                            content = txt.Text.Replace("\r\n", "<br/>");
                        }
                    }
                    InsertQuestionReplyCond.AccessToken = _User.AccessToken;
                    InsertQuestionReplyCond.RefreshToken = _User.RefreshToken;
                    InsertQuestionReplyCond.CompanySetting = CompanySetting;
                    InsertQuestionReplyCond.AutoKey = 0;
                    InsertQuestionReplyCond.Code = Guid.NewGuid().ToString();
                    InsertQuestionReplyCond.QuestionMainCode = Request.QueryString["Code"];
                    InsertQuestionReplyCond.Key1 = _User.EmpId;
                    if (_User.RoleKey == 2)
                    {
                        InsertQuestionReplyCond.Key2 = "Admin";
                    }
                    else if (_User.RoleKey == 8)
                    {
                        InsertQuestionReplyCond.Key2 = "Hr";
                    }
                    else if (_User.RoleKey == 64)
                    {
                        InsertQuestionReplyCond.Key2 = "User";
                    }
                    InsertQuestionReplyCond.Key3 = _User.EmpId;
                    InsertQuestionReplyCond.Name = _User.EmpName;
                    InsertQuestionReplyCond.Content = content;
                    InsertQuestionReplyCond.RoleKey = rsQRBP.RoleKey;
                    InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                    InsertQuestionReplyCond.ReplyToCode = CA.ToString();
                    InsertQuestionReplyCond.ParentCode = CN.ToString();
                    InsertQuestionReplyCond.Send = true;
                    InsertQuestionReplyCond.Status = "1";
                    InsertQuestionReplyCond.Note = "";
                    InsertQuestionReplyCond.InsertMan = _User.EmpName;
                    InsertQuestionReplyCond.InsertDate = DateTime.Now;
                    InsertQuestionReplyCond.UpdateMan = _User.EmpName;
                    InsertQuestionReplyCond.UpdateDate = DateTime.Now;

                    Result=oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                    if (Result.Status)
                    {
                        var oSendMail = new ShareSendQueueDao();
                        MailAddress address = new MailAddress("aron@jbjob.com.tw");
                        var Subject = "";
                        var Body = "";
                        var oShareMail = new ShareMailDao();
                        var dcParameter = new Dictionary<string, string>();
                        dcParameter.Add("MainCode", Request.QueryString["Code"]);
                        oShareMail.OutMailContent(out Subject, out Body, "02", 0, true, dcParameter);
                        oSendMail.SendMail(address, Subject, Body, true);
                        ViewState["ParentCode"] = CN.ToString();
                        QuestionReplyData.Rebind();
                    }
                }
                var oGetQuestionMain = new ShareGetQuestionMainByCodeDao();
                var GetQuestionMainCond = new ShareGetQuestionMainByCodeConditions();
                GetQuestionMainCond.Code = Request.QueryString["Code"];
                GetQuestionMainCond.AccessToken = _User.AccessToken;
                GetQuestionMainCond.RefreshToken = _User.RefreshToken;
                GetQuestionMainCond.CompanySetting = CompanySetting;
                var rsGQM = oGetQuestionMain.GetData(GetQuestionMainCond).Data as List<ShareGetQuestionMainByCodeRow>;
                var data = rsGQM.FirstOrDefault();
                var oUpdateQuestionMain = new ShareUpdateQuestionMainDao();
                var UpdateQuestionMainCond = new ShareUpdateQuestionMainConditions();
                UpdateQuestionMainCond.TargetCode = Request.QueryString["Code"];
                UpdateQuestionMainCond.AutoKey = 0;
                UpdateQuestionMainCond.AutoKey = data.AutoKey;
                UpdateQuestionMainCond.CompanyId = data.CompanyId;
                UpdateQuestionMainCond.Code = Request.QueryString["Code"];
                UpdateQuestionMainCond.SystemCategoryCode = data.SystemCategoryCode;
                UpdateQuestionMainCond.Key1 = data.Key1;
                UpdateQuestionMainCond.Key2 = data.Key2;
                UpdateQuestionMainCond.Key3 = data.Key3;
                UpdateQuestionMainCond.Name = data.Name;
                UpdateQuestionMainCond.TitleContent = data.TitleContent;
                UpdateQuestionMainCond.Content = data.Content;
                UpdateQuestionMainCond.QuestionCategoryCode = data.QuestionCategoryCode;
                UpdateQuestionMainCond.IpAddress = data.IpAddress;
                UpdateQuestionMainCond.DateE = data.DateE;
                UpdateQuestionMainCond.Complete = false;
                UpdateQuestionMainCond.Note = data.Note;
                UpdateQuestionMainCond.Status = data.Status;
                UpdateQuestionMainCond.InsertMan = data.InsertMan;
                UpdateQuestionMainCond.InsertDate = data.InsertDate;
                UpdateQuestionMainCond.UpdateMan = _User.EmpName;
                UpdateQuestionMainCond.UpdateDate = DateTime.Now;
                UpdateQuestionMainCond.AccessToken = _User.AccessToken;
                UpdateQuestionMainCond.RefreshToken = _User.RefreshToken;
                UpdateQuestionMainCond.CompanySetting = CompanySetting;
                UpdateQuestionMainCond.Code = Request.QueryString["Code"];
                oUpdateQuestionMain.GetData(UpdateQuestionMainCond);
            }
            catch (Exception ex)
            {

            }

        }

        protected void DataUpload_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oFileListByCodeDao = new FileListByCodeDao();
            var FileListByCodeCond = new FileListByCodeConditions();
            var result = new List<FileListByCodeRow>();
            FileListByCodeCond.AccessToken = _User.AccessToken;
            FileListByCodeCond.RefreshToken = _User.RefreshToken;
            FileListByCodeCond.CompanySetting = CompanySetting;
            FileListByCodeCond.Code = Request.QueryString["Code"];
            var Result = oFileListByCodeDao.GetData(FileListByCodeCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    result = Result.Data as List<FileListByCodeRow>;
                    DataUpload.DataSource = result;
                }
            }

        }
        protected void DataUpload_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

        }


        public void SetDefaultMessage(object sender, EventArgs e)
        {
            try
            {
                RadButton button = sender as RadButton;
                txtContent.Text = button.CommandArgument;
                //var Script = "$(document).ready(function() {$('.footable').footable();});";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

            }
            catch (Exception ex)
            {

            }
        }







        protected void RadioFirst_CheckedChanged(object sender, EventArgs e)
        {
            RadioSecond.Checked = false;
            RadioThird.Checked = false;
            RadioFourth.Checked = false;
            txtReturnS.Enabled = false;
            txtReturnS.SelectedIndex = 0;
            //var Script = "$(document).ready(function() {$('.footable').footable();});";
            //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void RadioSecond_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioThird.Checked = false;
            txtReturnS.Enabled = false;
            txtReturnS.SelectedIndex = 0;
            //var Script = "$(document).ready(function() {$('.footable').footable();});";
            //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

        }

        protected void RadioThird_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioSecond.Checked = false;
            RadioFourth.Checked = false;
            txtReturnS.Enabled = false;
            txtReturnS.SelectedIndex = 0;
            //var Script = "$(document).ready(function() {$('.footable').footable();});";
            //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void RadioFourth_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioSecond.Checked = false;
            RadioThird.Checked = false;
            txtReturnS.Enabled = true;
           
            //var Script = "$(document).ready(function() {$('.footable').footable();});";
            //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (_User.EmpName == "未登入")
            {
                string strUrl_No = "../Reply/LoginBind.aspx";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                return;
            }
            if (txtContent.Text == "" || txtContent.Text == null)
            {
                DraftStatus.InnerText = "回覆不得為空白";
                return;
            }
            if (RadioFourth.Checked == true)
            {
                if (txtReturnS.SelectedValue == "")
                {
                    DraftStatus.InnerText = "選擇系統商內部人員則轉呈/回覆人員不得為空白";
                    return;
                }
            }
            if (Request.QueryString["Code"] != null)
            {
                RadButton button = sender as RadButton;
                var CN = button.CommandName;

                var oGetQuestionReplyByParentCode = new ShareGetQuestionReplyByQuestionMainCodeDao();
                var GetQuestionReplyByParentCodeCond = new ShareGetQuestionReplyByQuestionMainCodeConditions();

                GetQuestionReplyByParentCodeCond.Code = Request.QueryString["Code"];
                var rsGQBP = (oGetQuestionReplyByParentCode.GetData(GetQuestionReplyByParentCodeCond).Data) as List<ShareGetQuestionReplyByQuestionMainCodeRow>;
                var Draft = rsGQBP.Where(x => x.Key1 == _User.EmpId).Where(x => x.Send == false).FirstOrDefault();



                var oInsertQuestionReply = new ShareInsertQuestionReplyDao();
                var InsertQuestionReplyCond = new ShareInsertQuestionReplyConditions();
                InsertQuestionReplyCond.AccessToken = _User.AccessToken;
                InsertQuestionReplyCond.RefreshToken = _User.RefreshToken;
                InsertQuestionReplyCond.CompanySetting = CompanySetting;
                InsertQuestionReplyCond.AutoKey = 0;
                InsertQuestionReplyCond.Code = Guid.NewGuid().ToString();
                InsertQuestionReplyCond.QuestionMainCode = Request.QueryString["Code"];
                InsertQuestionReplyCond.Key1 = _User.EmpId;
                if (_User.RoleKey == 2)
                {
                    InsertQuestionReplyCond.Key2 = "Admin";
                }
                else if(_User.RoleKey==8)
                {
                    InsertQuestionReplyCond.Key2 = "Hr";
                }
               
                InsertQuestionReplyCond.Key3 = _User.EmpId;
                InsertQuestionReplyCond.Name = _User.EmpName;
                InsertQuestionReplyCond.Content = txtContent.Text.Replace("\r\n", "<br/>");
                if (_User.RoleKey == 2)
                {
                    InsertQuestionReplyCond.RoleKey = 2;
                }
                else
                {
                    InsertQuestionReplyCond.RoleKey = 10;
                }              
                InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                InsertQuestionReplyCond.ReplyToCode = "";
                InsertQuestionReplyCond.ParentCode = Request.QueryString["Code"];
                InsertQuestionReplyCond.Send = true;
                InsertQuestionReplyCond.Status = "1";
                InsertQuestionReplyCond.Note = "";
                InsertQuestionReplyCond.InsertMan = _User.EmpName;
                InsertQuestionReplyCond.InsertDate = DateTime.Now;
                if (RadioFirst.Checked.Value)
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioFirst.Value);
                }
                else if (RadioSecond.Checked.Value)
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioSecond.Value);
                }
                else if (RadioThird.Checked.Value)
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioThird.Value);
                }
                else
                {
                    InsertQuestionReplyCond.RoleKey = Int32.Parse(RadioFourth.Value);
                    if (txtReturnS.Text != ""&& txtReturnS.Text != null)
                    {
                        InsertQuestionReplyCond.Content = "@" + txtReturnS.Text +" "+InsertQuestionReplyCond.Content;
                    }
                   
                }



                if (CN == "Draft")
                {                   
                    if (Draft == null)
                    {
                        InsertQuestionReplyCond.Send = false;                      
                        oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                    }
                    else
                    {
                        var oUpdateQuestionReplyContent = new ShareUpdateQuestionReplyContentDao();
                        var UpdateQuestionReplyContentCond = new ShareUpdateQuestionReplyContentConditions();
                        UpdateQuestionReplyContentCond.AccessToken = _User.AccessToken;
                        UpdateQuestionReplyContentCond.RefreshToken = _User.RefreshToken;
                        UpdateQuestionReplyContentCond.CompanySetting = CompanySetting;
                        UpdateQuestionReplyContentCond.Code = Draft.Code;
                        UpdateQuestionReplyContentCond.Content = txtContent.Text;
                        oUpdateQuestionReplyContent.GetData(UpdateQuestionReplyContentCond);
                    }

                    DraftStatus.InnerText = "草稿儲存成功";
                }
                else
                {
                    APIResult Result = new APIResult();
                    if (Draft != null)
                    {
                        var oUpdateQuestionReplySend = new ShareUpdateQuestionReplySendDao();
                        var UpdateQuestionReplySendCond = new ShareUpdateQuestionReplySendConditions();
                        UpdateQuestionReplySendCond.AccessToken = _User.AccessToken;
                        UpdateQuestionReplySendCond.RefreshToken = _User.RefreshToken;
                        UpdateQuestionReplySendCond.CompanySetting = CompanySetting;
                        UpdateQuestionReplySendCond.Code = Draft.Code;
                        UpdateQuestionReplySendCond.SetSend = true;
                        Result=oUpdateQuestionReplySend.GetData(UpdateQuestionReplySendCond);
                        var oUpdateQuestionReplyContent = new ShareUpdateQuestionReplyContentDao();
                        var UpdateQuestionReplyContentCond = new ShareUpdateQuestionReplyContentConditions();
                        UpdateQuestionReplyContentCond.AccessToken = _User.AccessToken;
                        UpdateQuestionReplyContentCond.RefreshToken = _User.RefreshToken;
                        UpdateQuestionReplyContentCond.CompanySetting = CompanySetting;
                        UpdateQuestionReplyContentCond.Code = Draft.Code;
                        UpdateQuestionReplyContentCond.Content = txtContent.Text;
                        Result=oUpdateQuestionReplyContent.GetData(UpdateQuestionReplyContentCond);
                        DraftStatus.InnerText = "";
                    }
                    else
                    {
                        InsertQuestionReplyCond.Send = true;
                        Result = oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                        DraftStatus.InnerText = "";
                    }
                    
                    txtContent.Text = "";
                    var oGetQuestionMain = new ShareGetQuestionMainByCodeDao();
                    var GetQuestionMainCond = new ShareGetQuestionMainByCodeConditions();
                    GetQuestionMainCond.Code = Request.QueryString["Code"];
                    GetQuestionMainCond.AccessToken = _User.AccessToken;
                    GetQuestionMainCond.RefreshToken = _User.RefreshToken;
                    GetQuestionMainCond.CompanySetting = CompanySetting;
                    var rsGQM = oGetQuestionMain.GetData(GetQuestionMainCond).Data as List<ShareGetQuestionMainByCodeRow>;
                    var data = rsGQM.FirstOrDefault();
                    var oUpdateQuestionMain = new ShareUpdateQuestionMainDao();
                    var UpdateQuestionMainCond = new ShareUpdateQuestionMainConditions();
                    UpdateQuestionMainCond.TargetCode = Request.QueryString["Code"];
                    UpdateQuestionMainCond.AutoKey = 0;
                    UpdateQuestionMainCond.AutoKey = data.AutoKey;
                    UpdateQuestionMainCond.CompanyId = data.CompanyId;
                    UpdateQuestionMainCond.Code = Request.QueryString["Code"];
                    UpdateQuestionMainCond.SystemCategoryCode = data.SystemCategoryCode;
                    UpdateQuestionMainCond.Key1 = data.Key1;
                    UpdateQuestionMainCond.Key2 = data.Key2;
                    UpdateQuestionMainCond.Key3 = data.Key3;
                    UpdateQuestionMainCond.Name = data.Name;
                    UpdateQuestionMainCond.TitleContent = data.TitleContent;
                    UpdateQuestionMainCond.Content = data.Content;
                    UpdateQuestionMainCond.QuestionCategoryCode = data.QuestionCategoryCode;
                    UpdateQuestionMainCond.IpAddress = data.IpAddress;
                    UpdateQuestionMainCond.DateE = data.DateE;
                    UpdateQuestionMainCond.Complete = false;
                    UpdateQuestionMainCond.Note = data.Note;
                    UpdateQuestionMainCond.Status = data.Status;
                    UpdateQuestionMainCond.InsertMan = data.InsertMan;
                    UpdateQuestionMainCond.InsertDate = data.InsertDate;
                    UpdateQuestionMainCond.UpdateMan = _User.EmpName;
                    UpdateQuestionMainCond.UpdateDate = DateTime.Now;
                    UpdateQuestionMainCond.AccessToken = _User.AccessToken;
                    UpdateQuestionMainCond.RefreshToken = _User.RefreshToken;
                    UpdateQuestionMainCond.CompanySetting = CompanySetting;
                    UpdateQuestionMainCond.Code = Request.QueryString["Code"];
                    oUpdateQuestionMain.GetData(UpdateQuestionMainCond);

                    if (Result.Status)
                    {
                        var oSendMail = new ShareSendQueueDao();
                        MailAddress address = new MailAddress("aron@jbjob.com.tw");
                        var Subject = "";
                        var Body = "";
                        var oShareMail = new ShareMailDao();
                        var dcParameter = new Dictionary<string, string>();
                        dcParameter.Add("MainCode", Request.QueryString["Code"]);
                        oShareMail.OutMailContent(out Subject, out Body, "02", 0, true, dcParameter);
                        oSendMail.SendMail(address, Subject, Body, true);
                        if (RadioFourth.Checked.Value)
                        {
                            Subject = "";
                            Body = "";
                            dcParameter.Add("ReplyToUserCode", txtReturnS.SelectedValue);
                            oShareMail.OutMailContent(out Subject, out Body, "05", 0, true, dcParameter);
                            oSendMail.SendMail(address, Subject, Body, true);
                        }    
                    }                   
                }                
                QuestionReplyData.Rebind();

               
                DraftStatus.InnerText = "";
            }
        }
        protected void SubQuestionReplyData_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {


            try
            {

                RadListView currListView = sender as RadListView;
                string ParentCode = "";
                //if (!IsPostBack)
                //{
                //    foreach (var item in QuestionReplyData.Items)
                //    {
                //        if (currListView.Parent.ClientID == item.ClientID)
                //        {
                //            if (item.DataItem as ShareGetQuestionReplyByQuestionMainCodeRow != null)
                //            {
                //                ParentCode = (item.DataItem as ShareGetQuestionReplyByQuestionMainCodeRow).Code;
                //            }
                //        };
                //    };
                //}
                //else
                //{
                //    ParentCode = ViewState["ParentCode"].ToString();
                //}
                if ((currListView.NamingContainer as RadListViewDataItem).DataItem != null)
                {
                    ParentCode = ((currListView.NamingContainer as RadListViewDataItem).DataItem as ShareGetQuestionReplyByQuestionMainCodeRow).Code;
                }
                else
                {
                    ParentCode = (((Telerik.Web.UI.RadCompositeDataBoundControl)((System.Web.UI.Control)sender).Parent.BindingContainer).DataSource as IEnumerator<ShareGetQuestionReplyByQuestionMainCodeRow>).Current.Code;

                }

                if (ParentCode != "" && ParentCode != null)
                {
                    var oGetQuestionReplyByQuestionMainCode = new ShareGetQuestionReplyByQuestionMainCodeDao();
                    var GetQuestionReplyByQuestionMainCodeCond = new ShareGetQuestionReplyByQuestionMainCodeConditions();
                    GetQuestionReplyByQuestionMainCodeCond.Code = Request.QueryString["Code"];
                    GetQuestionReplyByQuestionMainCodeCond.AccessToken = _User.AccessToken;
                    GetQuestionReplyByQuestionMainCodeCond.RefreshToken = _User.RefreshToken;
                    var rsQM = (oGetQuestionReplyByQuestionMainCode.GetData(GetQuestionReplyByQuestionMainCodeCond).Data as List<ShareGetQuestionReplyByQuestionMainCodeRow>);
                    var Reply = rsQM.Where(data => data.ParentCode == ParentCode);
                    Reply = Reply.Where(x => x.Send == true);
                    Reply = Reply.Where(x => Security.GetRoleKeyToBinaryKey(x.RoleKey).Contains(_User.RoleKey));
                    foreach (var DataDetail in Reply)
                    {
                        if (DataDetail.ReplyToCode != "")
                        {
                            DataDetail.ReplyName = rsQM.Where(x => x.Code == DataDetail.ReplyToCode).FirstOrDefault().Name;
                            DataDetail.ReplyContent = rsQM.Where(x => x.Code == DataDetail.ReplyToCode).FirstOrDefault().Content;
                            if (DataDetail.ReplyContent.Length > 200)
                            {
                                DataDetail.ReplyContent = DataDetail.ReplyContent.Substring(0, 200);
                                DataDetail.ReplyContent += "……";
                            }
                        }
                    }
                    (sender as RadListView).DataSource = Reply;
                }


            }
            catch (Exception ex)
            {

            }

        }

    }
}