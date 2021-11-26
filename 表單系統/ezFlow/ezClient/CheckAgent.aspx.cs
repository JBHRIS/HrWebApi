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

public partial class CheckAgent : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!this.IsPostBack) {
			ezClientDS.RoleDataTable dtMyRole = Module.adRole.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
			if(dtMyRole.Count > 0) {
				for(int i = 0; i < dtMyRole.Count; i++) {
					ListItem listItem = new ListItem();
					ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtMyRole[i].Pos_id);
					ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtMyRole[i].Dept_id);
					if(dtDept.Count > 0 && dtPos.Count > 0) {
						listItem.Text = dtPos[0].name + "@" + dtDept[0].name;
						listItem.Value = dtMyRole[i].id;

						cbMyRole.Items.Add(listItem);
					}
				}
			}			

			ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault = Module.adCheckAgentDefault.GetDataByOne(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
			UpdateDefaultAgentLabel(dtCheckAgentDefault);

			if(GridView1.Rows.Count > 0) {
				GridView1.SelectedIndex = 0;				
				GridView2.DataBind();
				if(GridView2.Rows.Count > 0) {
					GridView2.SelectedIndex = 0;
					GridView3.DataBind();
				}
			}

			if(dtMyRole.Count > 0) {
				ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtMyRole[0].Dept_id);
				if(dtDept.Count > 0) {
					Session["Dept_path"] = dtDept[0].path;
				}
				else Session["Dept_path"] = null;
			}
		}
    }
	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e) {
		MultiView1.ActiveViewIndex = Convert.ToInt32(RadioButtonList1.SelectedValue);
	}

	protected void txtAgentEmp_TextChanged(object sender, EventArgs e) {
		txtAgentDept.Text = "";
		txtAgentPos.Text = "";
		cbAgentRole.Items.Clear();
		if(txtAgentEmp.Text.Trim().Length > 0) {
			ezClientDS.EmpDataTable dtAgentEmp = Module.adEmp.GetDataBySearch(txtAgentEmp.Text);
			if(dtAgentEmp.Count > 0) {
				txtAgentEmp.Text = dtAgentEmp[0].name;
				ViewState["AgentEmpID"] = dtAgentEmp[0].id;
				ezClientDS.RoleDataTable dtAgentRole = Module.adRole.GetDataByEmp(dtAgentEmp[0].id);
				if(dtAgentRole.Count > 0) {
					for(int i = 0; i < dtAgentRole.Count; i++) {
						ListItem listItem = new ListItem();
						ezClientDS.PosDataTable dtAgentPos = Module.adPos.GetDataById(dtAgentRole[i].Pos_id);
						if(dtAgentPos.Count > 0) {
							listItem.Text = dtAgentPos[0].name;
							listItem.Value = dtAgentRole[i].id;

							cbAgentRole.Items.Add(listItem);

							if(i == 0) {
								txtAgentPos.Text = dtAgentPos[0].name;
								ezClientDS.DeptDataTable dtAgentDept = Module.adDept.GetDataById(dtAgentRole[i].Dept_id);
								if(dtAgentDept.Count > 0) {
									txtAgentDept.Text = dtAgentDept[0].name;
								}
							}
						}
					}
				}
			}
		}
	}

	protected void cbAgentRole_SelectedIndexChanged(object sender, EventArgs e) {
		ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(cbAgentRole.SelectedValue, ViewState["AgentEmpID"].ToString());
		if(dtRole.Count > 0) {
			ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
			if(dtDept.Count > 0) txtAgentDept.Text = dtDept[0].name;
			ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
			if(dtPos.Count > 0) txtAgentPos.Text = dtPos[0].name;
		}
	}

	protected void bnAddAgent_Click(object sender, EventArgs e) {
		if(ViewState["AgentEmpID"].ToString() == Request.Cookies["ezFlow"]["Emp_id"].ToString()) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('不可以指定自己為代理人');", true);
			return;
		}

		if(RadioButtonList1.SelectedValue == "0") {
			ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault = Module.adCheckAgentDefault.GetDataByOne(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
			ezClientDS.CheckAgentDefaultRow rowCheckAgentDefault = null;
			if(dtCheckAgentDefault.Count == 0) rowCheckAgentDefault = dtCheckAgentDefault.NewCheckAgentDefaultRow();
			else rowCheckAgentDefault = dtCheckAgentDefault[0];

			if(dtCheckAgentDefault.Count > 0) {
				if(ViewState["AgentEmpID"].ToString() == rowCheckAgentDefault.Emp_idTarget1 ||
					ViewState["AgentEmpID"].ToString() == rowCheckAgentDefault.Emp_idTarget2) {
					if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
						Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請勿重覆加入相同的成員');", true);
					return;
				}
			}

			rowCheckAgentDefault.Role_idSource = cbMyRole.SelectedValue;
			rowCheckAgentDefault.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"].ToString();

			bool bWrite = false;
			if(rowCheckAgentDefault.IsRole_idTarget1Null() || rowCheckAgentDefault.Role_idTarget1.Trim().Length == 0) {
				rowCheckAgentDefault.Role_idTarget1 = cbAgentRole.SelectedValue;
				rowCheckAgentDefault.Emp_idTarget1 = ViewState["AgentEmpID"].ToString();
				rowCheckAgentDefault.Role_idTarget2 = "";
				rowCheckAgentDefault.Emp_idTarget2 = "";
				rowCheckAgentDefault.Role_idTarget3 = "";
				rowCheckAgentDefault.Emp_idTarget3 = "";
				bWrite = true;
			}
			if(!bWrite && (rowCheckAgentDefault.IsRole_idTarget2Null() || rowCheckAgentDefault.Role_idTarget2.Trim().Length == 0)) {
				rowCheckAgentDefault.Role_idTarget2 = cbAgentRole.SelectedValue;
				rowCheckAgentDefault.Emp_idTarget2 = ViewState["AgentEmpID"].ToString();
				rowCheckAgentDefault.Role_idTarget3 = "";
				rowCheckAgentDefault.Emp_idTarget3 = "";
				bWrite = true;
			}
			if(!bWrite && (rowCheckAgentDefault.IsRole_idTarget3Null() || rowCheckAgentDefault.Role_idTarget3.Trim().Length == 0)) {
				rowCheckAgentDefault.Role_idTarget3 = cbAgentRole.SelectedValue;
				rowCheckAgentDefault.Emp_idTarget3 = ViewState["AgentEmpID"].ToString();
			}
			if(dtCheckAgentDefault.Count == 0) dtCheckAgentDefault.AddCheckAgentDefaultRow(rowCheckAgentDefault);
			Module.adCheckAgentDefault.Update(dtCheckAgentDefault);

			UpdateDefaultAgentLabel(dtCheckAgentDefault);
		}
		else {
			ezClientDS.CheckAgentAlwaysDataTable dtCheckAgentAlways = Module.adCheckAgentAlways.GetDataByEmp(ViewState["AgentEmpID"].ToString());
			if(dtCheckAgentAlways.Count > 0) {
				bool bError = false;
				for(int i = 0; i < dtCheckAgentAlways.Count; i++) {
					if(dtCheckAgentAlways[i].Role_idSource == cbMyRole.SelectedValue &&
						dtCheckAgentAlways[i].Emp_idSource == Request.Cookies["ezFlow"]["Emp_id"].ToString()) {
						bError = true;
						if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
							Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請勿重覆加入相同的成員');", true);
						break;
					}
				}
				if(bError) return;
			}

			ezClientDS.CheckAgentAlwaysRow rowCheckAgentAlways = dtCheckAgentAlways.NewCheckAgentAlwaysRow();
			rowCheckAgentAlways.Role_idSource = cbMyRole.SelectedValue;
			rowCheckAgentAlways.Emp_idSource = Request.Cookies["ezFlow"]["Emp_id"].ToString();
			rowCheckAgentAlways.Role_idTarget = cbAgentRole.SelectedValue;
			rowCheckAgentAlways.Emp_idTarget = ViewState["AgentEmpID"].ToString();
			dtCheckAgentAlways.AddCheckAgentAlwaysRow(rowCheckAgentAlways);
			Module.adCheckAgentAlways.Update(dtCheckAgentAlways);

			GridView1.DataBind();

			GridView1.SelectedIndex = GridView1.Rows.Count - 1;
			GridView2.DataBind();
			if(GridView2.Rows.Count > 0) {
				GridView2.SelectedIndex = 0;
				GridView3.DataBind();
			}
		}
	}
	protected void bnDel1_Click(object sender, EventArgs e) {
		ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault = Module.adCheckAgentDefault.GetDataByOne(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtCheckAgentDefault.Count > 0) {
			dtCheckAgentDefault[0].Role_idTarget1 = "";
			dtCheckAgentDefault[0].Emp_idTarget1 = "";
			if(!dtCheckAgentDefault[0].IsRole_idTarget2Null() && dtCheckAgentDefault[0].Role_idTarget2.Trim().Length > 0) {
				dtCheckAgentDefault[0].Role_idTarget1 = dtCheckAgentDefault[0].Role_idTarget2;
				dtCheckAgentDefault[0].Emp_idTarget1 = dtCheckAgentDefault[0].Emp_idTarget2;
				dtCheckAgentDefault[0].Role_idTarget2 = "";
				dtCheckAgentDefault[0].Emp_idTarget2 = "";
			}
			if(!dtCheckAgentDefault[0].IsRole_idTarget3Null() && dtCheckAgentDefault[0].Emp_idTarget3.Trim().Length > 0) {
				dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
				dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
				dtCheckAgentDefault[0].Role_idTarget3 = "";
				dtCheckAgentDefault[0].Emp_idTarget3 = "";
			}
			Module.adCheckAgentDefault.Update(dtCheckAgentDefault);
		}
		UpdateDefaultAgentLabel(dtCheckAgentDefault);
	}
	protected void bnDel2_Click(object sender, EventArgs e) {
		ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault = Module.adCheckAgentDefault.GetDataByOne(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtCheckAgentDefault.Count > 0) {
			dtCheckAgentDefault[0].Role_idTarget2 = "";
			dtCheckAgentDefault[0].Emp_idTarget2 = "";
			if(!dtCheckAgentDefault[0].IsRole_idTarget3Null() && dtCheckAgentDefault[0].Emp_idTarget3.Trim().Length > 0) {
				dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
				dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
				dtCheckAgentDefault[0].Role_idTarget3 = "";
				dtCheckAgentDefault[0].Emp_idTarget3 = "";
			}
			Module.adCheckAgentDefault.Update(dtCheckAgentDefault);
		}
		UpdateDefaultAgentLabel(dtCheckAgentDefault);
	}
	protected void bnDel3_Click(object sender, EventArgs e) {
		ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault = Module.adCheckAgentDefault.GetDataByOne(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtCheckAgentDefault.Count > 0) {
			dtCheckAgentDefault[0].Role_idTarget3 = "";
			dtCheckAgentDefault[0].Emp_idTarget3 = "";
			Module.adCheckAgentDefault.Update(dtCheckAgentDefault);
		}
		UpdateDefaultAgentLabel(dtCheckAgentDefault);
	}

	void UpdateDefaultAgentLabel(ezClientDS.CheckAgentDefaultDataTable dtCheckAgentDefault) {
		lbDept1.Text = "";
		lbPos1.Text = "";
		lbEmp1.Text = "";
		lbDept2.Text = "";
		lbPos2.Text = "";
		lbEmp2.Text = "";
		lbDept3.Text = "";
		lbPos3.Text = "";
		lbEmp3.Text = "";

		if(dtCheckAgentDefault.Count > 0) {
			if(!dtCheckAgentDefault[0].IsRole_idTarget1Null() && dtCheckAgentDefault[0].Role_idTarget1.Trim().Length > 0) {
				ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtCheckAgentDefault[0].Role_idTarget1, dtCheckAgentDefault[0].Emp_idTarget1);
				if(dtRole.Count > 0) {
					ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
					if(dtDept.Count > 0) lbDept1.Text = dtDept[0].name;
					ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
					if(dtPos.Count > 0) lbPos1.Text = dtPos[0].name;
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtRole[0].Emp_id);
					if(dtEmp.Count > 0) lbEmp1.Text = dtEmp[0].name;
				}
			}
			if(!dtCheckAgentDefault[0].IsRole_idTarget2Null() && dtCheckAgentDefault[0].Role_idTarget2.Trim().Length > 0) {
				ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtCheckAgentDefault[0].Role_idTarget2, dtCheckAgentDefault[0].Emp_idTarget2);
				if(dtRole.Count > 0) {
					ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
					if(dtDept.Count > 0) lbDept2.Text = dtDept[0].name;
					ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
					if(dtPos.Count > 0) lbPos2.Text = dtPos[0].name;
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtRole[0].Emp_id);
					if(dtEmp.Count > 0) lbEmp2.Text = dtEmp[0].name;
				}
			}
			if(!dtCheckAgentDefault[0].IsRole_idTarget3Null() && dtCheckAgentDefault[0].Role_idTarget3.Trim().Length > 0) {
				ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(dtCheckAgentDefault[0].Role_idTarget3, dtCheckAgentDefault[0].Emp_idTarget3);
				if(dtRole.Count > 0) {
					ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
					if(dtDept.Count > 0) lbDept3.Text = dtDept[0].name;
					ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
					if(dtPos.Count > 0) lbPos3.Text = dtPos[0].name;
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtRole[0].Emp_id);
					if(dtEmp.Count > 0) lbEmp3.Text = dtEmp[0].name;
				}
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
		if(e.Row.DataItem != null) {
			ezClientDS.CheckAgentAlwaysRow rowCheckAgentAlways = (ezClientDS.CheckAgentAlwaysRow)((DataRowView)e.Row.DataItem).Row;
			ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(rowCheckAgentAlways.Role_idTarget, rowCheckAgentAlways.Emp_idTarget);
			if(dtRole.Count > 0) {
				ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(dtRole[0].Pos_id);
				((Label)e.Row.FindControl("lbPos")).Text = dtPos[0].name;
				ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtRole[0].Emp_id);
				((Label)e.Row.FindControl("lbEmp")).Text = dtEmp[0].name;
			}
		}
	}


	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e) {
		if(e.Row.DataItem != null) {
			ezClientDS.CheckAgentPowerMRow rowCheckAgentPowerM = (ezClientDS.CheckAgentPowerMRow)((DataRowView)e.Row.DataItem).Row;
			ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(rowCheckAgentPowerM.Dept_id);
			if(dtDept.Count > 0) ((Label)e.Row.FindControl("lbDept")).Text = dtDept[0].name;
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e) {
		if(e.Row.DataItem != null) {
			ezClientDS.CheckAgentPowerDRow rowCheckAgentPowerD = (ezClientDS.CheckAgentPowerDRow)((DataRowView)e.Row.DataItem).Row;
			ezClientDS.FlowTreeDataTable dtFlowTree = Module.adFlowTree.GetDataById(rowCheckAgentPowerD.FlowTree_id);
			if(dtFlowTree.Count > 0) ((Label)e.Row.FindControl("lbFlow")).Text = dtFlowTree[0].name;
		}
	}

	protected void cbMyRole_SelectedIndexChanged(object sender, EventArgs e) {
		Session["Dept_path"] = null;
		ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByOne(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtRole.Count > 0) {
			ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(dtRole[0].Dept_id);
			if(dtDept.Count > 0) {
				Session["Dept_path"] = dtDept[0].path;
			}
		}
	}

	protected void bnAddOrg_Click(object sender, EventArgs e) {
		if(GridView1.Rows.Count == 0 || GridView1.SelectedIndex == -1) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請先選取代理人');", true);
			return;
		}

		ezClientDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = Module.adCheckAgentPowerM.GetDataByCheckAgentAlways(Convert.ToInt32(GridView1.SelectedValue));
		bool bCheck = true;
		if(dtCheckAgentPowerM.Count > 0) {
			for(int i = 0; i < dtCheckAgentPowerM.Count; i++) {
				if(cbDept.SelectedValue == dtCheckAgentPowerM[i].Dept_id) {
					if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
						Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請勿重覆加入相同部門');", true);
					bCheck = false;
					break;
				}
			}
		}

		if(bCheck) {
			ezClientDS.CheckAgentPowerMRow rowCheckAgentPowerM = dtCheckAgentPowerM.NewCheckAgentPowerMRow();
			rowCheckAgentPowerM.CheckAgentAlways_auto = Convert.ToInt32(GridView1.SelectedValue);
			rowCheckAgentPowerM.Dept_id = cbDept.SelectedValue;
			rowCheckAgentPowerM.isAllSub = ckAllSub.Checked;
			dtCheckAgentPowerM.AddCheckAgentPowerMRow(rowCheckAgentPowerM);
			Module.adCheckAgentPowerM.Update(dtCheckAgentPowerM);
			GridView2.DataBind();

			GridView2.SelectedIndex = GridView2.Rows.Count - 1;
			GridView3.DataBind();
		}
	}

	protected void bnAddFlow_Click(object sender, EventArgs e) {
		if(GridView2.Rows.Count == 0 || GridView2.SelectedIndex == -1) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請先選取可簽核部門');", true);
			return;
		}

		ezClientDS.CheckAgentPowerDDataTable dtCheckAgentPowerD = Module.adCheckAgentPowerD.GetDataByCheckAgentPowerM(Convert.ToInt32(GridView2.SelectedValue));
		bool bCheck = true;
		if(dtCheckAgentPowerD.Count > 0) {
			for(int i = 0; i < dtCheckAgentPowerD.Count; i++) {
				if(cbFlow.SelectedValue == dtCheckAgentPowerD[i].FlowTree_id) {
					if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
						Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('請勿重覆加入相同流程');", true);
					bCheck = false;
					break;
				}
			}
		}

		if(bCheck) {
			ezClientDS.CheckAgentPowerDRow rowCheckAgentPowerD = dtCheckAgentPowerD.NewCheckAgentPowerDRow();
			rowCheckAgentPowerD.CheckAgentPowerM_auto = Convert.ToInt32(GridView2.SelectedValue);
			rowCheckAgentPowerD.FlowTree_id = cbFlow.SelectedValue;
			dtCheckAgentPowerD.AddCheckAgentPowerDRow(rowCheckAgentPowerD);
			Module.adCheckAgentPowerD.Update(dtCheckAgentPowerD);

			GridView3.DataBind();
		}
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
		GridView2.DataBind();
		if(GridView2.Rows.Count > 0) {
			GridView2.SelectedIndex = 0;
			GridView3.DataBind();
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) {
		ezClientDS.CheckAgentAlwaysDataTable dtCheckAgentAlways = Module.adCheckAgentAlways.GetDataByIdSource(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtCheckAgentAlways.Count > 0) {
			ezClientDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = Module.adCheckAgentPowerM.GetDataByCheckAgentAlways(dtCheckAgentAlways[e.RowIndex].auto);
			if(dtCheckAgentPowerM.Count > 0) {
				for(int i = 0; i < dtCheckAgentPowerM.Count; i++) {
					ezClientDS.CheckAgentPowerDDataTable dtCheckAgentPowerD = Module.adCheckAgentPowerD.GetDataByCheckAgentPowerM(dtCheckAgentPowerM[i].auto);
					foreach(DataRow rowCheckAgentPowerD in dtCheckAgentPowerD.Rows) rowCheckAgentPowerD.Delete();
					Module.adCheckAgentPowerD.Update(dtCheckAgentPowerD);
					dtCheckAgentPowerM[i].Delete();
				}
				Module.adCheckAgentPowerM.Update(dtCheckAgentPowerM);
			}
		}
		GridView2.DataBind();
		GridView3.DataBind();
	}

	protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e) {
		ezClientDS.CheckAgentAlwaysDataTable dtCheckAgentAlways = Module.adCheckAgentAlways.GetDataByIdSource(cbMyRole.SelectedValue, Request.Cookies["ezFlow"]["Emp_id"].ToString());
		if(dtCheckAgentAlways.Count > 0) {
			GridView1.SelectedIndex = 0;
			GridView2.DataBind();
			if(GridView2.Rows.Count > 0) {
				GridView2.SelectedIndex = 0;
				GridView3.DataBind();
			}
		}
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e) {
		ezClientDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = Module.adCheckAgentPowerM.GetDataByCheckAgentAlways(Convert.ToInt32(GridView1.SelectedValue));
		if(dtCheckAgentPowerM.Count > 0) {
			ezClientDS.CheckAgentPowerDDataTable dtCheckAgentPowerD = Module.adCheckAgentPowerD.GetDataByCheckAgentPowerM(dtCheckAgentPowerM[e.RowIndex].auto);
			foreach(DataRow rowCheckAgentPowerD in dtCheckAgentPowerD.Rows) rowCheckAgentPowerD.Delete();
			Module.adCheckAgentPowerD.Update(dtCheckAgentPowerD);
		}
		GridView3.DataBind();
	}

	protected void ObjectDataSource2_Deleted(object sender, ObjectDataSourceStatusEventArgs e) {
		ezClientDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = Module.adCheckAgentPowerM.GetDataByCheckAgentAlways(Convert.ToInt32(GridView1.SelectedValue));
		if(dtCheckAgentPowerM.Count > 0) {
			GridView2.SelectedIndex = 0;
			GridView3.DataBind();
		}
	}
}
