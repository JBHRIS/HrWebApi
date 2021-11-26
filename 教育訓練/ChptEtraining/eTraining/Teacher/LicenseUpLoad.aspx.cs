using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Teacher_LicenseUpLoad : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
        {
            throw new ApplicationException("未傳入正確值，請確認");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (IsRefresh)
        {
            gvLicenseFile.Rebind();
            return;
        }


        for ( int i = 0 ; i < ul.UploadedFiles.Count ;i++ )
        {
            UPLOAD obj = new UPLOAD();

            Guid guid = Guid.NewGuid();
                        
            obj.FileCategory = Enum.GetName(typeof(EnumUploadCategories) , EnumUploadCategories.TeacherLicense);
            obj.FileStoredPath = SiteHelper.UPLOAD_PATH + obj.FileCategory + @"\";
            obj.FileNote = tbNote.Text;
            obj.FileCategoryKey = Request.QueryString["ID"];
            obj.FileKeyDate = DateTime.Now;
            obj.FileKeyMan = User.Identity.Name;
            obj.FileNameExt = ul.UploadedFiles[i].GetExtension();
            obj.FileOriginName = ul.UploadedFiles[i].FileName;
            obj.FileSize = ul.UploadedFiles[i].ContentLength;
            obj.FileStoredName = guid.ToString();

            if ( !Directory.Exists(Server.MapPath(obj.FileStoredPath)) )
            {
                Directory.CreateDirectory(Server.MapPath(obj.FileStoredPath));
            }

            ul.UploadedFiles[i].SaveAs(Server.MapPath(obj.FileStoredPath) + guid.ToString());

            if ( File.Exists(Server.MapPath(obj.FileStoredPath) + guid.ToString()) )
            {
                dcTraining.UPLOAD.InsertOnSubmit(obj);
                dcTraining.SubmitChanges();                
            }
        }
        gvLicenseFile.Rebind();
        AlertMsg("上傳完成");
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }
    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {        
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            
            var obj = (from c in dcTraining.UPLOAD
                       where c.iAutoKey == Convert.ToInt32(item.GetDataKeyValue("iAutoKey").ToString())
                       select c).FirstOrDefault();
            if (obj != null)
            {
                SiteHelper siteHelper = new SiteHelper();
                siteHelper.DeleteFile(obj);
                gvLicenseFile.Rebind();
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (ViewState["URL"] != null)
        {
            Response.Redirect(ViewState["URL"].ToString());
        }
    }
}