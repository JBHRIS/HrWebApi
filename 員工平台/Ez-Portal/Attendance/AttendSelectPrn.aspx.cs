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

public partial class Attendance_AttendSelect : JBWebPage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            Label lb = (Label)RoteList1.FindControl("lb_nobr");
            lb.Text = Session["selected_nobr"].ToString();
            ((ICU)RoteList1).bindGrid();            
        }

    }


}
