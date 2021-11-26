using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Performance
{
    public partial class LoginForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Single)Master)._DivClass = "passwordBox animated fadeInDown";
        }
    }
}