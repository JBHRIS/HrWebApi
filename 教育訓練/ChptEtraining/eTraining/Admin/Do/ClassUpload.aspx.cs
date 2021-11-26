using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;
public partial class eTraining_Admin_Do_ClassUpload:JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender , EventArgs e)
    {
        if (IsRefresh)
        {
            gv.Rebind();
            return;
        }

        string key = "";
        if (Request.QueryString["ID"] != null)
        {
            key = Request.QueryString["ID"].ToString();
        }

        for (int i = 0; i < ul.UploadedFiles.Count;i++ )
        {
            UPLOAD obj = new UPLOAD();

            Guid guid = Guid.NewGuid();
            obj.FileCategory = "Class";
            obj.FileStoredPath = @"~\UPLOAD\" + obj.FileCategory + @"\";

            obj.FileNote = tbNote.Text;
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
                dcTraining.SubmitChanges();
                gv.Rebind();
                AlertMsg("上傳完成");
            }
        }
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = e.Item as GridDataItem;

            if (itm["Download"].Controls[0] is HyperLink)
            {
               HyperLink hl = itm["Download"].Controls[0] as HyperLink;
               //hl.NavigateUrl = "~/eTraining/Admin/download.ashx?ID=" + itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["iAutoKey"].ToString();
               hl.NavigateUrl = "~/eTraining/Admin/download.ashx?ID=" + itm["FileStoredName"].Text;
            }
        }
    }
    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem itm = null;
        if (e.Item is GridDataItem)
        {
            itm = e.Item as GridDataItem;
        }

            var file = (from c in dcTraining.UPLOAD
                        where c.iAutoKey == Convert.ToInt32(itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["iAutoKey"].ToString())
                        select c).FirstOrDefault();

            if (file != null)
            {
                SiteHelper siteHelper = new SiteHelper();
                siteHelper.DeleteFile(file);
            }

            AlertMsg("已刪除");
            gv.Rebind();

            //siteHelper.DeleteFile
    }
}