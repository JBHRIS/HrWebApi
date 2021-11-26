using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBHR.Dll;

public partial class Card_Std : System.Web.UI.Page
{
    private bool isTest = false;

    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號

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

            ddlName.DataBind();
            SetDefault();

            //ddlName.Visible = ddlName.Visible || isManage;

            SetName(lblNobrAppM.Text);

            if (ddlName.Items.Count > 0 && lblNobrAppM.Text != ddlName.SelectedItem.Value)
            {
                lblNobr.Text = ddlName.SelectedItem.Value;
                txtName.Text = ddlName.SelectedItem.Text;

                SetName(lblNobr.Text);
            }
            else
                SetName(lblNobrAppM.Text);

            if (lblNobrAppM.Text.Trim().Length == 0 || ddlName.Items.Count == 0)
            {
                ddlName.Enabled = false;
                txtName.Enabled = false;
                btnAdd.Enabled = false;
            }

            txtDate.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        lblFlowTreeID.Text = "60";
        lblTitle.ToolTip = "Card";
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
        var rEmpBaseM = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
        var rEmpBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text).FirstOrDefault();

        //申請人是間接人員僅可幫自己申請或外勞申請
        if (lblNobrAppM.Text != lblNobr.Text)
        {
            if (rEmpBaseM != null && rEmpBase != null)
            {
                if (rEmpBaseM.bCountMa || rEmpBase.bCountMa == false)
                {
                    lblMsg.Text = "您僅可幫自己申請表單";
                    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                    return;
                }
            }
        }

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

        DateTime dDate = DateTime.Now;
        if (!DateTime.TryParse(txtDate.Text, out dDate))
        {
            lblMsg.Text = "日期格式不正確，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        string sNobr = lblNobr.Text.Trim();

        var rEmpBaseS = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();

        bool bSalaryLock = false;   //關帳鎖檔
        bool bAtt = false;  //出勤資料

        if (JBHR.Dll.Bas.IsDataPaB(dDate.Date, rEmpBaseS.sSaladr))
            bSalaryLock = true;

        if (bSalaryLock)
        {
            lblMsg.Text = "您所申請的日期已經關帳鎖檔，請洽人事單位(提示)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //檢查重複的資料
        var dtAppS = from c in dcForm.wfAppCard
                     where (c.sProcessID == lblProcessID.Text || (c.idProcess != 0 && c.sState == "1"))
                     && c.dDate.Date == dDate
                     && c.sTime == txtTime.Text.Trim()
                     && c.sNobr == lblNobr.Text
                     select c;

        if (dtAppS.Any())
        {
            lblMsg.Text = "資料重複或流程正在進行中，請先刪除申請資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        int iTime = 0;

        if (txtTime.Text.Trim().Length != 4)
        {
            lblMsg.Text = "時間格式不正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (!int.TryParse(txtTime.Text.Trim(), out iTime))
        {
            lblMsg.Text = "時間格式不正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (iTime >= 2400)
        {
            lblMsg.Text = "刷卡時間是採用24小時制，請輸入正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (JBHR.Dll.Att.CardCheck.IsRepeatTime(lblNobr.Text, dDate, txtTime.Text))
        {
            lblMsg.Text = "人事單位已有重複的資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var dtBase = from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == lblNobr.Text
                     select new { role, emp, dept, pos };

        if (!dtBase.Any())
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var rBase = dtBase.First();

        var rs = new wfAppCard();
        rs.sFormCode = lblTitle.ToolTip;
        rs.sProcessID = lblProcessID.Text;
        rs.idProcess = 0;
        rs.sNobr = lblNobr.Text;
        rs.sName = txtName.Text;
        rs.sDept = rBase.dept.id;
        rs.sDeptName = rBase.dept.name;
        rs.sJob = rBase.pos.id;
        rs.sJobName = rBase.pos.name;
        rs.sRole = rBase.role.id;
        rs.sDI = rEmpBase.sDI;
        rs.sRote = rEmpBase.sRotet;
        rs.dDate = Convert.ToDateTime(txtDate.Text);
        rs.sTime = txtTime.Text;
        rs.dDateTime = rs.dDate.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTime));
        rs.sReasonCode = ddlReason.SelectedItem.Value;
        rs.sReasonName = ddlReason.SelectedItem.Text;
        rs.bSign = true;
        rs.sState = "0";
        rs.bAuth = Convert.ToBoolean(rBase.role.deptMg);
        rs.sNote = txtNote.Text;
        rs.dKeyDate = DateTime.Now;
        rs.sCode1 = JBHR.Dll.Bas.GetDeptmManage(rs.sNobr, "");
        var rEmp = (from c in dcFlow.Emp
                    where c.id == rs.sCode1
                    select c).FirstOrDefault();

        if (rEmp != null && rEmp.email.Trim().Length > 0)
            rs.sName1 = rEmp.email.Trim();
        rs.sInfo = rs.sName + "," + rs.dDate.ToShortDateString() + "," + rs.sTime + ","  + rs.sNote;
        rs.sMailBody = MessageSendMail.CardBoy(rs.sNobr, rs.sName, rs.sDeptName, rs.dDate, rs.sTime, rs.sNote);
        dcForm.wfAppCard.InsertOnSubmit(rs);

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
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
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

        if (!dtBase.Any())
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        lblProcessID.ToolTip = lblProcessID.Text;

        var rBase = dtBase.First();

        var dtAppS = from c in dcForm.wfAppCard
                     where c.sProcessID == lblProcessID.ToolTip
                     select c;

        var lsAppS = dtAppS.GroupBy(c => new { c.sNobr });

        localhost.Service oService = new localhost.Service();


        int x = 0, y = 0;
        foreach (var rsAppS in lsAppS)
        {
            List<string> lsAgentMail = new List<string>();
            lsAgentMail.Add("");    //給主管審核用

            string sSubject = "【通知】(" + rsAppS.First().sNobr + ")" + rsAppS.First().sName + " 之忘刷單，請進入系統簽核";
            string sBody = "";

            //流程從這裡開始
            lblProcessID.Text = oService.GetProcessID().ToString();
            string Info = "";
            foreach (var rs in dtAppS)
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

            var dtDeptm = JBHR.Dll.Bas.Deptm( rBase.dept.id).FirstOrDefault();

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
            rm.sConditions5 = dtDeptm.sSignGroup;
            rm.sInfo = Info;
            rm.sMailSubject = sSubject;
            rm.sMailBdoy = sBody;
            dcFlow.wfFormApp.InsertOnSubmit(rm);

            if (!isTest)
            {
                dcForm.SubmitChanges();
                dcFlow.SubmitChanges();

                if (oService.FlowStart(rm.idProcess, lblFlowTreeID.Text, rsAppS.First().sRole, rsAppS.First().sNobr, lblRoleAppM.Text, lblNobrAppM.Text))
                    x++;
            }
        }

        if (x > 0)
        {
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
        }
        else
        {
            lblMsg.Text = "流程傳送失敗";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            lblProcessID.Text = lblProcessID.ToolTip;
        }
    }
}