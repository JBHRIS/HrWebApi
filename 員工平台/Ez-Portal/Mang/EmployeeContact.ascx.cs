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

public partial class Employee_EmployeeContact : JBUserControl {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            lb_nobr.Text = JbUser.NOBR;
       
    }
}
