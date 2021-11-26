using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Files;
using Bll.Files.Vdb;
using System.IO;
using System.Data;
using Newtonsoft.Json;

namespace Portal
{
    public partial class ImportAttend : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();

        /// <summary>
        ///用這個結構取代原本檔案上傳用的HttpFileCollection，因為原本的結構會在呼叫完API後被Dispose，無法繼續呼叫下個API
        /// 
        /// </summary>
        public class MemoryPostedFile : HttpPostedFileBase 
        {
            private readonly byte[] fileBytes;

            public MemoryPostedFile(byte[] fileBytes, string fileName = null, string contentType = null)
            {
                this.fileBytes = fileBytes;
                this.FileName = fileName;
                this.InputStream = new MemoryStream(fileBytes);
                this.ContentType = contentType;
            }

            public override string ContentType { get; }
            public override int ContentLength => this.fileBytes.Length;

            public override string FileName { get; }

            public override Stream InputStream { get; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                UnobtrusiveSession.Session["Files"] = null;
                plSubmit.Visible = false;
                plSheet.Visible = false;
            }
            //ddlSheetName_DATABIND();

        }
        public void ddlSheetName_DATABIND()
        {
            lblMsg.Text = "";
            var Files = (HttpFileCollection)UnobtrusiveSession.Session["Files"];
            if (Files != null)
            {
                MemoryStream ms = new MemoryStream();
                Files[0].InputStream.CopyTo(ms);
                Files[0].InputStream.Position = ms.Position = 0;
                byte[] bytes = ms.GetBuffer();
                HttpPostedFileBase objFile = (HttpPostedFileBase)new MemoryPostedFile(bytes, Files[0].FileName, Files[0].ContentType);
                var oExcelSheetName = new ExcelSheetNameCoverDao();
                var ExcelSheetNameCond = new ExcelSheetNameCoverConditions();
                ExcelSheetNameCond.AccessToken = _User.AccessToken;
                ExcelSheetNameCond.RefreshToken = _User.RefreshToken;
                ExcelSheetNameCond.CompanySetting = CompanySetting;
                ExcelSheetNameCond.file = objFile;
                var Result = oExcelSheetName.GetData(ExcelSheetNameCond);

                if (Result.Status)
                {
                    btnRefreshSheetName.Visible = false;
                    plSubmit.Visible = true;
                    plSheet.Visible = true;
                    var Message = Result.Data as ExcelSheetNameCoverRow;
                    ddlSheetName.Items.Clear();
                    foreach (var r in Message.Result)
                    {
                        ddlSheetName.Items.Add(new Telerik.Web.UI.RadComboBoxItem(r));
                    }

                }
                else
                {
                    lblMsg.Text = "刷新失敗 " + Result.Message;
                    lblMsg.CssClass = "badge badge-danger animated shake";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            var Files = (HttpFileCollection)UnobtrusiveSession.Session["Files"];
            if (ddlSheetName.Text == "")
            {
                lblMsg.Text = "請輸入excel的工作表名稱";
                lblMsg.CssClass = "badge badge-danger animated shake";
                return;
            }
            if (Files != null)
            {
                MemoryStream ms = new MemoryStream();
                Files[0].InputStream.CopyTo(ms);
                Files[0].InputStream.Position = ms.Position = 0;
                byte[] bytes = ms.GetBuffer();
                HttpPostedFileBase objFile = (HttpPostedFileBase)new MemoryPostedFile(bytes, Files[0].FileName, Files[0].ContentType);
                var oImportAttend = new ImportAttendExcelCoverDao();
                var ImportAttendCond = new ImportAttendExcelCoverConditions();
                ImportAttendCond.AccessToken = _User.AccessToken;
                ImportAttendCond.RefreshToken = _User.RefreshToken;
                ImportAttendCond.CompanySetting = CompanySetting;
                ImportAttendCond.SheetName = ddlSheetName.Text;
                ImportAttendCond.file = objFile;
                var Result = oImportAttend.GetData(ImportAttendCond);
                if (Result.Status)
                {
                    var Message = Result.Data as ImportAttendExcelCoverRow;

                    lblMsg.Text = "上傳成功";
                    lblMsg.CssClass = "badge badge-primary animated shake";
                }
                else
                {
                    var Message = Result.Data as ImportAttendExcelCoverRow;
                    lblMsg.Text = "上傳失敗 " + Message.Result;
                    lblMsg.CssClass = "badge badge-danger animated shake";
                }

            }
            else
            {
                lblMsg.Text = "請先選擇檔案";
                lblMsg.CssClass = "badge badge-danger animated shake";
            }

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string docupath = Request.PhysicalApplicationPath; //抓取專案所在之路徑
            if (!xDownload(docupath + "Data\\Sample.xlsx", "Sample.xlsx"))
            {
                lblMsg.Text = "檔案下載失敗";
                lblMsg.CssClass = "badge badge-danger animated shake";
            }
        }
        public bool xDownload(string xFile, string out_file)
        //xFile 路徑+檔案, 設定另存的檔名
        {
            if (File.Exists(xFile))
            {
                try
                {
                    FileInfo xpath_file = new FileInfo(xFile);  //要 using System.IO;
                                                                // 將傳入的檔名以 FileInfo 來進行解析（只以字串無法做）
                    System.Web.HttpContext.Current.Response.Clear(); //清除buffer
                    System.Web.HttpContext.Current.Response.ClearHeaders(); //清除 buffer 表頭
                    System.Web.HttpContext.Current.Response.Buffer = false;
                    System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                    // 檔案類型還有下列幾種"application/pdf"、"application/vnd.ms-excel"、"text/xml"、"text/HTML"、"image/JPEG"、"image/GIF"
                    System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(out_file, System.Text.Encoding.UTF8));
                    // 考慮 utf-8 檔名問題，以 out_file 設定另存的檔名
                    System.Web.HttpContext.Current.Response.AppendHeader("Content-Length", xpath_file.Length.ToString()); //表頭加入檔案大小
                    System.Web.HttpContext.Current.Response.WriteFile(xpath_file.FullName);

                    // 將檔案輸出
                    System.Web.HttpContext.Current.Response.Flush();
                    // 強制 Flush buffer 內容
                    System.Web.HttpContext.Current.Response.End();
                    return true;

                }
                catch (Exception)
                { return false; }

            }
            else
                return false;
        } // EOS xDownload(string xFile, string out_file)

        protected void btnRefreshSheetName_Click(object sender, EventArgs e)
        {
            ddlSheetName_DATABIND();
        }

    }
}