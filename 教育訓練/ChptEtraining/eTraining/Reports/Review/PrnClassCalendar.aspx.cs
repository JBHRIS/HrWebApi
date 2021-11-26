using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Reports_Review_PrnClassCalendar : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnPrint.OnClientClick = @"document.getElementById('btnPrint').style.display = 'none';
            window.print();
            document.getElementById('btnPrint').style.display = 'block';
            return false;";
        }                        
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        
    }
}