using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Telerik.Web.UI.Upload;
using Telerik.Web.UI;

public partial class WebTemplet_UpFile:System.Web.UI.Page
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }


    private void DeleteFiles()
    {
        string targetFolder = Server.MapPath(RadUpload1.TargetFolder);

        DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

        foreach ( FileInfo file in targetDir.GetFiles() )
        {
            if ( (file.Attributes & FileAttributes.ReadOnly) == 0 )
                file.Delete();
        }
    }

    private void RadUpload1_FileExists(object sender , UploadedFileEventArgs e)
    {
        int counter = 1;

        UploadedFile file = e.UploadedFile;

        string targetFolder = Server.MapPath(RadUpload1.TargetFolder);

        string targetFileName = Path.Combine(targetFolder ,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while ( System.IO.File.Exists(targetFileName) )
        {
            counter++;
            targetFileName = Path.Combine(targetFolder ,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
    }
    protected void Button1_Click(object sender , EventArgs e)
    {
        if ( RadUpload1.UploadedFiles.Count > 0 )
        {
            repeaterResults.DataSource = RadUpload1.UploadedFiles;
            repeaterResults.DataBind();
            labelNoResults.Visible = false;
            repeaterResults.Visible = true;
        }
        else
        {
            labelNoResults.Visible = true;
            repeaterResults.Visible = false;
        }
    }
}
