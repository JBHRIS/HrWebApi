using Dal;
using Bll.Files.Vdb;
using Dal.Dao.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Bll.Share.Vdb;
using Dal.Dao.Share;

namespace Portal.UserControls
{
    public partial class UC_FileManage : WebPageUserControl
    {
        List<UploadMultipleRow> result = new List<UploadMultipleRow>();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private CompanySettingRow CompanySetting;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["DataList" + _lblKey.Text] != null)
            {
                result = UnobtrusiveSession.Session["DataList" + _lblKey.Text] as List<UploadMultipleRow>;
            }
            else
                result = new List<UploadMultipleRow>();
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["Files"] = null;
                if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
                {
                    var CompanyId = Request.Cookies["CompanyId"].Value;
                    var oShareCompany = new ShareCompanyDao();
                    var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);
                    if (CompanySetting != null)
                    {
                        this.CompanySetting = CompanySetting;
                        dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
                    }
                }
            }
            UnobtrusiveSession.Session["AccessToken"] = _User.AccessToken;
            UnobtrusiveSession.Session["RefeshToken"] = _User.RefreshToken;

            //var s = "";

            //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnUpload);

        }
        protected class FileData
        { 
            public string EmpId { get; set; }
            public string Code { get; set; }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["Files"] != null)
            {

                var Files = (HttpFileCollection)UnobtrusiveSession.Session["Files"];

                string dirFullPath = HttpContext.Current.Server.MapPath("~/Upload/");
                //string[] files;
                //int numFiles;
                //files = Directory.GetFiles(dirFullPath);
                //numFiles = files.Length;
                //numFiles = numFiles + 1;

                //string str_image = "";

                //foreach (string s in Files)
                //{
                //    HttpPostedFile file = Files[s];
                //    string fileName = file.FileName;
                //    string fileExtension = file.ContentType;

                //    if (!string.IsNullOrEmpty(fileName))
                //    {
                //        fileExtension = Path.GetExtension(fileName);
                //        str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                //        string pathToSave = HttpContext.Current.Server.MapPath("~/Upload/") + str_image;
                //        file.SaveAs(pathToSave);
                //    }
                //}

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
                                if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
                                    resultData.CompanyId = Request.Cookies["CompanyId"].Value;
                                resultData.AccessToken = _User.AccessToken;
                                result.Add(resultData);
                            }
                            UnobtrusiveSession.Session["DataList" + _lblKey.Text] = result;
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

                    lvMain.Rebind();
                }
                UnobtrusiveSession.Session["Files"] = null;

                var Script = "Sys.Application.add_load(DropzoneInit);";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "DropzoneInit", Script, true);

                //var Script = "$('#dZUpload').dropzone({this.removeAllFiles();}";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel),Guid.NewGuid().ToString(), Script, true);
            }
            else 
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "上傳失敗";
            }
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
           
            if (UnobtrusiveSession.Session["DataList" + _lblKey.Text] != null)
            {
                result = UnobtrusiveSession.Session["DataList" + _lblKey.Text] as List<UploadMultipleRow>;
            }
            else
                 result = new List<UploadMultipleRow>();
            lvMain.DataSource = result;
            
        }

        [Bindable(true)]
        public RadLabel _lblKey
        {
            get
            {
                return lblKey;
            }
            set
            {
                lblKey = value;
            }
        }
        
        [Bindable(true)]
        public RadListView _lvMain
        {
            get
            {
                return lvMain;
            }
            set
            {
                lvMain = value;
            }
        }

        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var cn = e.CommandName;
            var ca = e.CommandArgument;
            if (cn == "Download")
            {
            }
            if(cn=="Delete")
            {
                var oDeleteFile = new DeleteFilesDao();
                var DeleteFileCond = new DeleteFilesConditions();
                DeleteFileCond.AccessToken = _User.AccessToken;
                DeleteFileCond.RefreshToken = _User.RefreshToken;
                DeleteFileCond.CompanySetting = CompanySetting;
                DeleteFileCond.fileGuid = ca.ToString();
                var Result = oDeleteFile.GetData(DeleteFileCond);
                if (Result.Status)
                {
                    
                    RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                    result.RemoveAt(item.DataItemIndex);
                    UnobtrusiveSession.Session["DataList" + _lblKey.Text] = result;
                    lblMsg.CssClass = "badge badge-primary animated shake";
                    lblMsg.Text = "刪除成功";
                    lvMain.Rebind();
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "刪除失敗";
                }
            }
        }

        protected void lvMain_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
        }

    }
}