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
                txtReturnS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "", Value = "0" });
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
                    lblTime.Text = Data.InsertDate.Value.ToString("HH:ss");
                    lblTitle.Text = Data.TitleContent;
                    lblQuestionCategory.Text = Data.QuestionCategoryCode;
                    lblContent.Text = Data.Content;

                    var oGetQuestionDefaultMessage = new ShareGetQuestionDefaultMessageByCompanyIdDao();
                    var GetQuestionDefaultMessageCond = new ShareGetQuestionDefaultMessageByCompanyIdConditions();
                    GetQuestionDefaultMessageCond.AccessToken = _User.AccessToken;
                    GetQuestionDefaultMessageCond.RefreshToken = _User.RefreshToken;
                    GetQuestionDefaultMessageCond.CompanySetting = CompanySetting;
                    GetQuestionDefaultMessageCond.CompanyId = _User.RoleKey.ToString();
                    var rsGQDM = oGetQuestionDefaultMessage.GetData(GetQuestionDefaultMessageCond).Data as List<ShareGetQuestionDefaultMessageByCompanyIdRow>;
                    lvMain.DataSource = rsGQDM;
                    var Script = "$(document).ready(function() {$('.footable').footable();});";
                    ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

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
                    RadioFirst.Enabled = false;
                    RadioSecond.Enabled = false;
                    RadioThird.Enabled = false;
                    RadioFourth.Enabled = false;
                    
                    btnAdd.Enabled = false;
                    btnDraft.Enabled = false;
                    txtContent.Text = "此筆回報單已結單";
                    txtContent.Style.Add("class", "text-success");
                    txtContent.Enabled = false;
                    var Script = "$('.btnDefaultMessage').hide();";
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "btnhide", Script, true);
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
                InsertQuestionReplyCond.Key1 =_User.EmpId;
                InsertQuestionReplyCond.Key2 = _User.EmpId;
                InsertQuestionReplyCond.Key3 = _User.EmpId;
                InsertQuestionReplyCond.Name = _User.EmpName;
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

                var oGetQuestionReplyByCode = new ShareGetQuestionReplyByCodeDao();
                var GetQuestionReplyByCodeCond = new ShareGetQuestionReplyByCodeConditions();
                GetQuestionReplyByCodeCond.Code = CA.ToString();
                var rsQRBP = (oGetQuestionReplyByCode.GetData(GetQuestionReplyByCodeCond).Data as List<ShareGetQuestionReplyByCodeRow>).FirstOrDefault();

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



        public void btnSet_Click(object sender, EventArgs e)
        {
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Response.Redirect("MessageList.aspx");

        }

        public void SetDefaultMessage(object sender, EventArgs e)
        {
            try
            {
                RadButton button = sender as RadButton;
                txtContent.Text = button.CommandArgument;
                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

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
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void RadioSecond_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioThird.Checked = false;
            txtReturnS.Enabled = false;
            txtReturnS.SelectedIndex = 0;
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);

        }

        protected void RadioThird_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioSecond.Checked = false;
            RadioFourth.Checked = false;
            txtReturnS.Enabled = false;
            txtReturnS.SelectedIndex = 0;
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void RadioFourth_CheckedChanged(object sender, EventArgs e)
        {
            RadioFirst.Checked = false;
            RadioSecond.Checked = false;
            RadioThird.Checked = false;
            txtReturnS.Enabled = true;
           
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
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
                InsertQuestionReplyCond.Key2 = _User.EmpId;
                InsertQuestionReplyCond.Key3 = _User.EmpId;
                InsertQuestionReplyCond.Name = _User.EmpName;
                InsertQuestionReplyCond.Content = txtContent.Text;
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
                        var oUpdateQuestionReplyContent = new ShareUpdateQuestionReplyContentDao();
                        var UpdateQuestionReplyContentCond = new ShareUpdateQuestionReplyContentConditions();
                        UpdateQuestionReplyContentCond.AccessToken = _User.AccessToken;
                        UpdateQuestionReplyContentCond.RefreshToken = _User.RefreshToken;
                        UpdateQuestionReplyContentCond.CompanySetting = CompanySetting;
                        UpdateQuestionReplyContentCond.Code = Draft.Code;
                        UpdateQuestionReplyContentCond.Content = txtContent.Text;
                        oUpdateQuestionReplyContent.GetData(UpdateQuestionReplyContentCond);
                        DraftStatus.InnerText = "";
                    }
                    else
                    {
                        InsertQuestionReplyCond.Send = true;
                        oInsertQuestionReply.GetData(InsertQuestionReplyCond);
                        DraftStatus.InnerText = "";
                    }
                    
                    txtContent.Text = "";
                }

                
                QuestionReplyData.Rebind();

                
                RadioFirst.Checked = true;
                RadioSecond.Checked = false;
                RadioThird.Checked = false;
                RadioFourth.Checked = false;
                DraftStatus.InnerText = "";
            }
        }
    }
}