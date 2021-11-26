using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_ClassCalendar : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbtn.OnClientClick = @"window.open('"+ResolveClientUrl("PrnClassCalendar.aspx")+"', '_blank');return false;";
        }
    }
}