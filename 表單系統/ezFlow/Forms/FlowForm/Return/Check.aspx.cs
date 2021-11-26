using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Return_Check : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();

        if (Request.Url.Query.Length == 0 || rSysVar == null)
        {
            lblMsg.Text = "表單資訊錯誤，請重新開啟";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["localhost"]);
        }

        string RequestName = Request.QueryString.AllKeys[0];
        string RequestValue = Request[RequestName];

        if ((RequestName == "ApParm") && (Request.Cookies["ezFlow"] == null))
        {
            lblMsg.Text = "表單資訊錯誤，請重新開啟";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["localhost"]);
        }

        if (!IsPostBack)
        {
            btnSubmit.Visible = (RequestName == "ApParm");
            lblNobrSign.Text = (RequestName == "ApParm") ? Request.Cookies["ezFlow"]["Emp_id"] : "";

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobrSign.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            lblProcessID.Text = Flow.GetProcessID(RequestName, Convert.ToInt32(RequestValue)).ToString();

            SetDefault();

            var rAppM = (from c in dcFlow.wfFormApp
                         where c.sProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            if (rAppM != null)
                rblSign.Items.FindByValue(rAppM.bSign ? "1" : "0").Selected = true;
        }
    }

    private void SetDefault()
    {
        lblTitle.ToolTip = "Return";
        (Page.Master as mpCheck0990119).sFormCode = lblTitle.ToolTip;
        if ((Page.Master as mpCheck0990119).FindControl("fvAppM") != null)
            (Page.Master as mpCheck0990119).FindControl("fvAppM").Visible = false;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
            lblTitle.ToolTip = rForm.sFormCode;
            txtNote.CausesValidation = rForm.bSignNote;
            gvSignM.Visible = rForm.bSignState;
        }
    }

    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnDL = e.Row.FindControl("btnDL") as Button;
        if (btnDL != null)
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnDL);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var dtAppM = from c in dcFlow.wfFormApp
                     where c.sProcessID == lblProcessID.Text
                     select c;
        var rAppM = dtAppM.FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppReturn
                     where c.sProcessID == lblProcessID.Text
                     && c.sState == "1"
                     select c;
        var rAppS = dtAppS.FirstOrDefault();

        if (rAppM == null || rAppS == null)
        {
            lblMsg.Text = "找不到重要的簽核資料，請洽管理人員";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

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

        rAppM.sNote = txtNote.Text;
        rAppM.bSign = rblSign.SelectedItem.Value == "1";
        rAppM.sConditions1 = sOrder;
        rAppM.sConditions2 = lblNobrSign.Text;
        rAppM.sState = !rAppM.bSign ? "2" : rAppM.sState;
        rAppM.dDateTimeD = DateTime.Now;

        rAppS.bSign = rAppM.bSign;
        rAppS.sState = rAppM.sState;

        var rBase = (from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == lblNobrSign.Text
                     select new { role, emp, dept, pos }).FirstOrDefault();

        var rSignM = new wfFormSignM();
        rSignM.sFormCode = lblTitle.ToolTip;
        rSignM.sFormName = lblTitle.Text;
        rSignM.sKey = Guid.NewGuid().ToString();
        rSignM.sProcessID = lblProcessID.Text;
        rSignM.idProcess = Convert.ToInt32(rSignM.sProcessID);
        rSignM.sNobr = lblNobrSign.Text;
        rSignM.sName = rBase == null ? "" : rBase.emp.name;
        rSignM.sRole = rBase == null ? "" : rBase.role.id;
        rSignM.sDept = rBase == null ? "" : rBase.dept.id;
        rSignM.sDeptName = rBase == null ? "" : rBase.dept.name;
        rSignM.sJob = rBase == null ? "" : rBase.pos.id;
        rSignM.sJobName = rBase == null ? "" : rBase.pos.name;
        rSignM.sNote = txtNote.Text;
        rSignM.bSign = rAppM.bSign;
        rSignM.dKeyDate = DateTime.Now;
        dcFlow.wfFormSignM.InsertOnSubmit(rSignM);

        dcFlow.SubmitChanges();
        dcForm.SubmitChanges();

        localhost.Service oService = new localhost.Service();

        if (!oService.WorkFinish(Convert.ToInt32(Request["ApParm"])))
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "AlertMsg", "alert('流程發生問題，您核准的動作可能無法完成。');self.close();", true);
        else
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "OKMsg", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
    }
}
