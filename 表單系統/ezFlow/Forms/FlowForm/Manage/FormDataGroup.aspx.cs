using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_FormDataGroup : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string sFormCode = ddlFormName.SelectedItem.Value;
        string sDataGroup = ddlDataGroup.SelectedItem.Value;

        var rFormDataGroup = (from c in dcFlow.wfFormDataGroup
                              where c.sFormCode == sFormCode
                              && c.sDataGroup == sDataGroup
                              select c).FirstOrDefault();

        if (rFormDataGroup != null)
        {
            lblMsg.Text = "資料重複！！";
            ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        rFormDataGroup = new wfFormDataGroup();
        rFormDataGroup.sFormCode = sFormCode;
        rFormDataGroup.sDataGroup = sDataGroup;
        rFormDataGroup.bFormDisplay = false;
        dcFlow.wfFormDataGroup.InsertOnSubmit(rFormDataGroup);
        dcFlow.SubmitChanges();

        gv.DataBind();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sFormCode = e.Row.Cells[2].Text;
            if (ddlDataGroup.Items.FindByValue(sFormCode) != null)
                e.Row.Cells[2].Text = ddlDataGroup.Items.FindByValue(sFormCode).Text;
        }
    }
}