using Dal.Dao.Flow;
using Bll.Flow.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Bll.Share.Vdb;
using Dal.Dao.Share;
using Dal.Dao.Token;
using Bll.Token.Vdb;

namespace Portal
{
    /// <summary>
    /// Download 的摘要描述
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string CompanyId = "";
            if (context.Request.Cookies["CompanyId"] != null)
                CompanyId = context.Request.Cookies["CompanyId"].Value;
            else if (context.Request.Params["CompanyId"] != null)
                CompanyId = context.Request.Params["CompanyId"];
            var oShareCompany = new ShareCompanyDao();
            var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);
            var index = Int32.Parse(context.Request.Params["index"]);
            string AccessToken = "";
            string RefreshToken = "";
            if (UnobtrusiveSession.Session["AccessToken"] != null)
            {
                AccessToken = (string)UnobtrusiveSession.Session["AccessToken"];
            }
            else if(context.Request.Params["AccessToken"] != null)
            {
                AccessToken = context.Request.Params["AccessToken"];
            }
            if (UnobtrusiveSession.Session["RefreshToken"] != null)
            {
                RefreshToken = (string)UnobtrusiveSession.Session["RefreshToken"];
            }
            var oDownloadFile = new DownloadByAutoKeyDao();
            var DownloadFileCond = new DownloadByAutoKeyConditions();
            DownloadFileCond.AccessToken = AccessToken;
            DownloadFileCond.RefreshToken = RefreshToken;
            DownloadFileCond.CompanySetting = CompanySetting;
            DownloadFileCond.AutoKey = index;
            var Result = oDownloadFile.GetData(DownloadFileCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    try
                    {
                        var rs = Result.Data as HttpResponseMessage;
                        context.Response.Clear();
                        context.Response.ClearHeaders();
                        context.Response.Buffer = false;
                        context.Response.HeaderEncoding = System.Text.Encoding.UTF8;
                        context.Response.Charset = "UFT8";
                        context.Response.AppendHeader("Accept-Language", "zh-tw");
                        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(rs.Content.Headers.ContentDisposition.FileNameStar, System.Text.Encoding.UTF8));
                        context.Response.AppendHeader("Content-Length", rs.Content.Headers.ContentLength.ToString());
                        context.Response.ContentType = rs.Content.Headers.ContentType.ToString();
                        context.Response.BinaryWrite(rs.Content.ReadAsByteArrayAsync().Result);
                        context.Response.Flush();
                        context.Response.End();
                    }
                    catch (Exception)
                    { 
                        
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}