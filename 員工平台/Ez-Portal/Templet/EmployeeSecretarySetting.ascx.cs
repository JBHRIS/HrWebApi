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
using BL;
using JBHRModel;
public partial class Templet_EmployeeSecretarySetting : JBUserControl,IUC
{
    private BASETTS_REPO basettsRepo = new BASETTS_REPO();
    protected void Page_Load(object sender, EventArgs e) 
    {
        //if (!IsPostBack)
        //    lb_nobr.Text = JbUser.NOBR;
       
    }

    public void BindData()
    {
        BASETTS basettsObj= basettsRepo.GetByNobrNow_DLO(lb_nobr.Text);
        if (basettsObj != null)
            ckSecretary.Checked = basettsObj.MANG1;
        else
            ckSecretary.Checked = false;
    }

    public void SetValue(string value)
    {
        lb_nobr.Text = value;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BASETTS basettsObj = basettsRepo.GetByNobrNow_DLO(lb_nobr.Text);
        if (basettsObj != null)
        {
            basettsObj.MANG1= ckSecretary.Checked;
            basettsRepo.Update(basettsObj);
            basettsRepo.Save();
        }
        BindData();


    }
}
