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

public partial class Account_AccountInfo : JBUserControl {
    protected void Page_Load(object sender, EventArgs e) 
    {       
        lb_nobr.Text = JbUser.NOBR;
        lb_name.Text = JbUser.NAME_C;
        lblEname.Text = JbUser.NAME_E;
        lb_dept.Text = JbUser.DepartmentName;
        lb_job.Text = JbUser.JobTitel;
    }
}
