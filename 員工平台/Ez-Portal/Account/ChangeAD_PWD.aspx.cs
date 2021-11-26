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
using SystemFrameworks.Helper;





public partial class Account_ChangeAD_PWD : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string nobr = JbUser.NOBR;
        string ad_name = new DataSet1TableAdapters.QueriesTableAdapter().GetADName(nobr).ToString();



        ADHelper.ChangeUserPassword(ad_name,old_pwd.Text, new_pwd.Text);
    }
}
