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
 
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class HR_MangUser : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loginname.Text = JbUser.NAME_C;
        }
    }
    
    protected void AddButton_Click(object sender, EventArgs e)
    {
        if (Label2.Text == "")
            JB.WebModules.Message.Show("無此員工編號！");
        else
            SqlDataSource1.Insert();
    }
    protected void UserNobr_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Label2.Text = JB.WebModules.Accounts.User.GetUserByID(UserNobr.Text).NAME_C;
            lb_pwd.Text = JB.WebModules.Data.Utli.encode( JB.WebModules.Accounts.User.GetUserByID(UserNobr.Text).BIRTHDAY.ToString("yyyyMMdd"));
            
        }
        catch 
        {            
        }
        
    }

    protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e) {
       
    }
}
