using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBHR.Dll;

public partial class ShiftLong_Std : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
            txtDateA.Text = DateTime.Now.ToString("yyyy/MM/dd");

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobrAppM.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            lblNobrAppM.Text = lblNobrAppM.Text.Trim().Length == 0 ? " " : lblNobrAppM.Text;

            //var rEmp = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
            //if (rEmp != null)
            //{
            //    lblDept.Text = rEmp.sDeptmCode;
            //    var rDeptm = JBHR.Dll.Bas.Deptm(lblDept.Text).FirstOrDefault();
            //    if (rDeptm != null)
            //        lblDept.Text = rDeptm.sDeptParent;
            //}

            var rRole = (from c in dcFlow.Role
                         where c.Emp_id == lblNobrAppM.Text
                         select c).FirstOrDefault();
            if (rRole != null)
                lblRoleAppM.Text = rRole.id;

            //JbhrService.JbhrServiceClient oJbhrServiceClient = new JbhrService.JbhrServiceClient();
            //bool isManage = oJbhrServiceClient.IsInRoleHR(lblNobrAppM.Text);
            //lblDept.Text = isManage ? "A000000" : lblDept.Text;

            SetDefault();

            //ddlName.Visible = ddlName.Visible || isManage;

            BindRotet();
            ddlHoli.DataBind();
            ddlOtRate.DataBind();

            SetName(lblNobrAppM.Text);

            txtDateA_TextChanged(txtDateA, null);
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        lblFlowTreeID.Text = "67";
        lblTitle.ToolTip = "ShiftLong";
        (Page.Master as mpStd0990111).sFormCode = lblTitle.ToolTip;
        (Page.Master as mpStd0990111).sAppNobr = lblNobrAppM.Text;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rEmp = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
            if (rEmp != null)
            {
                var rForm = dtForm.First();
                lblTitle.Text = rForm.sFormName;
                ddlName.Visible = rForm.bAgentApp || (rEmp.bMang || rEmp.bMang1);
                txtName.ReadOnly = !ddlName.Visible;
                txtNote.CausesValidation = rForm.bNote;
                txtDateA.ToolTip = rForm.iDelay.ToString();
                gvAppS.ToolTip = rForm.iAppCount.ToString();
            }
        }
    }

    #region 工號及姓名
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlName = sender as DropDownList;
        if (ddlName != null && ddlName.Items.Count > 0)
        {
            ListItem li = ddlName.SelectedItem;
            SetName(li);
        }
    }
    protected void ddlName_DataBound(object sender, EventArgs e)
    {
        DropDownList ddlName = sender as DropDownList;
        if (ddlName != null && ddlName.Items.Count > 0 && !IsPostBack)
        {
            ListItem li = ddlName.Items.FindByValue(lblNobrAppM.Text);
            SetName(li);
        }
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        TextBox txtName = sender as TextBox;
        if (txtName != null)
        {
            txtName.Text = txtName.Text.ToUpper();
            ListItem li = ddlName.Items.FindByValue(txtName.Text);
            li = li != null ? li : ddlName.Items.FindByText(txtName.Text);
            SetName(li);
        }
    }
    private void SetName(ListItem li)
    {
        if (li != null)
        {
            ddlName.ClearSelection();
            li.Selected = true;
            lblNobr.Text = li.Value;
            txtName.Text = li.Text;
            txtName.ToolTip = txtName.Text;
            lblFlowID.Text = lblNobr.Text;
        }
        else
            txtName.Text = txtName.ToolTip;

        SetInfo(lblNobr.Text);
    }
    private void SetName(string sNobr)
    {
        var r = (from c in dcFlow.Emp
                 where c.id == sNobr
                 select c).FirstOrDefault();

        if (r != null)
        {
            lblNobr.Text = r.id;
            txtName.Text = r.name;
            txtName.ToolTip = txtName.Text;
            lblFlowID.Text = lblNobr.Text;
        }
        else
            txtName.Text = txtName.ToolTip;

        SetInfo(lblNobr.Text);
    }
    private void SetInfo(string sNobr)
    {
        lblRotet.ToolTip = "";
        lblRotet.Text = "";
        lblHoli.ToolTip = "";
        lblHoli.Text = "";
        lblOtRate.ToolTip = "";
        lblOtRate.Text = "";

        var rBaseTts = JBHR.Dll.Bas.BaseTts(sNobr, DateTime.Now).FirstOrDefault();
        if (rBaseTts != null)
        {
            var rRotet = JBHR.Dll.Att.Rotet(rBaseTts.sRotet).FirstOrDefault();
            var rHoli = JBHR.Dll.Att.Holicd(rBaseTts.sHoliCode).FirstOrDefault();
            var rOtRate = JBHR.Dll.Att.OtRate(rBaseTts.sCalOt).FirstOrDefault();

            if (rRotet != null)
            {
                lblRotet.ToolTip = rRotet.sRotet.Trim();
                lblRotet.Text = rRotet.sRotetName.Trim() + "(" + rRotet.sRotet.Trim() + ")";

                ddlRotet.ClearSelection();
                if (ddlRotet.Items.FindByValue(rRotet.sRotet.Trim()) != null)
                    ddlRotet.Items.FindByValue(rRotet.sRotet.Trim()).Selected = true;
            }

            if (rHoli != null)
            {
                lblHoli.ToolTip = rHoli.sHoliCode.Trim();
                lblHoli.Text = rHoli.sHoliName.Trim() + "(" + rHoli.sHoliCode.Trim() + ")";

                ddlHoli.ClearSelection();
                if (ddlHoli.Items.FindByValue(rHoli.sHoliCode.Trim()) != null)
                    ddlHoli.Items.FindByValue(rHoli.sHoliCode.Trim()).Selected = true;
            }

            if (rOtRate != null)
            {
                lblOtRate.ToolTip = rOtRate.sOtRateCode.Trim();
                lblOtRate.Text = rOtRate.sOtRateName.Trim() + "(" + rOtRate.sOtRateCode.Trim() + ")";

                ddlOtRate.ClearSelection();
                if (ddlOtRate.Items.FindByValue(rOtRate.sOtRateCode.Trim()) != null)
                    ddlOtRate.Items.FindByValue(rOtRate.sOtRateCode.Trim()).Selected = true;
            }
        }
    }
    #endregion

    protected void btnFlow_Click(object sender, EventArgs e)
    {
        mpePopupFlow.Show();
    }

    protected void btnExitFlow_Click(object sender, EventArgs e)
    {
        mpePopupFlow.Hide();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string sRotetCode = ddlRotet.SelectedItem.Value;
        string sHoliCode = ddlHoli.SelectedItem.Value;
        string sOtRateCode = ddlOtRate.SelectedItem.Value;

        if (Convert.ToInt32(gvAppS.ToolTip) > 0 && Convert.ToInt32(gvAppS.ToolTip) <= gvAppS.Rows.Count)
        {
            lblMsg.Text = "每張表單最多申請" + Convert.ToInt32(gvAppS.ToolTip) + "筆資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (txtNote.CausesValidation && txtNote.Text.Trim().Length == 0)
        {
            lblMsg.Text = "申請原因為必填欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //檢查重複的資料
        var dtAppS = from c in dcForm.wfAppShiftLong
                     where (c.sProcessID == lblProcessID.Text || (c.idProcess != 0 && c.sState == "1"))
                     && c.sNobr == lblNobr.Text
                     //&& c.dDateA == Convert.ToDateTime(txtDateA.Text)
                     select c;

        if (dtAppS.Any())
        {
            lblMsg.Text = "資料重複或流程正在進行中，請先刪除申請資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        DateTime dDate;
        if (!DateTime.TryParse(txtDateA.Text, out dDate))
        {
            lblMsg.Text = "日期格式錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        int iDelay = Convert.ToInt32(txtDateA.ToolTip);

        //if (iDelay > 0 && dDate < DateTime.Now.Date.AddDays(iDelay))
        //{
        //    lblMsg.Text = "調班的日期要" + iDelay.ToString() + "天前提出申請";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        if (sRotetCode == lblRotet.ToolTip && sHoliCode == lblHoli.ToolTip && sOtRateCode == lblOtRate.ToolTip)
        {
            lblMsg.Text = "資料完全相同，請選擇要換的班別/行事曆/加班別";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //檢查日期是否為生效日期
        JBHR.Dll.dsBas.JB_HR_BaseTtsDataTable dtBaseTts = JBHR.Dll.Bas.BaseTts(lblNobr.Text);
        var rBaseTts = dtBaseTts.Where(p => p.dAdate <= Convert.ToDateTime("3000/1/1") && p.dDdate >= Convert.ToDateTime("3000/1/1") && p.dAdate <= dDate).FirstOrDefault();

        if (rBaseTts == null)
        {
            lblMsg.Text = "調班的日期不是正確的";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var dtBase = from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == lblNobr.Text
                     select new { role, emp, dept, pos };

        var rEmpBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text).FirstOrDefault();

        if (!dtBase.Any() || rEmpBase == null)
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var rBase = dtBase.First();

        var rs = new wfAppShiftLong();
        rs.sFormCode = lblTitle.ToolTip;
        rs.sProcessID = lblProcessID.Text;
        rs.idProcess = 0;
        rs.sNobr = lblNobr.Text;
        rs.sNobr = lblNobr.Text;
        rs.sName = txtName.Text;
        rs.sDept = rBase.dept.id;
        rs.sDeptName = rBase.dept.name;
        rs.sJob = rBase.pos.id;
        rs.sJobName = rBase.pos.name;
        rs.sRole = rBase.role.id;
        rs.sDI = rEmpBase.sDI;
        rs.sRote = rEmpBase.sRotet;
        rs.sRotetCode = ddlRotet.SelectedItem.Value;
        rs.sRotetName = ddlRotet.SelectedItem.Text;
        rs.sHoliCode = ddlHoli.SelectedItem.Value;
        rs.sHoliName = ddlHoli.SelectedItem.Text;
        rs.sOtRateCode = ddlOtRate.SelectedItem.Value;
        rs.sOtRateName = ddlOtRate.SelectedItem.Text;
        rs.dDate = Convert.ToDateTime(txtDateA.Text);
        rs.sRotetCodeA = lblRotet.ToolTip;
        rs.sRotetNameA = lblRotet.Text;
        rs.sHoliCodeA = lblHoli.ToolTip;
        rs.sHoliNameA = lblHoli.Text;
        rs.sOtRateCodeA = lblOtRate.ToolTip;
        rs.sOtRateNameA = lblOtRate.Text;
        rs.bSign = true;
        rs.sState = "0";
        rs.bAuth = Convert.ToBoolean(rBase.role.deptMg);
        rs.sNote = txtNote.Text;
        rs.dKeyDate = DateTime.Now;
        rs.sInfo = rs.sName + "," + rs.dDate + "," + rs.sRotetNameA + "," + rs.sNote;
        rs.sMailBody = MessageSendMail.ShiftLongBody(rs.sNobr, rs.sName, rs.sDeptName, rs.sRotetNameA, rs.dDate.Value, rs.sRotetName, rs.sNote);
        dcForm.wfAppShiftLong.InsertOnSubmit(rs);

        dcForm.SubmitChanges();

        gvAppS.DataBind();
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

        if (gvAppS.Rows.Count == 0)
        {
            lblMsg.Text = "您並未申請任何資料，請先申請至少一筆資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var dtBase = from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == lblNobrAppM.Text
                     select new { role, emp, dept, pos };

        var rEmpBase = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();

        if (!dtBase.Any() || rEmpBase == null)
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        lblProcessID.ToolTip = lblProcessID.Text;

        var rBase = dtBase.First();

        var dtAppS = from c in dcForm.wfAppShiftLong
                     where c.sProcessID == lblProcessID.ToolTip
                     select c;

        var lsAppS = dtAppS.GroupBy(c => new { c.sRole });

        localhost.Service oService = new localhost.Service();

        int x = 0, y = 0;
        foreach (var rsAppS in lsAppS)
        {
            List<string> lsAgentMail = new List<string>();
            lsAgentMail.Add("");    //給主管審核用

            string sSubject = "【通知】(" + rsAppS.First().sNobr + ")" + rsAppS.First().sName + " 之調班單，請進入系統簽核";
            string sBody = "";

            //流程從這裡開始
            lblProcessID.Text = oService.GetProcessID().ToString();
            string Info = "";
            foreach (var rs in rsAppS)
            {
                sBody += rs.sMailBody;

                rs.sProcessID = lblProcessID.Text;
                rs.idProcess = Convert.ToInt32(rs.sProcessID);
                rs.sState = "1"; //開始

                //當角色不同時，就將資料寫入ProcessFlowShare
                if (Request["idRole_Start"] != rs.sRole)
                    oService.FlowShare(rs.idProcess, rs.sRole, rs.sNobr);

                y++;
                Info += rs.sInfo + "<BR>";
            }

            foreach (var s in lsAgentMail)
            {
                var rSendMail = new wfSendMail();
                rSendMail.sProcessID = lblProcessID.Text;
                rSendMail.idProcess = Convert.ToInt32(rSendMail.sProcessID);
                rSendMail.sGuid = Guid.NewGuid().ToString();
                rSendMail.sToAddress = s;
                rSendMail.sSubject = sSubject;
                rSendMail.sBody = sBody;
                rSendMail.bOnly = s != "";
                rSendMail.sKeyMan = lblNobrAppM.Text;
                rSendMail.dKeyDate = DateTime.Now;
                dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
            }

            var dtDeptm = JBHR.Dll.Bas.Deptm(rsAppS.First().sDept).FirstOrDefault();

            var rm = new wfFormApp();
            rm.sFormCode = lblTitle.ToolTip;
            rm.sFormName = lblTitle.Text;
            rm.sProcessID = lblProcessID.Text;
            rm.idProcess = Convert.ToInt32(rm.sProcessID);
            rm.sNobr = lblNobrAppM.Text;
            rm.sName = rBase.emp.name;
            rm.sDept = rBase.dept.id;
            rm.sDeptName = rBase.dept.name;
            rm.sJob = rBase.pos.id;
            rm.sJobName = rBase.pos.name;
            rm.sRole = rBase.role.id;
            rm.iCateOrder = dtDeptm != null ? Convert.ToInt32(dtDeptm.sDeptTree) : 0;    //被申請者的部門層級
            rm.bDelay = false;  //是否有延遲需要補單
            rm.dDateTimeA = DateTime.Now;
            rm.bAuth = Convert.ToBoolean(rBase.role.deptMg);
            rm.bSign = true;
            rm.sState = "1";
            rm.sReserve4 = Info;
            rm.sConditions1 = rm.iCateOrder.ToString().PadLeft(2, '0'); //目前所簽核到的部門
            rm.sConditions2 = lblNobrAppM.Text; //最後簽核的人
            rm.sConditions5 = dtDeptm.sSignGroup;
            rm.sInfo = Info;
            rm.sMailSubject = sSubject;
            rm.sMailBdoy = sBody;
            dcFlow.wfFormApp.InsertOnSubmit(rm);

            if (oService.FlowStart(rm.idProcess, lblFlowTreeID.Text, rsAppS.First().sRole, rsAppS.First().sNobr, lblRoleAppM.Text, lblNobrAppM.Text))
                x++;
        }

        if (x > 0)
        {
            dcForm.SubmitChanges();
            dcFlow.SubmitChanges();
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
        }
        else
        {
            lblMsg.Text = "流程傳送失敗";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        }
    }

    protected void txtDateA_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txt = sender as TextBox;
            var rAttend = JBHR.Dll.Att.Attend(lblNobr.Text, Convert.ToDateTime(txt.Text)).FirstOrDefault();
            if (rAttend != null)
            {
                var rRote = JBHR.Dll.Att.Rote(rAttend.sRoteCode).FirstOrDefault();
                if (rRote != null)
                {

                }
            }
        }
        catch { }
    }

    private void BindRotet()
    {
        ListItem li;

        ddlRotet.Items.Clear();

        var rs = JBHR.Dll.Att.Rotet("0");
        foreach (var r in rs)
        {
            li = new ListItem();
            li.Text = r.sRotet + "_" + r.sRotetName;
            li.Value = r.sRotet;
            ddlRotet.Items.Add(li);
        }
    }
}