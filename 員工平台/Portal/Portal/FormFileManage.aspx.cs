using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormFileManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var cn = ((RadButton)sender).CommandName;
            var ca = ((RadButton)sender).CommandArgument;
            
            ucFileManage._lblKey.Text = ca;
        }
    }
}