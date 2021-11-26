using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaryWeb
{
    public partial class Error : System.Web.UI.Page
    {
        private const string MessageQueryStringName = "message";

        protected void Page_Load(object sender, EventArgs e)
        {
            string message = Request.QueryString[MessageQueryStringName] as string;

            ShowLabel.Text = message ?? "無接受到錯誤資訊";
        }
    }
}