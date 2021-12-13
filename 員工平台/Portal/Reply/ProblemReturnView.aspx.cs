using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class ProblemReturnView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = _User.EmpName;
        }
    }
}