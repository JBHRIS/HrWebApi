using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_BaseData : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.Cookies["ezFlow"] == null || Request.Cookies["ezFlow"]["Emp_id"] == null)
            {
                btnSearch.Enabled = false;
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
                btnSearch.Enabled = false;
                lblMsg.Text = "您不具備管理權限，請洽人事單位";
                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
                return;
            }
        }

        lblMsg.Text = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (JBHR.Dll.Bas.EmpBase(txtNobr.Text).Rows.Count > 0)
            fvBase.ChangeMode(FormViewMode.Edit);
    }
    protected void fvBase_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        //var rEmp = (from c in dcFlow.Emp
        //            where c.id == e.NewValues["NOBR"].ToString()
        //            select c).FirstOrDefault();

        //if (rEmp != null)
        //{
        //    rEmp.name = e.NewValues["NAME_C"].ToString();
        //    dcFlow.SubmitChanges();
        //}
    }
    protected void fvBase_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        lblMsg.Text = "修改完成";
        ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
    }
}