using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_RedirectHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["USER"] ==null)
            Response.Redirect("~/eTraining/login.aspx",true);

        if (Session["USER"] == "HR")
        {
            Response.Redirect("~/eTraining/Admin/HR.aspx" , true);
        }
        if (Session["USER"] == "STAFF")
        {
            Response.Redirect("~/eTraining/Staff/Staff.aspx" , true);
        }
        if (Session["USER"] == "MANAGER")
        {
            Response.Redirect("~/eTraining/Manager/Manager.aspx" , true);
        }
        if (Session["USER"] == "TEACHER")
        {
            Response.Redirect("~/eTraining/Teacher/Teacher.aspx" , true);
        }
    }
}