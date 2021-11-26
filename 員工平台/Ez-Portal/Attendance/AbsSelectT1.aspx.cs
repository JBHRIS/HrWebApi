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

public partial class Attendance_AbsSelectT1 : JBWebPage {
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) 
        {
            JbHrCL.AbsCS abscs = new JbHrCL.AbsCS();
             DataTable dt = abscs.GetAbsPersonal(JbUser.NOBR, DateTime.Now.Date, DateTime.Parse("2008/1/1"), DateTime.Parse("2008/12/31"), "1", "2");
             GridView1.DataSource = dt;
             GridView1.DataBind();
        }

    }
}
