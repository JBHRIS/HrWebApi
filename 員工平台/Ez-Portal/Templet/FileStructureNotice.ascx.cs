using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templet_FileStructureNotice : JUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            if (this.Page is JBWebPage)
            {
                JBWebPage p = this.Page as JBWebPage;
                if (p.DisplayNotice)
                {
                    this.Visible = true;
                    ltlContent.Text = p.NoticeContent;
                    ltlTitle.Text = p.NoticeTitle;
                }
                else
                    this.Visible = false;
            }
            
        }
    }
}