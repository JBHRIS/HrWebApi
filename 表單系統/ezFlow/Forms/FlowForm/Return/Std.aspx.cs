using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Return_Std : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

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

            SetDefault();

            SetName(lblNobrAppM.Text);
        }

        lblMsg.Text = "";
    }

    private void SetDefault()
    {
        dcFlow = new dcFlowDataContext();

        lblFlowTreeID.Text = "15";
        lblTitle.ToolTip = "Return";
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
            txtNote.CausesValidation = rForm.bNote;
        }
    }

    //設定表單內容的相關預設值
    private void SetBaseData(string sNobr)
    {
        var rEmpBase = JBHR.Dll.Bas.EmpBase(sNobr).FirstOrDefault();
        if (rEmpBase != null)
        {
            //var rDept = JBHR.Dll.Bas.Dept(rEmpBase.sDeptCode).FirstOrDefault();
            //if (rDept != null)
            //    lblDept.Text = rDept.sDeptName + "(" + rDept.sDeptCode + ")";

            var rJob = JBHR.Dll.Bas.Job().Where(p => p.sJobCode == rEmpBase.sJobCode).FirstOrDefault();
            if (rJob != null)
                lblJob.Text = rJob.sJobName + "(" + rJob.sJobCode + ")";
            txtDateB.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtDateE.Text = txtDateB.Text;
            txtTotalDay.Text = "1";

            lblHour.Text = JBHR.Dll.Att.Abs(sNobr, new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 12, 31), "U").Sum(p => p.iUse).ToString();
            //txtDateB1.Text = txtDateB.Text;
            //txtDateE1.Text = txtDateB1.Text;
            //txtTotalDay1.Text = "1";

            txtDate.Text = txtDateB.Text;
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
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtAgentName.Text.Trim().Length == 0 || txtAgentNobr.Text.Trim().Length == 0|| txtAgentDept.Text.Trim().Length == 0)
        {
            lblMsg.Text = "代理人相關資訊全為必填欄位";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (txtNote.CausesValidation && txtNote.Text.Trim().Length == 0)
        {
            lblMsg.Text = "申請原因為必填欄位";
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

        localhost.Service oService = new localhost.Service();

        //流程從這裡開始
        lblProcessID.Text = oService.GetProcessID().ToString();

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
        rm.sConditions5 = dtDeptm.sSignGroup;
        //rm.sConditions3 = ("W2,W5,W6,W7").IndexOf(rEmpBaseS.sWrokcd) >= 0 ? "1" : "0";   //工作地 1=海外
        //rm.sConditions4 = rEmpBaseS.sWrokcd;
        dcFlow.wfFormApp.InsertOnSubmit(rm);

        try
        {
            var rs = new wfAppReturn();
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
            rs.sIntentionCode = ddlIntention.SelectedItem.Value;
            rs.sIntentionName = ddlIntention.SelectedItem.Text;
            rs.dDateB = Convert.ToDateTime(txtDateB.Text);
            rs.dDateE = Convert.ToDateTime(txtDateE.Text);
            rs.sTimeB = "0000";
            rs.sTimeE = "2359";
            TimeSpan ts = rs.dDateE - rs.dDateB;
            rs.dDateTimeB = rs.dDateB.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeB, true));
            rs.dDateTimeE = rs.dDateE.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeE, false));
            rs.iDay = ts.Days + 1;

            if (rs.iDay > 10)
            {
                lblProcessID.Text = lblProcessID.ToolTip;
                lblMsg.Text = "超過10天，請重新輸入";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
                return;
            }

            rs.bExceptionHour = false;
            rs.iExceptionHour = 0;
            rs.dDateB1 = rs.dDateB;
            rs.dDateE1 = rs.dDateE;
            rs.sTimeB1 = "0000";
            rs.sTimeE1 = "2359";
            ts = rs.dDateE1.Value - rs.dDateB1.Value;
            rs.dDateTimeB1 = rs.dDateB1.Value.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeB1, true));
            rs.dDateTimeE1 = rs.dDateE1.Value.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(rs.sTimeE1, false));
            rs.iDay1 = ts.Days + 1;
            DateTime dDate = DateTime.Now;
            if (DateTime.TryParse(txtDate.Text, out dDate))
                rs.dDate = Convert.ToDateTime(txtDate.Text);
            rs.bSign = true;
            rs.sState = "1";
            rs.sOrginal = txtOrginal.Text;
            rs.sHeadquarters = txtHeadquarters.Text;
            rs.sNote = txtNote.Text;
            rs.dKeyDate = DateTime.Now;
            rs.sCode1 = "";
            rs.sName1 = txtAgentName.Text + " / " + txtAgentNobr.Text + " / " + txtAgentDept.Text;
            rs.sReserve1 = lblHour.Text;    //已請假時數
            rs.sInfo = rs.sName + "," + rs.dDateB + "," + rs.dDateE;
            dcForm.wfAppReturn.InsertOnSubmit(rs);

            rm.sInfo = rs.sInfo;
            rm.sReserve4 = rs.sInfo;
        }
        catch (Exception ex)
        {
            lblProcessID.Text = lblProcessID.ToolTip;
            lblMsg.Text = "日期轉換錯誤，請重新檢查格式是否輸入正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (oService.FlowStart(rm.idProcess, lblFlowTree.Text, rBaseS.role.id, rBaseS.role.Emp_id, rBaseM.role.id, rBaseM.role.Emp_id))
        {
            try
            {
                dcForm.SubmitChanges();
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in dcForm.ChangeConflicts)
                {
                    // *********************************************
                    // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                    // **********************************************

                    // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                    //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                    //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }

                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                dcForm.SubmitChanges();
            }

            try
            {
                dcFlow.SubmitChanges();
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in dcFlow.ChangeConflicts)
                {
                    // *********************************************
                    // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                    // **********************************************

                    // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                    //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                    //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }

                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                dcFlow.SubmitChanges();
            }

            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
        }
    }
    protected void btnCal_Click(object sender, EventArgs e)
    {
        DateTime dDateB, dDateE;
        try
        {
            dDateB = Convert.ToDateTime(txtDateB.Text);
            dDateE = Convert.ToDateTime(txtDateE.Text);
        }
        catch
        {
            lblMsg.Text = "日期轉換錯誤，請重新檢查格式是否輸入正確";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        TimeSpan ts = dDateE - dDateB;
        txtTotalDay.Text = Convert.ToString(ts.Days + 1);
    }

    protected void btnCal1_Click(object sender, EventArgs e)
    {
        //DateTime dDateB, dDateE;
        //try
        //{
        //    dDateB = Convert.ToDateTime(txtDateB1.Text);
        //    dDateE = Convert.ToDateTime(txtDateE1.Text);
        //}
        //catch
        //{
        //    lblMsg.Text = "日期轉換錯誤，請重新檢查格式是否輸入正確";
        //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
        //    return;
        //}

        //TimeSpan ts = dDateE - dDateB;
        //txtTotalDay1.Text = Convert.ToString(ts.Days + 1);
    }
}