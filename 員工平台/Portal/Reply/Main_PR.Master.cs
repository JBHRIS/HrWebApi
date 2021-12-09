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
                Page.PreRenderComplete += Page_PreRenderComplete;
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