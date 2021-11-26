using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Form : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();

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

            if (Request.Cookies["ezFlow"] == null || Request.Cookies["ezFlow"]["Emp_id"] == null)
            {
                lblMsg.Text = "由於太久沒有動作，請先登出，再重新登入";
                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
                return;
            }

            //lblNobr.Text = "F6816";
            lblNobr.Text = Convert.ToString(Request.Cookies["ezFlow"]["Emp_id"]);

            //是否具備管理權限
            bool bManage = (from c in dcFlow.SysAdmin
                            where c.Emp_id == lblNobr.Text
                            select c).Count() > 0;

            if (!bManage)
            {
                lblMsg.Text = "您不具備管理權限，請洽人事單位";
                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
                return;
            }
        }

        lblMsg.Text = "";
    }
    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        var rCode = from c in dcFlow.wfFormCode
                    where c.sCode == Convert.ToString(e.Values["sCode"])
                    select c;

        if (rCode.Any())
        {
            lblMsg.Text = "代碼不可以重複";
            ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            e.Cancel = true;
            return;
        }

        e.Values["sKeyMan"] = Request.Cookies["ezFlow"] != null ? Request.Cookies["ezFlow"]["Emp_id"] : "";
        e.Values["dKeyDate"] = DateTime.Now;
    }
    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        gv.DataBind();
    }
    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["sKeyMan"] = Request.Cookies["ezFlow"] != null ? Request.Cookies["ezFlow"]["Emp_id"] : "";
        e.NewValues["dKeyDate"] = DateTime.Now;
    }
    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        gv.DataBind();
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        fv.ChangeMode(FormViewMode.Edit);
    }
    protected void gv_Sorted(object sender, EventArgs e)
    {
        fv.ChangeMode(FormViewMode.Insert);
        fv.DataBind();
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ca = e.CommandName;
        string cn = e.CommandArgument.ToString();

        if (cn.Length > 0)
        {
            var rForm = (from c in dcFlow.wfForm
                         where c.iAutoKey == Convert.ToInt32(cn)
                         select c).FirstOrDefault();

            if (rForm != null)
            {
                lblNoteID.Text = cn;
                lblNoteID.ToolTip = ca;

                switch (ca)
                {
                    case "EditStdNote":
                        txtNote.Content = rForm.sStdNote;
                        lblDragNameNote.Text = "申請備註";
                        mpePopupNote.Show();
                        break;
                    case "EditChkNote":
                        txtNote.Content = rForm.sCheckNote;
                        lblDragNameNote.Text = "審核備註";
                        mpePopupNote.Show();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    protected void btnNoteSave_Click(object sender, EventArgs e)
    {
        var rForm = (from c in dcFlow.wfForm
                     where c.iAutoKey == Convert.ToInt32(lblNoteID.Text)
                     select c).FirstOrDefault();

        if (rForm != null)
        {
            switch (lblNoteID.ToolTip)
            {
                case "EditStdNote":
                    rForm.sStdNote = txtNote.Content;
                    break;
                case "EditChkNote":
                    rForm.sCheckNote = txtNote.Content;
                    break;
                default:
                    break;
            }

            lblMsg.Text = "儲存完成";
            dcFlow.SubmitChanges();
        }
    }
}