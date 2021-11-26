using Dal.Dao.Files;
using Bll.Files.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Bll.Share.Vdb;
using Dal.Dao.Share;
using System.IO;

namespace Portal
{
    /// <summary>
    /// Download 的摘要描述
    /// </summary>
    public class DownloadTEST : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!xDownload(@"C:\JBHR\Portal\Data\Sample.xlsx", "Sample.xlsx"))
            {
                
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}