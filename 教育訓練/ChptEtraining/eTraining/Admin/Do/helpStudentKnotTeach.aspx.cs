using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Do_helpStudentKnotTeach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "設定結訓學員說明";
            
        }
    }
    protected void HyperLink1_Disposed(object sender, EventArgs e)
    {
        
    }
}