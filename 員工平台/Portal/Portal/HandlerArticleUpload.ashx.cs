using System;
using System.Web;
using Telerik.Web.UI;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.IO;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using System.Collections.Generic;
using Dal;
using System.Web.UI;

namespace Sample.ImageButton
{
    /// <summary>
    /// HandlerFileUpload 的摘要描述
    /// </summary>
    public class HandlerArticleUpload : AsyncUploadHandler, System.Web.SessionState.IRequiresSessionState
    {
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected override IAsyncUploadResult Process(UploadedFile file, HttpContext context, IAsyncUploadConfiguration configuration, string tempFileName)
        {
            //return base.Process(file, context, configuration, tempFileName);
            // Call the base Process method to save the file to the temporary folder
            // base.Process(file, context, configuration, tempFileName);

            // Populate the default (base) result into an object of type SampleAsyncUploadResult
            var result = CreateDefaultUploadResult<ShareUploadAsyncUploadResult>(file);

            int userID = -1;
            // You can obtain any custom information passed from the page via casting the configuration parameter to your custom class
            var sampleConfiguration = configuration as ShareUploadAsyncUploadConfiguration;
            if (sampleConfiguration != null)
            {
                userID = sampleConfiguration.UserID;
            }

            // Populate any additional fields into the upload result.
            // The upload result is available both on the client and on the server
            result.ImageID = InsertImage(file, userID, context);

            return result;
        }

        public int InsertImage(UploadedFile file, int userID, HttpContext context)
        {
            if (HttpContext.Current.Request.QueryString["sFormCode"] == null || HttpContext.Current.Request.QueryString["sProcessID"] == null || HttpContext.Current.Request.QueryString["sNobr"] == null || HttpContext.Current.Request.QueryString["sGuid"] == null)
                return 0;

            var sFormCode = HttpContext.Current.Request.QueryString["sFormCode"];
            var sProcessID = HttpContext.Current.Request.QueryString["sProcessID"];
            var sNobr = HttpContext.Current.Request.QueryString["sNobr"];
            var sGuid = HttpContext.Current.Request.QueryString["sGuid"];
            //var file = fu.UploadedFiles[0];
            var Size = Convert.ToInt32(file.ContentLength);
            //byte[] bytes = GetImageBytes(file.InputStream);
            //byte[] bytes = new byte[Size];
            //file.InputStream.Read(bytes, 0, Size);
            //var Obj = bytes;
            var ObjectName = file.GetName();
            var Type = file.ContentType;

            var Code = Guid.NewGuid().ToString();
            string ServerName = Guid.NewGuid().ToString();

            var rf = new wfFormUploadFile();
            rf.sFormCode = sFormCode;
            rf.sFormName = "";
            rf.sProcessID = sProcessID;
            rf.idProcess = 0;
            rf.sNobr = sNobr;
            rf.sKey = sGuid;
            rf.sUpName = ObjectName;
            rf.sServerName = ServerName;
            rf.sDescription = "";
            rf.sType = file.ContentType == null ? "" : file.ContentType;
            rf.iSize = Convert.ToInt32(file.ContentLength / 1024);
            rf.dKeyDate = DateTime.Now;
            dcFlow.wfFormUploadFile.InsertOnSubmit(rf);
            dcFlow.SubmitChanges();
            string path = context.Server.MapPath("~/Upload/");
            file.SaveAs(path + ServerName, true);
            //var oShareUpload = new ShareUploadDao();
            //var oShareUploadInsert = new ShareUploadInsertRow();
            //oShareUploadInsert.ListShareUpload = new List<ShareUploadRow>();
            //var rShareUpload = new ShareUploadRow();
            //rShareUpload.Code = Code;
            //rShareUpload.Key1 = ArticleCode;
            //rShareUpload.Key2 = "Article";
            //rShareUpload.Key3 = "Image";
            //rShareUpload.UploadName = ObjectName;
            //rShareUpload.ServerName = Code;
            //rShareUpload.Blob = Obj;
            //rShareUpload.Type = Type;
            //rShareUpload.Size = Size;
            //rShareUpload.Sort = Sort;
            //oShareUploadInsert.IpAddress = "";
            //oShareUploadInsert.AppName = HttpContext.Current.Request.Url.ToString();
            //oShareUploadInsert.InsertMan = "";
            //oShareUploadInsert.ListShareUpload.Add(rShareUpload);
            //var Vdb = oShareUpload.ShareUploadInsert(oShareUploadInsert);

            return 1;
        }

        public byte[] GetImageBytes(Stream stream)
        {
            byte[] buffer;

            using (Bitmap image = ResizeImage(stream))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);

                    //return the current position in the stream at the beginning
                    ms.Position = 0;

                    buffer = new byte[ms.Length];
                    ms.Read(buffer, 0, (int)ms.Length);
                    return buffer;
                }
            }
        }

        public Bitmap ResizeImage(Stream stream)
        {
            Image originalImage = Bitmap.FromStream(stream);

            int height = 500;
            int width = 500;

            double ratio = Math.Min(originalImage.Width, originalImage.Height) / (double)Math.Max(originalImage.Width, originalImage.Height);

            if (originalImage.Width > originalImage.Height)
            {
                height = Convert.ToInt32(height * ratio);
            }
            else
            {
                width = Convert.ToInt32(width * ratio);
            }

            Bitmap scaledImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);

                return scaledImage;
            }

        }
    }

    public class ShareUploadAsyncUploadResult : AsyncUploadResult
    {
        private int imageID;

        public int ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }
    }

    public class ShareUploadAsyncUploadConfiguration : AsyncUploadConfiguration
    {
        private int userID;
        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }
    }
}