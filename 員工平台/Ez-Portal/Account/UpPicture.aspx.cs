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
using JB.WebModules.Data.Ｕpload;
using JB.WebModules;
using Telerik.Web.UI;
using System.IO;
using Telerik.Web.UI.Upload;

public partial class Account_UpPicture :JBWebPage {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //RadUpload file1 = (RadUpload)RadUpload1.FindControl("RadUpload1");
        //UpLoadFile file1 = (UpLoadFile)RadUpload1.FindControl("RadUpload1");
        UploadedFile file = RadUpload1.UploadedFiles[0];
        
        
        UpLoadFile upfile = new UpLoadFile();       
        if (file.ContentLength >= 700000) 
        {
            Message.Show("檔案必需小於700K");
            return;
        }
        int index = file.FileName.IndexOf('.');
        if (index < 0) 
        {
            Message.Show("上傳失敗！請先上傳檔是否為圖檔！");
            return;
        }

        if (!file.FileName.Substring(index).ToLower().Trim().Equals(".jpg")) 
        {

            Message.Show("上傳失敗！圖檔格式只接受JPG");
            return;
        }

       
        Stream fs = file.InputStream;
        byte[] buffer = new byte[fs.Length]; // 用來儲存檔案的 byte 陣列，檔案有多大，陣列就有多大 
        fs.Read(buffer, 0, buffer.Length);
        fs.Close();




        HRDsTableAdapters.BASETableAdapter ad = new HRDsTableAdapters.BASETableAdapter();
        HRDs.BASEDataTable dt = ad.GetData(JbUser.NOBR.Trim());
        if (dt.Rows.Count > 0)
        {
            dt[0].PHOTO = buffer;
            ad.Update(dt);
        }
        Message.Show("上傳成功，請重請登出系統，再登入系統確認！");
       
    }


    private void RadUpload1_FileExists(object sender, UploadedFileEventArgs e)
    {
        int counter = 1;


        UploadedFile file = e.UploadedFile;

        string targetFolder = Server.MapPath(RadUpload1.TargetFolder);

        string targetFileName = Path.Combine(targetFolder,
            file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());

        while (System.IO.File.Exists(targetFileName))
        {
            counter++;
            targetFileName = Path.Combine(targetFolder,
                file.GetNameWithoutExtension() + counter.ToString() + file.GetExtension());
        }

        file.SaveAs(targetFileName);
    }
}
