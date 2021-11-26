using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
public partial class eTraining_Teacher_UploadCourse : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !IsPostBack )
        {

            DoHelper doHelper = new DoHelper();
            doHelper.setCbYear(cbxYear);

            ul.Enabled = false;
            btnUpload.Enabled = false;
            tbFileNote.Enabled = false;
        }
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

        if (gvCourseList.SelectedValue == null)
        {
            AlertMsg("請先選擇課程");
            return;
        }


        

        for (int i = 0; i < ul.UploadedFiles.Count; i++)
        {
            UPLOAD obj = new UPLOAD();

            Guid guid = Guid.NewGuid();
            obj.FileCategory = "TeachingMaterial";
            obj.FileStoredPath = @"~\UPLOAD\" + obj.FileCategory + @"\";

            obj.FileNote = tbFileNote.Text;
            obj.FileCategoryKey = gvCourseList.SelectedValue.ToString();
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
                gvTeachingMaterial.Rebind();
                AlertMsg("上傳完成");
            }

        //if (IsRefresh)
        //{
        //    gvTeachingMaterial.Rebind();
        //    return;
        //}

        //if ( gvCourseList.SelectedValue == null )
        //{
        //    Show("請先選擇課程");
        //    return;
        //}

        //for (int i = 0; i < ul.UploadedFiles.Count;i++ )
        //{
        //    UPLOAD obj = new UPLOAD();

        //    Guid guid = Guid.NewGuid();
        //    obj.FileCategory = "TeachingMaterial";
        //    obj.FileStoredPath = @"~\UPLOAD\" + obj.FileCategory + @"\";

        //    obj.FileNote = tbFileNote.Text;
        //    obj.FileCategoryKey = gvCourseList.SelectedValue.ToString();
        //    obj.FileKeyDate = DateTime.Now;
        //    obj.FileKeyMan = User.Identity.Name;
        //    obj.FileNameExt = ul.UploadedFiles[i].GetExtension();
        //    obj.FileOriginName = ul.UploadedFiles[i].FileName;
        //    obj.FileSize = ul.UploadedFiles[i].ContentLength;
        //    obj.FileStoredName = guid.ToString();

        //    if (!Directory.Exists(Server.MapPath(obj.FileStoredPath)))
        //    {
        //        Directory.CreateDirectory(Server.MapPath(obj.FileStoredPath));
        //    }

        //    ul.UploadedFiles[i].SaveAs(Server.MapPath(obj.FileStoredPath) + guid.ToString());

        //    if (File.Exists(Server.MapPath(obj.FileStoredPath) + guid.ToString()))
        //    {
        //        dcTraining.UPLOAD.InsertOnSubmit(obj);
        //        dcTraining.SubmitChanges();
        //        gvTeachingMaterial.Rebind();
        //        Show("上傳完成");
        //    }
        }
    }
    protected void gvCourseList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        ul.Enabled = false;
        btnUpload.Enabled = false;
        tbFileNote.Enabled = false;
        GridColumn colDelete = gvTeachingMaterial.Columns.FindByUniqueName("Delete");
        colDelete.Visible = false;

        DoHelper doHelper = new DoHelper();

        if ( gvCourseList.SelectedItems.Count != 0 )
        {
            GridDataItem item = gvCourseList.SelectedItems[0] as GridDataItem;
            DateTime dDateTimeA;
            if ( DateTime.TryParse(item["dDateA"].Text , out dDateTimeA) )
            {
                //如果開課日期已超過現在時間，不允許新增或刪除
                dDateTimeA = dDateTimeA.AddDays(1);
                dDateTimeA = new DateTime(dDateTimeA.Year, dDateTimeA.Month, dDateTimeA.Day);
                if ( dDateTimeA.CompareTo(DateTime.Now) < 0 )
                {
                    lblMsg.Text = "已超過開課時間";
                    return;
                }
            }
        }


        if (doHelper.IsClassTeacher(Convert.ToInt32(gvCourseList.SelectedValue), User.Identity.Name))
        {
            ul.Enabled = true;
            btnUpload.Enabled = true;
            tbFileNote.Enabled = true;
            colDelete.Visible = true;
        }
        else
        {
            lblMsg.Text = "課程講師非本人，不允許上傳檔案";

        }
    }
    protected void sdsMyClassGv_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = User.Identity.Name;
    }
    protected void cbMyClass_CheckedChanged(object sender, EventArgs e)
    {
        if (cbMyClass.Checked)        
            gvCourseList.DataSourceID = "sdsMyClassGv";                   
        else
            gvCourseList.DataSourceID = "sdsClassGv";

        gvCourseList.Rebind();
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