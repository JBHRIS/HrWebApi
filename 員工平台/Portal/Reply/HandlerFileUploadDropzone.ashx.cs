using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Portal
{
    /// <summary>
    /// HandlerFileUploadDropzone 的摘要描述
    /// </summary>
    public class HandlerFileUploadDropzone : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //foreach (string s in context.Request.Files)
            //{
            //    HttpPostedFile file = context.Request.Files[s];
            //    string fileName = file.FileName;
            //    string fileExtension = file.ContentType;
               
            //}

            UnobtrusiveSession.Session["Files"] = context.Request.Files;

        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}