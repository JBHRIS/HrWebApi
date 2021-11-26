using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CFlow 的摘要描述
/// </summary>
public class CFlow
{
	static ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();
	static ezFlowDSTableAdapters.FlowNodeTableAdapter adFlowNode = new ezFlowDSTableAdapters.FlowNodeTableAdapter();
	static ezFlowDSTableAdapters.FlowLinkTableAdapter adFlowLink = new ezFlowDSTableAdapters.FlowLinkTableAdapter();
	static ezFlowDSTableAdapters.FlowLinkPowerTableAdapter adFlowLinkPower = new ezFlowDSTableAdapters.FlowLinkPowerTableAdapter();
	static ezFlowDSTableAdapters.NodeMangLoopBreakTableAdapter adNodeMangLoopBreak = new ezFlowDSTableAdapters.NodeMangLoopBreakTableAdapter();	
	static ezFlowDSTableAdapters.NodeEndTableAdapter adNodeEnd = new ezFlowDSTableAdapters.NodeEndTableAdapter();
	static ezFlowDSTableAdapters.NodeStartTableAdapter adNodeStart = new ezFlowDSTableAdapters.NodeStartTableAdapter();
	static ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlowDSTableAdapters.NodeCustomTableAdapter();
	static ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlowDSTableAdapters.NodeDynamicTableAdapter();
	static ezFlowDSTableAdapters.NodeMailTableAdapter adNodeMail = new ezFlowDSTableAdapters.NodeMailTableAdapter();
	static ezFlowDSTableAdapters.NodeServiceTableAdapter adNodeService = new ezFlowDSTableAdapters.NodeServiceTableAdapter();
	
	static ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();
	static ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
	static ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrgDSTableAdapters.DeptTableAdapter();
	static ezOrgDSTableAdapters.AllStartEmailTableAdapter adAllStartEmail = new ezOrgDSTableAdapters.AllStartEmailTableAdapter();
	static ezOrgDSTableAdapters.AllCheckEmailTableAdapter adAllCheckEmail = new ezOrgDSTableAdapters.AllCheckEmailTableAdapter();

	static ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
	static ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
	static ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
	static ezProcessDSTableAdapters.SysVarTableAdapter adSysVar = new ezProcessDSTableAdapters.SysVarTableAdapter();	
	static ezProcessDSTableAdapters.ProcessApViewTableAdapter adProcessApView = new ezProcessDSTableAdapters.ProcessApViewTableAdapter();
	static ezProcessDSTableAdapters.ProcessMultiFlowTableAdapter adProcessMultiFlow = new ezProcessDSTableAdapters.ProcessMultiFlowTableAdapter();

	//從 Source 節點，取得 Target 節點集合
	public static List<string> GetLinkNextNode(int idProcess, int idProcessNode_Source, int idProcessCheck_Source, 
		string idFlowTree, string idFlowNode_Source) {
		ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataByFlowNodeSource(idFlowTree, idFlowNode_Source);
		List<string> lstNode1 = new List<string>();
		List<string> lstNode2 = new List<string>();
		List<string> lstNode3 = new List<string>();
		
		foreach(DataRow drFlowLink in dtFlowLink.Rows) {
			ezFlowDS.FlowLinkRow rowFlowLink = (ezFlowDS.FlowLinkRow)drFlowLink;
			if(rowFlowLink.linkType == "1") {
				ezFlowDS.FlowLinkPowerDataTable dtFlowLinkPower = adFlowLinkPower.GetDataByFlowLink(rowFlowLink.id);
				if(adFlowLinkPower.Connection.State != ConnectionState.Open) adFlowLinkPower.Connection.Open();

				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = adFlowLinkPower.Connection;		

				bool isRight = false;
				foreach(DataRow drFlowLinkPower in dtFlowLinkPower.Rows) {
					string criteria = "";
					ezFlowDS.FlowLinkPowerRow rowFlowLinkPower = (ezFlowDS.FlowLinkPowerRow)drFlowLinkPower;
					sqlCommand.CommandText = "Select * From " + rowFlowLinkPower.tableName +
						" Where idProcess = " + idProcess.ToString();

					criteria = GetCriteriaString(rowFlowLinkPower.fdName1,
										rowFlowLinkPower.fdType1,rowFlowLinkPower.criteria1,
										rowFlowLinkPower.minValue1,rowFlowLinkPower.maxValue1);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = GetCriteriaString(rowFlowLinkPower.fdName2,
										rowFlowLinkPower.fdType2, rowFlowLinkPower.criteria2,
										rowFlowLinkPower.minValue2, rowFlowLinkPower.maxValue2);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = GetCriteriaString(rowFlowLinkPower.fdName3,
										rowFlowLinkPower.fdType3, rowFlowLinkPower.criteria3,
										rowFlowLinkPower.minValue3, rowFlowLinkPower.maxValue3);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = GetCriteriaString(rowFlowLinkPower.fdName4,
										rowFlowLinkPower.fdType4, rowFlowLinkPower.criteria4,
										rowFlowLinkPower.minValue4, rowFlowLinkPower.maxValue4);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = GetCriteriaString(rowFlowLinkPower.fdName5,
										rowFlowLinkPower.fdType5, rowFlowLinkPower.criteria5,
										rowFlowLinkPower.minValue5, rowFlowLinkPower.maxValue5);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = GetCriteriaString(rowFlowLinkPower.fdName6,
										rowFlowLinkPower.fdType6, rowFlowLinkPower.criteria6,
										rowFlowLinkPower.minValue6, rowFlowLinkPower.maxValue6);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					try {
						SqlDataReader rdCriteria = sqlCommand.ExecuteReader();
						if(rdCriteria.HasRows) {
							lstNode1.Add(rowFlowLink.FlowNode_idTarget);
							isRight = true;
						}
						rdCriteria.Close();
						if(isRight) break;
					}
					catch(Exception ex) {
						CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
							ErrorType.Error, "原因：" + ex.Message);
					}
				}
				adFlowLinkPower.Connection.Close();
			}
			if(rowFlowLink.linkType == "2") {
				lstNode2.Add(rowFlowLink.FlowNode_idTarget);
			}
			if(rowFlowLink.linkType == "3") {
				lstNode3.Add(rowFlowLink.FlowNode_idTarget);
			}
		}

		List<string> lstAll = new List<string>();
		lstAll.AddRange(lstNode1);
		if(lstNode1.Count == 0) lstAll.AddRange(lstNode2);
		lstAll.AddRange(lstNode3);

		return lstAll;
	}

	//取得AND條件字串
	public static string GetCriteriaString(string fieldName, string fieldType, string criteria, string minValue, string maxValue) {
		string fdCriteria = "", fdValue1 = "", fdValue2 = "";
		string CLIP = "";

		if(fieldName.Trim().Length > 0) {
			if(criteria == ">>") fdCriteria = ">";
			if(criteria == "<<") fdCriteria = "<";
			if(criteria == "==") fdCriteria = "=";
			if(criteria == ">=") fdCriteria = ">=";
			if(criteria == "<=") fdCriteria = "<=";
			if(criteria == "<>") fdCriteria = "<>";
			if(criteria == "><") fdCriteria = "BETWEEN";

			if(fieldType == "Boolean" || fieldType == "Numeric") {
				fdValue1 = minValue.Trim();
				fdValue2 = maxValue.Trim();
			}
			if(fieldType == "DateTime" || fieldType == "String") {
				fdValue1 = "'" + minValue.Trim() + "'";
				fdValue2 = "'" + maxValue.Trim() + "'";
			}

			if(fdCriteria == "BETWEEN")
				CLIP = " AND " + fieldName + " " + fdCriteria + " " + fdValue1 + " AND " + fdValue2;
			else
				CLIP = " AND " + fieldName + " " + fdCriteria + " " + fdValue1;			
		}

		return CLIP;
	}

	public static bool GoToNextNode(int idProcess,int idProcessNode_Source, int idProcessCheck_Source,
		string idFlowTree,string idFlowNodeSource, string idRoleSource, string idEmpSource, List<string> lstNode_Next) {

		bool isFromMultiNode = false;
		ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataById(idFlowNodeSource);
		if (dtFlowNode.Count > 0 && dtFlowNode[0].nodeType == "9") isFromMultiNode = true;

		bool isOK = true;
		for(int i = 0; i < lstNode_Next.Count; i++) {
			List<string> lstNode_NewNext = null;
			ezFlowDS.FlowNodeDataTable dtFlowNode_Next = adFlowNode.GetDataById(lstNode_Next[i]);
			//ezFlowDS
			CMan Man_Default = null;
			CMan Man_Agent = null;
			switch(dtFlowNode_Next[0].nodeType) {
				case "2": //表單填寫，直接過去吧！
					{
						lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, dtFlowNode_Next[0].id);
						GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
							idRoleSource, idEmpSource, lstNode_NewNext);
					}
					break;
				case "3": //主管審核，只處理第一次進入	
					{
                    repert:
						Man_Default = COrg.GetManager(idProcess, idRoleSource);

						if (Man_Default == null) {
							ezOrgDS.RoleDataTable dtRole_Manager = adRole.GetDataById(idRoleSource);
							ezOrgDS.DeptDataTable dtDept_Manager = adDept.GetDataById(dtRole_Manager[0].Dept_id);
							//如果到部門樹頂，則往下一點執行
							if (dtDept_Manager[0].idParent.Trim().Length == 0) {
								isOK = true;
								lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, dtFlowNode_Next[0].id);
								GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source,
									idFlowTree, idFlowNodeSource, idRoleSource, idEmpSource, lstNode_NewNext);
							}
							else {
								CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
									ErrorType.Error, "原因：找不到直屬主管");
								isOK = false;
							}
						}
						else {
							//若承送的工號與抓到的主管同一人，則繼續抓主管
                            if (Man_Default.idEmp == idEmpSource && !isFromMultiNode)
                            {
                                //Man_Default = COrg.GetManager(idProcess, Man_Default.idRole);
                                idRoleSource = Man_Default.idRole;
                                idEmpSource = Man_Default.idEmp;
                                goto repert;
                            }

							//是否需要找代理人
							CMan Man_AgentTmp = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
							if (Man_AgentTmp != null) {
								ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
								if (dtEmp_Default.Count > 0 && dtEmp_Default[0].isNeedAgent && DateTime.Now >= dtEmp_Default[0].dateB && DateTime.Now <= dtEmp_Default[0].dateE) {
									//萬一代理人與送出表單的人為同一人，就要從預設的抓出其它人來簽
									if (Man_AgentTmp.idEmp != idEmpSource && !isFromMultiNode) Man_Agent = Man_AgentTmp;
									else Man_Agent = COrg.GetDefaultAgent(Man_Default.idRole, Man_Default.idEmp, idEmpSource);
								}
								else {
									if (Man_AgentTmp.agentType == AgentType.Always) {
										//常態性代理人的表單，須由本人來簽…
										if (Man_AgentTmp.idEmp != idEmpSource) Man_Agent = Man_AgentTmp;
									}
								}
							}
							CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id, Man_Default, Man_Agent);
						}
					}
					break;
				case "4": //流程起始者
					{
						Man_Default = COrg.GetFlowInit(idProcess);
						if (Man_Default == null) {
							CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
								ErrorType.Error, "原因：找不到流程起始者");
							isOK = false;
						}
						else {
							if (Man_Default.idEmp == idEmpSource && !isFromMultiNode) {
								lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, dtFlowNode_Next[0].id);
								GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
									idRoleSource, idEmpSource, lstNode_NewNext);
							}
							else {
								//是否需要找代理人
								CMan Man_AgentTmp = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
								if (Man_AgentTmp != null) {
									ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
									if (dtEmp_Default.Count > 0 && dtEmp_Default[0].isNeedAgent && DateTime.Now >= dtEmp_Default[0].dateB && DateTime.Now <= dtEmp_Default[0].dateE) {
										//萬一代理人與送出表單的人為同一人，就要從預設的抓出其它人來簽
										if (Man_AgentTmp.idEmp != idEmpSource && !isFromMultiNode) Man_Agent = Man_AgentTmp;
										else Man_Agent = COrg.GetDefaultAgent(Man_Default.idRole, Man_Default.idEmp, idEmpSource);
									}
									else {
										if (Man_AgentTmp.agentType == AgentType.Always) {
											//常態性代理人的表單，須由本人來簽…
											if (Man_AgentTmp.idEmp != idEmpSource) Man_Agent = Man_AgentTmp;
										}
									}
								}
								CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id, Man_Default, Man_Agent);
							}
						}
					}
					break;
				case "5": //會簽起始者
					{
						Man_Default = COrg.GetMultiInit(idProcess, dtFlowNode_Next[0].id);
						if (Man_Default == null) {
							CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
								ErrorType.Error, "原因：找不到會簽起始者");
							isOK = false;
						}
						else {
							//是否需要找代理人
							CMan Man_AgentTmp = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
							if (Man_AgentTmp != null) {
								ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
								if (dtEmp_Default.Count > 0 && dtEmp_Default[0].isNeedAgent && DateTime.Now >= dtEmp_Default[0].dateB && DateTime.Now <= dtEmp_Default[0].dateE) {
									//萬一代理人與送出表單的人為同一人，就要從預設的抓出其它人來簽
									if (Man_AgentTmp.idEmp != idEmpSource && !isFromMultiNode) Man_Agent = Man_AgentTmp;
									else Man_Agent = COrg.GetDefaultAgent(Man_Default.idRole, Man_Default.idEmp, idEmpSource);
								}
								else {
									if (Man_AgentTmp.agentType == AgentType.Always) {
										//常態性代理人的表單，須由本人來簽…
										if (Man_AgentTmp.idEmp != idEmpSource) Man_Agent = Man_AgentTmp;
									}
								}
							}
							CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id, Man_Default, Man_Agent);
						}
					}
					break;
				case "6": //自訂簽核者
					{
						Man_Default = COrg.GetCustom(dtFlowNode_Next[0].id);
						if (Man_Default == null) {
							CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
								ErrorType.Error, "原因：找不到自訂成員");
							isOK = false;
						}
						else {
							if (Man_Default.idEmp == idEmpSource && !isFromMultiNode) {
								lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, dtFlowNode_Next[0].id);
								GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
									idRoleSource, idEmpSource, lstNode_NewNext);
							}
							else {
								//是否需要找代理人
								CMan Man_AgentTmp = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
								if (Man_AgentTmp != null) {
									ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
									if (dtEmp_Default.Count > 0 && dtEmp_Default[0].isNeedAgent && DateTime.Now >= dtEmp_Default[0].dateB && DateTime.Now <= dtEmp_Default[0].dateE) {
										//萬一代理人與送出表單的人為同一人，就要從預設的抓出其它人來簽
										if (Man_AgentTmp.idEmp != idEmpSource && !isFromMultiNode) Man_Agent = Man_AgentTmp;
										else Man_Agent = COrg.GetDefaultAgent(Man_Default.idRole, Man_Default.idEmp, idEmpSource);
									}
									else {
										if (Man_AgentTmp.agentType == AgentType.Always) {
											//常態性代理人的表單，須由本人來簽…
											if (Man_AgentTmp.idEmp != idEmpSource) Man_Agent = Man_AgentTmp;
										}
									}
								}
								CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id, Man_Default, Man_Agent);
							}
						}
					}
					break;
				case "7": //動態簽核者
					{
						Man_Default = COrg.GetDynamic(idProcess, dtFlowNode_Next[0].id);
						if (Man_Default == null) {
							CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
								ErrorType.Error, "原因：找不到動態成員");
							isOK = false;
						}
						else {
							if (Man_Default.idEmp == idEmpSource && !isFromMultiNode) {
								lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, dtFlowNode_Next[0].id);
								GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
									idRoleSource, idEmpSource, lstNode_NewNext);
							}
							else {
								//是否需要找代理人
								CMan Man_AgentTmp = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
								if (Man_AgentTmp != null) {
									ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
									if (dtEmp_Default.Count > 0 && dtEmp_Default[0].isNeedAgent && DateTime.Now >= dtEmp_Default[0].dateB && DateTime.Now <= dtEmp_Default[0].dateE) {
										//萬一代理人與送出表單的人為同一人，就要從預設的抓出其它人來簽
										if (Man_AgentTmp.idEmp != idEmpSource && !isFromMultiNode) Man_Agent = Man_AgentTmp;
										else Man_Agent = COrg.GetDefaultAgent(Man_Default.idRole, Man_Default.idEmp, idEmpSource);
									}
									else {
										if (Man_AgentTmp.agentType == AgentType.Always) {
											//常態性代理人的表單，須由本人來簽…
											if (Man_AgentTmp.idEmp != idEmpSource) Man_Agent = Man_AgentTmp;
										}
									}
								}
								CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id, Man_Default, Man_Agent);
							}
						}
					}
					break;
				case "8": //代理起始者
					{
						Man_Default = COrg.GetAgentInit(idProcess);
						if (Man_Default == null) {
							CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
								ErrorType.Error, "原因：找不到代理起始者");
							isOK = false;
						}
						else {
							if (Man_Default.idEmp == idEmpSource && !isFromMultiNode) {
								lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, dtFlowNode_Next[0].id);
								GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
									idRoleSource, idEmpSource, lstNode_NewNext);
							}
							else {
								//是否需要找代理人
								CMan Man_AgentTmp = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
								if (Man_AgentTmp != null) {
									ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
									if (dtEmp_Default.Count > 0 && dtEmp_Default[0].isNeedAgent && DateTime.Now >= dtEmp_Default[0].dateB && DateTime.Now <= dtEmp_Default[0].dateE) {
										//萬一代理人與送出表單的人為同一人，就要從預設的抓出其它人來簽
										if (Man_AgentTmp.idEmp != idEmpSource && !isFromMultiNode) Man_Agent = Man_AgentTmp;
										else Man_Agent = COrg.GetDefaultAgent(Man_Default.idRole, Man_Default.idEmp, idEmpSource);
									}
									else {
										if (Man_AgentTmp.agentType == AgentType.Always) {
											//常態性代理人的表單，須由本人來簽…
											if (Man_AgentTmp.idEmp != idEmpSource) Man_Agent = Man_AgentTmp;
										}
									}
								}
								CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id, Man_Default, Man_Agent);
							}
						}
					}
					break;
				case "9": //會簽流程
					{
						int ProcessNode_auto = CProcess.CreateProcessNode(idProcessNode_Source, idProcess, dtFlowNode_Next[0].id);
						ezProcessDS.ProcessMultiFlowDataTable dtProcessMultiFlow = adProcessMultiFlow.GetDataByNewMultiFlow(idProcess);

						Service srv = new Service();
						foreach (ezProcessDS.ProcessMultiFlowRow rowProcessMultiFlow in dtProcessMultiFlow.Rows) {
							rowProcessMultiFlow.ProcessNode_auto = ProcessNode_auto;
							int sub_idProcess = srv.GetProcessID(); //先取得 idProcess

							//抓取流程的啟始點來呼叫 FlowStart
							bool isError = true;
							ezFlowDS.FlowNodeDataTable dtSubFlowNode = adFlowNode.GetDataByFlowTree(rowProcessMultiFlow.SubFlowTree_id);
							string nStart_id = "";
							if (dtSubFlowNode.Count > 0) {
								bool hasStart = false;
								foreach (ezFlowDS.FlowNodeRow rowSubFlowNode in dtSubFlowNode.Rows) {
									if (rowSubFlowNode.nodeType == "1") {
										hasStart = true;
										nStart_id = rowSubFlowNode.id;
									}
									if (hasStart) break;
								}
								//找到起始點後，找起始點的下一點的 FlowNode_id
								if (hasStart) {
									ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataByFlowNodeSource(rowProcessMultiFlow.SubFlowTree_id, nStart_id);
									if (dtFlowLink.Count > 0) {
										string dynamic_node_id = dtFlowLink[0].FlowNode_idTarget;
										ezFlowDS.FlowNodeDataTable dtFlowNode_dynamic = CFlow.adFlowNode.GetDataById(dynamic_node_id);
										if (dtFlowNode_dynamic.Count > 0) {
											if (dtFlowNode_dynamic[0].nodeType == "7") { //確定下一點接的是動態成員
												ezFlowDS.NodeDynamicDataTable dtSubNodeDynamic = adNodeDynamic.GetDataByFlowNode(dynamic_node_id);
												if (dtSubNodeDynamic.Count > 0) {
													string dynamic_tablename = dtSubNodeDynamic[0].tableName;
													SqlCommand sqlCommand = new SqlCommand();
													sqlCommand.Connection = adNodeDynamic.Connection;
													sqlCommand.CommandText = string.Format(@"insert into {0}(idProcess,idFlowNode,{1},{2}) values('{3}','{4}','{5}','{6}')",
														dynamic_tablename, dtSubNodeDynamic[0].fdRole, dtSubNodeDynamic[0].fdEmp, sub_idProcess.ToString(), dynamic_node_id, rowProcessMultiFlow.SubDynamicRole_id, rowProcessMultiFlow.SubDynamicEmp_id);
													try {
														if (adNodeDynamic.Connection.State == ConnectionState.Closed) adNodeDynamic.Connection.Open();
														sqlCommand.ExecuteNonQuery();
														isError = false;
													}
													finally {
														adNodeDynamic.Connection.Close();
													}
												}
											}
										}
									}
								}
							}

							if (!isError) {	//填完動態成員資訊後，啟動子流程，並設定為並行。
								srv.FlowStart(sub_idProcess, rowProcessMultiFlow.SubFlowTree_id, rowProcessMultiFlow.SubInitRole_id, rowProcessMultiFlow.SubInitEmp_id, "", "");
								SqlCommand sqlCommand = new SqlCommand();
								sqlCommand.Connection = adProcessMultiFlow.Connection;
								sqlCommand.CommandText = string.Format(@"update processflow set ismultiflow = 1 where id = {0}", sub_idProcess.ToString());
								try {
									if (adProcessMultiFlow.Connection.State == ConnectionState.Closed) adProcessMultiFlow.Connection.Open();
									sqlCommand.ExecuteNonQuery();
									isError = false;
								}
								finally {
									adProcessMultiFlow.Connection.Close();
								}
							}

							rowProcessMultiFlow.SubProcessFlow_id = sub_idProcess;
						}
						adProcessMultiFlow.Update(dtProcessMultiFlow);
					}
					break;
				case "10": //郵件通知，直接過去吧！
					{
						ezFlowDS.NodeMailDataTable dtNodeMail = adNodeMail.GetDataByFlowNode(dtFlowNode_Next[0].id);
						switch (dtNodeMail[0].receiveType) {
							case "1": {
									ezProcessDS.ProcessFlowShareDataTable dtProcessFlowShare = adProcessFlowShare.GetDataByProcessFlow(idProcess);
									foreach (DataRow drProcessFlowShare in dtProcessFlowShare.Rows) {
										ezProcessDS.ProcessFlowShareRow rowProcessFlowShare = (ezProcessDS.ProcessFlowShareRow)drProcessFlowShare;
										ezOrgDS.EmpDataTable dtEmp = adEmp.GetDataById(rowProcessFlowShare.Emp_id);
										if (dtEmp.Count > 0 && !dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
											string mailto = dtEmp[0].email;
											if (dtNodeMail[0].isCustom) {
												SendMail(idProcess, idProcessNode_Source, idProcessCheck_Source, dtFlowNode_Next[0].name,rowProcessFlowShare.Emp_id,
													mailto, dtNodeMail[0].subject, dtNodeMail[0].mailContent);
											}
											else {
												SendMail(idProcess, idProcessNode_Source, idProcessCheck_Source, dtFlowNode_Next[0].name,rowProcessFlowShare.Emp_id,
													mailto, "", "");
											}
										}
									}
								}
								break;
							case "2": {
									if (dtNodeMail[0].isCustom) {
										if (!dtNodeMail[0].IscustomEmailNull() && dtNodeMail[0].customEmail.Trim().Length > 0) {
											SendMail(idProcess, idProcessNode_Source, idProcessCheck_Source, dtFlowNode_Next[0].name,"",
												dtNodeMail[0].customEmail, dtNodeMail[0].subject, dtNodeMail[0].mailContent);
										}
									}
									else {
										if (!dtNodeMail[0].IscustomEmailNull() && dtNodeMail[0].customEmail.Trim().Length > 0) {
											SendMail(idProcess, idProcessNode_Source, idProcessCheck_Source, dtFlowNode_Next[0].name,"",
												dtNodeMail[0].customEmail, "", "");
										}
									}
								}
								break;
							case "3": {
									if (adNodeMail.Connection.State == ConnectionState.Closed) adNodeMail.Connection.Open();
									SqlCommand sqlCommand = new SqlCommand();
									sqlCommand.Connection = adNodeMail.Connection;
									sqlCommand.CommandText = "Select * From " + dtNodeMail[0].dynamicTable +
										" Where idProcess = " + idProcess.ToString();
									SqlDataReader rdDynamicMail = sqlCommand.ExecuteReader();
									if (rdDynamicMail.HasRows) {
										while (rdDynamicMail.Read()) {
											try {
												if (dtNodeMail[0].isCustom) {
													SendMail(idProcess, idProcessNode_Source, idProcessCheck_Source, dtFlowNode_Next[0].name,"",
														rdDynamicMail[dtNodeMail[0].dynamicFdMail].ToString(),
														dtNodeMail[0].subject, dtNodeMail[0].mailContent);
												}
												else {
													SendMail(idProcess, idProcessNode_Source, idProcessCheck_Source, dtFlowNode_Next[0].name,"",
														rdDynamicMail[dtNodeMail[0].dynamicFdMail].ToString(), "", "");
												}
											}
											catch (Exception ex) {
												CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
													ErrorType.Warning, "原因：" + ex.Message);
											}
										}
									}
								}
								break;
						}
						lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source,
							idFlowTree, dtFlowNode_Next[0].id);
						GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
							idRoleSource, idEmpSource, lstNode_NewNext);
					}
					break;
				case "11": //服務程式，直接過去吧！
					{
						ezProcessDS.ProcessApViewDataTable dtProcessApView = adProcessApView.GetDataByFlowProcess_id(idProcess);

						ezFlowDS.NodeServiceDataTable dtNodeService = adNodeService.GetDataByFlowNode(dtFlowNode_Next[0].id);

						localhost.Service dynamicSrv = new localhost.Service();
						dynamicSrv.Url = dtNodeService[0].webSrvUrl;
						if (!dynamicSrv.Run(dtProcessApView[0].auto)) {
							CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
								ErrorType.Warning, "原因：Web Service 呼叫失敗");
							isOK = false;
						}

						lstNode_NewNext = GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source,
							idFlowTree, dtFlowNode_Next[0].id);
						GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNodeSource,
							idRoleSource, idEmpSource, lstNode_NewNext);
					}
					break;
				case "12": //流程結束
					{
						ezProcessDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(idProcess);
						dtProcessFlow[0].isFinish = true;
						adProcessFlow.Update(dtProcessFlow);
						//子流程回主流程的處理
						ezProcessDS.ProcessMultiFlowDataTable dtProcessMultiFlow = adProcessMultiFlow.GetDataBySubProcess(idProcess);
						if (dtProcessMultiFlow.Count > 0) {
							int ProcessFlow_id = dtProcessMultiFlow[0].ProcessFlow_id;
							int ProcessNode_auto = dtProcessMultiFlow[0].ProcessNode_auto;
							dtProcessMultiFlow = adProcessMultiFlow.GetDataByMainFlow(ProcessFlow_id, ProcessNode_auto);
							bool isAllFinish = true;
							foreach (ezProcessDS.ProcessMultiFlowRow rowProcessMultiFlow in dtProcessMultiFlow.Rows) {
								dtProcessFlow = adProcessFlow.GetDataById(rowProcessMultiFlow.SubProcessFlow_id);
								if (dtProcessFlow.Count > 0 && !dtProcessFlow[0].isFinish) isAllFinish = false;
							}

							if (isAllFinish) { //當全部完成的話，則主流程繼續往下走。
								dtProcessFlow = adProcessFlow.GetDataById(ProcessFlow_id);
								if (dtProcessFlow.Count > 0) {
									idFlowTree = dtProcessFlow[0].FlowTree_id;
									ezProcessDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByAuto(ProcessNode_auto);
									if (dtProcessNode.Count > 0) {
										string idFlowNode = dtProcessNode[0].FlowNode_id;
										lstNode_NewNext = GetLinkNextNode(ProcessFlow_id, ProcessNode_auto, 0, idFlowTree, idFlowNode);
										GoToNextNode(ProcessFlow_id, ProcessNode_auto, 0, idFlowTree, idFlowNode, dtProcessMultiFlow[0].SubInitRole_id, dtProcessMultiFlow[0].SubInitEmp_id, lstNode_NewNext);
									}
								}
							}
						}
					}
					break;
			}			
		}
		return isOK;
	}

    public static void SendMail(int idProcess, int idProcessNode_Source, int idProcessCheck_Source, string FlowNodeName, string ToEmp,
        string to, string subject, string body)
    {
		if(to.Trim().Length == 0) return;

		ezProcessDS.SysVarDataTable dtSysVar = adSysVar.GetData();

		if(dtSysVar.Count > 0) {
			string mailServerName = dtSysVar[0].mailServer;

			string fromAddress = dtSysVar[0].senderMail;
			string fromName = dtSysVar[0].senderName;

			string toAddress = to;
            ezOrgDS.EmpDataTable dtEmp = adEmp.GetDataById(ToEmp.Trim());
			string toName = "";
			if(dtEmp.Count > 0) toName = dtEmp[0].name;

			bool isUseDefaultCredentials = true;
			string strFrom = "", strFromPass = "";
			if(dtSysVar[0].mailID.Trim().Length > 0) {
				strFrom = dtSysVar[0].mailID;
				strFromPass = dtSysVar[0].mailPW;
				isUseDefaultCredentials = false;
			}

			ezProcessDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(idProcess);			
			ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(dtProcessFlow[0].FlowTree_id);			

			if(subject.Trim().Length == 0 || body.Trim().Length == 0) {
                subject = fromName + dtFlowTree[0].name + "-" + FlowNodeName;

				string urlAp = "";
				ezProcessDS.ProcessApViewDataTable dtProcessApView = adProcessApView.GetDataByFlowProcess_id(idProcess);
                if (dtProcessApView.Count > 0)
                {
                    //找出 Start Node
                    ezFlowDS.FlowNodeDataTable dtFlowNode_tmp = adFlowNode.GetDataByFlowTree(dtProcessFlow[0].FlowTree_id);
                    string nStart_id = "";
                    foreach (DataRow drFlowNode in dtFlowNode_tmp.Rows)
                    {
                        ezFlowDS.FlowNodeRow rowFlowNode = (ezFlowDS.FlowNodeRow)drFlowNode;
                        if (rowFlowNode.nodeType == "1")
                        {
                            nStart_id = rowFlowNode.id;
                            break;
                        }
                    }

                    if (nStart_id.Trim().Length > 0)
                    {
                        ezFlowDS.NodeStartDataTable dtNodeStart = adNodeStart.GetDataByFlowNode(nStart_id);
                        urlAp = dtSysVar[0].urlRoot + "/Forms/" + dtNodeStart[0].virtualPath + "/" + dtNodeStart[0].viewAp;
                    }

                    if (urlAp.Trim().Length > 0) urlAp += "?ApView=" + dtProcessApView[0].auto.ToString();
                }

                body = "嗨！您好…<br><br>";
                body += "這是由 ezFlow 信差服務所發出的信件，詳情請點選下面的超連結。<br><br>";
                body += "<a href='" + urlAp + "'>我想要查看表單填寫內容</a>";

                body = dtEmp[0].name + ",您好...<br><br>" +
                     "這封信，是由 ezFlow System 所發出的。<br>" +
                     "系統偵測到在流程中，有您的待辦事項需要完成，請您抽空前往處理。謝謝！<br><br>" +
                     "<a href='" + dtSysVar[0].urlRoot + "/ezClient/Default.aspx'>待核決事項</a>";
			}

            body += "<br><br><font color='red'>此信件為系統自動寄送，請勿直接回信，同仁若有疑問請直接洽人事單位辦理，謝謝您！</font>";

			try {				
				MailMessage message = new MailMessage();
				message.From = new MailAddress(fromAddress, fromName,System.Text.Encoding.Default);
				message.To.Add(new MailAddress(toAddress, toName, System.Text.Encoding.Default));
				message.Subject = subject;
				message.Body = body;
				message.IsBodyHtml = true;
				message.Priority = MailPriority.High;
				message.BodyEncoding = System.Text.Encoding.Default;
				message.SubjectEncoding = System.Text.Encoding.Default;

				SmtpClient mailClient = new SmtpClient(mailServerName);
				mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

				if(isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
				else {
					mailClient.UseDefaultCredentials = false;
					mailClient.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
				}

                //mailClient.Send(message);
			}
			catch(Exception ex) {
				CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
					ErrorType.Warning, "原因：" + ex.Message);
			}
		}
	}
}
