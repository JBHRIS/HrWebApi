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
                    GetQuestionMainCond.AccessToken = _User.AccessToken;
                    GetQuestionMainCond.RefreshToken = _User.RefreshToken;
                    GetQuestionMainCond.CompanySetting = CompanySetting;
                    GetQuestionMainCond.Code = Request.QueryString["Code"];
                    var rsGQM = oGetQuestionMain.GetData(GetQuestionMainCond);
                    var Data = (rsGQM.Data as List<ShareGetQuestionMainByCodeRow>).FirstOrDefault();
                    lblName.Text = Data.InsertMan;
                    lblDate.Text = Data.InsertDate.Value.ToString("yyyy/MM/dd");
                    lblTime.Text = Data.InsertDate.Value.ToString("HH:ss");
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
                foreach (var select in rsQM)
                {

                    if (Security.GetRoleKeyToBinaryKey(select.RoleKey).Contains(_User.RoleKey))
                    {
                        rsViewrsQM.Add(select);
                    }


                }
                var dataview = rsViewrsQM.GroupBy(x => x.ParentCode);
                Reply = Reply.Where(x => Security.GetRoleKeyToBinaryKey(x.RoleKey).Contains(_User.RoleKey));
                //if (Reply.Count() != 0)
                //{
                //    Useful.Style.Remove("display");
                //}
                //else
                //{
                //    btnWtReply.Style.Remove("display");
                //}


                foreach (var Data in Reply)
                {
                    foreach (var v in dataview)
                    {
                        if (Data.Code == v.Key)
                        {
                            foreach (var DataDetail in v)
                            {

                                Data.DataView +=
                            "<div class=\"media-body\">" +
                           "<span class = \"name_font\" />" + DataDetail.Name + " </span>" +
                           "<span >" + DataDetail.Content + "</span><br>" +
                           "<button ID=\"btnSubReply\" type = \"button\" class=\"btnReply btn btn-link fa comment_icon text-blue\" data-toggle=\"collapse\" data-target=\"#rep" + DataDetail.ParentCode + "\">回覆</button>" +
                           "<span class=\"text-muted\">" + DataDetail.InsertDate.Value.ToString("yyyy-MM-dd") + " </span>" +
                           "<span class=\"text-muted\">" + DataDetail.InsertDate.Value.ToString("HH: ss") + "</span><br>" +
                           "</div><br>";







                            }
                        }
                    }
                }

                QuestionReplyData.DataSource = Reply;
                if (QuestionMain.Complete)
                {
                    pCompleteStatus.Style.Remove("display");
                    btnWtReply.Disabled = true;
                    btnHelpful.Enabled = false;
                    btnHelpless.Enabled = false;
                    btnDraft.Enabled = false;
                    btnAdd.Enabled = false;

                    foreach (var control in QuestionReplyData.Items)
                    {
                        var target = control.FindControl("btnReplyAdd") as RadButton;
                        if (target != null)
                        {
                            target.Enabled = false;
                        }

                    }
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
                }
            }
            DataUpload.DataSource = result;
        }
        protected void DataUpload_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Code"] != null)
                {
                    RadButton button = sender as RadButton;
                    var CN = button.CommandName;

                    var oGetQuestionReplyByParentCode = new ShareGetQuestionReplyByQuestionMainCodeDao();
                    var GetQuestionReplyByParentCodeCond = new ShareGetQuestionReplyByQuestionMainCodeConditions();
                    GetQuestionReplyByParentCodeCond.AccessToken = _User.AccessToken;
                    GetQuestionReplyByParentCodeCond.RefreshToken = _User.RefreshToken;
                    GetQuestionReplyByParentCodeCond.CompanySetting = CompanySetting;
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
                    if (CN == "Draft")
                    {
                        if (Draft == null)
                        {
                            InsertQuestionReplyCond.Send = false;
                            oInsertQuestionReply.GetData(InsertQuestionReplyCond);
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
                            oUpdateQuestionReplySend.GetData(UpdateQuestionReplySendCond);
                        }
                        else
                        {
                            InsertQuestionReplyCond.Send = true;
                            oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                        }

                        txtContent.Text = "";
                    }


                    QuestionReplyData.Rebind();
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
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

            var oInsertQuestionReply = new ShareInsertQuestionReplyDao();
            var InsertQuestionReplyCond = new ShareInsertQuestionReplyConditions();
            var CN = e.CommandName;
            var CA = e.CommandArgument;
            if (CN == "Add")
            {

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
                InsertQuestionReplyCond.RoleKey = 74;
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
                lblAddStatus.InnerText = "送出成功";
                txtContent.Text = "";
                QuestionReplyData.Rebind();
            }
            else if (CN == "Reply")
            {

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
                InsertQuestionReplyCond.RoleKey = 74;
                InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                InsertQuestionReplyCond.ReplyToCode = "";
                InsertQuestionReplyCond.ParentCode = CA.ToString();
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
            else if (CN == "ReplyAdd")//留言回覆
            {

                var oGetQuestionReplyByParentCode = new ShareGetQuestionReplyByCodeDao();
                var GetQuestionReplyByParentCodeCond = new ShareGetQuestionReplyByCodeConditions();
                GetQuestionReplyByParentCodeCond.Code = CA.ToString();
                var rsQRBP = (oGetQuestionReplyByParentCode.GetData(GetQuestionReplyByParentCodeCond).Data as List<ShareGetQuestionReplyByCodeRow>).FirstOrDefault();

                string content = "";
                RadTextBox txt = new RadTextBox();
                foreach (var control in QuestionReplyData.Items)
                {
                    if (e.ListViewItem.ClientID == control.ClientID)
                    {
                        txt = control.FindControl("txtReply") as RadTextBox;
                        content = txt.Text;
                    }
                }
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
                InsertQuestionReplyCond.Content = content;
                InsertQuestionReplyCond.RoleKey = rsQRBP.RoleKey;
                InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
                InsertQuestionReplyCond.ReplyToCode = "";
                InsertQuestionReplyCond.ParentCode = CA.ToString();
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

        }

        protected void btnReply_Click(object sender, EventArgs e)
        {



            RadButton button = sender as RadButton;

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
            InsertQuestionReplyCond.Content = "";
            InsertQuestionReplyCond.RoleKey = Int32.Parse(lblRoleKey.Text);
            InsertQuestionReplyCond.IpAddress = WebPage.GetClientIP(Context);
            InsertQuestionReplyCond.ReplyToCode = "";
            InsertQuestionReplyCond.ParentCode = button.CommandArgument;
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

        protected void btnHelpful_Click(object sender, EventArgs e)
        {
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

            oUpdateQuestionMain.GetData(UpdateQuestionMainCond);

            pCompleteStatus.Style.Remove("display");
           

            foreach (var control in QuestionReplyData.Items)
            {
                var target = control.FindControl("btnReplyAdd") as RadButton;
                if (target != null)
                {
                    target.Enabled = false;
                }

            }
            var Script = "$('.btnReply').hide();";
            ScriptManager.RegisterStartupScript(this, typeof(Button), "btnhide", Script, true);
            btnHelpful.Enabled = false;
            btnHelpless.Enabled = false;
            btnDraft.Enabled = false;
            btnAdd.Enabled = false;
        }

    }
}