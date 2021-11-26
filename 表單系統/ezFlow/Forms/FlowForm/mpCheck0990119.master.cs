using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpCheck0990119 : System.Web.UI.MasterPage
{
    public string sFormCode
    {
        get { return lblTitle.ToolTip; }
        set { lblTitle.ToolTip = value; }
    }

    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltModalProgress.Text = "<script type='text/javascript' language='javascript'>var ModalProgress = '" + ModalProgress.ClientID + "';</script>";

        string RequestName = Request.QueryString.AllKeys[0];
        string RequestValue = Request[RequestName];
        //lblNobrSign.Text = Request.Cookies["ezFlow"]["Emp_id"];

        lblProcessID.Text = Flow.GetProcessID(RequestName, Convert.ToInt32(RequestValue)).ToString();

        var dtAppM = from c in dcFlow.wfFormApp
                     where c.sProcessID == lblProcessID.Text
                     select c;

        var rAppM = dtAppM.FirstOrDefault();
        if (rAppM != null)
            lblNobrAppM.Text = rAppM.sNobr;

        SetDefault();
    }

    private void SetDefault()
    {
        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
            lblNote.Text = rForm.sCheckNote;
        }
    }
}
