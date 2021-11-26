using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JBHR.Dll;
using System.IO;
using AjaxControlToolkit;
using System.Net;

public partial class Abs_Std1 : System.Web.UI.Page
{
    private bool isTest = false;

    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

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
            txtDateE.Text = txtDateB.Text;

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobrAppM.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);

                //Response.Write("NOBR:"+User.Identity.Name);
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
            ddlAname.DataBind();
            ddlHcode.DataBind();

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

            ddlAgentName.DataBind();
        }

        lblMsg.Text = "";

        //gvAbsView.DataSource = JBHR.Dll.Att.AbsCal.AbsView(lblNobr.Text, Convert.ToDateTime("2009/12/4"), "");
        //gvAbsView.DataBind();
    }

    private void SetDefault()
    {
        lblFlowTreeID.Text = "80";
        lblTitle.ToolTip = "Abs2";
        (Page.Master as mpStd0990111).sFormCode = lblTitle.ToolTip;
        (Page.Master as mpStd0990111).sAppNobr =lblNobrAppM.Text;

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
            //SetAgentNobr(li.Value);
        }
        else
            txtName.Text = txtName.ToolTip;

        txtDateB_TextChanged(null, null);
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
            //SetAgentNobr(r.id);
        }
        else
            txtName.Text = txtName.ToolTip;

        txtDateB_TextChanged(null, null);
    }

    //代理人
    //private void SetAgentNobr(string sNobr)
    //{
    //    var rs = (from c in dcForm.wfAppAgent
    //              where c.sNobr == sNobr
    //              select c).ToList();

    //    ddlAgentName.Items.Clear();

    //    ListItem li = new ListItem();
    //    li.Text = "請選擇";
    //    li.Value = "0";
    //    ddlAgentName.Items.Add(li);

    //    foreach (var r in rs)
    //    {
    //        li = new ListItem();
    //        li.Text = r.sAgentName;
    //        li.Value = r.sAgentNobr;
    //        ddlAgentName.Items.Add(li);
    //    }
    //}

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


    protected void ddlAgentName2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlAgentName2 = sender as DropDownList;
        if (ddlAgentName2 != null && ddlAgentName2.Items.Count > 0)
        {
            ListItem li = ddlAgentName2.SelectedItem;
            SetAgentName2(li);
        }
    }
    protected void ddlAgentName2_DataBound(object sender, EventArgs e)
    {
        if (ddlAgentName2.Items.FindByValue(lblNobr.Text) != null)
            ddlAgentName2.Items.Remove(lblNobr.Text);
    }
    protected void txtAgentName2_TextChanged(object sender, EventArgs e)
    {
        TextBox txtAgentName2 = sender as TextBox;
        if (txtAgentName2 != null)
        {
            txtAgentName2.Text = txtAgentName2.Text.ToUpper();
            ListItem li = ddlAgentName2.Items.FindByValue(txtAgentName2.Text);
            li = li != null ? li : ddlAgentName2.Items.FindByText(txtAgentName2.Text);
            SetAgentName2(li);
        }
    }
    private void SetAgentName2(ListItem li)
    {
        if (li != null)
        {
            ddlAgentName2.ClearSelection();
            li.Selected = true;
            lblAgentNobr2.Text = li.Value;
            txtAgentName2.Text = li.Text;
            txtAgentName2.ToolTip = txtAgentName2.Text;
        }
        else
            txtAgentName.Text = txtAgentName.ToolTip;
    }
    private void SetAgentName2(string sNobr)
    {
        dcFlow = new dcFlowDataContext();

        var r = (from c in dcFlow.Emp
                 where c.id == sNobr
                 select c).FirstOrDefault();

        if (r != null)
        {
            lblAgentNobr2.Text = r.id;
            txtAgentName2.Text = r.name;
            txtAgentName2.ToolTip = txtAgentName2.Text;
        }
        else
            txtAgentName2.Text = txtAgentName2.ToolTip;
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
        string sNobr = lblNobr.Text.Trim();
        string sHcode = "O";// ddlHcode.SelectedItem.Value;

        var rEmpBaseS = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();

        if (rEmpBaseS == null)
        {
            lblMsg.Text = "Data Error!";
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

        if (ddlAgentName.SelectedItem.Value == "0" && ddlAgentName2.SelectedItem.Value == "0")
        {
            lblMsg.Text = "代理人為必選欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (ddlAgentName.Items.Count >= 2 && ddlName.SelectedItem.Value == ddlAgentName.SelectedItem.Value)
        {
            lblMsg.Text = "代理人不可與被申請人相同";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (ddlAgentName2.Items.Count >= 2 && ddlName.SelectedItem.Value == ddlAgentName2.SelectedItem.Value)
        {
            lblMsg.Text = "代理人不可與被申請人相同";
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

        DateTime dDateE = DateTime.Now;
        if (!DateTime.TryParse(txtDateE.Text, out dDateE))
        {
            lblMsg.Text = "日期格式不正確，請重新輸入(結束)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var rHcode = JBHR.Dll.Att.Hcode(sHcode).FirstOrDefault();
        if (rHcode == null)
        {
            lblMsg.Text = "您所請的假別並不存在，請重新選擇";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (sHcode == "F")
            dDateE = dDateB.AddDays(55);

        string sTimeB, sTimeE;
        sTimeB = txtTimeB.Text.Trim();
        sTimeE = txtTimeE.Text.Trim();
        if (sTimeB.Length != 4 || sTimeE.Length != 4)
        {
            lblMsg.Text = "時間格式不正確，請重新輸入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        JBHR.Dll.dsAtt.JB_HR_RoteDataTable dtRote = JBHR.Dll.Att.Rote(sNobr, dDateB.Date, dDateE.Date);

        bool bSalaryLock = false;   //關帳鎖檔
        bool bAtt = false;  //出勤資料
        for (DateTime i = dDateB; i <= dDateE; i = i.AddDays(1))
        {
            if (JBHR.Dll.Bas.IsDataPaB(i.Date, rEmpBaseS.sSaladr))
                bSalaryLock = true;

            var rRote = dtRote.Where(p => p.dAdate.Date == i.Date).FirstOrDefault();
            if (rRote == null)
                bAtt = true;
        }

        if (bSalaryLock && !isTest)
        {
            lblMsg.Text = "您所申請的日期已經關帳鎖檔，請洽人事單位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (bAtt)
        {
            lblMsg.Text = "您所請的假沒有排班資料，請通知人事單位幫您產生";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        DateTime dDateTimeB, dDateTimeE;
        dDateTimeB = dDateB.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeB));
        dDateTimeE = dDateE.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(sTimeE));

        if (rHcode.sGroupCode != "F")
        {
            if (!JBHR.Dll.Att.AbsCheck.IsWorkTime(sNobr, dDateTimeB, dDateB))
            {
                lblMsg.Text = "您的請假開始日期或時間不在當日的上班時間裡";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }

            if (!JBHR.Dll.Att.AbsCheck.IsWorkTime(sNobr, dDateTimeE, dDateE))
            {
                lblMsg.Text = "您的請假結束日期或時間不在當日的上班時間裡";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }
        }

        if (rHcode.sSex.Trim().Length > 0 && rHcode.sSex.Trim() != rEmpBaseS.sSex.Trim())
        {
            lblMsg.Text = "此假只限" + ((rHcode.sSex == "M") ? "男性" : "女性") + "可申請";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //檢查重複的資料
        var dtAppS = from c in dcForm.wfAppAbs
                     where (c.sProcessID == lblProcessID.Text || (c.idProcess != 0 && c.sState == "1"))
                     && c.sNobr == sNobr
                     && c.dDateTimeB < dDateTimeE && c.dDateTimeE > dDateTimeB
                     select c;

        if (dtAppS.Any() && !isTest)
        {
            lblMsg.Text = "資料重複或流程正在進行中，請先刪除申請資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (JBHR.Dll.Att.AbsCheck.IsRepeatData(sNobr, dDateTimeB, dDateTimeE, false) && !isTest)
        {
            lblMsg.Text = "人事單位已有重複的資料";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

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

        //計算在途中的時數
        dtAppS = from c in dcForm.wfAppAbs
                 where (c.sProcessID == lblProcessID.Text || (c.idProcess != 0 && c.sState == "1"))
                 && c.sNobr == sNobr
                 && c.sHcode == sHcode
                 && new DateTime(dDateB.Year, 1, 1) <= c.dDateB && c.dDateB <= new DateTime(dDateB.Year, 12, 31)
                 select c;

        //帶入對沖的人
        string sName = "";
        if (ddlAname.Visible && ddlAname.SelectedItem != null)
            sName = ddlAname.SelectedItem.Value;

        decimal iProceedingHour = 0;
        if (dtAppS.Any())
            iProceedingHour = dtAppS.Sum(p => p.iTotalDay) + dtAppS.Sum(p => p.iTotalHour);

        JBHR.Dll.Att.AbsCal.AbsDetail oAbsDetail = JBHR.Dll.Att.AbsCal.AbsCalculation(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, sName, iProceedingHour);

        if (!oAbsDetail.bHcodeMin)
        {
            lblMsg.Text = "您請的假至少要請" + oAbsDetail.iHcodeMinMax.ToString() + oAbsDetail.sHcodeUnit;
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (!oAbsDetail.bBalance)
        {
            lblMsg.Text = "剩餘時數不足(包含在途中的)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //if (rHcode.sGroupCode == "E" && oAbsDetail.iTotalDay < 56)
        //{
        //    lblMsg.Text = "產假天數不正確，請確定日期及時間是否正確，請重新輸入";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        var rEmp = (from c in dcFlow.Emp
                    where c.id == sNobr
                    select c).FirstOrDefault();

        var rBase = dtBase.First();

        var rs = new wfAppAbs();
        rs.sFormCode = lblTitle.ToolTip;
        rs.sProcessID = lblProcessID.Text;
        rs.idProcess = 0;
        rs.sNobr = sNobr;
        rs.sName = rEmp.name;
        rs.sDept = rBase.dept.id;
        rs.sDeptName = rBase.dept.name;
        rs.sJob = rBase.pos.id;
        rs.sJobName = rBase.pos.name;
        rs.sJobl = rEmpBaseS.sJoblCode;
        rs.sEmpcd = rEmpBaseS.sEmpcd;
        rs.sRole = rBase.role.id;
        rs.sDI = rEmpBaseS.sDI;
        rs.sRote = rEmpBaseS.sRotet;
        rs.dDateB = dDateB;
        rs.dDateE = dDateE;
        rs.sTimeB = sTimeB;
        rs.sTimeE = sTimeE;
        rs.dDateTimeB = dDateTimeB;
        rs.dDateTimeE = dDateTimeE;
        rs.sHcode = sHcode;
        rs.sHname = rHcode.sHname;
        rs.iDay = oAbsDetail.iDay;
        rs.iHour = oAbsDetail.iHour;
        rs.iTotalDay = oAbsDetail.iTotalDay;
        rs.iTotalHour = oAbsDetail.iTotalHour;
        rs.bExceptionHour = false;
        rs.iExceptionHour = 0;
        rs.sSalYYMM = JBHR.Dll.Att.SetYYMM(dDateB, "2", 1, rEmpBaseS.sSaladr);
        rs.bSign = true;
        rs.sState = "0";

        if (ddlAgentName.SelectedItem != null)
        {
            var rAgentEmp = (from c in dcFlow.Emp
                             where c.id == ddlAgentName.SelectedItem.Value
                             select c).FirstOrDefault();

            if (rAgentEmp != null)
            {
                rs.sAgentNobr = rAgentEmp.id;
                rs.sAgentName = rAgentEmp.name;
            }
        }

        if (ddlAgentName2.SelectedItem != null)
        {
            var rAgentEmp = (from c in dcFlow.Emp
                             where c.id == ddlAgentName2.SelectedItem.Value
                             select c).FirstOrDefault();

            if (rAgentEmp != null)
            {
                rs.sAgentNobr2 = rAgentEmp.id;
                rs.sAgentName2 = rAgentEmp.name;
            }
        }

        rs.sAgentNote = txtAgentNote.Text;
        rs.sReserve1 = rEmpBaseS.sSaladr;   //薪資群組 公司別
        rs.sReserve2 = sName;
        rs.sReserve4 = Guid.NewGuid().ToString();
        rs.bAuth = Convert.ToBoolean(rBase.role.deptMg);
        rs.sNote = txtNote.Text;
        rs.dKeyDate = DateTime.Now;
        rs.sInfo = rs.sName + "," + rs.sHname + "," + rs.dDateB.ToShortDateString() + "," + rs.sTimeB + "," + rs.dDateE.ToShortDateString() + "," + rs.sTimeE + "," + rs.sNote;
        rs.sMailBody = MessageSendMail.AbsBody(rs.sNobr, rs.sName, rs.sDeptName, rs.sHname, rs.dDateB, rs.sTimeB, rs.dDateE, rs.sTimeE, rs.iDay > 0 ? rs.iDay : rs.iHour, rs.sUnit, rs.sNote, rs.sAgentNote);
        dcForm.wfAppAbs.InsertOnSubmit(rs);

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

        var dtAppS = from c in dcForm.wfAppAbs
                     where c.sProcessID == lblProcessID.ToolTip
                     select c;

        var lsAppS = dtAppS.GroupBy(c => new { c.sHcode, c.sNobr });

        var dtFile = from c in dcFlow.wfFormUploadFile
                     where c.sProcessID == lblProcessID.ToolTip
                     select c;

        //檢查某些假別是否有一定要夾帶附件
        //bool bNotPass = false;
        //var dtHcode = JBHR.Dll.Att.Hcode("").Where(p => p.bUpload);
        //foreach (var rs in dtAppS)
        //{
        //    if (dtHcode.Where(p => p.sHcode == rs.sHcode).Count() > 0)
        //        bNotPass = (dtFile.Where(p => p.sKey == rs.sReserve4).Count() == 0);

        //    if (bNotPass)
        //        break;
        //}

        //if (bNotPass)
        //{
        //    lblMsg.Text = "某些假別(C,G,H)需要夾帶證明附件";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        var rsDataGroup = JBHR.Dll.Bas.DataGroup();

        localhost.Service oService = new localhost.Service();

        int x = 0, y = 0;

        foreach (var rsAppS in lsAppS)
        {
            List<string> lsAgentMail = new List<string>();
            lsAgentMail.Add("");    //給主管審核用

            string sSubject = "【通知】(" + rsAppS.First().sNobr + ")" + rsAppS.First().sName + " 之公出單，請進入系統簽核";
            string sAgengSubject = "【通知】(" + rsAppS.First().sNobr + ")" + rsAppS.First().sName + " 之公出單，您是他的代理人";
            string sBody = "";

            //流程從這裡開始
            lblProcessID.Text = oService.GetProcessID().ToString();
            string Info = "";
            foreach (var rs in rsAppS)
            {
                sBody += rs.sMailBody;

                //更改附檔流程序號
                var dtFileWhere = dtFile.Where(p => p.sKey == rs.sReserve4);
                foreach (var rf in dtFileWhere)
                {
                    rf.sProcessID = lblProcessID.Text;
                    rf.idProcess = Convert.ToInt32(rf.sProcessID);
                }

                rs.sProcessID = lblProcessID.Text;
                rs.idProcess = Convert.ToInt32(rs.sProcessID);
                rs.sState = "1"; //開始

                //當角色不同時，就將資料寫入ProcessFlowShare
                if (Request["idRole_Start"] != rs.sRole)
                    oService.FlowShare(rs.idProcess, rs.sRole, rs.sNobr);

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

                if (rs.sAgentNobr2 != null && rs.sAgentNobr2.Trim().Length > 0)
                {
                    var rAgent = (from c in dcFlow.Emp
                                  where c.id == rs.sAgentNobr2.Trim()
                                  select c).FirstOrDefault();

                    if (rAgent != null && rAgent.email.Trim().Length > 0)
                        lsAgentMail.Add(rAgent.email);
                }

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
                rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                rSendMail.sBody = sBody;
                rSendMail.bOnly = s != "";
                rSendMail.sKeyMan = lblNobrAppM.Text;
                rSendMail.dKeyDate = DateTime.Now;
                dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
            }

            var dtDeptm = JBHR.Dll.Bas.Deptm(rsAppS.First().sDept).FirstOrDefault();
            var rRote = JBHR.Dll.Att.Rote(rsAppS.First().sNobr, rsAppS.First().dDateB).FirstOrDefault();
            var rHcode = JBHR.Dll.Att.Hcode(rsAppS.First().sHcode.Trim()).First();
            int iDay = rsAppS.First().iTotalDay > 0 ? Convert.ToInt32(rsAppS.Sum(p => p.iTotalDay)) : Convert.ToInt32(rsAppS.Sum(p => p.iTotalHour) / (rRote != null ? rRote.iWkHrs : 8));

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
            rm.sConditions2 = iDay.ToString("00");
            rm.sConditions5 = dtDeptm.sSignGroup;
            rm.sInfo = Info;
            rm.sMailSubject = sSubject;
            rm.sMailBdoy = sBody;
            dcFlow.wfFormApp.InsertOnSubmit(rm);

            if (!isTest)
            {
                dcForm.SubmitChanges();
                dcFlow.SubmitChanges();

                if (oService.FlowStart(rm.idProcess, lblFlowTreeID.Text, rsAppS.First().sRole, rsAppS.First().sNobr,lblRoleAppM.Text, lblNobrAppM.Text))
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
    protected void txtDateB_TextChanged(object sender, EventArgs e)
    {
        DateTime dDateB;
        dDateB = DateTime.Now;

        if (!DateTime.TryParse(txtDateB.Text, out dDateB))
        {
            lblMsg.Text = "日期格式不正確，請重新輸入(開始)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        txtDateE.Text = txtDateB.Text;

        JBHR.Dll.dsAtt.JB_HR_RoteRow rRote = JBHR.Dll.Att.Rote(lblNobr.Text, dDateB.Date).FirstOrDefault();
        if (rRote == null)
        {
            lblMsg.Text = "您所請的假沒有排班資料，請通知人事單位幫您產生";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        //ddlHcode.DataBind();

        txtTimeB.Text = rRote.sOnTime.Trim();
        txtTimeE.Text = rRote.sOffTime.Trim();
        ddlHcode_SelectedIndexChanged(null, null);

        gvAbsView.DataBind();
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

    protected void gvAppS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cn = e.CommandName;
        string ca = e.CommandArgument.ToString();

        if (cn == "Upload")
        {
            var r = (from c in dcForm.wfAppAbs
                     where c.iAutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();

            if (r != null)
            {
                lblUploadID.Text = r.sNobr;
                lblUploadKey.Text = r.sReserve4;
                lblDragNameUpload.Text = lblProcessID.Text;
                lblMsgUpload.Text = "";

                gvUpload.DataBind();
                mpePopupUpload.Show();
            }
        }
    }
    protected void btnExitUpload_Click(object sender, EventArgs e)
    {
        mpePopupUpload.Hide();
    }
    protected void fu_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size", "top.$get(\"" + lblMsgUpload.ClientID + "\").innerHTML = 'Uploaded size: " + fu.FileBytes.Length.ToString() + "';", true);

        //lblDragNameUpload.Text = e.filename;
        lblDragNameUpload.ToolTip = Guid.NewGuid().ToString();

        string savePath = MapPath("~/Upload/" + lblDragNameUpload.ToolTip);
        fu.SaveAs(savePath);

        Session["FileName"] = fu.FileName;
        Session["ServerName"] = lblDragNameUpload.ToolTip;
        Session["FileSize"] = e.filesize;
        Session["ContentType"] = fu.ContentType;

        mpePopupUpload.Show();
    }
    protected void fu_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "top.$get(\"" + lblMsgUpload.ClientID + "\").innerHTML = 'Error: " + e.statusMessage + "';", true);
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        mpePopupUpload.Show();
        if (Session["FileName"] == null)
        {
            lblMsgUpload.Text = "檔案正在上傳中或沒有選擇檔案";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsgUpload.Text + "');", true);
            return;
        }

        var r = new wfFormUploadFile();
        r.sFormCode = "Abs2";
        r.sFormName = "公出單";
        r.sProcessID = lblProcessID.Text;
        r.idProcess = 0;
        r.sKey = lblUploadKey.Text;
        r.sNobr = lblUploadID.Text;
        r.sUpName = Session["FileName"].ToString();
        r.sServerName = Session["ServerName"].ToString();
        r.sDescription = txtUpload.Text;
        r.sType = Session["ContentType"].ToString();
        r.iSize = (Convert.ToInt32(Session["FileSize"]) / 1024) > 0 ? Convert.ToInt32(Session["FileSize"]) / 1024 : 1;
        r.dKeyDate = DateTime.Now;
        dcFlow.wfFormUploadFile.InsertOnSubmit(r);

        dcFlow.SubmitChanges();
        gvUpload.DataBind();

        Session.RemoveAll();
    }

    protected void gvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsgUpload.Text = "";

        mpePopupUpload.Show();

        string cn = e.CommandName;
        string ca = e.CommandArgument.ToString();

        if (cn == "Download" || cn == "Del")
        {
            var r = (from c in dcFlow.wfFormUploadFile
                     where c.iAutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();

            if (r != null)
            {
                string FN = Server.MapPath("../Upload/" + r.sServerName);
                FileInfo fi = new FileInfo(FN);

                if (fi.Exists)
                {
                    if (cn == "Download")
                    {
                        Response.ClearHeaders();
                        Response.Clear();
                        Response.AddHeader("Accept-Language", "zh-tw");
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(r.sUpName, System.Text.Encoding.UTF8));

                        Response.AddHeader("Content-Length", fi.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(fi.FullName);
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
                        fi.Delete();
                        dcFlow.wfFormUploadFile.DeleteOnSubmit(r);
                        dcFlow.SubmitChanges();
                        gvUpload.DataBind();
                        lblMsgUpload.Text = "刪除完成";
                    }
                }
                else
                {
                    lblMsgUpload.Text = "系統找不到檔案";
                }
            }
        }
    }
    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnDownload = e.Row.FindControl("btnDownload") as Button;
        if (btnDownload != null)
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnDownload);
    }
    protected void ddlHcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAname.Items.Clear();

        ddlAname.Visible = false;

        DateTime dDateB = DateTime.Now.Date;

        if (!DateTime.TryParse(txtDateB.Text, out dDateB))
            dDateB = DateTime.Now.Date;

        if (ddlHcode.SelectedItem == null)
            return;

        DateTime dDateE = new DateTime(DateTime.Now.Year, 12, 31).Date;

        var dtAbst = JBHR.Dll.Att.Abst(lblNobr.Text, ddlHcode.SelectedItem.Value, dDateB);

        if (dtAbst.Rows.Count > 0)
        {
            ddlAname.Visible = true;

            ListItem li;

            foreach (JBHR.Dll.dsAtt.JB_HR_AbstRow r in dtAbst.Rows)
            {
                li = new ListItem();
                li.Text = r.sAname;
                li.Value = r.sAname;
                ddlAname.Items.Add(li);
            }

            ddlAname.DataBind();
        }
    }
    protected void ddlAname_DataBound(object sender, EventArgs e)
    {

    }

}