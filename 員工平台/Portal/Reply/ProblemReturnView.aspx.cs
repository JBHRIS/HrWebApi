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
    public partial class ProblemReturnView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SetUserInfo();
                SetDefault();


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
        private void SetDefault()
        {
            if (Request.QueryString["Code"] != null)
            {
                try
                {
                    var oGetQuestionMain = new ShareGetQuestionMainByCodeDao();
                    var GetQuestionMainCond = new ShareGetQuestionMainByCodeConditions();
                    GetQuestionMainCond.Code = Request.QueryString["Code"];
                    var rsGQM = oGetQuestionMain.GetData(GetQuestionMainCond);
                    var Data = (rsGQM.Data as List<ShareGetQuestionMainByCodeRow>).FirstOrDefault();
                    lblName.Text = Data.InsertMan;
                    lblDate.Text = Data.InsertDate.Value.ToString("yyyy/MM/dd");
                    lblTime.Text = Data.InsertDate.Value.ToString("HH:ss");
                    lblTitle.Text = Data.TitleContent;
                    lblQuestionCategory.Text = Data.QuestionCategoryCode;
                    lblContent.Text = Data.Content;

                }
                catch (Exception ex)
                {

                }



            }



        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {

            try
            {


                var oGetQuestionReply = new ShareGetQuestionReplyByQuestionMainCodeDao();
                var GetQuestionReplyCond = new ShareGetQuestionReplyByQuestionMainCodeConditions();
                GetQuestionReplyCond.AccessToken = _User.AccessToken;
                GetQuestionReplyCond.RefreshToken = _User.RefreshToken;
                GetQuestionReplyCond.CompanySetting = CompanySetting;
                GetQuestionReplyCond.Code = Request.QueryString["Code"];
                var rsGQR = oGetQuestionReply.GetData(GetQuestionReplyCond);
                var rsQM = rsGQR.Data as List<ShareGetQuestionReplyByQuestionMainCodeRow>;
                var ViewrsQM = rsQM.Where(data => data.ParentCode == Request.QueryString["Code"]);
                if (rsQM.Count != 0)
                {
                    Useful.Style.Remove("display");
                }
                var rsViewrsQM = new List<ShareGetQuestionReplyByQuestionMainCodeRow>();
                foreach (var select in rsQM)
                {

                    if (Security.GetRoleKeyToBinaryKey(select.RoleKey).Contains(_User.RoleKey))
                    {
                        rsViewrsQM.Add(select);
                    }


                }
                var dataview = rsViewrsQM.GroupBy(x => x.ParentCode);



                foreach (var Data in ViewrsQM)
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
                           "<button type = \"button\" class=\"btn btn-link fa comment_icon text-blue\" data-toggle=\"collapse\" data-target=\"#rep"+DataDetail.ParentCode+"\">回覆</button>" +
                           "<span class=\"text-muted\">" + DataDetail.InsertDate.Value.ToString("yyyy-MM-dd") + " </span>" +
                           "<span class=\"text-muted\">" + DataDetail.InsertDate.Value.ToString("HH: ss") + "</span><br>" +
                           "</div><br>";
                          
                           





                            }
                        }
                    }
                }




                QuestionReplyData.DataSource = ViewrsQM;

            }
            catch (Exception ex)
            {

            }
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
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
                QuestionReplyData.Rebind();
                txtContent.Text = "";
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
                string content="";
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
    }
}