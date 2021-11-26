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
    public partial class UC_FileView : WebPageUserControl
    {
        static List<UploadMultipleRow> result = new List<UploadMultipleRow>();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private CompanySettingRow CompanySetting;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["Files"] = null;
                UnobtrusiveSession.Session["FileTicket"] = null;
                if (Request.Cookies["CompanyId"] != null)
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

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {

            var FileTicket = UnobtrusiveSession.Session["FileTicket"] as string;
            var result = new List<FilesByFileTicketRow>();
            var oFilesByFileTicket = new FilesByFileTicketDao();
            var FilesByFileTicketCond = new FilesByFileTicketConditions();
            FilesByFileTicketCond.AccessToken = _User.AccessToken;
            FilesByFileTicketCond.RefreshToken = _User.RefreshToken;
            FilesByFileTicketCond.CompanySetting = CompanySetting;
            FilesByFileTicketCond.fileTicket = FileTicket;
            var Result = oFilesByFileTicket.GetData(FilesByFileTicketCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    result = Result.Data as List<FilesByFileTicketRow>;
                }
            }
            //switch (FormCode)
            //{
            //    case "Abs":
            //        var  = (from c in dcFlow.FormsAppAbs
            //                            join d in dcFlow.wfFormUploadFile on c.Code equals d.sKey
            //                            where c.AutoKey.ToString() == AutoKey
            //                            select d).ToList();
            //        foreach (var )
            //        {
            //            var UploadData = new FilesByFileTicketRow();
            //            UploadData.FileSize = FileData.iSize.ToString();
            //            UploadData.FileName = FileData.sUpName;
            //            UploadData.FileId = FileData.sKey2;
            //            result.Add(UploadData);
            //        }
            //        break;
            //    case "Ot":
            //        FileDataList = (from c in dcFlow.FormsAppOt
            //                            join d in dcFlow.wfFormUploadFile on c.Code equals d.sKey
            //                            where c.AutoKey.ToString() == AutoKey
            //                            select d).ToList();
            //        foreach (var FileData in FileDataList)
            //        {
            //            var UploadData = new FilesByFileTicketRow();
            //            UploadData.FileSize = FileData.iSize.ToString();
            //            UploadData.FileName = FileData.sUpName;
            //            UploadData.FileId = FileData.sKey2;
            //            result.Add(UploadData);
            //        }
            //        break;
            //    case "Abs1":
            //        FileDataList = (from c in dcFlow.FormsAppAbs
            //                        join d in dcFlow.wfFormUploadFile on c.Code equals d.sKey
            //                        where c.AutoKey.ToString() == AutoKey
            //                        select d).ToList();
            //        foreach (var FileData in FileDataList)
            //        {
            //            var UploadData = new FilesByFileTicketRow();
            //            UploadData.FileSize = FileData.iSize.ToString();
            //            UploadData.FileName = FileData.sUpName;
            //            UploadData.FileId = FileData.sKey2;
            //            result.Add(UploadData);
            //        }
            //        break;
            //}



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
            if (cn == "Delete")
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
                    var DeleteFile = (from d in dcFlow.wfFormUploadFile
                                      where d.sKey2 == ca.ToString()
                                      select d).FirstOrDefault();
                    dcFlow.wfFormUploadFile.DeleteOnSubmit(DeleteFile);
                    dcFlow.SubmitChanges();
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