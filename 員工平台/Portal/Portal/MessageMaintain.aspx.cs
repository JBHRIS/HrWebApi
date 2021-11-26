using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class MessageMaintain : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             ((Single)Master)._DivClass = "middle-box text-center animated fadeInDown";
        }
    }
}