using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Flow_WorkAgent : JBWebPage
{
    AllModule Module = new AllModule();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            lb_nobr.Text = JbUser.NOBR;
            ezClientDS.RoleDataTable dtMyRole = Module.adRole.GetDataByEmp(JbUser.NOBR);
            if (dtMyRole.Count > 0)
            {
                for (int i = 0; i < dtMyRole.Count; i++)
                {
                    ListItem listItem = new ListItem();
                    ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtMyRole[i].Pos_id);
                    ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtMyRole[i].Dept_id);
                    if (dtDept.Count > 0 && dtPos.Count > 0)
                    {
                        listItem.Text = dtPos[0].name + "@" + dtDept[0].name;
                        listItem.Value = dtMyRole[i].id;

                        cbMyRole.Items.Add(listItem);
                    }
                }
            }

            if (GridView1.Rows.Count > 0)
            {
                GridView1.SelectedIndex = 0;
                ezClientDS.WorkAgentDataTable dtWorkAgent = Module.adWorkAgent.GetDataByAuto(Convert.ToInt32(GridView1.SelectedValue));
                if (dtWorkAgent.Count > 0)
                {
                    ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtWorkAgent[0].Role_idTarget, dtWorkAgent[0].Emp_idTarget);
                    if (dtRole.Count > 0)
                    {
                        ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
                        if (dtDept.Count > 0) Session["Path"] = dtDept[0].path;
                        Session["Role_ID"] = dtRole[0].id;
                    }
                }
            }
        }
    }

    protected void txtAgentEmp_TextChanged(object sender, EventArgs e)
    {
        txtAgentDept.Text = "";
        txtAgentPos.Text = "";
        cbAgentRole.Items.Clear();
        if (txtAgentEmp.Text.Trim().Length > 0)
        {
            ezClientDS.EmpDataTable dtAgentEmp = Module.adEmp.GetDataBySearch(txtAgentEmp.Text);
            if (dtAgentEmp.Count > 0)
            {
                txtAgentEmp.Text = dtAgentEmp[0].name;
                ViewState["AgentEmpID"] = dtAgentEmp[0].id;
                ezClientDS.RoleDataTable dtAgentRole = Module.adRole.GetDataByEmp(dtAgentEmp[0].id);
                if (dtAgentRole.Count > 0)
                {
                    for (int i = 0; i < dtAgentRole.Count; i++)
                    {
                        ListItem listItem = new ListItem();
                        ezClientDS.PosDataTable dtAgentPos = Module.adPos.GetDataById(dtAgentRole[i].Pos_id);
                        if (dtAgentPos.Count > 0)
                        {
                            listItem.Text = dtAgentPos[0].name;
                            listItem.Value = dtAgentRole[i].id;

                            cbAgentRole.Items.Add(listItem);

                            if (i == 0)
                            {
                                txtAgentPos.Text = dtAgentPos[0].name;
                                ezClientDS.DeptDataTable dtAgentDept = Module.adDept.GetDataById(dtAgentRole[i].Dept_id);
                                if (dtAgentDept.Count > 0)
                                {
                                    txtAgentDept.Text = dtAgentDept[0].name;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            ezClientDS.WorkAgentRow rowWorkAgent = (ezClientDS.WorkAgentRow)((DataRowView)e.Row.DataItem).Row;
            ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(rowWorkAgent.Role_idTarget, rowWorkAgent.Emp_idTarget);
            if (dtRole.Count > 0)
            {
                Control ctrl = null;
                ctrl = e.Row.FindControl("lbDept");
                if (ctrl != null)
                {
                    ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
                    if (dtDept.Count > 0) ((Label)ctrl).Text = dtDept[0].name;
                }

                ctrl = e.Row.FindControl("lbPos");
                if (ctrl != null)
                {
                    ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
                    if (dtPos.Count > 0) ((Label)ctrl).Text = dtPos[0].name;
                }

                ctrl = e.Row.FindControl("lbEmp");
                if (ctrl != null)
                {
                    ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtRole[0].Emp_id);
                    if (dtEmp.Count > 0) ((Label)ctrl).Text = dtEmp[0].name;
                }
            }
        }
    }

    protected void bnAddAgent_Click(object sender, EventArgs e)
    {
        if (txtAgentEmp.Text.Trim().Length > 0 && txtAgentDept.Text.Trim().Length > 0 && txtAgentPos.Text.Trim().Trim().Length > 0)
        {
            if (ViewState["AgentEmpID"].ToString() == JbUser.NOBR)
            {
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('不可以指定自己為工作代理人');", true);
                return;
            }

            ezClientDS.WorkAgentDataTable dtWorkAgent = Module.adWorkAgent.GetDataByIdTarget(cbAgentRole.SelectedValue, ViewState["AgentEmpID"].ToString());
            if (dtWorkAgent.Count > 0)
            {
                bool bError = false;
                foreach (ezClientDS.WorkAgentRow drWorkAgent in dtWorkAgent.Rows)
                {
                    if (drWorkAgent.Role_idSource == cbMyRole.SelectedValue &&
                        drWorkAgent.Emp_idSource == JbUser.NOBR)
                    {
                        bError = true;
                        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                            Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請勿重覆加入相同的成員');", true);
                        break;
                    }
                }
                if (bError) return;
            }

            ezClientDS.WorkAgentRow rowWorkAgent = dtWorkAgent.NewWorkAgentRow();
            rowWorkAgent.Role_idSource = cbMyRole.SelectedValue;
            rowWorkAgent.Emp_idSource = JbUser.NOBR;
            rowWorkAgent.Role_idTarget = cbAgentRole.SelectedValue;
            rowWorkAgent.Emp_idTarget = ViewState["AgentEmpID"].ToString();
            dtWorkAgent.AddWorkAgentRow(rowWorkAgent);
            Module.adWorkAgent.Update(dtWorkAgent);

            GridView1.DataBind();
            GridView1.SelectedIndex = GridView1.Rows.Count - 1;

            if (dtWorkAgent.Count > 0)
            {
                ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtWorkAgent[0].Role_idTarget, dtWorkAgent[0].Emp_idTarget);
                if (dtRole.Count > 0)
                {
                    ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
                    if (dtDept.Count > 0) Session["Path"] = dtDept[0].path;
                    Session["Role_ID"] = dtRole[0].id;
                }
            }

            txtAgentEmp.Text = "";
            cbAgentRole.Items.Clear();
            txtAgentDept.Text = "";
            txtAgentPos.Text = "";
        }
    }

    protected void cbAgentRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(cbAgentRole.SelectedValue, ViewState["AgentEmpID"].ToString());
        if (dtRole.Count > 0)
        {
            ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
            if (dtDept.Count > 0) txtAgentDept.Text = dtDept[0].name;
            ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
            if (dtPos.Count > 0) txtAgentPos.Text = dtPos[0].name;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ezClientDS.WorkAgentDataTable dtWorkAgent = Module.adWorkAgent.GetDataByAuto(Convert.ToInt32(GridView1.SelectedValue));
            if (dtWorkAgent.Count > 0)
            {
                ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtWorkAgent[0].Role_idTarget, dtWorkAgent[0].Emp_idTarget);
                if (dtRole.Count > 0)
                {
                    ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
                    if (dtDept.Count > 0) Session["Path"] = dtDept[0].path;
                    Session["Role_ID"] = dtRole[0].id;
                }
            }
        }
    }

    protected void bnAddFlow_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex == -1)
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請先選取代理人');", true);
            return;
        }

        if (cbFlow.Items.Count > 0)
        {
            ezClientDS.WorkAgentPowerDataTable dtWorkAgentPower = new ezClientDS.WorkAgentPowerDataTable();
            ezClientDS.WorkAgentPowerRow rowWorkAgentPower = dtWorkAgentPower.NewWorkAgentPowerRow();
            rowWorkAgentPower.WorkAgent_auto = Convert.ToInt32(GridView1.SelectedValue);
            rowWorkAgentPower.FlowTree_id = cbFlow.SelectedValue;
            dtWorkAgentPower.AddWorkAgentPowerRow(rowWorkAgentPower);
            Module.adWorkAgentPower.Update(dtWorkAgentPower);

            GridView2.DataBind();
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            ezClientDS.WorkAgentPowerRow rowWorkAgentPower = (ezClientDS.WorkAgentPowerRow)((DataRowView)e.Row.DataItem).Row;
            ezClientDS.FlowTreeDataTable dtFlowTree = Module.adFlowTree.GetDataById(rowWorkAgentPower.FlowTree_id);
            if (dtFlowTree.Count > 0)
            {
                Control ctrl = e.Row.FindControl("lbFlow");
                if (ctrl != null)
                {
                    ((Label)ctrl).Text = dtFlowTree[0].name;
                }
            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ezClientDS.WorkAgentDataTable dtWorkAgent = Module.adWorkAgent.GetDataByIdSource(cbMyRole.SelectedValue, JbUser.NOBR);
        if (dtWorkAgent.Count > 0)
        {
            ezClientDS.WorkAgentPowerDataTable dtWorkAgentPower = Module.adWorkAgentPower.GetDataByWorkAgent(dtWorkAgent[e.RowIndex].auto);
            for (int i = 0; i < dtWorkAgentPower.Count; i++) dtWorkAgentPower[i].Delete();
            Module.adWorkAgentPower.Update(dtWorkAgentPower);
            GridView2.DataBind();
        }
        Session["Path"] = null;
        Session["Role_ID"] = null;
        cbFlow.Items.Clear();
    }

    protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ezClientDS.WorkAgentDataTable dtWorkAgent = Module.adWorkAgent.GetDataByIdSource(cbMyRole.SelectedValue, JbUser.NOBR);
        if (dtWorkAgent.Count > 0)
        {
            GridView1.SelectedIndex = 0;
            ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtWorkAgent[0].Role_idTarget, dtWorkAgent[0].Emp_idTarget);
            if (dtRole.Count > 0)
            {
                ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
                if (dtDept.Count > 0) Session["Path"] = dtDept[0].path;
                Session["Role_ID"] = dtRole[0].id;
            }
        }
        cbFlow.DataBind();
    }
}
