using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Manage_Agent : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobrAppM.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            lblNobrAppM.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobrAppM.Text;
            lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號

            lblNobrAppM.Text = lblNobrAppM.Text.Trim().Length == 0 ? " " : lblNobrAppM.Text;

            var rEmp = JBHR.Dll.Bas.EmpBase(lblNobrAppM.Text).FirstOrDefault();
            if (rEmp != null)
                lblDept.Text = rEmp.sDeptmCode;

            lblDate.Text = "AD-1000";

            cbName.DataBind();

            SetName(lblNobrAppM.Text);
            txtMail.ReadOnly = true;
        }

        lblMsg.Text = "";
    }

    #region 工號及姓名
    protected void cbName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBoxItem li = cbName.SelectedItem;

        if (li != null)
            SetName(li);
    }
    protected void cbName_DataBound(object sender, EventArgs e)
    {
        RadComboBoxItem li = cbName.SelectedItem;
        if (!IsPostBack)
        {
            SetName(lblNobrAppM.Text);
        }
    }
    protected void cbName_TextChanged(object sender, EventArgs e)
    {
        RadComboBoxItem li = cbName.SelectedItem;
        if (li != null)
            SetName(li);
        else if (cbName.Text.Trim().Length > 0)
            SetName(cbName.Text);
    }
    private void SetName(RadComboBoxItem li)
    {
        if (li != null)
        {
            cbName.ClearSelection();
            li.Selected = true;
            SetName(li.Value);
        }
    }
    private void SetName(string sNobr)
    {
        string[] arrTtscode = { "1", "4", "6" };
        var r = JBHR.Dll.Bas.EmpBaseByNobrDeptmAll("0", "DI")
            .Where(p => (p.sNobr == sNobr || p.sNameC.Trim() == sNobr) && arrTtscode.Contains(p.sTtsCode.Trim())).FirstOrDefault();

        if (r != null && (cbName.Text.Trim().Length > 0 || sNobr.Trim().Length > 0))
        {
            lblNobr.Text = r.sNobr.Trim();
            cbName.Text = r.sName.Trim();
            cbName.ToolTip = r.sName.Trim();
            txtMail.Text = r.sEmail;
        }
        else
            cbName.Text = cbName.ToolTip;
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var rEmp = (from c in dcFlow.Emp
                    where c.id == lblNobrAppM.Text
                    select c).FirstOrDefault();

        var rEmpA = (from c in dcFlow.Emp
                     where c.id == lblNobr.Text
                     select c).FirstOrDefault();

        if (rEmp == null)
        {
            lblMsg.Text = "資訊不正確，請重新登入";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        if (rEmpA == null)
        {
            lblMsg.Text = "代理人不正確";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        var r = (from c in dcForm.wfAppAgent
                 where c.sNobr == rEmp.id
                 && c.sAgentNobr == rEmpA.id
                 select c).FirstOrDefault();

        if (r == null)
        {
            r = new wfAppAgent();
            dcForm.wfAppAgent.InsertOnSubmit(r);
        }
       
        r.sNobr = rEmp.id;
        r.sName = rEmp.name;
        r.sAgentNobr = rEmpA.id;
        r.sAgentName = rEmpA.name;
        r.sAgentMail = txtMail.Text.Trim().Length > 0 ? txtMail.Text.Trim() : rEmpA.email;
        r.sKeyMan = rEmp.id;
        r.dKeyDate = DateTime.Now;
       
        dcForm.SubmitChanges();

        gv.DataBind();
    }
}