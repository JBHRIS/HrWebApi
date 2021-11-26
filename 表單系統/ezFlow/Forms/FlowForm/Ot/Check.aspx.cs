using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBHR.Dll;

public partial class Ot_Check : System.Web.UI.Page
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
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["localhost"]);
        }

        if (!IsPostBack)
        {
            string RequestName = Request.QueryString.AllKeys[0];
            string RequestValue = Request[RequestName];

            if (RequestName == "ApParm")
            {
                var rA = (from c in dcFlow.ProcessApParm
                          where c.auto == Convert.ToInt32(RequestValue)
                          select c).FirstOrDefault();

                if (rA != null)
                    lblNobrSign.Text = rA.Emp_id;
            }
            else
            {
                var rA = (from c in dcFlow.ProcessApView
                          where c.auto == Convert.ToInt32(RequestValue)
                          select c).FirstOrDefault();

                if (rA != null)
                    lblNobrSign.Text = rA.Emp_id;
            }

            if (Request.Cookies["ezFlow"] != null && Request.Cookies["ezFlow"]["Emp_id"] != null)
            {
                lblNobrSign.Text = Request.Cookies["ezFlow"]["Emp_id"];
                //Response.Write(lblNobrSign.Text);
            }

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                //Response.Write(User.Identity.Name.Trim());
                lblNobrSign.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            if (lblNobrSign.Text.Trim().Length == 0)
                Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["localhost"]);

            btnSubmit.Visible = (RequestName == "ApParm");

            lblProcessID.Text = Flow.GetProcessID(RequestName, Convert.ToInt32(RequestValue)).ToString();

            SetDefault();
        }
    }

    private void SetDefault()
    {
        lblTitle.ToolTip = "Ot";
        (Page.Master as mpCheck0990119).sFormCode = lblTitle.ToolTip;

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

    protected void gvAppS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CheckBox ckSign = (CheckBox)e.Row.FindControl("ckSign");
        if (ckSign != null)
        {
            e.Row.Visible = (Request.QueryString.AllKeys[0] == "ApView") || ckSign.Checked;
            ckSign.Enabled = (Request.QueryString.AllKeys[0] != "ApView");

            var r = from c in dcForm.wfAppOt
                    where c.iAutoKey == Convert.ToInt32(ckSign.ToolTip)
                    select c;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();
        if (rSysVar == null || rSysVar.sysClose == null || rSysVar.sysClose.Value)
        {
            lblMsg.Text = "系統維護中，請稍後再送出表單 System maintain,please sent it later.";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var dtAppM = from c in dcFlow.wfFormApp
                     where c.sProcessID == lblProcessID.Text
                     select c;
        var rAppM = dtAppM.FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppOt
                     where c.sProcessID == lblProcessID.Text
                     && c.sState == "1"
                     select c;

        if (rAppM == null || !dtAppS.Any())
        {
            lblMsg.Text = "找不到重要的簽核資料，請洽管理人員 There is no approval be found,please ask the manager.";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        CheckBox ckSign;
        string sBody, sSubTitle;
        int i = gvAppS.Rows.Count;
        foreach (GridViewRow rs in gvAppS.Rows)
        {
            ckSign = (CheckBox)rs.FindControl("ckSign");
            if (ckSign != null)
            {
                var rAppS = dtAppS.Where(p => p.iAutoKey == Convert.ToInt32(ckSign.ToolTip)).FirstOrDefault();
                if (rAppS != null)
                {
                    rAppS.bSign = ckSign.Checked;
                    rAppS.sState = rAppS.bSign ? "1" : "2";

                    if (!rAppS.bSign)
                    {
                        i--;
                    }
                }
            }
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
        rAppM.bSign = i > 0;
        rAppM.sConditions1 = sOrder.PadLeft(2, '0');
        rAppM.sState = !rAppM.bSign ? "2" : rAppM.sState;
        rAppM.dDateTimeD = DateTime.Now;

        var rBase = (from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == lblNobrSign.Text
                     select new { role, emp, dept, pos }).FirstOrDefault();

        var rSignM = (from c in dcFlow.wfFormSignM
                      where c.sProcessID == lblProcessID.Text
                      && c.sNobr == lblNobrSign.Text
                      select c).FirstOrDefault();

        if (rSignM == null)
        {
            rSignM = new wfFormSignM();
            dcFlow.wfFormSignM.InsertOnSubmit(rSignM);
        }

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

        dcFlow.SubmitChanges();
        dcForm.SubmitChanges();

        localhost.Service oService = new localhost.Service();

        if (!oService.WorkFinish(Convert.ToInt32(Request["ApParm"])))
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('流程發生問題，您核准的動作可能無法完成。 There is a problem with the process,your approval will not complete.');self.close();", true);
        else
        {
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "OKMsg", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
        }
    }
}