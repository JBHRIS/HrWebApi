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
using JB.WebModules.Authentication;

public partial class Account_AccountPictureBind : System.Web.UI.UserControl, ICU
{
    private SiteHelper siteHelper = new SiteHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //img_AccountPicture.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + ((SiteIdentity)Context.User.Identity).JbUser.NOBR.Trim() + ".jpg";
            bindGrid();
        }
    }
    #region ICU 成員

    public void bindGrid()
    {
        if(Request["NOPIC"]==null)
            img_AccountPicture.ImageUrl = siteHelper.GetEmpPhotoPath(lb_nobr.Text.Trim());
            //img_AccountPicture.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + lb_nobr.Text.Trim() + ".jpg";
        else
            img_AccountPicture.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + "NOPIC.jpg";


    }

    #endregion
}
