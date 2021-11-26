using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AjaxControlToolkit;
using JBHR.Dll;

public partial class Abs_Check : System.Web.UI.Page
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
            btnMail.Visible = (RequestName == "ApParm");
            plMail.Visible =false && (RequestName == "ApParm");
            gvMail.Columns[0].Visible = (RequestName == "ApParm");

            lblProcessID.Text = Flow.GetProcessID(RequestName, Convert.ToInt32(RequestValue)).ToString();

            ddlName.DataBind();

            SetDefault();
        }
    }

    private void SetDefault()
    {
        lblTitle.ToolTip = "Abs";
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
            ListItem li = ddlName.Items.FindByValue("");
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
        }
        else
            txtName.Text = txtName.ToolTip;
    }
    #endregion

    protected void gvAppS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CheckBox ckSign = (CheckBox)e.Row.FindControl("ckSign");
        if (ckSign != null)
        {
            e.Row.Visible = (Request.QueryString.AllKeys[0] == "ApView") || ckSign.Checked;
            ckSign.Enabled = (Request.QueryString.AllKeys[0] != "ApView");
        }

        Button btnUpload = e.Row.FindControl("btnUpload") as Button;
        if (btnUpload != null)
        {
            btnUpload.Visible = false;

            var r = (from c in dcForm.wfAppAbs
                     where c.iAutoKey == Convert.ToInt32(btnUpload.CommandArgument)
                     select c).FirstOrDefault();

            if (r != null)
            {
                var rf = from c in dcFlow.wfFormUploadFile
                         where c.sProcessID == r.sProcessID
                         && c.sKey == r.sReserve4
                         select c;

                if (rf.Any())
                    btnUpload.Visible = true;
            }
        }
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

        var dtAppM = from c in dcFlow.wfFormApp
                     where c.sProcessID == lblProcessID.Text
                     select c;
        var rAppM = dtAppM.FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppAbs
                     where c.sProcessID == lblProcessID.Text
                     && c.sState == "1"
                     select c;

        if (rAppM == null || !dtAppS.Any())
        {
            lblMsg.Text = "找不到重要的簽核資料，請洽管理人員";
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

                        //發信通知被駁回的資料
                        //var rB = JBHR.Dll.Bas.EmpBase(rAppS.sNobr).FirstOrDefault();
                        //if (rB != null && rB.sEmail.Trim().Length > 0)
                        //{
                        //    sSubTitle = "駁回通知";
                        //    sBody = rAppS.sName + "您好：<br>您" + lblTitle.Text + "被主管駁回了，原因：" + txtNote.Text + "。<br>特此通知。";

                        //    Flow.SendMail(rB.sEmail.Trim(), sSubTitle, sBody);
                        //}
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
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('流程發生問題，您核准的動作可能無法完成。');self.close();", true);
        else
        {
            //闖關直接通知流程起始者
            if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
            {
                localhost.CApParm oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                var rProcessApParm = (from c in dcFlow.ProcessApParm
                                      where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                                      orderby c.auto descending
                                      select c).FirstOrDefault();

                if (rProcessApParm != null)
                {
                    rAppM.sConditions6 = "0";  //代理人簽過了

                    rProcessApParm.Emp_id = dtAppS.First().sNobr;
                    rProcessApParm.Role_id = dtAppS.First().sRole;

                    dcFlow.SubmitChanges();
                    dcForm.SubmitChanges();

                    if (!oService.WorkFinish(rProcessApParm.auto))
                        ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('流程發生問題，您核准的動作可能無法完成。');self.close();", true);
                }
            }

            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "OKMsg", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
        }
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

                mpePopupUpload.Show();
            }
        }
    }
    protected void btnExitUpload_Click(object sender, EventArgs e)
    {
        mpePopupUpload.Hide();
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
    protected void btnMail_Click(object sender, EventArgs e)
    {
        var rEmp = (from c in dcFlow.Emp
                    where c.id == lblNobrSign.Text
                    select c).FirstOrDefault();

        var rEmpA = (from c in dcFlow.Emp
                     where c.id == lblNobr.Text 
                     && c.email.Trim().Length  > 0
                     select c).FirstOrDefault();

        if (rEmp == null)
        {
            lblMsg.Text = "資訊不正確，請重新登入";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (rEmpA == null)
        {
            lblMsg.Text = "通知人不正確或沒有建立E-Mail";
            ScriptManager.RegisterStartupScript(updatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var r = new wfFormSendMail();
        r.sFormCode = lblTitle.ToolTip;
        r.sFormName = lblTitle.Text;
        r.sCategory = "";
        r.sProcessID = lblProcessID.Text;
        r.idProcess = Convert.ToInt32(r.sProcessID);
        r.sNobr = rEmpA.id;
        r.sName = rEmpA.name;
        r.sMail = rEmpA.email.Trim().Length > 0 ? rEmpA.email.Trim() : "";
        r.sContent = txtMail.Text;
        r.sKeyMan = rEmp.id;
        r.dKeyDate = DateTime.Now;
        dcForm.wfFormSendMail.InsertOnSubmit(r);

        dcForm.SubmitChanges();

        gvMail.DataBind();
    }
}