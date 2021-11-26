using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Check : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string RequestName = Request.QueryString.AllKeys[0];
            string RequestValue = Request[RequestName];
            lblNobrSign.Text = Request.Cookies["ezFlow"]["Emp_id"];
            btnSubmit.Visible = (RequestName == "ApParm");

            lblProcessID.Text = Flow.GetProcessID(RequestName, Convert.ToInt32(RequestValue)).ToString();

            SetDefault();
        }
    }

    private void SetDefault()
    {
        lblTitle.ToolTip = "Test";
        (Page.Master as mpCheck0990119).sFormCode = lblTitle.ToolTip;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
            lblTitle.ToolTip = rForm.sFormCode;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var dtAppM = from c in dcFlow.wfFormApp
                     where c.sProcessID == lblProcessID.Text
                     select c;
        var rAppM = dtAppM.FirstOrDefault();

        var sDept = (from pc in dcFlow.ProcessCheck
                     join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                     join role in dcFlow.Role on pc.Role_idDefault equals role.id
                     where Convert.ToString(pn.ProcessFlow_id) == lblProcessID.Text
                     && pc.Emp_idDefault == lblNobrSign.Text
                     orderby pc.auto descending
                     select role.Dept_id).FirstOrDefault();

        string sOrder = "00";
        if (sDept != null)
        {
            var sTree = JBHR.Dll.Bas.Deptm(sDept).FirstOrDefault();
            if (sTree != null)
                sOrder = sTree.sDeptTree;
        }

        rAppM.sNote = "";
        rAppM.bSign = true;
        rAppM.sConditions1 = sOrder;
        rAppM.sState = !rAppM.bSign ? "2" : rAppM.sState;
        rAppM.dDateTimeD = DateTime.Now;
        dcFlow.SubmitChanges();

        localhost.Service oService = new localhost.Service();

        if (!oService.WorkFinish(Convert.ToInt32(Request["ApParm"])))

            Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", "alert('流程發生問題，您核准的動作可能無法完成。');self.close();", true);
        else
            Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);


    }
}