using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
public partial class eTraining_Admin_Do_TeachingMaterial : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            lblClassId.Text = Request.QueryString["ID"].ToString();
        }
        else
            throw new ApplicationException("無輸入課程ID");
    }

    protected void gvCourseList_ItemDataBound(object sender , GridItemEventArgs e)
    {

    }
    protected void btnUpload_Click(object sender , EventArgs e)
    {
        if (IsRefresh)
        {
            gvTeachingMaterial.Rebind();
            return;
        }
        

        for (int i = 0; i < ul.UploadedFiles.Count; i++)
        {
            UPLOAD obj = new UPLOAD();

            Guid guid = Guid.NewGuid();
            obj.FileCategory = "TeachingMaterial";
            obj.FileStoredPath = @"~\UPLOAD\" + obj.FileCategory + @"\";

            obj.FileNote = tbFileNote.Text;
            obj.FileCategoryKey = lblClassId.Text;
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
                dcTraining.SubmitChanges();
            }
        }
        gvTeachingMaterial.Rebind();
        AlertMsg("上傳完成");
    }
 

    protected void gvTeachingMaterial_ItemCommand(object sender , GridCommandEventArgs e)
    {
        if ( e.Item is GridDataItem )
        {
            string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
            GridDataItem itm = e.Item as GridDataItem;
            if ( itm == null )
                return;

            if ( e.CommandName.Equals("MyDel") )
            {
                var file = (from c in dcTraining.UPLOAD
                            where c.iAutoKey == Convert.ToInt32(itm["iAutoKey"].Text)
                            select c).FirstOrDefault();

                if ( file != null )
                {
                    SiteHelper siteHelper = new SiteHelper();
                    siteHelper.DeleteFile(file);
                }

                AlertMsg("已刪除");
                gvTeachingMaterial.Rebind();

            }
        }
    }
}