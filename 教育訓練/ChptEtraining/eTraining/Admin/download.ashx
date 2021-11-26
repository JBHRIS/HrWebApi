<%@ WebHandler Language="C#" Class="download" %>

using System;
using System.Web;
using System.Linq;
using System.IO;

public class download : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    
    public void ProcessRequest (HttpContext context) {

        try
        {
            if (context.User.Identity.IsAuthenticated == false)
            {
                throw new ApplicationException("請先登入系統，才可下載");
            }

            if (context.Request["ID"] == null)
            {
                throw new ApplicationException("無檔案目標");
            }
        }
        catch(Exception ex)
        {
            context.Session["errorMsg"] = ex.Message;
            context.Response.Redirect("~/error.aspx");
        }
        
        var data = (from c in dcTraining.UPLOAD
                    where c.FileStoredName == context.Request["ID"].ToString()
                    select c).FirstOrDefault();

        if (data == null)
        {
            context.Response.Write("<h1>No File Found!</h1>");
            context.Response.End(); 
        }
        else
        {
            string fileStoredPath = data.FileStoredPath + data.FileStoredName;
            if (File.Exists(context.Server.MapPath(fileStoredPath)))
            {
                context.Response.ContentType = "application/octet-stream";                
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + context.Server.UrlPathEncode(data.FileOriginName));
                string fullpath = context.Server.MapPath(fileStoredPath);

                context.Response.WriteFile(fullpath);
                context.Response.End();

            }
            else
            {
                string msg = "User："+ context.User.Identity.Name + " get "+context.Request["ID"].ToString() + " error";
                logger.Error(msg);
                context.Response.Write("<h1>No File Found!</h1>");
                context.Response.End(); 
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}