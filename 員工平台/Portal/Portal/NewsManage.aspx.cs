using Bll.News.Vdb;
using Dal.Dao.News;
using Bll.Files.Vdb;
using Dal.Dao.Files;
using Bll.Tools;
using Dal.Dao.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design;
using Telerik.Web.UI;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Portal
{
    public partial class NewsManage : WebPageBase
    {
        public static bool IsNew = true;
        //public static string FileTicket = Guid.NewGuid().ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["AutoKey"] == null || Request.QueryString["AutoKey"] == "0")
                {
                    IsNew = true;
                    var r = new NewsByIdRow();
                    txtIdNo.Text = Guid.NewGuid().ToString();
                    txtNewsPostDate.SelectedDate = r.PostDate;
                    txtNewsDeadLine.SelectedDate = r.DeadLine;
                    txtNewsTitle.Text = r.ContentTitle;
                    txtNewsContent.Content = r.Content;
                    cbIsOn.Checked = r.IsOn;
                    UnobtrusiveSession.Session["DataList"] = null;
                }
                else
                {
                    IsNew = false;
                    var rs = new NewsByIdRow();
                    var NewsId = Request.QueryString["AutoKey"];
                    var oNewsById = new NewsByIdDao();
                    var NewsByIdCond = new NewsByIdConditions();
                    NewsByIdCond.AccessToken = _User.AccessToken;
                    NewsByIdCond.RefreshToken = _User.RefreshToken;
                    NewsByIdCond.CompanySetting = CompanySetting;
                    NewsByIdCond.id = NewsId;
                    var Result = oNewsById.GetData(NewsByIdCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            rs = Result.Data as NewsByIdRow;
                        }
                    }
                    txtIdNo.Text = rs.ContentId;
                    txtNewsPostDate.SelectedDate = rs.PostDate;
                    txtNewsDeadLine.SelectedDate = rs.DeadLine;
                    txtNewsTitle.Text = rs.ContentTitle;
                    txtNewsContent.Content = rs.Content;
                    cbIsOn.Checked = rs.IsOn;
                    //FileTicket = rs.FileTicket;
                    var oFilesByFileTicket = new FilesByFileTicketDao();
                    var FilesByFileTicketCond = new FilesByFileTicketConditions();
                    FilesByFileTicketCond.AccessToken = _User.AccessToken;
                    FilesByFileTicketCond.RefreshToken = _User.RefreshToken;
                    FilesByFileTicketCond.CompanySetting = CompanySetting;
                    FilesByFileTicketCond.fileTicket = txtIdNo.Text;
                    var FileTicketResult = oFilesByFileTicket.GetData(FilesByFileTicketCond);

                    if (FileTicketResult.Status)
                    {
                        if (FileTicketResult.Data != null)
                        {
                            UnobtrusiveSession.Session["DataList"] = FileTicketResult.Data as List<FilesByFileTicketRow>;
                        }
                    }
                }
            }
        }

        public void LoadData(string Key = "")
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIdNo.Text == "" || txtNewsTitle.Text == "" || txtNewsContent.Content == "")
            {
                lblMsg.CssClass = "label label-danger animated shake";
                lblMsg.Text = "請確認輸入是否正確";
                return;
            }
            var AutoKey = 0;
            if (Request.QueryString["AutoKey"] != null)
                AutoKey = Convert.ToInt32(Request.QueryString["AutoKey"]);

            if (IsNew)
            {
                var oInsertNews = new InsertNewsDao();
                var InsertNewsCond = new InsertNewsConditions();
                InsertNewsCond.AccessToken = _User.AccessToken;
                InsertNewsCond.RefreshToken = _User.RefreshToken;
                InsertNewsCond.CompanySetting = CompanySetting;
                InsertNewsCond.iAutoKey = AutoKey;
                InsertNewsCond.newsId = txtIdNo.Text;
                InsertNewsCond.newsHead = txtNewsTitle.Text;
                InsertNewsCond.newsBody = txtNewsContent.Content;
                InsertNewsCond.postDate = txtNewsPostDate.SelectedDate.GetValueOrDefault();
                InsertNewsCond.postDeadline = txtNewsDeadLine.SelectedDate.GetValueOrDefault();
                InsertNewsCond.isOn = (bool)cbIsOn.Checked;
                InsertNewsCond.newsfileid = "";
                InsertNewsCond.sort = 0;
                var Result = oInsertNews.GetData(InsertNewsCond);
                if (Result.Status)
                {
                    lblMsg.CssClass = "label-primary animated shake";
                    lblMsg.Text = "已成功新增";
                }
                else
                {
                    lblMsg.CssClass = "label-danger animated shake";
                    lblMsg.Text = "新增失敗，請確認輸入是否正確";
                }
            }
            else
            {
                var oUpdateNews = new UpdateNewsDao();
                var UpdateNewsCond = new UpdateNewsConditions();
                UpdateNewsCond.AccessToken = _User.AccessToken;
                UpdateNewsCond.RefreshToken = _User.RefreshToken;
                UpdateNewsCond.CompanySetting = CompanySetting;
                UpdateNewsCond.iAutoKey = AutoKey;
                UpdateNewsCond.newsId = txtIdNo.Text;
                UpdateNewsCond.newsHead = txtNewsTitle.Text;
                UpdateNewsCond.newsBody = txtNewsContent.Content;
                UpdateNewsCond.postDate = txtNewsPostDate.SelectedDate.GetValueOrDefault();
                UpdateNewsCond.postDeadline = txtNewsDeadLine.SelectedDate.GetValueOrDefault();
                UpdateNewsCond.isOn = (bool)cbIsOn.Checked;
                UpdateNewsCond.newsfileid = txtIdNo.Text;
                UpdateNewsCond.sort = 0;
                var Result = oUpdateNews.GetData(UpdateNewsCond);
                if (Result.Status)
                {
                    lblMsg.CssClass = "label-primary animated shake";
                    lblMsg.Text = "已成功更新";
                }
                else
                {
                    lblMsg.CssClass = "label-danger animated shake";
                    lblMsg.Text = "更新失敗，請確認輸入是否正確";
                }
            }    
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //var oUploadSingleFile = new UploadSingleFileDao();
            //var UploadSingleFileCond = new UploadSingleFileConditions();
            //UploadSingleFileCond.AccessToken = _User.AccessToken;
            //UploadSingleFileCond.RefreshToken = _User.RefreshToken;
            //UploadSingleFileCond.file = new MultipartFormDataContent();
            //using (var content = new MultipartFormDataContent())
            //{
            //    Stream fileStream = File.OpenRead(@"images.png");
            //    StreamContent streamContent = new StreamContent(fileStream);
            //    streamContent.Headers.Add("Content-Type", MimeMapping.GetMimeMapping(@"images.png"));

            //    content.Add(streamContent, "\"file\"", @"images.png");
            //    UploadSingleFileCond.file = content;
            //}
            //var Result = oUploadSingleFile.GetData(UploadSingleFileCond);
            //if(Result.Status)
            //{
            //    if (Result.Data != null)
            //    { 
                    
            //    }
            //}
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UnobtrusiveSession.Session["FormGuidCode"] = txtIdNo.Text;
        }
    }
}