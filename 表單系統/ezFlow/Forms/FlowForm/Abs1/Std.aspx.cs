using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Abs1_Std : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();
    private JBHR.Dll.dcBasDataContext dcBas;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblFlowTree.Text = Request.QueryString["idFlowTree"] != null ? Request.QueryString["idFlowTree"].ToUpper() : lblFlowTree.Text;
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

            ddlName.DataBind();
            ddlAgentName.DataBind();

            SetDefault();

            SetName(lblNobrAppM.Text);

            lblDateA.Text = DateTime.Now.ToShortDateString();

            if (ddlName.Items.Count > 0 && lblNobrAppM.Text != ddlName.SelectedItem.Value)
            {
                lblNobr.Text = ddlName.SelectedItem.Value;
                txtName.Text = ddlName.SelectedItem.Text;

                SetName(lblNobr.Text);
            }
            else
                SetName(lblNobrAppM.Text);
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        dcFlow = new dcFlowDataContext();
        lblFlowTreeID.Text = "62";
        lblTitle.ToolTip = "Abs1";
        (Page.Master as mpStd0990111).sFormCode = lblTitle.ToolTip;
        (Page.Master as mpStd0990111).sAppNobr = lblNobrAppM.Text;

        if ((Page.Master as mpStd0990111).FindControl("fvAppM") != null)
            (Page.Master as mpStd0990111).FindControl("fvAppM").Visible = false;

        var dtForm = from c in dcFlow.wfForm where c.sFormCode == lblTitle.ToolTip select c;

        if (dtForm.Any())
        {
            var rForm = dtForm.First();
            lblTitle.Text = rForm.sFormName;
            ddlName.Visible = rForm.bAgentApp;
            txtName.ReadOnly = !ddlName.Visible;

            var rBase = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();

            if (rBase != null)
            {
                ddlName.Visible = rBase.bMang1;
                txtName.ReadOnly = !rBase.bMang1;
            }
        }
    }

    //設定表單內容的相關預設值
    private void SetBaseData(string sNobr)
    {
        var rEmpBase = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
        if (rEmpBase != null)
        {
            var rDept = JBHR.Dll.Bas.Deptm(rEmpBase.sDeptmCode).FirstOrDefault();
            if (rDept != null)
                lblDept.Text = rDept.sDeptName + "(" + rDept.sDeptCode + ")";

            var rJob = JBHR.Dll.Bas.Job().Where(p => p.sJobCode == rEmpBase.sJobCode).FirstOrDefault();
            if (rJob != null)
                lblJob.Text = rJob.sJobName + "(" + rJob.sJobCode + ")";

            txtDateB.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtDateE.Text = txtDateB.Text;

            //ddlDeptA.DataBind();

            //取消自動帶出，由使用者自行挑選 by 20110505 正青
            //if (ddlDeptA.Items.FindByValue(rEmpBase.sDeptsCode) != null)
            //    ddlDeptA.Items.FindByValue(rEmpBase.sDeptsCode).Selected = true;
        }
    }

    #region 工號及姓名
    //被申請人
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
        }
        else
            txtName.Text = txtName.ToolTip;

        SetBaseData(lblNobr.Text);
    }
    private void SetName(string sNobr)
    {
        dcFlow = new dcFlowDataContext();

        var r = (from c in dcFlow.Emp
                 where c.id == sNobr
                 select c).FirstOrDefault();

        if (r != null)
        {
            lblNobr.Text = r.id;
            txtName.Text = r.name;
            txtName.ToolTip = txtName.Text;
        }
        else
            txtName.Text = txtName.ToolTip;

        SetBaseData(lblNobr.Text);
    }

    //代理人
    protected void ddlAgentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlAgentName = sender as DropDownList;
        if (ddlAgentName != null && ddlAgentName.Items.Count > 0)
        {
            ListItem li = ddlAgentName.SelectedItem;
            SetAgentName(li);
        }
    }
    protected void ddlAgentName_DataBound(object sender, EventArgs e)
    {
        if (ddlAgentName.Items.FindByValue(lblNobr.Text) != null)
            ddlAgentName.Items.Remove(lblNobr.Text);

        //string[] sTtsCode = { "2", "3", "5" };

        //dcBas = new JBHR.Dll.dcBasDataContext();
        //var dtBas = from c in dcBas.JB_HR_BaseTts
        //            where sTtsCode.Contains(c.sTtsCode)
        //            select c;

        //var lsBas = dtBas.ToList();

        //foreach(var r in lsBas)
        //    if (ddlAgentName.Items.FindByValue(r.sNobr) != null)
        //        ddlAgentName.Items.Remove(r.sNobr);

    }
    protected void txtAgentName_TextChanged(object sender, EventArgs e)
    {
        TextBox txtAgentName = sender as TextBox;
        if (txtAgentName != null)
        {
            txtAgentName.Text = txtAgentName.Text.ToUpper();
            ListItem li = ddlAgentName.Items.FindByValue(txtAgentName.Text);
            li = li != null ? li : ddlAgentName.Items.FindByText(txtAgentName.Text);
            SetAgentName(li);
        }
    }
    private void SetAgentName(ListItem li)
    {
        if (li != null)
        {
            ddlAgentName.ClearSelection();
            li.Selected = true;
            lblAgentNobr.Text = li.Value;
            txtAgentName.Text = li.Text;
            txtAgentName.ToolTip = txtAgentName.Text;
        }
        else
            txtAgentName.Text = txtAgentName.ToolTip;
    }
    private void SetAgentName(string sNobr)
    {
        dcFlow = new dcFlowDataContext();

        var r = (from c in dcFlow.Emp
                 where c.id == sNobr
                 select c).FirstOrDefault();

        if (r != null)
        {
            lblAgentNobr.Text = r.id;
            txtAgentName.Text = r.name;
            txtAgentName.ToolTip = txtAgentName.Text;
        }
        else
            txtAgentName.Text = txtAgentName.ToolTip;
    }
    #endregion

    #region 各廠聯絡人 工作項目
    protected void btnFactoryContactAdd_Click(object sender, EventArgs e)
    {
        dcFlow = new dcFlowDataContext();

        var r = new wfFormAppCode();
        r.sFormCode = lblTitle.ToolTip;
        r.sFormName = lblTitle.Text;
        r.sCategory = "Abs1FactoryContact";
        r.sProcessID = lblProcessID.Text;
        r.idProcess = 0;
        r.sNobr = lblNobr.Text;
        r.sKey = "";
        r.sCode = "";
        r.sName = "";
        r.sContent = txtFactoryContact.Text;
        r.dKeyDate = DateTime.Now;

        dcFlow.wfFormAppCode.InsertOnSubmit(r);
        dcFlow.SubmitChanges();

        gvFactoryContact.DataBind();
    }
    #endregion

    #region 待辦事項
    protected void btnTransactAdd_Click(object sender, EventArgs e)
    {
        dcFlow = new dcFlowDataContext();

        var r = new wfFormAppCode();
        r.sFormCode = lblTitle.ToolTip;
        r.sFormName = lblTitle.Text;
        r.sCategory = "Abs1Transact";
        r.sProcessID = lblProcessID.Text;
        r.idProcess = 0;
        r.sNobr = lblNobr.Text;
        r.sKey = "";
        r.sCode = ddlTransact.SelectedItem.Value;
        r.sName = ddlTransact.SelectedItem.Text;
        r.sContent = txtTransact.Text;
        r.dKeyDate = DateTime.Now;

        dcFlow.wfFormAppCode.InsertOnSubmit(r);
        dcFlow.SubmitChanges();

        gvTransact.DataBind();
    }
    #endregion

    #region 出差地點
    protected void btnPlace1Add_Click(object sender, EventArgs e)
    {
        if (ddlPlace1.SelectedItem.Value == "0")
        {
            lblMsg.Text = "請選擇正確的預定前往地點";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        dcFlow = new dcFlowDataContext();

        var r = new wfFormAppCode();
        r.sFormCode = lblTitle.ToolTip;
        r.sFormName = lblTitle.Text;
        r.sCategory = "Place1";
        r.sProcessID = lblProcessID.Text;
        r.idProcess = 0;
        r.sNobr = lblNobr.Text;
        r.sKey = "";
        r.sCode = ddlPlace1.SelectedItem.Value;
        r.sName = ddlPlace1.SelectedItem.Text;
        r.sContent = txtPlace1.Text;
        r.dKeyDate = DateTime.Now;

        dcFlow.wfFormAppCode.InsertOnSubmit(r);
        dcFlow.SubmitChanges();

        gvPlace1.DataBind();
    }
    #endregion

    //匯率轉換
    protected void btnRate_Click(object sender, EventArgs e)
    {
        webservicex.CurrencyConvertor oCurrencyConvertor = new webservicex.CurrencyConvertor();

        //txtRate.Text = Convert.ToString(oCurrencyConvertor.ConversionRate((webservicex.Currency)Enum.Parse(typeof(webservicex.Currency), "TWD"), webservicex.Currency.JPY));
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

        if (txtAgentName.Text.Trim().Length == 0)
        {
            lblMsg.Text = "代理人為必填欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (rblInOut.SelectedItem == null)
        {
            lblMsg.Text = "出差類別為必選欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        dcFlow = new dcFlowDataContext();
        dcForm = new dcFormDataContext();

        var dtBaseM = from role in dcFlow.Role
                      join emp in dcFlow.Emp on role.Emp_id equals emp.id
                      join dept in dcFlow.Dept on role.Dept_id equals dept.id
                      join pos in dcFlow.Pos on role.Pos_id equals pos.id
                      where role.Emp_id == lblNobrAppM.Text
                      select new { role, emp, dept, pos };
        var dtBaseS = from role in dcFlow.Role
                      join emp in dcFlow.Emp on role.Emp_id equals emp.id
                      join dept in dcFlow.Dept on role.Dept_id equals dept.id
                      join pos in dcFlow.Pos on role.Pos_id equals pos.id
                      where role.Emp_id == lblNobr.Text
                      select new { role, emp, dept, pos };

        var rEmpBaseM = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
        var rEmpBaseS = JBHR.Dll.Bas.EmpBase(lblNobr.Text).FirstOrDefault();

        if (!dtBaseM.Any() || !dtBaseS.Any() || rEmpBaseM == null || rEmpBaseS == null)
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        lblProcessID.ToolTip = lblProcessID.Text;

        var rBaseM = dtBaseM.First();
        var rBaseS = dtBaseS.First();

        //出差地
        var dtPlace1 = from c in dcFlow.wfFormAppCode
                       where c.sProcessID == lblProcessID.ToolTip
                       && c.sCategory == "Place1"
                       select c;

        if (!dtPlace1.Any())
        {
            lblMsg.Text = "出差地，至少新增一筆資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //各廠聯絡人(FactoryContact)
        var dtFactoryContact = from c in dcFlow.wfFormAppCode
                               where c.sProcessID == lblProcessID.ToolTip
                               && c.sCategory == "Abs1FactoryContact"
                               select c;

        if (!dtFactoryContact.Any())
        {
            lblMsg.Text = "工作項目，至少新增一筆資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //總務聯絡人(GeneralContact)
        //var dtGeneralContact = from c in dcFlow.wfFormAppCode
        //                       where c.sProcessID == lblProcessID.ToolTip
        //                       && c.sCategory == "Abs1GeneralContact"
        //                       select c;

        //if (!dtGeneralContact.Any())
        //{
        //    lblMsg.Text = "總務聯絡人，至少新增一筆資料";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        //會計聯絡人(AccountantContact)
        //var dtAccountantContact = from c in dcFlow.wfFormAppCode
        //                          where c.sProcessID == lblProcessID.ToolTip
        //                          && c.sCategory == "Abs1AccountantContact"
        //                          select c;

        //旅行社聯絡人(TravelContact)
        //var dtTravelContact = from c in dcFlow.wfFormAppCode
        //                      where c.sProcessID == lblProcessID.ToolTip
        //                      && c.sCategory == "Abs1TravelContact"
        //                      select c;

        localhost.Service oService = new localhost.Service();

        //流程從這裡開始
        lblProcessID.Text = oService.GetProcessID().ToString();

        //出差類別
        var rErrandType = new wfFormAppCode();
        rErrandType.sFormCode = lblTitle.ToolTip;
        rErrandType.sFormName = lblTitle.Text;
        rErrandType.sCategory = "Abs1ErrandType";
        rErrandType.sProcessID = lblProcessID.Text;
        rErrandType.idProcess = Convert.ToInt32(rErrandType.sProcessID);
        rErrandType.sNobr = lblNobr.Text;
        rErrandType.sKey = "";
        rErrandType.sCode = ddlErrandType.SelectedItem.Value;
        rErrandType.sName = ddlErrandType.SelectedItem.Text;
        rErrandType.sContent = txtErrandType.Text;
        rErrandType.dKeyDate = DateTime.Now;
        dcFlow.wfFormAppCode.InsertOnSubmit(rErrandType);

        //代辦事項(Transact)、地點(Place1)
        var dtFormAppCode = from c in dcFlow.wfFormAppCode
                            where c.sProcessID == lblProcessID.ToolTip
                            select c;
        foreach (var r in dtFormAppCode)
        {
            r.sProcessID = lblProcessID.Text;
            r.idProcess = Convert.ToInt32(r.sProcessID);
        }

        //暫支款
        var dtCurrency = from c in dcForm.wfAppAbs1Currency
                         where c.sProcessID == lblProcessID.ToolTip
                         select c;
        foreach (var r in dtCurrency)
        {
            r.sProcessID = lblProcessID.Text;
            r.idProcess = Convert.ToInt32(r.sProcessID);
            r.sState = "1";
        }

        TimeSpan ts;

        //try
        //{
        //    if (dtCurrency.Count() > 0)
        //    {
        //        decimal iAmount = dtCurrency.Sum(p => p.iAmount * p.iRate);
        //        decimal iRuleSum = 0;

        //        DateTime dDateB = Convert.ToDateTime(txtDateB.Text);
        //        DateTime dDateE = Convert.ToDateTime(txtDateE.Text);

        //        ts = dDateE - dDateB;

        //        if (Convert.ToInt32(rEmpBaseS.sJoblCode) >= 6)
        //            iRuleSum = (ts.Days + 1) * 6000;
        //        else if (Convert.ToInt32(rEmpBaseS.sJoblCode) >= 4)
        //            iRuleSum = (ts.Days + 1) * 3000;
        //        else if (Convert.ToInt32(rEmpBaseS.sJoblCode) >= 1)
        //            iRuleSum = (ts.Days + 1) * 2400;
        //        else
        //            iRuleSum = (ts.Days + 1) * 1500;

        //        if (iRuleSum < iAmount)
        //        {
        //            lblProcessID.Text = lblProcessID.ToolTip;
        //            lblMsg.Text = "您已超過申請的日支費總額，請修正金額，或是勾選無條件送出傳簽";
        //            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //            return;
        //        }
        //    }
        //}
        //catch
        //{
        //    lblProcessID.Text = lblProcessID.ToolTip;
        //    lblMsg.Text = "日期格式不正確，請重新輸入";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        //機票訂購
        var dtTicket = from c in dcForm.wfAppAbs1Ticket
                       where c.sProcessID == lblProcessID.ToolTip
                       select c;
        foreach (var r in dtTicket)
        {
            r.sProcessID = lblProcessID.Text;
            r.idProcess = Convert.ToInt32(r.sProcessID);
            r.sState = "1";
        }

        if (txtTimeB.Text.Trim().Length != 4 || txtTimeE.Text.Trim().Length != 4)
        {
            lblMsg.Text = "請輸入開始與結束時間";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        try
        {
            if (dtTicket.Count() == 0)
            {
                //lblProcessID.Text = lblProcessID.ToolTip;
                //lblMsg.Text = "一定要訂購機票";
                //ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                //return;
            }
            if (dtTicket.Count() > 0)
            {
                DateTime dDateB = Convert.ToDateTime(txtDateB.Text);
                DateTime dDateE = Convert.ToDateTime(txtDateE.Text);

                if (dtTicket.Where(p => p.dDateB.Date < dDateB.Date || p.dDateE.Value.Date > dDateE.Date).Count() > 0)
                {
                    lblProcessID.Text = lblProcessID.ToolTip;
                    lblMsg.Text = "機票訂購的去回程日期只可以在預定起訖日期裡面";
                    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                    return;
                }
            }
        }
        catch
        {
            lblProcessID.Text = lblProcessID.ToolTip;
            lblMsg.Text = "日期格式不正確，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var dtDeptm = JBHR.Dll.Bas.Deptm(rBaseS.dept.id).FirstOrDefault();

        var rm = new wfFormApp();
        rm.sFormCode = lblTitle.ToolTip;
        rm.sFormName = lblTitle.Text;
        rm.sProcessID = lblProcessID.Text;
        rm.idProcess = Convert.ToInt32(rm.sProcessID);
        rm.sNobr = lblNobrAppM.Text;
        rm.sName = rBaseM.emp.name;
        rm.sDept = rBaseM.dept.id;
        rm.sDeptName = rBaseM.dept.name;
        rm.sJob = rBaseM.pos.id;
        rm.sJobName = rBaseM.pos.name;
        rm.sJobl = rEmpBaseM.sJoblCode;
        rm.sRole = rBaseM.role.id;
        rm.sDI = rEmpBaseM.sDI;
        rm.iCateOrder = dtDeptm != null ? Convert.ToInt32(dtDeptm.sDeptTree) : 0;    //被申請者的部門層級
        rm.bDelay = false;  //是否有延遲需要補單
        rm.dDateTimeA = DateTime.Now;
        rm.bAuth = Convert.ToBoolean(rBaseM.role.deptMg);
        rm.bSign = true;
        rm.sState = "1";
        rm.sConditions1 = rm.iCateOrder.ToString(); //目前所簽核到的部門
        rm.sConditions2 = lblNobr.Text; //簽核主管
        rm.sConditions4 = dtDeptm.sSignGroup;   //1類型的群組只要簽到75
        rm.sConditions5 = rblInOut.SelectedItem.Value;  //如果是國外出差才需要上呈總經理
        dcFlow.wfFormApp.InsertOnSubmit(rm);
       
        try
        {
            var rs = new wfAppAbs1();
            rs.sFormCode = lblTitle.ToolTip;
            rs.sProcessID = lblProcessID.Text;
            rs.idProcess = Convert.ToInt32(rs.sProcessID);
            rs.sNobr = lblNobr.Text;
            rs.sName = txtName.Text;
            rs.sDept = rBaseS.dept.id;
            rs.sDeptName = rBaseS.dept.name;
            rs.sJob = rBaseS.pos.id;
            rs.sJobName = rBaseS.pos.name;
            rs.sJobl = rEmpBaseS.sJoblCode;
            rs.sRole = rBaseS.role.id;
            rs.sDI = rEmpBaseS.sDI;
            rs.sRote = rEmpBaseS.sRotet;
            rs.dDateB = Convert.ToDateTime(txtDateB.Text);
            rs.dDateE = Convert.ToDateTime(txtDateE.Text);
            rs.sTimeB = txtTimeB.Text;
            rs.sTimeE = txtTimeE.Text;
            rs.dDateTimeB = rs.dDateB.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeB, true));
            rs.dDateTimeE = rs.dDateE.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeE, false));

            if (rs.dDateTimeB >= rs.dDateTimeE)
            {
                lblProcessID.Text = lblProcessID.ToolTip;
                lblMsg.Text = "開始日期不可以比結束日期大";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }

            rs.dDateB1 = Convert.ToDateTime(txtDateB.Text);
            rs.dDateE1 = Convert.ToDateTime(txtDateE.Text);
            rs.sTimeB1 = txtTimeB.Text;
            rs.sTimeE1 = txtTimeE.Text;
            rs.dDateTimeB1 = rs.dDateB.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeB, true));
            rs.dDateTimeE1 = rs.dDateE.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeE, false));
            rs.sHcode = "223caecc-c03d-4eaf-a00e-c3fbedd43a41";
            rs.sHname = "出差";
            ts = rs.dDateTimeE - rs.dDateTimeB;
            rs.iDay = ts.Days + 1;
            rs.iHour = 0;
            rs.iTotalDay = rs.iDay;
            rs.iTotalHour = 0;
            rs.bExceptionHour = false;
            rs.iExceptionHour = 0;
            rs.iDay1 = ts.Days + 1;
            rs.iHour1 = 0;
            rs.iTotalDay1 = rs.iDay1;
            rs.iTotalHour1 = 0;
            rs.sSalYYMM = "";
            rs.bSign = true;
            rs.sState = "1";
            rs.sAgentNobr = lblAgentNobr.Text;
            rs.sAgentName = txtAgentName.Text;
            rs.bAuth = Convert.ToBoolean(rBaseS.role.deptMg);
            rs.sWork = "";//主要工作項目
            rs.sCode2 = rblInOut.SelectedItem.Value;    //國內外出差
            rs.sName2 = rblInOut.SelectedItem.Text;
            rs.sCode3 = ddlErrandType.SelectedItem.Value;
            rs.sName3 = ddlErrandType.SelectedItem.Text;
            rs.sReserve1 = txtErrandType.Text;
            rs.sNote = "";
            rs.dKeyDate = DateTime.Now;
            dcForm.wfAppAbs1.InsertOnSubmit(rs);

            rs.sInfo = rs.sName + "," + rs.sHname + "," + rs.dDateB.ToShortDateString() + "," + rs.sTimeB + "," + rs.dDateE.ToShortDateString() + "," + rs.sTimeE + "," + rs.sNote;
            rm.sReserve4 = rs.sInfo;
            rm.sInfo = rs.sInfo;

            List<string> lsAgentMail = new List<string>();
            lsAgentMail.Add("");    //給主管審核用

            string sSubject = "【通知】(" + rs.sNobr + ")" + rs.sName + " 之出差單，請進入系統簽核";
            string sAgengSubject = "【通知】(" + rs.sNobr + ")" + rs.sName + " 之出差單，您是他的代理人";
            string sBody = MessageSendMail.AbsBody(rs.sNobr, rs.sName, rs.sDeptName, rs.sHname, rs.dDateB, rs.sTimeB, rs.dDateE, rs.sTimeE, rs.iDay > 0 ? rs.iDay : rs.iHour, rs.sUnit, rs.sNote , rs.sAgentNote);

            rs.sMailBody = sBody;
            rm.sMailSubject = sSubject;
            rm.sMailBdoy = sBody;

            //發信通知代理人
            var rsAppAgent = (from c in dcForm.wfAppAgent
                              where c.sNobr == rs.sNobr
                              select c).ToList();

            foreach (var rAppAgent in rsAppAgent)
                if (rAppAgent.sAgentMail.Trim().Length > 0)
                    lsAgentMail.Add(rAppAgent.sAgentMail);

            if (rs.sAgentNobr != null && rs.sAgentNobr.Trim().Length > 0)
            {
                var rAgent = (from c in dcFlow.Emp
                              where c.id == rs.sAgentNobr.Trim()
                              select c).FirstOrDefault();

                if (rAgent != null && rAgent.email.Trim().Length > 0)
                    lsAgentMail.Add(rAgent.email);
            }

            foreach (var s in lsAgentMail)
            {
                var rSendMail = new wfSendMail();
                rSendMail.sProcessID = lblProcessID.Text;
                rSendMail.idProcess = Convert.ToInt32(rSendMail.sProcessID);
                rSendMail.sGuid = Guid.NewGuid().ToString();
                rSendMail.sToAddress = s;
                rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                rSendMail.sBody = sBody;
                rSendMail.bOnly = s != "";
                rSendMail.sKeyMan = lblNobrAppM.Text;
                rSendMail.dKeyDate = DateTime.Now;
                dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
            }
        }
        catch (Exception ex)
        {
            lblProcessID.Text = lblProcessID.ToolTip;
            lblMsg.Text = "日期轉換錯誤，請重新檢查格式是否輸入正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        dcForm.SubmitChanges();
        dcFlow.SubmitChanges();

        if (oService.FlowStart(rm.idProcess, lblFlowTreeID.Text, rBaseS.role.id, rBaseS.role.Emp_id, rBaseM.role.id, rBaseM.role.Emp_id))
        {
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
        }
    }
}