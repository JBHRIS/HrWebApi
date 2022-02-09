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
using Dal.Dao.Files;
using Bll.Files.Vdb;
using Bll.Token.Vdb;
using System.Net.Mail;

namespace Portal
{
    public partial class ProblemReturnView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SetUserInfo();
                SetDefault();


            }
            UnobtrusiveSession.Session["AccessToken"] = _User.AccessToken;
            UnobtrusiveSession.Session["RefeshToken"] = _User.RefreshToken;
        }
        private void SetUserInfo()
        {
            lblUserCode.Text = _User.UserCode;
            lblCompanyId.Text = _User.CompanyId;
            _User.EmpId = _User.EmpId;
            _User.EmpName = _User.EmpName;
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
                    lblQuestionCategory.Text = Data.QuestionCategoryName;
                    lblContent.Text = Data.Content;
                    if (Data.Key1 != _User.EmpId)
                    {
                        btnHelpful.Enabled = false;
                        btnHelpless.Enabled = false;

                    }
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
              
                //string Jumpto = "";
                //foreach (var Data in Reply)
                //{
                //    foreach (var v in dataview)
                //    {
                //        if (Data.Code == v.Key)
                //        {
                //            foreach (var DataDetail in v)
                //            {

                //                var Parent = v.Where(x => x.Code == DataDetail.ReplyToCode);
                //                if (Parent.FirstOrDefault() != null)
                //                {
                //                    var oParent = Parent.FirstOrDefault();
                //                    DataDetail.ReplyContent = oParent.Content;
                //                    DataDetail.ReplyName = oParent.Name;
                //                    Jumpto = oParent.Code;
                //                }
                //                else
                //                {
                //                    DataDetail.ReplyContent = Data.Content;
                //                    DataDetail.ReplyName = Data.Name;
                //                    Jumpto = Data.Code;
                //                }
                //                //DataDetail.ReplyName = v.Where(x => x.Code == DataDetail.ReplyToCode).DefaultIfEmpty().FirstOrDefault().Name;
                //                Data.DataView +=
                //             "<div class=\"float-left\">" +
                //             "<div class=\"navy-bg admin_circle\">";
                //                if (DataDetail.Key2 == "admin")
                //                {
                //                    Data.DataView += "<i class=\"fa fa-users\"></i>";
                //                }
                //                {
                //                    Data.DataView += "<i class=\"fa fa-user\"></i>";
                //                }
                //                Data.DataView +=
                //               "</div>" +
                //             "</div>" +
                //            "<div class=\"media-body\">" +
                //           "<span class = \"name_font\"/>" + DataDetail.Name + " </span>" +
                //           "<a href=\"#" + Jumpto + "\"><span class=\"text-blue\"><i class=\"fa fa-share \"></i>" + DataDetail.ReplyName + "</span></a><span class=\"replyreply_text\">" + DataDetail.ReplyContent + "</span><br/>" +
                //           "<span>" + DataDetail.Content + "</span><br/>" +
                //           "<button ID=\"btnSubReply\" type = \"button\" class=\"btnReply btn btn-white btn-xs\" data-toggle=\"collapse\" data-target=\"#rep" + DataDetail.Code + "\"> <i class=\"fa fa-comments\"></i> 回覆</button>" +
                //           "<span class=\"text-muted\">" + DataDetail.InsertDate.Value.ToString("yyyy/MM/dd") + " </span>-" +
                //           "<span class=\"text-muted\">" + DataDetail.InsertDate.Value.ToString("HH:mm") + "</span><br/>" +
                //            "<div class=\"form-group\">" +
                //           "<div id=\"rep" + DataDetail.Code + "\"class=\"collapse\"><span style=\"width:100%;\"class=\"RadInput RadInput_Bootstrap RadInputMultiline RadInputMultiline_Bootstrap\">" +
                //           "<textarea style=\"resize: none\" rows=\"3\" cols=\"20\" class=\"riTextBox riEmpty\" id=\"con" + DataDetail.Code + "\" placeholder=\"請填寫您想回覆的內容...\" ></textarea></span><br/>" +
                //             "<asp:Button id=\""+DataDetail.Code+"\" runat=\"server\" CssClass=\"btn btn-primary btn-primary btn-md\" Text=\"送出\" OnClick=\"ReplyAdd\"></asp:Button>" +
                //           "</div>" + "</div>" +
                //           "</div><br/>";

                //            }
                //        }
                //    }
                //}

                QuestionReplyData.DataSource = Reply;
                if (QuestionMain.Complete)
                {
                    divCompleteStatus.Visible = true;
                    pCompleteStatus.Visible = true;
                    //pCompleteStatus.Style.Remove("display");
                    btnWtReply.Disabled = true;
                    btnHelpful.Enabled = false;
                    btnHelpless.Enabled = false;
                    btnDraft.Enabled = false;
                    btnAdd.Enabled = false;

                    //foreach (var control in QuestionReplyData.Items)
                    //{
                    //    var target = control.FindControl("btnReplyAdd") as RadButton;
                    //    if (target != null)
                    //    {
                    //        target.Enabled = false;
                    //    }

                    //}
                    var Script = "$('.btnReply').hide();";
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "btnhide", Script, true);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void DataUpload_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oFilesByFileTicket = new FilesByFileTicketDao();
            var FilesByFileTicketCond = new FilesByFileTicketConditions();
            var result = new List<FilesByFileTicketRow>();
            FilesByFileTicketCond.AccessToken = _User.AccessToken;
            FilesByFileTicketCond.RefreshToken = _User.RefreshToken;
            FilesByFileTicketCond.CompanySetting = CompanySetting;
            FilesByFileTicketCond.fileTicket = Request.QueryString["Code"];
            var Result = oFilesByFileTicket.GetData(FilesByFileTicketCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    result = Result.Data as List<FilesByFileTicketRow>;
                    DataUpload.DataSource = result;
                }
            }

        }
        protected void DataUpload_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            APIResult Result = new APIResult();
            if (_User.EmpName == "未登入")
            {
                string strUrl_No = "../Reply/LoginBind.aspx";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                return;
            }
            if (txtContent.Text == "" || txtContent.Text == null)
            {
                lblAddStatus.InnerText = "回覆不得為空白";
                return;
            }
            try
            {
                if (Request.QueryString["Code"] != null)
                {
                    RadButton button = sender as RadButton;
                    var CN = button.CommandName;

                    var oGetQuestionReplyByQuestionMainCode = new ShareGetQuestionReplyByQuestionMainCodeDao();
                    var GetQuestionReplyByQuestionMainCodeCond = new ShareGetQuestionReplyByQuestionMainCodeConditions();
                    GetQuestionReplyByQuestionMainCodeCond.AccessToken = _User.AccessToken;
                    GetQuestionReplyByQuestionMainCodeCond.RefreshToken = _User.RefreshToken;
                    GetQuestionReplyByQuestionMainCodeCond.CompanySetting = CompanySetting;
                    GetQuestionReplyByQuestionMainCodeCond.Code = Request.QueryString["Code"];
                    var rsGQBP = (oGetQuestionReplyByQuestionMainCode.GetData(GetQuestionReplyByQuestionMainCodeCond).Data) as List<ShareGetQuestionReplyByQuestionMainCodeRow>;
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
                    InsertQuestionReplyCond.Content = txtContent.Text.Replace("\r\n", "<br/>");
                    InsertQuestionReplyCond.RoleKey = 74 ;
                    InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                    InsertQuestionReplyCond.ReplyToCode = Request.QueryString["Code"];
                    InsertQuestionReplyCond.ParentCode = Request.QueryString["Code"];
                    InsertQuestionReplyCond.Send = true;
                    InsertQuestionReplyCond.Status = "1";
                    InsertQuestionReplyCond.Note = "";
                    InsertQuestionReplyCond.InsertMan = _User.EmpName;
                    InsertQuestionReplyCond.InsertDate = DateTime.Now;
                    if (CN == "Draft")
                    {
                        if (Draft == null)
                        {
                            InsertQuestionReplyCond.Send = false;
                            oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                            lblAddStatus.InnerText = "草稿儲存成功";
                        }
                        else
                        {
                            var oUpdateQuestionReplySend = new ShareUpdateQuestionReplyContentDao();
                            var UpdateQuestionReplySendCond = new ShareUpdateQuestionReplyContentConditions();
                            UpdateQuestionReplySendCond.AccessToken = _User.AccessToken;
                            UpdateQuestionReplySendCond.RefreshToken = _User.RefreshToken;
                            UpdateQuestionReplySendCond.CompanySetting = CompanySetting;
                            UpdateQuestionReplySendCond.Code = Draft.Code;
                            UpdateQuestionReplySendCond.Content = txtContent.Text;
                            oUpdateQuestionReplySend.GetData(UpdateQuestionReplySendCond);
                            lblAddStatus.InnerText = "草稿儲存成功";
                        }
                    }
                    else
                    {
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

                        }
                        else
                        {
                            InsertQuestionReplyCond.Send = true;
                            Result=oInsertQuestionReply.GetData(InsertQuestionReplyCond);

                        }
                        lblAddStatus.InnerText = "";
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
                    }
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
            }
            catch (Exception ex)
            {

            }



        }

        public void btnPage_Click(object sender, EventArgs e)
        {

            Response.Redirect("ProblemReturnList.aspx");

        }
        protected void QuestionReplyData_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            APIResult Result = new APIResult();
            if (_User.EmpName == "未登入")
            {
                string strUrl_No = "../Reply/LoginBind.aspx";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                return;
            }
            try
            {
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
                    InsertQuestionReplyCond.Content = content.Replace("\r\n","<br/>");
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

                    Result =oInsertQuestionReply.GetData(InsertQuestionReplyCond);
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

     

    protected void btnHelpful_Click(object sender, EventArgs e)
        {
            APIResult Result = new APIResult();
            if (_User.EmpName == "未登入")
            {
                string strUrl_No = "../Reply/LoginBind.aspx";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
                return;
            }
            btnHelpful.Enabled = false;
            btnHelpless.Enabled = false;
            btnDraft.Enabled = false;
            btnAdd.Enabled = false;
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
            UpdateQuestionMainCond.Complete = true;
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

            Result = oUpdateQuestionMain.GetData(UpdateQuestionMainCond);
            if (Result.Status)
            {
                var oSendMail = new ShareSendQueueDao();
                MailAddress address = new MailAddress("aron@jbjob.com.tw");
                var Subject = "";
                var Body = "";
                var oShareMail = new ShareMailDao();
                var dcParameter = new Dictionary<string, string>();
                dcParameter.Add("MainCode", Request.QueryString["Code"]);
                oShareMail.OutMailContent(out Subject, out Body, "03", 0, true, dcParameter);
                oSendMail.SendMail(address, Subject, Body, true);
               
                QuestionReplyData.Rebind();
                divCompleteStatus.Visible = true;
                pCompleteStatus.Visible = true;
                //pCompleteStatus.Style.Remove("display");

                var Script = "$('.btnReply').hide();";
                ScriptManager.RegisterStartupScript(this, typeof(Button), "btnhide", Script, true);
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
                                DataDetail.ReplyContent = DataDetail.ReplyContent.Substring(0,200);
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