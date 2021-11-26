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
using JB.WebModules;

public partial class Utli_ShowEmpImage : JBWebPage {

    string _Photo = "";
    protected void Page_Load(object sender, EventArgs e) {
        _Photo = Request.QueryString["Photo"];

        if (_Photo.Trim().Length > 0) {
            _Photo = _Photo.Substring(0, _Photo.IndexOf('.'));
        
        }

        showImage();
    }
    void showImage()
    {
        //IJbhrService jbSrv = new JbhrService();
        //byte[] imgArr= jbSrv.GetEmpPhoto(_Photo);
        //if (imgArr == null)
        //{
        //    Response.ClearContent();
        //    Response.ContentType = "Image/Jpeg";
        //    Response.BinaryWrite(getBMPimage(Server.MapPath("../") + "Images/stick_on_picture.gif"));
        //    Response.End();
        //    return;
        //}
        //else
        //{
        //    Response.ClearContent();
        //    Response.ContentType = "Image/Jpeg";
        //    Response.BinaryWrite(imgArr);
        //    Response.End();
        //    return;
        //}

        string imgPath = Globals.Settings.AccountPicturePath + "\\" + _Photo;

        DataSet1TableAdapters.BASEPHOTOTableAdapter ad = new DataSet1TableAdapters.BASEPHOTOTableAdapter();
        DataSet1.BASEPhotoDataTable dt = ad.GetData(_Photo);
        if (dt.Rows.Count == 0)
        {
            Response.BinaryWrite(getBMPimage(Server.MapPath("../") + "Images/stick_on_picture.gif"));
            Response.End();
            return;
        }

        if (dt[0].IsPHOTONull())
            Response.BinaryWrite(getBMPimage(Server.MapPath("../") + "Images/stick_on_picture.gif"));
        else
        {
            if (dt[0].PHOTO.Length < 10)
                Response.BinaryWrite(getBMPimage(Server.MapPath("../") + "Images/stick_on_picture.gif"));
            else
                Response.BinaryWrite(dt[0].PHOTO);
        }

        Response.End();
    }

    public static byte[] getBMPimage(string FilePath) {
        Stream FileStream;
        if (!File.Exists(FilePath)) {
            return null;
        }
        FileStream = File.OpenRead(FilePath);
        byte[] img = new byte[FileStream.Length];
        FileStream.Read(img, 0, int.Parse(FileStream.Length.ToString()));
        FileStream.Close();

        return img;
    }
}
