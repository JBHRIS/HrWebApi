using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Abs1_Check : System.Web.UI.Page
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

                plDate.Visible = true;
                plDate.Enabled = false;
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
                lblNobrSign.Text = Request.Cookies["ezFlow"]["Emp_id"];

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
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

            var rAppM = (from c in dcFlow.wfFormApp
                         where c.sProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            if (rAppM != null)
            {
                rblSign.Items.FindByValue(rAppM.bSign ? "1" : "0").Selected = true;

                btnSubmit_ConfirmButtonExtender.ConfirmText = rAppM.sConditions3 == "1" ? "此單據已超過暫支款的總預算，您確定要送出嗎？" : btnSubmit_ConfirmButtonExtender.ConfirmText;
                lblCurrency.Visible = rAppM.sConditions3 == "1";

                var rAppS = (from c in dcForm.wfAppAbs1
                             where c.sProcessID == lblProcessID.Text
                             select c).FirstOrDefault();

                //簽核者=申請者
                if (rAppS != null)
                {
                    lblNobr.Text = rAppS.sNobr;
                    txtDateB.Text = rAppS.dDateB.ToString("yyyy/MM/dd");
                    txtDateE.Text = rAppS.dDateE.ToString("yyyy/MM/dd");

                    if (lblNobr.Text == lblNobrSign.Text)
                    {
                        plDate.Visible = true;
                        btnSubmit.ValidationGroup = "fv";

                        //btnSubmit.Visible = DateTime.Now.Date.AddDays(7) >= Convert.ToDateTime(txtDateE.Text);
                        //lblMsg.Visible = !btnSubmit.Visible;
                        //if (!btnSubmit.Visible)     //會發生一個問題，如果簽核過程中是相同的人，就會卡住了
                        //    lblMsg.Text = "目前還不允許簽核(需要回國前七日以後才可以簽核)";
                    }

                    if (rAppM.dDateTimeA.Value.AddDays(7) >= rAppS.dDateB)
                        ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('此表單為急件！');", true);
                }
            }
        }
    }

    private void SetDefault()
    {
        lblTitle.ToolTip = "Abs1";
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
        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();
        if (rSysVar == null || rSysVar.sysClose == null || rSysVar.sysClose.Value)
        {
            lblMsg.Text = "系統維護中，請稍後再送出表單";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var dtAppM = from c in dcFlow.wfFormApp
                     where c.sProcessID == lblProcessID.Text
                     select c;
        var rAppM = dtAppM.FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppAbs1
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
                     && (pc.Emp_idDefault == lblNobrSign.Text || pc.Emp_idAgent == lblNobrSign.Text)
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
        rAppS.dDateB = Convert.ToDateTime(txtDateB.Text);
        rAppS.dDateE = Convert.ToDateTime(txtDateE.Text);
        rAppS.sTimeB = txtTimeB.Text;
        rAppS.sTimeE = txtTimeE.Text;
        rAppS.dDateTimeB = rAppS.dDateB.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rAppS.sTimeB, true));
        rAppS.dDateTimeE = rAppS.dDateE.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rAppS.sTimeE, false));
        TimeSpan ts = rAppS.dDateTimeE - rAppS.dDateTimeB;
        rAppS.iDay = ts.Days + 1;
        rAppS.iTotalDay = rAppS.iDay;

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
    protected void fvAppS_DataBound(object sender, EventArgs e)
    {
        Label lblDateTimeB , lblDateTimeE , lblTotalDay;
        lblDateTimeB = fvAppS.FindControl("lblDateTimeB") as Label;
        lblDateTimeE = fvAppS.FindControl("lblDateTimeE") as Label;
        lblTotalDay = fvAppS.FindControl("lblTotalDay") as Label;

        if (lblDateTimeB != null && lblDateTimeE != null && lblTotalDay != null)
        {
            string RequestName = Request.QueryString.AllKeys[0];
            lblDateTimeB.Visible = (RequestName != "ApParm");
            lblDateTimeE.Visible = (RequestName != "ApParm");
            lblTotalDay.Visible = (RequestName != "ApParm");
        }
    }
}