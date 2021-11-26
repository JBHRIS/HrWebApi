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

public partial class AgentStart : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!this.IsPostBack) {
			CreateFlow_Agent();
		}
    }

	void CreateFlow_Agent() {
		ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
		if(dtSysVar.Count == 0) return;

		string Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
		ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByEmp(Emp_id);

		//我的多重角色
		foreach(DataRow drRole in dtRole.Rows) {
			ezClientDS.RoleRow rowRole = (ezClientDS.RoleRow)drRole;
			ezClientDS.WorkAgentDataTable dtWorkAgent = Module.adWorkAgent.GetDataByIdTarget(rowRole.id, rowRole.Emp_id);
			//我是誰的工作代理人
			foreach(DataRow drWorkAgent in dtWorkAgent.Rows) {
				ezClientDS.WorkAgentRow rowWorkAgent = (ezClientDS.WorkAgentRow)drWorkAgent;

				ezClientDS.RoleDataTable dtRole_Source = Module.adRole.GetDataByOne(rowWorkAgent.Role_idSource, rowWorkAgent.Emp_idSource);
				ezClientDS.DeptDataTable dtDept_Source = Module.adDept.GetDataById(dtRole_Source[0].Dept_id);
				ezClientDS.PosDataTable dtPos_Source = Module.adPos.GetDataById(dtRole_Source[0].Pos_id);
				ezClientDS.EmpDataTable dtEmp_Source = Module.adEmp.GetDataById(dtRole_Source[0].Emp_id);

				//尋找被代理人
				TreeNode findNode_Role = null;
				foreach(TreeNode node in tvMain.Nodes) {
					Hashtable hashTable = GetHash(node.Value);
					if(hashTable["Role_id"].ToString() == dtRole_Source[0].id &&
						hashTable["Emp_id"].ToString() == dtRole_Source[0].Emp_id) {
						findNode_Role = node;
						break;
					}
				}
				if(findNode_Role == null) {
					findNode_Role = new TreeNode();					
					findNode_Role.Text = dtEmp_Source[0].name + "@" + dtPos_Source[0].name + "." + dtDept_Source[0].name;
					findNode_Role.ToolTip = findNode_Role.Text;
					findNode_Role.Value = "Role_id=" + dtRole_Source[0].id + "&Emp_id=" + dtRole_Source[0].Emp_id;
					findNode_Role.ImageUrl = "images/person.bmp";
					tvMain.Nodes.Add(findNode_Role);
				}
				findNode_Role.NavigateUrl = "#";

				ezClientDS.WorkAgentPowerDataTable dtWorkAgentPower = Module.adWorkAgentPower.GetDataByWorkAgent(rowWorkAgent.auto);
				//我可代理的權限
				if(dtWorkAgentPower.Count == 0) { //如果未指定，表示全流程皆可代理
					ezClientDS.FlowTreeDataTable dtFlowTree = Module.adFlowTree.GetDataByPower(dtDept_Source[0].path, dtRole_Source[0].id);
					//被代理人的工作流程
					foreach(DataRow drFlowTree in dtFlowTree.Rows) {
						ezClientDS.FlowTreeRow rowFlowTree = (ezClientDS.FlowTreeRow)drFlowTree;
						AddAgentFlowTree(findNode_Role, rowFlowTree, dtSysVar, dtRole_Source, rowRole);
					}
				}
				else {
					foreach(DataRow drWorkAgentPower in dtWorkAgentPower.Rows) {
						ezClientDS.WorkAgentPowerRow rowWorkAgentPower = (ezClientDS.WorkAgentPowerRow)drWorkAgentPower;
						ezClientDS.FlowTreeDataTable dtFlowTree = Module.adFlowTree.GetDataById(rowWorkAgentPower.FlowTree_id);
						if(dtFlowTree.Count > 0) {
							ezClientDS.FlowTreeRow rowFlowTree = dtFlowTree[0];
							AddAgentFlowTree(findNode_Role, rowFlowTree, dtSysVar, dtRole_Source, rowRole);
						}
						else rowWorkAgentPower.Delete();
					}
					Module.adWorkAgentPower.Update(dtWorkAgentPower);
				}
			}
		}

		foreach(TreeNode node in tvMain.Nodes) {
			if(node.ChildNodes.Count > 0) DeleteEmptyNode(node);
			else tvMain.Nodes.Remove(node);
		}
	}

	void AddAgentFlowTree(TreeNode findNode_Role, ezClientDS.FlowTreeRow rowFlowTree,
	ezClientDS.SysVarDataTable dtSysVar, ezClientDS.RoleDataTable dtRole_Source, ezClientDS.RoleRow rowRole) {
		ezClientDS.FlowNodeDataTable dtFlowNode;

		dtFlowNode = Module.adFlowNode.GetDataOfNodeStart(rowFlowTree.id);
		if(dtFlowNode.Count == 0) return;
		ezClientDS.NodeStartDataTable dtNodeStart = Module.adNodeStart.GetDataByFlowNode(dtFlowNode[0].id);
		if(dtNodeStart.Count == 0 || dtNodeStart[0].IsvirtualPathNull() || dtNodeStart[0].virtualPath.Trim().Length == 0) return;

		dtFlowNode = Module.adFlowNode.GetDataOfNodeForm(rowFlowTree.id);
		if(dtFlowNode.Count == 0) return;
		ezClientDS.NodeFormDataTable dtNodeForm = Module.adNodeForm.GetDataByFlowNode(dtFlowNode[0].id);
		if(dtNodeForm.Count == 0 || dtNodeForm[0].IsapNameNull() || dtNodeForm[0].apName.Trim().Length == 0) return;

		ezClientDS.FlowGroupDataTable dtFlowGroup = Module.adFlowGroup.GetDataById(rowFlowTree.FlowGroup_id);
		TreeNode findFlowGroup = null;
		if(dtFlowGroup.Count > 0) {
			//如果還有父群組
			if(!dtFlowGroup[0].IsidParentNull() && dtFlowGroup[0].idParent.Trim().Length > 0) {
				TreeNode FlowGroupParent = GetFlowGroupNode(findNode_Role, findNode_Role.Value + dtFlowGroup[0].idParent);
				//如果找不到父群組，則建立父群組，連同子群組一併建立
				if(FlowGroupParent == null) {
					ezClientDS.FlowGroupDataTable dtFlowGroupParent = Module.adFlowGroup.GetDataById(dtFlowGroup[0].idParent);
					if(dtFlowGroupParent.Count > 0) {
						FlowGroupParent = new TreeNode();
						FlowGroupParent.Text = dtFlowGroupParent[0].name;
						FlowGroupParent.Value = findNode_Role.Value + dtFlowGroupParent[0].id;
						FlowGroupParent.ImageUrl = "images/folder.bmp";
						findNode_Role.ChildNodes.Add(FlowGroupParent);
						FlowGroupParent.NavigateUrl = "#";
					}
					if(FlowGroupParent != null) {
						findFlowGroup = new TreeNode();
						findFlowGroup.Text = dtFlowGroup[0].name;
						findFlowGroup.Value = findNode_Role.Value + dtFlowGroup[0].id;
						findFlowGroup.ImageUrl = "images/folder.bmp";
						FlowGroupParent.ChildNodes.Add(findFlowGroup);
						findFlowGroup.NavigateUrl = "#";
					}
				}
				else {
					//父群組找到了，就找看看有沒有符合的子群組
					findFlowGroup = GetFlowGroupNode(FlowGroupParent, findNode_Role.Value + dtFlowGroup[0].id);
					if(findFlowGroup == null) {
						findFlowGroup = new TreeNode();
						findFlowGroup.Text = dtFlowGroup[0].name;
						findFlowGroup.Value = findNode_Role.Value + dtFlowGroup[0].id;
						findFlowGroup.ImageUrl = "images/folder.bmp";
						FlowGroupParent.ChildNodes.Add(findFlowGroup);
						findFlowGroup.NavigateUrl = "#";
					}
				}
			}
			else {
				//沒有父群組，則直接找尋符合的群組
				findFlowGroup = GetFlowGroupNode(findNode_Role, findNode_Role.Value + dtFlowGroup[0].id);
				if(findFlowGroup == null) {
					findFlowGroup = new TreeNode();
					findFlowGroup.Text = dtFlowGroup[0].name;
					findFlowGroup.Value = findNode_Role.Value + dtFlowGroup[0].id;
					findFlowGroup.ImageUrl = "images/folder.bmp";
					findNode_Role.ChildNodes.Add(findFlowGroup);
					findFlowGroup.NavigateUrl = "#";
				}
			}
		}

		string link = dtSysVar[0].urlRoot + "/Forms/" + dtNodeStart[0].virtualPath + "/" + dtNodeForm[0].apName;

		TreeNode node_FlowTree = new TreeNode();
		node_FlowTree.Text = rowFlowTree.name;
		node_FlowTree.Value = rowFlowTree.id;
		node_FlowTree.NavigateUrl = link + "?idFlowTree=" + rowFlowTree.id + "&" +
			"idRole_Start=" + dtRole_Source[0].id + "&idEmp_Start=" + dtRole_Source[0].Emp_id + "&" +
			"idRole_Agent=" + rowRole.id + "&idEmp_Agent=" + rowRole.Emp_id;
		node_FlowTree.ImageUrl = "images/html.bmp";
		node_FlowTree.Target = "frameMain";
		findFlowGroup.ChildNodes.Add(node_FlowTree);
	}

	TreeNode GetFlowGroupNode(TreeNode rNode, string findValue) {
		TreeNode findNode = null;
		foreach(TreeNode node in rNode.ChildNodes) {
			if(node.Value == findValue) {
				findNode = node;
				break;
			}
			else {
				if(node.ChildNodes.Count > 0) findNode = GetFlowGroupNode(node, findValue);
				if(findNode != null) break;
			}
		}
		return findNode;
	}

	Hashtable GetHash(string value) {
		string[] parms = value.Split(new char[] { '&' });
		Hashtable hashTable = new Hashtable();
		for(int i = 0; i < parms.Length; i++) {
			string[] parmTmp = parms[i].Split(new char[] { '=' });
			hashTable.Add(parmTmp[0], parmTmp[1]);
		}
		return hashTable;
	}

	void DeleteEmptyNode(TreeNode rNode) {
		foreach(TreeNode sNode in rNode.ChildNodes) {
			if(sNode.ChildNodes.Count > 0) DeleteEmptyNode(sNode);
			else {
				if(sNode.NavigateUrl.Trim().Length == 0) rNode.ChildNodes.Remove(sNode);
			}
		}
	}
}
