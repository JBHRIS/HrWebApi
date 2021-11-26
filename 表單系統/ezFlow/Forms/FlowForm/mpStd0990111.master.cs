using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpStd0990111 : System.Web.UI.MasterPage
{
    public string sFormCode
    {
        get { return lblTitle.ToolTip; }
        set { lblTitle.ToolTip = value; }
    }

    public string sAppNobr
    {
        get { return lblNobrAppM.Text; }
        set { lblNobrAppM.Text = value; }
    }

    private dcFlowDataContext dcFlow = new dcFlowDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltModalProgress.Text = "<script type='text/javascript' language='javascript'>var ModalProgress = '" + ModalProgress.ClientID + "';</script>";

        SetDefault();
    }

    private void SetDefault()
    {
        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
            lblNote.Text = rForm.sStdNote;
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["localhostDefault"]);
    }
}