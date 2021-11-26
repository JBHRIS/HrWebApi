using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JBHR.Dll;

public partial class Ot1_Std : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();
    private dcHRDataContext dcHR = new dcHRDataContext();

    private dsAtt.JB_HR_AttendDataTable dtAttend;
    private dsAtt.JB_HR_AttCardDataTable dtAttCard;
    private dsAtt.JB_HR_RoteDataTable dtRote;
    private dsAtt.JB_HR_AbsUnionDataTable dtAbs;
    private dsAtt.JB_HR_OtDataTable dtOt;

    private DataRow[] rows;
    private string Rote, RoteName, R, OnTime, OffTime, Time, T1, T2, T, tr, html;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
            txtDateB.Text = DateTime.Now.ToString("yyyy/MM/dd");

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
            ddlDepts.DataBind();

            SetDefault();

            //ddlName.Visible = ddlName.Visible || isManage;

            if (ddlName.Items.Count > 0 && lblNobrAppM.Text != ddlName.SelectedItem.Value)
            {
                lblNobr.Text = ddlName.SelectedItem.Value;
                txtName.Text = ddlName.SelectedItem.Text;

                SetName(lblNobr.Text);
            }
            else
                SetName(lblNobrAppM.Text);

            //var rsDept = JBHR.Dll.Bas.Deptm().Where(p => p.sDeptCode == lblDept.Text && p.sNobr == lblNobrAppM.Text);

            //ddlName.Visible = rEmp.bMang || rsDept.Any();
            //txtName.Enabled = rEmp.bMang || rsDept.Any();

            if (lblNobrAppM.Text.Trim().Length == 0 || ddlName.Items.Count == 0)
            {
                ddlName.Enabled = false;
                txtName.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        lblFlowTreeID.Text = "73";
        lblTitle.ToolTip = "Ot1";
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

            SetOtCat(li.Value);
            SetDepts(li.Value);
        }
        else
            txtName.Text = txtName.ToolTip;

        //txtDateB_TextChanged(null, null);

        DateTime dDate = DateTime.Now;
        if (!DateTime.TryParse(txtDateB.Text, out dDate))
            return;


        SetRote(lblNobr.Text, dDate);
        SetTime(lblNobr.Text, dDate);
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

            SetOtCat(sNobr);
            SetDepts(sNobr);
        }
        else
            txtName.Text = txtName.ToolTip;

        //txtDateB_TextChanged(null, null);

        DateTime dDate = DateTime.Now;
        if (!DateTime.TryParse(txtDateB.Text, out dDate))
            return;

        SetRote(lblNobr.Text, dDate);
        SetTime(lblNobr.Text, dDate);
    }
    #endregion

    private void SetOtCat(string sNobr)
    {
        ddlOtCat.Items.Clear();
        ddlOtCat.Items.Add(new ListItem("加班費", "1"));
        ddlOtCat.Items.Add(new ListItem("補休假", "2"));

        //ListItem li = new ListItem("加班費", "1");
        //var rEmpBaseS = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
        //if (rEmpBaseS.sDI == "D")
        //{
        //    ddlOtCat.Items.Add(li);
        //    ddlOtCat.Items.FindByValue(li.Value).Selected = true;
        //}
    }

    private void SetDepts(string sNobr)
    {
        var r = JBHR.Dll.Bas.BaseTts(sNobr).Where(p => p.dAdate.Date <= DateTime.Now.Date && DateTime.Now.Date <= p.dDdate.Date).FirstOrDefault();
        if (r != null)
        {
            ddlDepts.ClearSelection();
            if (ddlDepts.Items.FindByValue(r.sDeptsCode) != null)
                ddlDepts.Items.FindByValue(r.sDeptsCode).Selected = true;
        }
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
        string sNobr = lblNobr.Text.Trim();
        string sOtCat = ddlOtCat.SelectedItem.Value;
        string Otrcd = ddlOtrcd.SelectedItem.Value;
        string OtRote = ddlRote.SelectedItem.Value;
        var rEmpBaseS = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();

        if (rEmpBaseS == null)
        {
            lblMsg.Text = "員工資訊不正確，請洽HR單位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        bool bEat = ckEat.Checked;
        var rDeptm = JBHR.Dll.Bas.Deptm(rEmpBaseS.sDeptmCode).FirstOrDefault();

        if (rDeptm == null)
        {
            lblMsg.Text = "部門資訊不正確，請洽HR單位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
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

        DateTime dDateB = DateTime.Now;
        if (!DateTime.TryParse(txtDateB.Text, out dDateB))
        {
            lblMsg.Text = "日期格式不正確，請重新輸入(開始)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        string sTimeB, sTimeE;
        sTimeB = txtTimeB.Text.Trim();
        sTimeE = txtTimeE.Text.Trim();
        if (sTimeB.Length != 4 || sTimeE.Length != 4)
        {
            lblMsg.Text = "時間格式不正確，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        int iTimeB = JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB);
        int iTimeE = JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE);
        int iTemp;

        iTemp = (10 - (iTimeB % 10));
        iTimeB = iTemp == 10 ? iTimeB : iTimeB + iTemp;
        sTimeB = ConvertMinutesToHhMm(iTimeB);

        iTemp = iTimeE % 10;
        iTimeE -= iTemp;
        sTimeE = ConvertMinutesToHhMm(iTimeE);

        bool bSalaryLock = false;   //關帳鎖檔
        bool bAtt = false;  //出勤資料

        if (JBHR.Dll.Bas.IsDataPaB(dDateB.Date, rEmpBaseS.sSaladr))
            bSalaryLock = true;

        JBHR.Dll.dsAtt.JB_HR_RoteRow rRote = JBHR.Dll.Att.Rote(sNobr, dDateB.Date).FirstOrDefault();
        if (rRote == null)
            bAtt = true;
        else
            ddlRote.ToolTip = rRote.sRoteCode;  //把今天的班別記下來

        //if (bSalaryLock)
        //{
        //    lblMsg.Text = "您所申請的日期已經關帳鎖檔，請洽人事單位(提示)";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        if (bAtt)
        {
            lblMsg.Text = "您所申請的日期沒有排班資料，請通知人事單位幫您產生";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //帶出職稱中文名稱
        var rJob = (from c in dcFlow.Pos
                    where c.id == rEmpBaseS.sJobCode
                    select c).FirstOrDefault();

        if (rJob == null)
        {
            lblMsg.Text = "職稱不正確請洽HR單位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //計算整個月的加班時數及補休時數
        var rDataGroup = JBHR.Dll.Bas.DataGroup().Where(p => p.sDataGroup == rEmpBaseS.sSaladr).FirstOrDefault();
        if (rDataGroup == null)
        {
            lblMsg.Text = "資料群組錯誤，請洽人事單位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        int iSalaryDay = JBHR.Dll.Att.SalaryDay(rDataGroup.sComp);

        DateTime dDateB1, dDateE1;

        dDateB1 = new DateTime(dDateB.Year, dDateB.Month, 1);
        dDateE1 = new DateTime(dDateB.Year, dDateB.Month, DateTime.DaysInMonth(dDateB.Year, dDateB.Month));

        if (iSalaryDay < 31)
        {
            dDateE1 = new DateTime(dDateB.Year, dDateB.Month, iSalaryDay);
            dDateB1 = new DateTime(dDateE1.AddMonths(-1).Year, dDateE1.AddMonths(-1).Month, iSalaryDay + 1);

            if (dDateB.Day > iSalaryDay)
            {
                dDateE1 = dDateE1.AddMonths(1);
                dDateB1 = dDateB1.AddMonths(1);
            }
        }

        var rsOt = JBHR.Dll.Att.Ot(sNobr, dDateB1, dDateE1);

        decimal iOt = 0, iRes = 0;
        if (rsOt.Any())
        {
            iOt = rsOt.Sum(p => p.iOtHrs);
            iRes = rsOt.Sum(p => p.iRestHrs);
        }

        DateTime dDateTimeB, dDateTimeE;
        dDateTimeB = dDateB.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB));
        dDateTimeE = dDateB.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE));

        JBHR.Dll.dsAtt.JB_HR_OtrcdDataTable dtOtrcd = JBHR.Dll.Att.Otrcd(Otrcd);

        if (dtOtrcd.Rows.Count == 0)
        {
            lblMsg.Text = "加班原因不正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        JBHR.Dll.dsAtt.JB_HR_OtrcdRow rOtrcd = dtOtrcd.Rows[0] as JBHR.Dll.dsAtt.JB_HR_OtrcdRow;

        //不判斷上班時間 天然災害日 by ming 20120615
        if (!rOtrcd.bNoCalc)
        {
            if (JBHR.Dll.Att.OtCheck.IsWorkTime(sNobr, dDateTimeB, dDateB))
            {
                lblMsg.Text = "您的開始日期在當日的上班時間裡";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }

            if (JBHR.Dll.Att.OtCheck.IsWorkTime(sNobr, dDateTimeE, dDateB))
            {
                lblMsg.Text = "您的結束日期在當日的上班時間裡";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }
        }

        //檢查刷卡資料
        JBHR.Dll.dsAtt.JB_HR_RoteRow rR = JBHR.Dll.Att.Rote(sNobr, dDateB).FirstOrDefault();

        //判斷加班開始時間需小於上班時間且1個小時，非假日
        if (rR.sRoteCode != "00")
        {
            if (sTimeB.CompareTo(rR.sOnTime) < 0)
            {
                int iMin = JBHR.Dll.Tools.ConvertHhMmToMinutes(rR.sOnTime) - JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB);
                if (iMin < 60)
                {
                    lblMsg.Text = "您提前加班時數必須大於1個小時";
                    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                    return;
                }
            }
        }

        JBHR.Dll.dsAtt.JB_HR_AttCardRow rAttCard = JBHR.Dll.Att.AttCard(lblNobr.Text, dDateB.Date).FirstOrDefault();

        //檢查重複的資料
        var dtAppS = from c in dcForm.wfAppOt1
                     where (c.sProcessID == lblProcessID.Text || (c.idProcess != 0 && c.sState == "1"))
                     && c.sNobr == sNobr
                     && c.dDateTimeB <= dDateTimeE && c.dDateTimeE >= dDateTimeB
                     select c;

        if (dtAppS.Any())
        {
            lblMsg.Text = "資料重複或流程正在進行中，請先刪除申請資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (JBHR.Dll.Att.OtCheck.IsRepeatData(sNobr, dDateTimeB, dDateTimeE))
        {
            lblMsg.Text = "人事單位已有重複的資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //if (JBHR.Dll.Att.OtCheck.IsRepeatData1(sNobr, dDateTimeB, dDateTimeE))
        //{
        //    lblMsg.Text = "人事單位已有重複的資料";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        var dtBase = from role in dcFlow.Role
                     join emp in dcFlow.Emp on role.Emp_id equals emp.id
                     join dept in dcFlow.Dept on role.Dept_id equals dept.id
                     join pos in dcFlow.Pos on role.Pos_id equals pos.id
                     where role.Emp_id == sNobr
                     select new { role, emp, dept, pos };

        if (!dtBase.Any())
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        JBHR.Dll.Att.OtCal.OtDetail oOtDetail = JBHR.Dll.Att.OtCal.CalculationOt(sNobr, (rOtrcd.bNoCalc ? "00" : OtRote), dDateB.Date, sTimeB, sTimeE, bEat);

        var rOtRate = JBHR.Dll.Att.OtRate(rEmpBaseS.sCalOt).FirstOrDefault();

        decimal iOtUnit = Convert.ToDecimal(rOtRate.iOtUnit) / 60M;

        if (oOtDetail.iHour == 0)
        {
            lblMsg.Text = "加班時數必須大於0";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var rBase = dtBase.First();

        var rs = new wfAppOt1();
        rs.sFormCode = lblTitle.ToolTip;
        rs.sProcessID = lblProcessID.Text;
        rs.idProcess = 0;
        rs.sNobr = sNobr;
        rs.sName = txtName.Text;
        rs.sDept = rBase.dept.id;
        rs.sDeptName = rBase.dept.name;
        rs.sJob = rBase.pos.id;
        rs.sJobName = rBase.pos.name;
        rs.sJobl = rEmpBaseS.sJoblCode;
        rs.sEmpcd = rEmpBaseS.sEmpcd;
        rs.sRole = rBase.role.id;
        rs.sDI = rEmpBaseS.sDI;
        rs.sRote = ddlRote.ToolTip; //今天班別
        rs.dDateB = dDateB;
        rs.dDateE = dDateB;
        rs.sTimeB = sTimeB;
        rs.sTimeE = sTimeE;
        rs.dDateTimeB = dDateTimeB;
        rs.dDateTimeE = dDateTimeE;
        rs.sOtDeptCode = ddlDepts.SelectedItem.Value;
        rs.sOtDeptName = ddlDepts.SelectedItem.Text;
        rs.sOtcatCode = ddlOtCat.SelectedItem.Value;
        rs.sOtcatName = ddlOtCat.SelectedItem.Text;
        rs.sOtrcdCode = ddlOtrcd.SelectedItem.Value;
        rs.sOtrcdName = ddlOtrcd.SelectedItem.Text;
        rs.sRoteCode = ddlRote.SelectedItem.Value;
        rs.sRoteName = ddlRote.SelectedItem.Text;
        rs.iTotalHour = oOtDetail.iHour;
        rs.bExceptionHour = ckEat.Checked;  //沒有用餐或沒有休息
        rs.iExceptionHour = 0;
        rs.sSalYYMM = JBHR.Dll.Att.SetYYMM(dDateB, "2", 1, rEmpBaseS.sSaladr);
        rs.bSign = true;
        rs.sState = "0";
        rs.bAuth = Convert.ToBoolean(rBase.role.deptMg);
        rs.sNote = txtNote.Text;
        rs.dKeyDate = DateTime.Now;
        rs.sReserve1 = iOt.ToString();
        rs.sReserve2 = iRes.ToString();
        rs.sMailBody = MessageSendMail.Ot1Body(rs.sNobr, rs.sName, rs.sDeptName, rs.sRoteName, rs.dDateB, rs.sTimeB, rs.sTimeE, rs.iTotalHour, rs.sOtcatName, rs.sNote);
        dcForm.wfAppOt1.InsertOnSubmit(rs);

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

        if (!dtBase.Any())
        {
            lblMsg.Text = "資料錯誤，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        lblProcessID.ToolTip = lblProcessID.Text;

        var rBase = dtBase.First();

        var lsAppS = (from c in dcForm.wfAppOt1
                      where c.sProcessID == lblProcessID.ToolTip
                      group c by new { c.sRole, c.sDI, c.sRote });

        var dtAppS = from c in dcForm.wfAppOt1
                     where c.sProcessID == lblProcessID.ToolTip
                     select c;

        localhost.Service oService = new localhost.Service();

        int x = 0, y = 0;
        foreach (var rsAppS in lsAppS)
        {
            List<string> lsAgentMail = new List<string>();
            lsAgentMail.Add("");    //給主管審核用

            string sSubject = "【通知】(" + rsAppS.First().sNobr + ")" + rsAppS.First().sName + " 之預估加班單，請進入系統簽核";
            string sBody = "";

            string Info = "";
            //流程從這裡開始
            lblProcessID.Text = oService.GetProcessID().ToString();

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
                Info += "工號：" + rs.sNobr + ",給付方式：" + rs.sOtcatName + ",日期：" + rs.dDateTimeB + " 至 " + rs.dDateTimeE + ",時數：" + rs.iTotalHour + "<BR>";
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
            rm.bAuth = rsAppS.First().bAuth;
            rm.bSign = true;
            rm.sState = "1";
            rm.sReserve4 = Info;
            rm.sConditions1 = rm.iCateOrder.ToString("00"); //目前所簽核到的部門
            rm.sConditions2 = rsAppS.First().sRote;
            rm.sConditions3 = rsAppS.First().sDI;
            rm.sConditions5 = dtDeptm.sSignGroup;
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
            lblProcessID.Text = lblProcessID.ToolTip;
        }
    }
    protected void txtDateB_TextChanged(object sender, EventArgs e)
    {
        DateTime dDateB;
        dDateB = DateTime.Now;

        ddlRote.Enabled = true;
        lblCard.Text = "";
        lblCardTime.Text = "";

        if (!DateTime.TryParse(txtDateB.Text, out dDateB))
        {
            lblMsg.Text = "日期格式不正確，請重新輸入(開始)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        JBHR.Dll.dsAtt.JB_HR_RoteRow rRote = JBHR.Dll.Att.Rote(lblNobr.Text, dDateB.Date).FirstOrDefault();
        if (rRote == null)
        {
            //lblMsg.Text = "您所請的假沒有排班資料，請通知人事單位幫您產生";
            //ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        ddlRote.ToolTip = rRote.sRoteCode.Trim();   //暫時放入目前班別

        SetTime(lblNobr.Text, dDateB);

        SetRote(lblNobr.Text, dDateB.Date);

        //假日不用判斷
        JBHR.Dll.dsAtt.JB_HR_AttCardRow rAttCard = JBHR.Dll.Att.AttCard(lblNobr.Text, dDateB).FirstOrDefault();

        if (rRote.sRoteCode != "00")
        {
            if (rAttCard == null)
            {
                //lblMsg.Text = "您沒有此天的刷卡資料";
                //ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }

            txtTimeB.Text = "";// rRote.sOtBegin.Trim().Length == 0 ? rAttCard.sT1.Trim() : rRote.sOtBegin.Trim();
            txtTimeE.Text = "";// rAttCard.sT2.Trim();
        }
        else
        {
            //先往前抓，如果前一天是00再往後抓
            rRote = JBHR.Dll.Att.Rote(lblNobr.Text, dDateB.Date.AddDays(-1)).FirstOrDefault();
            if (rRote == null || rRote.sRoteCode == "00")
                rRote = JBHR.Dll.Att.Rote(lblNobr.Text, dDateB.Date.AddDays(1)).FirstOrDefault();

            if (rRote != null && rRote.sRoteCode != "00")
            {
                txtTimeB.Text = "";//rAttCard != null && rAttCard.sT1.Trim().Length > 0 ? rAttCard.sT1.Trim() : rRote.sOnTime;
                txtTimeE.Text = "";//rAttCard != null && rAttCard.sT2.Trim().Length > 0 ? rAttCard.sT2.Trim() : rRote.sOffTime;
            }
        }
    }

    public void SetTime(string sNobr, DateTime dDate)
    {
        //假日不用判斷
        JBHR.Dll.dsAtt.JB_HR_AttCardRow rAttCard = JBHR.Dll.Att.AttCard(sNobr, dDate).FirstOrDefault();
        if (rAttCard != null)
            lblCard.Text = "刷卡時間：" + rAttCard.sT1 + "-" + rAttCard.sT2;

        //顯示當日的刷卡資料
        JBHR.Dll.dsAtt.JB_HR_CardDataTable dtCard = JBHR.Dll.Att.Card(sNobr, dDate);
        if (dtCard.Rows.Count > 0)
            lblCardTime.Text = JBHR.Dll.Tools.ConvertDataTableToHtml(dtCard, "sOnTime", 10);
    }

    protected void ddlRote_DataBound(object sender, EventArgs e)
    {
        if (ddlRote.Items.FindByValue("00") != null)
            ddlRote.Items.Remove(ddlRote.Items.FindByValue("00"));
    }

    protected void btnAttendView_Click(object sender, EventArgs e)
    {
        SetYYMM(DateTime.Now.Date);

        lblCalendarID.Text = lblNobr.Text;
        lblDragNameCalendar.Text = ddlName.SelectedItem.Text;

        mpePopupCalendar.Show();
    }

    private void SetYYMM(DateTime dDate)
    {
        DateTime dDateB, dDateE;
        dDateB = new DateTime(dDate.Year, dDate.Month, 1).AddDays(-7);
        dDateE = new DateTime(dDate.Year, dDate.Month, DateTime.DaysInMonth(dDate.Year, dDate.Month)).AddDays(7);

        dtRote = Att.Rote(lblNobr.Text, dDateB, dDateE);
        dtAbs = Att.Abs(lblNobr.Text, dDateB, dDateE);
        dtOt = Att.Ot(lblNobr.Text, dDateB, dDateE);
        dtAttend = Att.Attend(lblNobr.Text, dDateB, dDateE);
        dtAttCard = Att.AttCard(lblNobr.Text, dDateB, dDateE);

        //下拉選單，每次顯示11個，前5個月跟後5個月
        dDateB = dDate.AddMonths(-5);
        dDateE = dDate.AddMonths(5);

        ddlYYMM.Items.Clear();
        ListItem li;
        for (DateTime i = dDateB; i <= dDateE; i = i.AddMonths(1))
        {
            li = new ListItem();
            li.Text = i.Year.ToString() + i.Month.ToString("00");
            li.Value = i.ToString();
            ddlYYMM.Items.Add(li);
        }

        ddlYYMM.ClearSelection();
        if (ddlYYMM.Items.FindByText(dDate.Year.ToString() + dDate.Month.ToString("00")) != null)
            ddlYYMM.Items.FindByText(dDate.Year.ToString() + dDate.Month.ToString("00")).Selected = true;

        cldAttendView.VisibleDate = dDate;
    }

    protected void ddlYYMM_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;

        if (ddl == null)
            return;

        SetYYMM(Convert.ToDateTime(ddl.SelectedItem.Value));

        mpePopupCalendar.Show();
    }

    protected void cldAttendView_DayRender(object sender, DayRenderEventArgs e)
    {
        CheckBox cbColor = new CheckBox();
        cbColor.Checked = true;

        tr = "";

        if (dtRote != null && dtAttend != null && dtAttCard != null)
        {
            var rRote = dtRote.Where(p => p.dAdate.Date == e.Day.Date).FirstOrDefault();
            var rAttend = dtAttend.Where(p => p.dAdate.Date == e.Day.Date).FirstOrDefault();
            var rAttCard = dtAttCard.Where(p => p.dAdate.Date == e.Day.Date).FirstOrDefault();
            if (rRote != null && rAttend != null)
            {
                Rote = rRote.sRoteCode;
                RoteName = rRote.sRoteName;
                R = rRote.sName;
                OnTime = rRote.sOnTime;
                OffTime = rRote.sOffTime;
                Time = OnTime + "-" + OffTime;

                T = "";
                if (rAttCard != null)
                {
                    T1 = rAttCard.sT1;
                    T2 = rAttCard.sT2;
                    T = T1 + "-" + T2;
                }

                tr = "<tr><td" + (cbColor.Checked ? " bgcolor='#FFC0C0'" : "") + "><font color='#000000' size='2pt'>" + R + "</font></td></tr>";
                //tr += "<tr><td" + (cbColor.Checked ? " bgcolor='#FFFFC0'" : "") + "><font color='#000000' size='2pt'>" + Time + "</font></td></tr>";
                tr += "<tr><td" + (cbColor.Checked ? " bgcolor='#C0FFFF'" : "") + "><font color='#000000' size='2pt'>" + T + "</font></td></tr>";

                //請假
                var lsAbs = dtAbs.Where(p => p.dDateB.Date == e.Day.Date).ToList();
                foreach (var rAbs in lsAbs)
                    tr += "<tr><td" + (cbColor.Checked ? " bgcolor='Red'" : "") + "><font color='#FF0000' size='2pt'>" + rAbs.sHoliName + rAbs.sTimeB + "-" + rAbs.sTimeE + "</font></td></tr>";

                //加班
                var lsOt = dtOt.Where(p => p.dDateB.Date == e.Day.Date).ToList();
                foreach (var rOt in lsOt)
                    tr += "<tr><td" + (cbColor.Checked ? " bgcolor='Yellow'" : "") + "><font color='#00FF00' size='2pt'>加班：" + Convert.ToString(rOt.iOtHrs + rOt.iRestHrs) + "小時" + "</font></td></tr>";
            }

            html = "<font size='1'><table width='100%' border='0'>" + tr + "</table></font>";
            Label lb = new Label();
            lb.Text = html;
            e.Cell.Controls.Add(lb);
        }
    }
    protected void cldAttendView_SelectionChanged(object sender, EventArgs e)
    {
        mpePopupCalendar.Show();
    }
    protected void cldAttendView_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        SetYYMM(e.NewDate);

        mpePopupCalendar.Show();
    }
    protected void gvAppS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btn = e.Row.FindControl("btnDelete") as Button;
        if (btn != null)
        {
            var r = from c in dcForm.wfAppOt1
                    where c.iAutoKey == Convert.ToInt32(btn.ToolTip)
                    select c;

            e.Row.ForeColor = r.Any() && r.First().bExceptionHour ? System.Drawing.Color.Red : e.Row.ForeColor;
        }
    }

    //帶出預設班別(班別隨日期不同而改變)
    public void SetRote(string sNobr, DateTime dDate)
    {
        JBHR.Dll.dsAtt.JB_HR_RoteDataTable dtRote = JBHR.Dll.Att.Rote(sNobr, dDate);
        if (dtRote.Rows.Count > 0)
        {
            JBHR.Dll.dsAtt.JB_HR_RoteRow rRote = dtRote.Rows[0] as JBHR.Dll.dsAtt.JB_HR_RoteRow;
            string sRoteCode = rRote.sRoteCode;
            string sRote = rRote.sRoteCode;

            //往前抓是00班就一直往後抓
            if (sRote == "00")
            {
                dDate = dDate.AddDays(-1);

                dtRote = JBHR.Dll.Att.Rote(sNobr, dDate);
                if (dtRote.Rows.Count > 0)
                {
                    rRote = dtRote.Rows[0] as JBHR.Dll.dsAtt.JB_HR_RoteRow;
                    sRote = rRote.sRoteCode;

                    if (sRote == "00")
                    {
                        do
                        {
                            dDate = dDate.AddDays(1);
                            dtRote = JBHR.Dll.Att.Rote(sNobr, dDate);
                            if (dtRote.Rows.Count > 0)
                            {
                                rRote = dtRote.Rows[0] as JBHR.Dll.dsAtt.JB_HR_RoteRow;
                                sRote = rRote.sRoteCode;
                            }
                        } while (dtRote.Rows.Count > 0 && sRote == "00");
                    }
                }
            }
            else
                ddlRote.Enabled = false;   //當日班別不是假日班00就鎖住班別選項

            ddlRote.ClearSelection();
            if (sRote != "00")
                if (ddlRote.Items.FindByValue(sRote) != null)
                    ddlRote.Items.FindByValue(sRote).Selected = true;

            return;

            //帶入當日上班時間及下班時間
            if (sRoteCode != "00")
            {
                //非假日班以下班時間為加起時間
                dtRote = JBHR.Dll.Att.Rote(sRoteCode);
                if (dtRote.Rows.Count > 0)
                {
                    rRote = dtRote.Rows[0] as JBHR.Dll.dsAtt.JB_HR_RoteRow;
                    txtTimeB.Text = rRote.sOffTime;
                    txtTimeE.Text = rRote.sOffTime;
                }
            }
            else
            {
                //假日班以預設班別為加起時間
                dtRote = JBHR.Dll.Att.Rote(sRote);
                if (dtRote.Rows.Count > 0)
                {
                    rRote = dtRote.Rows[0] as JBHR.Dll.dsAtt.JB_HR_RoteRow;
                    txtTimeB.Text = rRote.sOnTime;
                    txtTimeE.Text = rRote.sOffTime;
                }
            }

            //有刷卡時間帶刷卡資料的時間
            JBHR.Dll.dsAtt.JB_HR_AttCardDataTable dtAttCard = JBHR.Dll.Att.AttCard(sNobr, dDate);
            if (dtAttCard.Rows.Count > 0)
            {
                JBHR.Dll.dsAtt.JB_HR_AttCardRow rAttCard = dtAttCard.Rows[0] as JBHR.Dll.dsAtt.JB_HR_AttCardRow;
                txtTimeB.Text = rAttCard.sT1.Trim().Length > 0 && sRoteCode == "00" ? rAttCard.sT1.Trim() : txtTimeB.Text;
                txtTimeE.Text = rAttCard.sT2.Trim().Length > 0 && txtTimeB.Text.CompareTo(rAttCard.sT2) < 0 ? rAttCard.sT2.Trim() : txtTimeE.Text;
            }
        }
    }

    public static string ConvertMinutesToHhMm(int iMinutes)
    {
        return Convert.ToInt32(iMinutes / 60).ToString("00") + (iMinutes % 60).ToString("00");
    }
}