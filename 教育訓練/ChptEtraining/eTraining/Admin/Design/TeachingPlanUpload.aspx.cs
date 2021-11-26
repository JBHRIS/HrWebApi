using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;

//using Telerik

public partial class eTraining_Design_TeachingPlan : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        if (ViewState["URL"] != null)
        {
            Response.Redirect(ViewState["URL"].ToString());
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string key = "";
        if (Request.QueryString["ID"] != null)
        {
            key = Request.QueryString["ID"].ToString();
        }

        if (ul.UploadedFiles.Count > 0)
        {
            for (int i = 0; i < ul.UploadedFiles.Count; i++)
            {
                var oldFile = (from c in dcTraining.UPLOAD
                               where c.FileCategory == "TeachingPlan"
                               && c.FileCategoryKey == key
                               select c).FirstOrDefault();
                if (oldFile != null)
                {
                    SiteHelper siteHelper = new SiteHelper();
                    siteHelper.DeleteFile(oldFile);
                }


                UPLOAD obj = new UPLOAD();

                Guid guid = Guid.NewGuid();
                obj.FileCategory = "TeachingPlan";
                obj.FileStoredPath = @"~\UPLOAD\" + obj.FileCategory + @"\";

                obj.FileCategoryKey = key;
                obj.FileKeyDate = DateTime.Now;
                obj.FileKeyMan = User.Identity.Name;
                obj.FileNameExt = ul.UploadedFiles[i].GetExtension();
                obj.FileOriginName = ul.UploadedFiles[i].FileName;
                obj.FileSize = ul.UploadedFiles[i].ContentLength;
                obj.FileStoredName = guid.ToString();

                if (!Directory.Exists(Server.MapPath(obj.FileStoredPath)))
                {
                    Directory.CreateDirectory(Server.MapPath(obj.FileStoredPath));
                }

                ul.UploadedFiles[i].SaveAs(Server.MapPath(obj.FileStoredPath) + guid.ToString());

                if (File.Exists(Server.MapPath(obj.FileStoredPath) + guid.ToString()))
                {
                    dcTraining.UPLOAD.InsertOnSubmit(obj);
                    //寫入檔案名稱到教案主檔
                    var data = (from c in dcTraining.trTeachingMaterial
                                where c.iAutoKey == Convert.ToInt32(key)
                                select c).FirstOrDefault();

                    data.FileStoredName = obj.FileStoredName;

                    dcTraining.SubmitChanges();
                }
                AlertMsg("上傳完成");
            }
        }
        else
        {
            AlertMsg("無檔案可上傳!!");
        }
    }
}