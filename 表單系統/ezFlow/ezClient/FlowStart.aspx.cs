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

public partial class FlowStart : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!this.IsPostBack) {
			CreateFlow_MyRole();			
		}
    }

	void CreateFlow_MyRole() {
		ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
		if(dtSysVar.Count == 0) return;

        if (Request.Cookies["ezFlow"] == null || Request.Cookies["ezFlow"]["Emp_id"] == null)
            Response.Redirect("http://192.168.0.202/ezPortal/Login.aspx");

		ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());

        ezClientDS.wfFormDataTable dtForm = Module.adForm.GetData();
        ezClientDS.wfFormDataGroupDataTable dtFormDataGroup = Module.adFormDataGroup.GetData();

        hrDSTableAdapters.JB_HR_BaseTtsTableAdapter adJB_HR_BaseTts = new hrDSTableAdapters.JB_HR_BaseTtsTableAdapter();
        hrDS.JB_HR_BaseTtsDataTable dtJB_HR_BaseTts = adJB_HR_BaseTts.GetDataByNobr(Request.Cookies["ezFlow"]["Emp_id"].ToString());

        if (dtJB_HR_BaseTts.Rows.Count == 0)
            Response.Redirect("http://192.168.0.202/ezPortal/Login.aspx");

        hrDS.JB_HR_BaseTtsRow rJB_HR_BaseTts = dtJB_HR_BaseTts.Rows[0] as hrDS.JB_HR_BaseTtsRow;

		foreach(ezClientDS.RoleRow drRole in dtRole.Rows) {

            if (drRole.Dept_id != rJB_HR_BaseTts.sDeptmCode)
                continue;

			ezClientDS.RoleRow rowRole = (ezClientDS.RoleRow)drRole;
			ezClientDS.DeptDataTable dtDept = Module.adDept.GetDataById(rowRole.Dept_id);
			ezClientDS.PosDataTable dtPos = Module.adPos.GetDataById(rowRole.Pos_id);
			ezClientDS.FlowTreeDataTable dtFlowTree = Module.adFlowTree.GetDataByPower(dtDept[0].path, rowRole.id);			

			foreach(DataRow drFlowTree in dtFlowTree.Rows) {
				ezClientDS.FlowTreeRow rowFlowTree = (ezClientDS.FlowTreeRow)drFlowTree;

				ezClientDS.FlowNodeDataTable dtFlowNode;

				dtFlowNode = Module.adFlowNode.GetDataOfNodeStart(rowFlowTree.id);
				if(dtFlowNode.Count == 0) continue;
				ezClientDS.NodeStartDataTable dtNodeStart = Module.adNodeStart.GetDataByFlowNode(dtFlowNode[0].id);
				if(dtNodeStart.Count == 0 || dtNodeStart[0].IsvirtualPathNull() || dtNodeStart[0].virtualPath.Trim().Length == 0) continue;

				dtFlowNode = Module.adFlowNode.GetDataOfNodeForm(rowFlowTree.id);
				if(dtFlowNode.Count == 0) continue;
				ezClientDS.NodeFormDataTable dtNodeForm = Module.adNodeForm.GetDataByFlowNode(dtFlowNode[0].id);
				if(dtNodeForm.Count == 0 || dtNodeForm[0].IsapNameNull() || dtNodeForm[0].apName.Trim().Length == 0) continue;

				//找出角色的 TreeNode 節點
				TreeNode findNode_Role = null;
				foreach(TreeNode node in tvMain.Nodes) {
					if(node.Value == rowRole.id) {
						findNode_Role = node;
						break;
					}
				}
				if(findNode_Role == null) {
					findNode_Role = new TreeNode();
					findNode_Role.Text = dtPos[0].name + "@" + dtDept[0].name;
					findNode_Role.Value = rowRole.id;
					findNode_Role.ImageUrl = "images/person.bmp";					
					tvMain.Nodes.Add(findNode_Role);
				}
				findNode_Role.NavigateUrl = "#";

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

                //利用TreeID找出表單名稱
                bool bDisplay = true;
                DataRow[] rsf = dtForm.Select("sFlowTree = '" + rowFlowTree.id + "'");
                if (rsf.Length > 0)
                {
                    ezClientDS.wfFormRow rf = rsf[0] as ezClientDS.wfFormRow;
                    DataRow[] rsfd = dtFormDataGroup.Select("sFormCode = '" + rf.sFormCode + "' AND sDataGroup = '" + rJB_HR_BaseTts.sSaladr + "'");
                    if (rsfd.Length > 0)
                    {
                        ezClientDS.wfFormDataGroupRow rfd = rsfd[0] as ezClientDS.wfFormDataGroupRow;
                        if (!rfd.IsbFormDisplayNull())
                            bDisplay = rfd.bFormDisplay;
                    }
                }
                else if (rowFlowTree.id == "58")
                {
                    DataRow[] rsfd = dtFormDataGroup.Select("sFormCode = 'Batch' AND sDataGroup = '" + rJB_HR_BaseTts.sSaladr + "'");
                    if (rsfd.Length > 0)
                    {
                        ezClientDS.wfFormDataGroupRow rfd = rsfd[0] as ezClientDS.wfFormDataGroupRow;
                        if (!rfd.IsbFormDisplayNull())
                            bDisplay = rfd.bFormDisplay;
                    }
                }

				string link = dtSysVar[0].urlRoot + "/Forms/" + dtNodeStart[0].virtualPath + "/" + dtNodeForm[0].apName;

                if (bDisplay)
                {
                    TreeNode node_FlowTree = new TreeNode();
                    node_FlowTree.Text = rowFlowTree.name;
                    node_FlowTree.Value = rowFlowTree.id;
                    node_FlowTree.ImageUrl = "images/html.bmp";
                    //string _do = "?_do=" + FlowCS.encode("idFlowTree=" + rowFlowTree.id + "&idRole_Start=" + rowRole.id + "&idEmp_Start=" + rowRole.Emp_id + "&idRole_Agent=&idEmp_Agent=");
                    //node_FlowTree.NavigateUrl = link + _do;
                    node_FlowTree.NavigateUrl = link + "?idFlowTree=" + rowFlowTree.id + "&" +
                        "idRole_Start=" + rowRole.id + "&idEmp_Start=" + rowRole.Emp_id + "&idRole_Agent=&idEmp_Agent=&test=" + Guid.NewGuid().ToString();
                    node_FlowTree.Target = "frameMain";

                    findFlowGroup.ChildNodes.Add(node_FlowTree);
                }
			}
		}

		foreach(TreeNode node in tvMain.Nodes) {
			if(node.ChildNodes.Count > 0) DeleteEmptyNode(node);
			else tvMain.Nodes.Remove(node);
		}
	}

	TreeNode GetFlowGroupNode(TreeNode rNode,string findValue) {
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

	void DeleteEmptyNode(TreeNode rNode) {
		foreach(TreeNode sNode in rNode.ChildNodes) {
			if(sNode.ChildNodes.Count > 0) DeleteEmptyNode(sNode);
			else {
				if(sNode.NavigateUrl.Trim().Length == 0) rNode.ChildNodes.Remove(sNode);
			}
		}
	}
}
