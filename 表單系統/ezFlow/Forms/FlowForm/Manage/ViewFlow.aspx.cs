using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Manage_ViewFlow : System.Web.UI.Page
{
    dcFlowDataContext dcFlow = new dcFlowDataContext();
    dcFormDataContext dcForm = new dcFormDataContext();

    private List<string> lsProcessID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobr.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            //if (Request.Cookies["ezFlow"] == null || Request.Cookies["ezFlow"]["Emp_id"] == null)
            //{
            //    plOverflow.Attributes.Add("style", "overflow-x: hidden; overflow-y: auto; height: 500px; padding: 0 17px 0 0");

            //    lblMsg.Text = "由於太久沒有動作，請先登出，再重新登入";
            //    ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
            //    return;
            //}
            lblNobr.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobr.Text;

            //lblNobr.Text = "10100955";
            //lblNobr.Text = Convert.ToString(Request.Cookies["ezFlow"]["Emp_id"]);

            //是否具備管理權限
            bool bManage = (from c in dcFlow.SysAdmin
                            where c.Emp_id == lblNobr.Text
                            select c).Count() > 0;

            ckManage.Checked = bManage;
            ckManage.Visible = bManage;
            btnActive.Visible = bManage;
            ddlActive.Visible = bManage;
            btnSql.Visible = bManage;
        }

        BindFlow();

        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnDisplay);
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExport);
    }

    private void BindFlow()
    {
        var dtCode = from c in dcFlow.wfFormCode
                     where c.bDisplay
                     && c.sCategory == "State"
                     orderby c.iOrder
                     select c;

        DataTable dtFlow = new DataTable();
        dtFlow.Columns.Add("sFormName", typeof(string)).DefaultValue = "";
        foreach (var rCode in dtCode)
            if (!dtFlow.Columns.Contains(rCode.sCode))
                dtFlow.Columns.Add(rCode.sCode, typeof(string));

        var dtForm = from c in dcFlow.wfForm
                     orderby c.s5
                     select c;

        DataRow r;
        foreach (var rForm in dtForm)
        {
            r = dtFlow.NewRow();
            r["sFormName"] = rForm.sFormName;
            foreach (var rCode in dtCode)
                r[rCode.sCode] = GetDataTable(GetStateCountSqlString(rForm.s4, rCode.sCode, rForm.s2, rForm.s3 , rForm.sFormCode)).Rows.Count;

            dtFlow.Rows.Add(r);
        }

        dtFlow.Columns["sFormName"].ColumnName = "表單名稱";
        foreach (var rCode in dtCode)
            dtFlow.Columns[rCode.sCode].ColumnName = rCode.sName;

        gvFlow.DataSource = dtFlow;
        gvFlow.DataBind();
    }

    private static SqlConnection GetConnection()
    {
        string sCon = ConfigurationManager.ConnectionStrings["Flow"].ConnectionString;
        SqlConnection con = new SqlConnection(sCon);
        return con;
    }

    private static DataTable GetDataTable(string sSelect)
    {
        DataTable dt = new DataTable();

        SqlConnection con = null;
        SqlCommand cmd = null;

        try
        {
            con = GetConnection();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sSelect;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (con != null) con.Dispose();
        }

        return dt;
    }

    private string GetStateCountSqlString(string AppS, string State, string AppM, string SignM, string FormCode)
    {
        string sSelect = "Select * From " + AppS + " Where sState = '" + State + "'";

        //如果不具備管理權限，僅可查詢(申請者)及(被申請者)及(審核者)工號相符的資料
        if (!ckManage.Checked)
        {
            if (FormCode == "Abs")
                sSelect += " AND sHcode <> 'O'";
            else if (FormCode == "Abs2")
                sSelect += " AND sHcode = 'O'";

            sSelect += " AND (sNobr = '" + lblNobr.Text + "'";
            sSelect += " OR EXISTS (Select 1 From " + AppM + " Where " + AppM + ".sProcessID = " + AppS + ".sProcessID AND " + AppM + ".sNobr = '" + lblNobr.Text + "')";
            sSelect += " OR EXISTS (Select 1 From " + SignM + " Where " + SignM + ".sProcessID = " + AppS + ".sProcessID AND " + SignM + ".sNobr =  '" + lblNobr.Text + "'))";
        }


        return sSelect;
    }

    private static string GetAppSqlString(string dtName, string sProcessID)
    {
        return "Select * From " + dtName + " Where sProcessID = '" + sProcessID + "' AND idProcess <> 0";
    }

    protected void gvFlow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void gvFlow_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        BindFlow();
    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        lblPage.Text = "0";
        lblSort.Text = "";

        GridView gv;
        foreach (ListItem li in ddlForm.Items)
        {
            gv = updatePanel1.FindControl("gv" + li.Value) as GridView;
            if (gv != null)
            {
                gv.Visible = (li.Value == ddlForm.SelectedItem.Value);

                if (li.Value == ddlForm.SelectedItem.Value)
                {
                    btnDisplay.CommandArgument = li.Value;  //將選的表單暫存到顯示的按鈕裡，以防止使用者中途更換
                    btnSelectAll.CommandArgument = li.Value;    //全選專用
                    BindGV(gv);
                }
            }
        }
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblPage.Text = e.NewPageIndex.ToString();
        GridView gv = sender as GridView;
        BindGV(gv);
    }
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (lblSort.Text == e.SortExpression)
            lblSort.ToolTip = "Desc" == lblSort.ToolTip ? "" : "Desc";
        else
            lblSort.ToolTip = "";

        lblSort.Text = e.SortExpression;

        GridView gv = sender as GridView;
        BindGV(gv);
    }

    private void BindGV(GridView gv)
    {
        var rForm = (from c in dcFlow.wfForm
                     where c.sFormCode == btnDisplay.CommandArgument
                     select c).FirstOrDefault();

        if (rForm != null)
        {
            lblCount.ToolTip = rForm.sFlowTree;

            lsProcessID = (from pc in dcFlow.ProcessCheck
                           join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                           join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                           where !Convert.ToBoolean(pn.isFinish)
                           && !Convert.ToBoolean(pf.isFinish)
                           && !Convert.ToBoolean(pf.isError)
                           && !Convert.ToBoolean(pf.isCancel)
                           && pf.FlowTree_id == lblCount.ToolTip
                           //&& (pc.Emp_idDefault == lblNobr.Text || pc.Emp_idAgent == lblNobr.Text)
                           select pf.id.ToString()).ToList();

            string sProcessID = "";
            foreach (string s in lsProcessID)
                sProcessID += "'" + s + "',";
            sProcessID = sProcessID.Length > 0 ? sProcessID + "'-1'" : "";

            string sSelect = "Select * From " + rForm.s4 + " Where 1 = 1";
            //sSelect += " AND idProcess <> 0";
            sSelect += ddlState.SelectedItem.Value != "-1" ? " AND sState = '" + ddlState.SelectedItem.Value + "'" : "";
            sSelect += txtProcessID.Text.Trim().Length > 0 ? " AND sProcessID = '" + txtProcessID.Text.Trim() + "'" : "";
            sSelect += txtNobr.Text.Trim().Length > 0 ? " AND sNobr = '" + txtNobr.Text.Trim() + "'" : "";
            sSelect += ckError.Checked && sProcessID.Length > 0 ? " AND sProcessID Not IN (" + sProcessID + ")" : "";

            switch (rForm.sFormCode)
            {
                case "Abs":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    sSelect += " AND sHcode <> 'O'";
                    break;
                case "Ot":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "Card":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "ShiftShort":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateA >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateA <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDeptA = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "ShiftLong":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "Abs1":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    sSelect += " AND sHcode = 'O'";
                    break;
                case "Abs2":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    sSelect += " AND sHcode = 'O'";
                    break;
                case "Absc":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                default:
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
            }

            sSelect += " AND idProcess > 0";

            //如果不具備管理權限，僅可查詢(申請者)及(被申請者)及(審核者)工號相符的資料
            if (!ckManage.Checked)
            {
                sSelect += " AND (sNobr = '" + lblNobr.Text + "'";
                sSelect += " OR EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".sNobr = '" + lblNobr.Text + "')";
                sSelect += " OR EXISTS (Select 1 From " + rForm.s3 + " Where " + rForm.s3 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s3 + ".sNobr =  '" + lblNobr.Text + "'))";
            }

            //簽核開始日
            if (txtDateA.Text.Trim().Length > 0)
                sSelect += " AND EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".dKeyDate >= '" + txtDateA.Text + "')";

            //簽結結束日
            if (txtDateD.Text.Trim().Length > 0)
                sSelect += " AND EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".dKeyDate <= '" + txtDateD.Text + "')";

            sSelect += lblSort.Text.Trim().Length > 0 ? " Order by " + lblSort.Text.Trim() + " " + lblSort.ToolTip.Trim() : "";

            sdsView.SelectCommand = sSelect;
            sdsView.DataBind();

            gv.AllowSorting = true;
            gv.AllowPaging = true;
            gv.PageSize = 20;
            gv.PageIndex = Convert.ToInt32(lblPage.Text);
            gv.DataSource = sdsView;
            gv.DataBind();

            lblCount.Text = GetDataTable(sSelect).Rows.Count.ToString();

            btnActive.CommandName = gv.ID;
        }
    }
    private void SqlGV(GridView gv)
    {
        var rForm = (from c in dcFlow.wfForm
                     where c.sFormCode == btnDisplay.CommandArgument
                     select c).FirstOrDefault();

        if (rForm != null)
        {
            lblCount.ToolTip = rForm.sFlowTree;

            lsProcessID = (from pc in dcFlow.ProcessCheck
                           join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                           join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                           where !Convert.ToBoolean(pn.isFinish)
                           && !Convert.ToBoolean(pf.isFinish)
                           && !Convert.ToBoolean(pf.isError)
                           && !Convert.ToBoolean(pf.isCancel)
                           && pf.FlowTree_id == lblCount.ToolTip
                           //&& (pc.Emp_idDefault == lblNobr.Text || pc.Emp_idAgent == lblNobr.Text)
                           select pf.id.ToString()).ToList();

            string sProcessID = "";
            foreach (string s in lsProcessID)
                sProcessID += "'" + s + "',";
            sProcessID = sProcessID.Length > 0 ? sProcessID + "'-1'" : "";

            string sSelect = "Select * From " + rForm.s4 + " Where 1 = 1";
            //sSelect += " AND idProcess <> 0";
            sSelect += ddlState.SelectedItem.Value != "-1" ? " AND sState = '" + ddlState.SelectedItem.Value + "'" : "";
            sSelect += txtProcessID.Text.Trim().Length > 0 ? " AND sProcessID = '" + txtProcessID.Text.Trim() + "'" : "";
            sSelect += txtNobr.Text.Trim().Length > 0 ? " AND sNobr = '" + txtNobr.Text.Trim() + "'" : "";
            sSelect += ckError.Checked && sProcessID.Length > 0 ? " AND sProcessID Not IN (" + sProcessID + ")" : "";

            switch (rForm.sFormCode)
            {
                case "Abs":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    sSelect += " AND sHcode <> 'O'";
                    break;
                case "Ot":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "Card":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "ShiftShort":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateA >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateA <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDeptA = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "ShiftLong":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                case "Abs1":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    sSelect += " AND sHcode = 'O'";
                    break;
                case "Abs2":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    sSelect += " AND sHcode = 'O'";
                    break;
                case "Absc":
                    sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                    sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
                default:
                    sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                    break;
            }

            //簽核開始日
            if (txtDateA.Text.Trim().Length > 0)
                sSelect += " AND EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".dKeyDate >= '" + txtDateA.Text + "')";

            //簽結結束日
            if (txtDateD.Text.Trim().Length > 0)
                sSelect += " AND EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".dKeyDate <= '" + txtDateD.Text + "')";

            //如果不具備管理權限，僅可查詢(申請者)及(被申請者)及(審核者)工號相符的資料
            if (!ckManage.Checked)
            {
                sSelect += " AND (sNobr = '" + lblNobr.Text + "'";
                sSelect += " OR EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".sNobr = '" + lblNobr.Text + "')";
                sSelect += " OR EXISTS (Select 1 From " + rForm.s3 + " Where " + rForm.s3 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s3 + ".sNobr =  '" + lblNobr.Text + "'))";
            }

            sSelect += lblSort.Text.Trim().Length > 0 ? " Order by " + lblSort.Text.Trim() + " " + lblSort.ToolTip.Trim() : "";
            lblSql.Text = sSelect;
        }
    }
    protected void btnSql_Click(object sender, EventArgs e)
    {
        lblPage.Text = "0";
        lblSort.Text = "";

        GridView gv;
        foreach (ListItem li in ddlForm.Items)
        {
            gv = updatePanel1.FindControl("gv" + li.Value) as GridView;
            if (gv != null)
            {
                gv.Visible = (li.Value == ddlForm.SelectedItem.Value);

                if (li.Value == ddlForm.SelectedItem.Value)
                {
                    btnDisplay.CommandArgument = li.Value;  //將選的表單暫存到顯示的按鈕裡，以防止使用者中途更換
                    SqlGV(gv);
                }
            }
        }
    }
    protected void ddlActive_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnActive.OnClientClick = "";
        if (ddlActive.SelectedItem.Value != "0")
            btnActive.OnClientClick = "return confirm('您確定要將選取的流程" + ddlActive.SelectedItem.Text + "嗎？')";
        else
            btnActive.OnClientClick = "alert('請選擇執行動作');return false;";
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {
        string sActive = ddlActive.SelectedItem.Value;
        if (sActive == "0") return;

        var rForm = (from c in dcFlow.wfForm
                     where c.sFormCode == btnDisplay.CommandArgument
                     select c).FirstOrDefault();

        if (rForm != null)
        {
            List<int> lsAutoKey = new List<int>();
            List<string> lsID = new List<string>();

            GridView gv = updatePanel1.FindControl(btnActive.CommandName) as GridView;
            if (gv != null)
            {
                CheckBox ckActive;
                foreach (GridViewRow gvr in gv.Rows)
                {
                    ckActive = gvr.FindControl("ckActive") as CheckBox;
                    if (ckActive != null && ckActive.Checked)
                    {
                        lsAutoKey.Add(Convert.ToInt32(ckActive.ValidationGroup));
                        if (!lsID.Contains(ckActive.ToolTip))
                            lsID.Add(ckActive.ToolTip);
                    }
                }

                localhost.Service oService = new localhost.Service();
                DynamicSrv.Service oDynamicSrv = new DynamicSrv.Service();

                //取得服務網址
                var rFlowNode = (from c in dcFlow.FlowNode
                                 where c.nodeType == "11"
                                 && c.FlowTree_id == rForm.sFlowTree
                                 select c).FirstOrDefault();

                if (rFlowNode != null)
                    oDynamicSrv.Url = rFlowNode.NodeService.webSrvUrl;

                int iID, i = 0, j = 0;
                string sRoleM, sRoleS, sNobrM, sNobrS;
                int iCateOrder;
                object[] obj = new object[] { "" }, objM = new object[] { "" }, objS = new object[] { "" };

                foreach (var rID in lsID)
                {
                    //把原本的流程修正變成完成狀態
                    var rProcessFlow = (from c in dcFlow.ProcessFlow
                                        where c.id == Convert.ToInt32(rID)
                                        select c).FirstOrDefault();

                    var lsProcessNode = (from c in dcFlow.ProcessNode
                                         where c.ProcessFlow_id == Convert.ToInt32(rID)
                                         select c).ToList();

                    i++;

                    sRoleM = "";
                    sRoleS = "";
                    sNobrM = "";
                    sNobrS = "";
                    iCateOrder = 0;

                    var dtAppM = GetDataTable(GetAppSqlString(rForm.s3, rID));
                    if (dtAppM.Rows.Count > 0)
                    {
                        var dtAppS = GetDataTable(GetAppSqlString(rForm.s4, rID));
                        if (dtAppS.Rows.Count > 0)
                        {
                            sNobrM = Convert.ToString(dtAppM.Rows[0]["sNobr"]);
                            var dtRoleM = from c in dcFlow.Role
                                          where c.Emp_id == sNobrM
                                          select c;
                            var rRoleM = dtRoleM.FirstOrDefault();

                            sNobrS = Convert.ToString(dtAppS.Rows[0]["sNobr"]);
                            var dtRoleS = from c in dcFlow.Role
                                          where c.Emp_id == sNobrS
                                          select c;
                            var rRoleS = dtRoleS.FirstOrDefault();

                            if (rRoleM != null && rRoleS != null)
                            {
                                sRoleM = rRoleM.id;
                                sNobrM = rRoleM.Emp_id;
                                sRoleS = rRoleS.id;
                                sNobrS = rRoleS.Emp_id;

                                var dtDept = from c in dcFlow.Dept
                                            where c.id == rRoleS.Dept_id
                                            select c;
                                var rDept = dtDept.FirstOrDefault();

                                if (rDept != null)
                                    iCateOrder = Convert.ToInt32(rDept.DeptLevel_id);
                            }
                        }
                    }

                    switch (sActive)
                    {
                        case "1":  //重送
                            if (rProcessFlow != null)
                            {
                                rProcessFlow.isCancel = true;
                                dcFlow.SubmitChanges();

                                iID = oService.GetProcessID();
                                objM = new object[] { rForm.s3, "1", iID, rID, "1" };
                                objS = new object[] { rForm.s4, "1", iID, rID, "1" };

                                if (oService.FlowStart(iID, rForm.sFlowTree, sRoleS, sNobrS, sRoleM, sNobrM))
                                {
                                    j++;

                                    obj = new object[] { iID, rID };

                                    //把附件檔案改過來
                                    switch (rForm.sFormCode)
                                    {
                                        case "Abs":
                                            dcForm.ExecuteCommand("UPDATE wfFormApp SET sConditions1 = '0' WHERE idProcess = {1}", obj);
                                            dcForm.ExecuteCommand("UPDATE wfFormUploadFile SET sProcessID = {0} , idProcess = {0} WHERE idProcess = {1}", obj);
                                            break;
                                        //case "Abs1":
                                        //    dcForm.ExecuteCommand("UPDATE wfAppAbs1Currency SET sProcessID = {0} , idProcess = {0} WHERE idProcess = {1}", obj);
                                        //    dcForm.ExecuteCommand("UPDATE wfAppAbs1Ticket SET sProcessID = {0} , idProcess = {0} WHERE idProcess = {1}", obj);
                                        //    dcForm.ExecuteCommand("UPDATE wfFormAppCode SET sProcessID = {0} , idProcess = {0} WHERE idProcess = {1}", obj);
                                        //    break;
                                        //case "Ot" :
                                        //    dcForm.ExecuteCommand("UPDATE wfOtAppM SET iCateOrder = " + iCateOrder + " WHERE idProcess = {1}", obj);
                                        //    break;
                                    }
                                }
                            }

                            break;

                        case "4":   //原點重送
                            foreach (var rProcessNode in lsProcessNode)
                            {
                                var lsProcessCheck = (from c in dcFlow.ProcessCheck
                                                      where c.ProcessNode_auto == rProcessNode.auto
                                                      select c).ToList();

                                foreach (var rProcessCheck in lsProcessCheck)
                                    dcFlow.ProcessCheck.DeleteOnSubmit(rProcessCheck);

                                dcFlow.ProcessNode.DeleteOnSubmit(rProcessNode);
                            }

                            dcFlow.ProcessFlow.DeleteOnSubmit(rProcessFlow);

                            dcFlow.SubmitChanges();

                            objM = new object[] { rForm.s3, "1", rID, rID, "1" };
                            objS = new object[] { rForm.s4, "1", rID, rID, "1" };
                            if (oService.FlowStart(Convert.ToInt32(rID), rForm.sFlowTree, sRoleS, sNobrS, sRoleM, sNobrM))
                                j++;

                            break;
                        case "5":   //上點重送
                            //節點大於2筆才能尋找上點重送
                            if (lsProcessNode.Count >= 2)
                            {
                                var rProcessNode = lsProcessNode.OrderByDescending(p => p.auto).ToList()[0];    //取得當前的ProcessNode
                                var rProcessNode1 = lsProcessNode.OrderByDescending(p => p.auto).ToList()[1];   //取得上一筆的ProcessNode

                                //用當前的ProcessNode取得ProcessCheck
                                var rProcessCheck = (from c in dcFlow.ProcessCheck
                                                     where c.ProcessNode_auto == rProcessNode.auto
                                                     select c).FirstOrDefault();

                                //取得上一筆ProcessCheck
                                var rProcessCheck1 = (from c in dcFlow.ProcessCheck
                                                      where c.ProcessNode_auto == rProcessNode1.auto
                                                      select c).FirstOrDefault();

                                if (rProcessCheck != null)
                                {
                                    //當前的ProcessApParm
                                    var rProcessApParm = (from c in dcFlow.ProcessApParm
                                                          where c.ProcessFlow_id == Convert.ToInt32(rID)
                                                          && c.ProcessNode_auto == rProcessNode.auto
                                                          && c.ProcessCheck_auto == rProcessCheck.auto
                                                          select c).FirstOrDefault();

                                    //上一筆ProcessApParm
                                    var rProcessApParm1 = (from c in dcFlow.ProcessApParm
                                                           where c.ProcessFlow_id == Convert.ToInt32(rID)
                                                           && c.ProcessNode_auto == rProcessNode1.auto
                                                           && c.ProcessCheck_auto == rProcessCheck1.auto
                                                           select c).FirstOrDefault();

                                    if (rProcessApParm != null)
                                    {
                                        //刪除所有當前的值
                                        rProcessFlow.isError = false;
                                        rProcessCheck1.Emp_idReal = "";
                                        rProcessCheck1.Role_idReal = "";
                                        rProcessNode1.isFinish = false;
                                        dcFlow.ProcessApParm.DeleteOnSubmit(rProcessApParm);
                                        dcFlow.ProcessNode.DeleteOnSubmit(rProcessNode);
                                        dcFlow.ProcessCheck.DeleteOnSubmit(rProcessCheck);
                                        dcFlow.SubmitChanges();

                                        if (oService.WorkFinish(rProcessApParm1.auto))
                                            j++;
                                    }
                                }
                            }

                            objM = new object[] { rForm.s3, "1", rID, rID, "1" };
                            objS = new object[] { rForm.s4, "1", rID, rID, "1" };

                            break;
                        case "2":   //存入
                            if (rProcessFlow != null)
                            {
                                rProcessFlow.isCancel = true;
                                dcFlow.SubmitChanges();

                                objM = new object[] { rForm.s3, "3", rID, rID, "1" };
                                objS = new object[] { rForm.s4, "3", rID, rID, "1" };

                                //呼叫服務
                                oDynamicSrv.Run(Flow.GetViewID(Convert.ToInt32(rID), ""));

                                j++;
                            }
                            break;
                        case "3":   //刪除
                            if (rProcessFlow != null)
                            {
                                rProcessFlow.isCancel = true;
                                dcFlow.SubmitChanges();
                                objM = new object[] { rForm.s3, "4", rID, rID, "0" };
                                objS = new object[] { rForm.s4, "4", rID, rID, "0" };

                                j++;
                            }
                            break;
                        default:
                            break;
                    }

                    dcFlow.ExecuteCommand("UPDATE " + rForm.s3 + " SET sState = {1} , sProcessID = {2} , idProcess = {2} , bSign = {4} WHERE idProcess = {3}", objM);
                    dcFlow.ExecuteCommand("UPDATE " + rForm.s4 + " SET sState = {1} , sProcessID = {2} , idProcess = {2} , bSign = {4} WHERE idProcess = {3}", objS);
                }   //foreach

                BindGV(gv);
                BindFlow();
                lblMsg.Text = "共" + ddlActive.SelectedItem.Text + i.ToString() + "筆,成功" + j.ToString() + "筆";
                ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
            }   //if
        }
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddlState.SelectedItem.Value == "1")
        {
            if (lsProcessID == null)
            {
                lsProcessID = (from pc in dcFlow.ProcessCheck
                               join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                               join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                               where !Convert.ToBoolean(pn.isFinish)
                               && !Convert.ToBoolean(pf.isFinish)
                               && !Convert.ToBoolean(pf.isError)
                               && !Convert.ToBoolean(pf.isCancel)
                               && pf.FlowTree_id == lblCount.ToolTip
                               //&& (pc.Emp_idDefault == lblNobr.Text || pc.Emp_idAgent == lblNobr.Text)
                               select pf.id.ToString()).ToList();
            }

            Button btnView = e.Row.FindControl("btnView") as Button;
            if (btnView != null)
            {
                if (!lsProcessID.Contains(btnView.CommandArgument))
                    e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }

        HyperLink hlForm = e.Row.FindControl("hlForm") as HyperLink;
        if (hlForm != null)
        {
            var rForm = (from c in dcFlow.wfForm
                         where c.sFormCode == btnDisplay.CommandArgument
                         select c).FirstOrDefault();

            var rSysVar = (from c in dcFlow.SysVar
                           select c).FirstOrDefault();

            int iProcessID = 0;
            hlForm.Visible = false;
            if (int.TryParse(hlForm.ToolTip, out iProcessID))
            {
                var rApViw = (from c in dcFlow.ProcessApView
                              where c.ProcessFlow_id == Convert.ToInt32(hlForm.ToolTip)
                              select c).FirstOrDefault();

                if (rSysVar != null && rForm != null && rApViw != null)
                {
                    hlForm.Visible = true;
                    hlForm.NavigateUrl = "" + rSysVar.urlRoot + "/Forms/FlowForm/" + rForm.sFormCode + "/Check.aspx?ApView=" + rApViw.auto.ToString();
                }
            }
        }
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cn = e.CommandName;
        string ca = e.CommandArgument.ToString();

        var rForm = (from c in dcFlow.wfForm
                     where c.sFormCode == btnDisplay.CommandArgument
                     select c).FirstOrDefault();

        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();

        var rApViw = (from c in dcFlow.ProcessApView
                      where c.ProcessFlow_id == Convert.ToInt32(ca)
                      select c).FirstOrDefault();

        if (rForm != null && cn == "View")
        {
            lblViewID.Text = ca;
            sdsAppM.SelectCommand = "Select * From " + rForm.s3 + " Where sProcessID = '" + lblViewID.Text + "'";
            sdsAppM.DataBind();

            sdsSignM.SelectCommand = "Select * From " + rForm.s2 + " Where sProcessID = '" + lblViewID.Text + "' Order By iAutoKey";
            sdsSignM.DataBind();

            lblDragNameView.Text = "流程序號" + ca;

            gvAppM.DataBind();
            gvSignM.DataBind();

            int t = 0;
            int.TryParse(ca, out t);
            lblViewID.Text = t.ToString();

            mpePopupView.Show();
        }
        else if (cn == "Message")   //特為出差單而設計
        {
            Abs1Message oAbs1Message = new Abs1Message();
            oAbs1Message.Run(Flow.GetViewID(Convert.ToInt32(ca), "ApView"));

            lblMsg.Text = "通知成功";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
            return;
        }
        //else if (rSysVar != null && rForm != null && rApViw != null && cn == "Form")
        //{
        //    string sLink = "" + rSysVar.urlRoot + "/Forms/FlowForm/" + rForm.sFormCode + "/Check.aspx?ApView=" + rApViw.auto.ToString();
        //    this.Page.Controls.Add(new LiteralControl(String.Format("<script>var w = window.open('{0}','_blank'); w.focus();</script>", sLink)));
        //    //Response.Write("<script>window.open('" + sLink + "','_blank')</script>");
        //    //Server.Transfer(sLink);
        //    //Response.Write("<script>window.showModelessDialog('" + sLink + "')</script>");
        //}
    }
    protected void btnExitView_Click(object sender, EventArgs e)
    {
        mpePopupView.Hide();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblCount.Text) > 1000)
        {
            lblMsg.Text = "由於資料筆數太多，匯出會有問題，請縮小條件範圍(1000筆)";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        GridView gv = updatePanel1.FindControl(btnActive.CommandName) as GridView;

        if (gv != null && gv.Rows.Count > 0)
        {
            gv.AllowPaging = false;
            gv.AllowSorting = false;
            var rForm = (from c in dcFlow.wfForm
                         where c.sFormCode == btnDisplay.CommandArgument
                         select c).FirstOrDefault();

            if (rForm != null)
            {
                lblCount.ToolTip = rForm.sFlowTree;

                lsProcessID = (from pc in dcFlow.ProcessCheck
                               join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                               join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                               where !Convert.ToBoolean(pn.isFinish)
                               && !Convert.ToBoolean(pf.isFinish)
                               && !Convert.ToBoolean(pf.isError)
                               && !Convert.ToBoolean(pf.isCancel)
                               && pf.FlowTree_id == lblCount.ToolTip
                               //&& (pc.Emp_idDefault == lblNobr.Text || pc.Emp_idAgent == lblNobr.Text)
                               select pf.id.ToString()).ToList();

                string sProcessID = "";
                foreach (string s in lsProcessID)
                    sProcessID += "'" + s + "',";
                sProcessID = sProcessID.Length > 0 ? sProcessID + "'-1'" : "";

                string sSelect = "Select * From " + rForm.s4 + " Where 1 = 1";
                //sSelect += " AND idProcess <> 0";
                sSelect += ddlState.SelectedItem.Value != "-1" ? " AND sState = '" + ddlState.SelectedItem.Value + "'" : "";
                sSelect += txtProcessID.Text.Trim().Length > 0 ? " AND sProcessID = '" + txtProcessID.Text.Trim() + "'" : "";
                sSelect += txtNobr.Text.Trim().Length > 0 ? " AND sNobr = '" + txtNobr.Text.Trim() + "'" : "";
                sSelect += ckError.Checked && sProcessID.Length > 0 ? " AND sProcessID Not IN (" + sProcessID + ")" : "";

                switch (rForm.sFormCode)
                {
                    case "Abs":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        sSelect += " AND sHcode <> 'O'";
                        break;
                    case "Ot":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        break;
                    case "Card":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        break;
                    case "ShiftShort":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateA >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateA <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDeptA = '" + txtDept.Text.Trim() + "'" : "";
                        break;
                    case "ShiftLong":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        break;
                    case "Abs1":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        sSelect += " AND sHcode = 'O'";
                        break;
                    case "Abs2":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDateB >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDateB <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        sSelect += " AND sHcode = 'O'";
                        break;
                    case "Absc":
                        sSelect += txtDateB.Text.Trim().Length > 0 ? " AND dDate >= '" + txtDateB.Text + "'" : "";
                        sSelect += txtDateE.Text.Trim().Length > 0 ? " AND dDate <= '" + txtDateE.Text + "'" : "";
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        break;
                    default:
                        sSelect += txtDept.Text.Trim().Length > 0 ? " AND sDept = '" + txtDept.Text.Trim() + "'" : "";
                        break;
                }

                //如果不具備管理權限，僅可查詢(申請者)及(被申請者)及(審核者)工號相符的資料
                if (!ckManage.Checked)
                {
                    sSelect += " AND (sNobr = '" + lblNobr.Text + "'";
                    sSelect += " OR EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".sNobr = '" + lblNobr.Text + "')";
                    sSelect += " OR EXISTS (Select 1 From " + rForm.s3 + " Where " + rForm.s3 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s3 + ".sNobr =  '" + lblNobr.Text + "'))";
                }

                //簽核開始日
                if (txtDateA.Text.Trim().Length > 0)
                    sSelect += " AND EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".dKeyDate >= '" + txtDateA.Text + "')";

                //簽結結束日
                if (txtDateD.Text.Trim().Length > 0)
                    sSelect += " AND EXISTS (Select 1 From " + rForm.s2 + " Where " + rForm.s2 + ".sProcessID = " + rForm.s4 + ".sProcessID AND " + rForm.s2 + ".dKeyDate <= '" + txtDateD.Text + "')";

                sSelect += lblSort.Text.Trim().Length > 0 ? " Order by " + lblSort.Text.Trim() + " " + lblSort.ToolTip.Trim() : "";

                sdsView.SelectCommand = sSelect;
                sdsView.DataBind();

                int i = Convert.ToInt32(gv.ToolTip);

                gv.Columns[0].Visible = false;
                if (i > 0)
                    gv.Columns[i].Visible = false;
                gv.AllowSorting = false;
                gv.AllowPaging = false;
                gv.PageSize = 20;
                gv.PageIndex = Convert.ToInt32(lblPage.Text);
                gv.DataSource = sdsView;
                gv.DataBind();

                lblCount.Text = GetDataTable(sSelect).Rows.Count.ToString();

                btnActive.CommandName = gv.ID;

                Flow.ExportXls(gv);

            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control) { }
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridView gv = updatePanel1.FindControl("gv" + btn.CommandArgument) as GridView;

        if (gv == null) return;

        CheckBox ckSend;
        foreach (GridViewRow r in gv.Rows)
        {
            ckSend = r.FindControl("ckActive") as CheckBox;
            ckSend.Checked = btn.CommandName == "1";
        }
    }
}