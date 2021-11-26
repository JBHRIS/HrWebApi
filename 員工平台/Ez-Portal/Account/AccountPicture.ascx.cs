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

public partial class Account_AccountPicture : System.Web.UI.UserControl ,ICU{

    private SiteHelper siteHelper = new SiteHelper();
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            //img_AccountPicture.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + ((SiteIdentity)Context.User.Identity).JbUser.NOBR.Trim() + ".jpg";
            img_AccountPicture.ImageUrl = siteHelper.GetEmpPhotoPath(((SiteIdentity)Context.User.Identity).JbUser.NOBR.Trim());
        }
    }



    #region ICU 成員

    public void bindGrid() {
        //img_AccountPicture.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + lb_nobr.Text.Trim() + ".jpg";
        img_AccountPicture.ImageUrl = siteHelper.GetEmpPhotoPath(lb_nobr.Text.Trim());

    }

    #endregion
}
