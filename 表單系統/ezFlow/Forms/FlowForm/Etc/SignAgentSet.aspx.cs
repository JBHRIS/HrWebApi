using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Etc_SignAgentSet : System.Web.UI.Page
{
    private dcHRDataContext dcHR = new dcHRDataContext();

    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblNobr.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobr.Text;
            txtDateB.SelectedDate = DateTime.Now.Date;
            txtDateE.SelectedDate = DateTime.Now.Date;

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                lblNobr.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            lblNobr.Text = lblNobr.Text.Trim().Length == 0 ? " " : lblNobr.Text;

            txtNobr_DataBind();
            txtNameAgent_DataBind();

            SetDefault();

            txtNobr.Enabled = false;

            var rSysAdmin = (from c in dcFlow.SysAdmin
                             where c.Emp_id == lblNobr.Text
                             select c).FirstOrDefault();

            if (rSysAdmin != null)
                txtNobr.Enabled = true;
        }
    }

    private void txtNobr_DataBind()
    {
        Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHR.Connection);
        var rsBas = oBasDao.GetBaseByDept();

        txtNobr.DataSource = rsBas;
        txtNobr.DataTextField = "Name";
        txtNobr.DataValueField = "Nobr";
        txtNobr.DataBind();
    }

    private void txtNameAgent_DataBind()
    {
        Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHR.Connection);
        var rsBas = oBasDao.GetBaseByDept();

        txtAgent1.DataSource = rsBas;
        txtAgent1.DataTextField = "Name";
        txtAgent1.DataValueField = "Nobr";
        txtAgent1.DataBind();

        txtAgent2.DataSource = rsBas;
        txtAgent2.DataTextField = "Name";
        txtAgent2.DataValueField = "Nobr";
        txtAgent2.DataBind();

        txtAgent3.DataSource = rsBas;
        txtAgent3.DataTextField = "Name";
        txtAgent3.DataValueField = "Nobr";
        txtAgent3.DataBind();
    }

    private void SetDefault()
    {
        if (txtNobr.Items.FindItemByValue(lblNobr.Text) != null)
            txtNobr.Items.FindItemByValue(lblNobr.Text).Selected = true;

        SetRole(lblNobr.Text);

        if (txtRole.SelectedItem != null)
            SetAgent(lblNobr.Text, txtRole.SelectedItem.Value);

        SetAgentDate(lblNobr.Text);
    }

    private void SetRole(string sNobr)
    {
        var rRole = (from r in dcFlow.Role
                     join d in dcFlow.Dept on r.Dept_id equals d.id
                     join p in dcFlow.Pos on r.Pos_id equals p.id
                     where r.Emp_id == sNobr
                     select new
                     {
                         Code = r.id,
                         Name = d.name.Trim() + "-" + p.name.Trim(),
                     }).ToList();

        txtRole.DataSource = rRole;
        txtRole.DataTextField = "Name";
        txtRole.DataValueField = "Code";
        txtRole.DataBind();
    }

    private void SetAgent(string sNobr , string sRole)
    {
        txtAgent1.ClearSelection();
        txtAgent2.ClearSelection();
        txtAgent3.ClearSelection();
        txtAgent1.Text = "";
        txtAgent2.Text = "";
        txtAgent3.Text = "";
        lblAgent1.Text = "";
        lblAgent2.Text = "";
        lblAgent3.Text = "";

        var rCheckAgentDefault = (from c in dcFlow.CheckAgentDefault
                                  where c.Emp_idSource == sNobr && c.Role_idSource == sRole
                                  select c).FirstOrDefault();

        if (rCheckAgentDefault != null)
        {
            if (rCheckAgentDefault.Emp_idTarget1 != null && rCheckAgentDefault.Emp_idTarget1.Length > 0)
                if (txtAgent1.Items.FindItemByValue(rCheckAgentDefault.Emp_idTarget1) != null)
                {
                    txtAgent1.Items.FindItemByValue(rCheckAgentDefault.Emp_idTarget1).Selected = true;

                    var rEmp = (from c in dcFlow.Emp
                                where c.id == rCheckAgentDefault.Emp_idTarget1
                                select c).FirstOrDefault();

                    if (rEmp != null)
                        lblAgent1.Text = rEmp.name;
                }

            if (rCheckAgentDefault.Emp_idTarget2 != null && rCheckAgentDefault.Emp_idTarget2.Length > 0)
                if (txtAgent2.Items.FindItemByValue(rCheckAgentDefault.Emp_idTarget2) != null)
                {
                    txtAgent2.Items.FindItemByValue(rCheckAgentDefault.Emp_idTarget2).Selected = true;

                    var rEmp = (from c in dcFlow.Emp
                                where c.id == rCheckAgentDefault.Emp_idTarget2
                                select c).FirstOrDefault();

                    if (rEmp != null)
                        lblAgent2.Text = rEmp.name;
                }

            if (rCheckAgentDefault.Emp_idTarget3 != null && rCheckAgentDefault.Emp_idTarget3.Length > 0)
                if (txtAgent3.Items.FindItemByValue(rCheckAgentDefault.Emp_idTarget3) != null)
                {
                    txtAgent3.Items.FindItemByValue(rCheckAgentDefault.Emp_idTarget3).Selected = true;

                    var rEmp = (from c in dcFlow.Emp
                                where c.id == rCheckAgentDefault.Emp_idTarget3
                                select c).FirstOrDefault();

                    if (rEmp != null)
                        lblAgent3.Text = rEmp.name;
                }
        }        
    }

    private void SetAgentDate(string sNobr)
    {
        lblDateBE.Text = "";

        var rEmp = (from c in dcFlow.Emp
                    where c.id == sNobr
                    select c).FirstOrDefault();

        if (rEmp != null)
        {
            txtDateB.SelectedDate = rEmp.dateB;
            txtDateE.SelectedDate = rEmp.dateE;

            lblDateBE.Text = rEmp.dateB.Value.ToShortDateString() + "-" + rEmp.dateE.Value.ToShortDateString();
        }
    }


    protected void txtNobr_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (txtNobr.SelectedItem != null)
        {
            SetRole(txtNobr.SelectedItem.Value);
            SetAgent(txtNobr.SelectedItem.Value, txtRole.SelectedItem.Value);
            SetAgentDate(txtNobr.SelectedItem.Value);
        }
    }

    protected void txtRole_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (txtNobr.SelectedItem != null)
        {
            SetAgent(txtNobr.SelectedItem.Value, txtRole.SelectedItem.Value);
            SetAgentDate(txtNobr.SelectedItem.Value);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sNobr = txtNobr.SelectedItem != null ? txtNobr.SelectedItem.Value : "";
        string sRole = txtRole.SelectedItem != null ? txtRole.SelectedItem.Value : "";
        string sAgent1 = txtAgent1.SelectedItem != null ? txtAgent1.SelectedItem.Value : "";
        string sAgent2 = txtAgent2.SelectedItem != null ? txtAgent2.SelectedItem.Value : "";
        string sAgent3 = txtAgent3.SelectedItem != null ? txtAgent3.SelectedItem.Value : "";

        DateTime dDateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;
        DateTime dDateE = txtDateE.SelectedDate.GetValueOrDefault(DateTime.Now).Date;

        if (sNobr.Length == 0 || sNobr.Length == 0)
        {
            RadWindowManager1.RadAlert("工號或角色不正確", 300, 100, "警告訊息", "", "");
            return;
        }

        if (dDateB > dDateE)
        {
            RadWindowManager1.RadAlert("開始日期比結束日期大", 300, 100, "警告訊息", "", "");
            return;
        } 

        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        oMainDao.SetAgent(sNobr, sRole, sAgent1, sAgent2, sAgent3, dDateB, dDateE);

        SetAgent(txtNobr.SelectedItem.Value, txtRole.SelectedItem.Value);
        SetAgentDate(txtNobr.SelectedItem.Value);
    }
}