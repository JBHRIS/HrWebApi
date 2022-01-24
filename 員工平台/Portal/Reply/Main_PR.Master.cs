using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Main_PR : WebPageMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
            }
            Page.PreRenderComplete += Page_PreRenderComplete;
            if (_User.RoleKey == 64)
            {
                ProblemReturnListM.Visible = false;
            }
            var Path = System.IO.Path.GetFileName(Request.PhysicalPath);
            if (Path == "ProblemReturn.aspx")
                ProblemReturn.Style.Add(HtmlTextWriterStyle.Color, "#1ab394");
            if (Path == "ProblemReturnList.aspx")
                ProblemReturnList.Style.Add(HtmlTextWriterStyle.Color, "#1ab394");
            if (Path == "ProblemReturnView.aspx")
                ProblemReturnList.Style.Add(HtmlTextWriterStyle.Color, "#1ab394");
            if (Path == "ProblemReturnListM.aspx")
                ProblemReturnListM.Style.Add(HtmlTextWriterStyle.Color, "#1ab394");
            if (Path == "MessageReturn.aspx")
                ProblemReturnListM.Style.Add(HtmlTextWriterStyle.Color, "#1ab394");
            if (_User.EmpName == "未登入" )
            {
                string strUrl_No = "../Reply/LoginBind.aspx";
                ScriptManager.RegisterClientScriptBlock(Page,Page.GetType(), "script", "if ( window.alert('登入已逾時，請重新登入')) { } else {window.location.href='" + strUrl_No + "' };", true);
            }
        }
        private void Page_PreRenderComplete(object sender, EventArgs e)
        {
            //將css檔放在最後不然沒有效果
            var CSS = new HtmlGenericControl();
            CSS.TagName = "link";
            //CSS.Attributes.Add("type", "text/css");
            CSS.Attributes.Add("rel", "stylesheet");
            CSS.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("styles/redcontrol_form.css")));
            this.Page.Header.Controls.Add(CSS);
        }
    }
}