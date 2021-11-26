using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_Std : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
            txtDateD.Text = DateTime.Now.ToString("yyyy/MM/dd");

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

            SetDefault();

            SetName(lblNobrAppM.Text);
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        lblFlowTreeID.Text = "78";
        lblTitle.ToolTip = "Form";
        (Page.Master as mpStd0990111).sFormCode = lblTitle.ToolTip;
        (Page.Master as mpStd0990111).sAppNobr = lblNobrAppM.Text;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
            ddlName.Visible = rForm.bAgentApp;
            txtName.ReadOnly = !ddlName.Visible;
            txtNote.CausesValidation = rForm.bNote;
            gvAppS.ToolTip = rForm.iAppCount.ToString();
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

            //到職日期
            JBHR.Dll.dsBas.JB_HR_BaseDataTable dtBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text);
            if (dtBase.Rows.Count > 0)
                lblDateIn.Text = dtBase.FirstOrDefault().dInDate.ToShortDateString();
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

            //到職日期
            JBHR.Dll.dsBas.JB_HR_BaseDataTable dtBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text);
            if (dtBase.Rows.Count > 0)
                lblDateIn.Text = dtBase.FirstOrDefault().dInDate.ToShortDateString();
        }
        else
            txtName.Text = txtName.ToolTip;
    }
    #endregion

    protected void ddlForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlForm = sender as DropDownList;
        if (ddlForm != null)
            txtForm.Visible = ddlForm.SelectedItem.Value == "0";
    }

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

        if (ddlForm.SelectedItem.Value == "0" && txtForm.Text.Trim().Length == 0)
        {
            lblMsg.Text = "您沒有輸入申請單文件名稱";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //檢查重複的資料
        var dtAppS = from c in dcForm.wfAppForm
                     where (c.sProcessID == lblProcessID.Text || (c.idProcess != 0 && c.sState == "1"))
                     && c.sNobr == lblNobr.Text
                     && c.sNameF == (ddlForm.SelectedItem.Value == "0" ? txtForm.Text : ddlForm.SelectedItem.Text)
                     select c;

        if (dtAppS.Any())
        {
            lblMsg.Text = "資料重複或流程正在進行中，請先刪除申請資料";
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

        var rs = new wfAppForm();
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
        rs.sCodeF = ddlForm.SelectedItem.Value;
        rs.sNameF = rs.sCodeF == "0" ? txtForm.Text : ddlForm.SelectedItem.Text;
        rs.iPage = txtPage.Text.Trim().Length == 0 ? 1 : Convert.ToInt32(txtPage.Text);
        rs.dDateIn = Convert.ToDateTime(lblDateIn.Text).Date;
        rs.dDateD = Convert.ToDateTime(txtDateD.Text).Date;
        rs.bSign = true;
        rs.sState = "0";
        rs.bAuth = Convert.ToBoolean(rBase.role.deptMg);
        rs.sNote = txtNote.Text;
        rs.dKeyDate = DateTime.Now;
        rs.sInfo = rs.sName + "," + rs.sNameF + "," + rs.sNote;
        dcForm.wfAppForm.InsertOnSubmit(rs);

        dcForm.SubmitChanges();

        gvAppS.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
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

        var lsAppS = (from c in dcForm.wfAppForm
                      where c.sProcessID == lblProcessID.ToolTip 
                      select new { c.sDept, c.sRole }).ToList().Distinct();

        var dtAppS = from c in dcForm.wfAppForm
                     where c.sProcessID == lblProcessID.ToolTip 
                     select c;

        localhost.Service oService = new localhost.Service();

        int x = 0, y = 0;
        foreach (var rAppS in lsAppS)
        {
            string Info = "";
            //流程從這裡開始
            lblProcessID.Text = oService.GetProcessID().ToString();

            var dtAppSWhere = dtAppS.Where(p => p.sRole == rAppS.sRole);

            foreach (var rs in dtAppSWhere)
            {
                rs.sProcessID = lblProcessID.Text;
                rs.idProcess = Convert.ToInt32(rs.sProcessID);
                rs.sState = "1"; //開始

                //當角色不同時，就將資料寫入ProcessFlowShare
                if (Request["idRole_Start"] != rAppS.sRole)
                    oService.FlowShare(rs.idProcess, rAppS.sRole, rs.sNobr);

                y++;

                Info += rs.sInfo + "<BR>";
            }

            var dtDeptm = JBHR.Dll.Bas.Deptm(rAppS.sDept).FirstOrDefault();

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
            rm.sConditions1 = rm.iCateOrder.ToString(); //目前所簽核到的部門
            rm.sConditions5 = dtDeptm.sSignGroup;
            rm.sInfo = Info;
            dcFlow.wfFormApp.InsertOnSubmit(rm);

            if (oService.FlowStart(rm.idProcess, lblFlowTreeID.Text, rAppS.sRole, rm.sNobr, lblRoleAppM.Text, lblNobrAppM.Text))
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
}