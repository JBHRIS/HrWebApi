using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
	ezProcessDSTableAdapters.ProcessApParmTableAdapter adProcessApParm = new ezProcessDSTableAdapters.ProcessApParmTableAdapter();
	ezProcessDSTableAdapters.ProcessApViewTableAdapter adProcessApView = new ezProcessDSTableAdapters.ProcessApViewTableAdapter();
	ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();
	ezProcessDSTableAdapters.ProcessExceptionTableAdapter adProcessException = new ezProcessDSTableAdapters.ProcessExceptionTableAdapter();
	ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
	ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
	ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
	ezProcessDSTableAdapters.SysVarTableAdapter adSysVar = new ezProcessDSTableAdapters.SysVarTableAdapter();
	ezProcessDSTableAdapters.ProcessMultiFlowTableAdapter adProcessMultiFlow = new ezProcessDSTableAdapters.ProcessMultiFlowTableAdapter();

	ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();
	ezFlowDSTableAdapters.FlowNodeTableAdapter adFlowNode = new ezFlowDSTableAdapters.FlowNodeTableAdapter();
	ezFlowDSTableAdapters.FlowLinkTableAdapter adFlowLink = new ezFlowDSTableAdapters.FlowLinkTableAdapter();
	ezFlowDSTableAdapters.FlowLinkPowerTableAdapter adFlowLinkPower = new ezFlowDSTableAdapters.FlowLinkPowerTableAdapter();
	ezFlowDSTableAdapters.NodeMangLoopBreakTableAdapter adNodeMangLoopBreak = new ezFlowDSTableAdapters.NodeMangLoopBreakTableAdapter();

	ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
	ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();
	ezOrgDSTableAdapters.PosTableAdapter adPos = new ezOrgDSTableAdapters.PosTableAdapter();

	ezProcessDSTableAdapters.SendMailLogTableAdapter adSendMailLog = new ezProcessDSTableAdapters.SendMailLogTableAdapter();

	[Serializable]
	public class CApParm {
		public int ProcessFlow_id;
		public int ProcessNode_auto;
		public int ProcessCheck_auto;
		public string Role_id;
		public string Emp_id;

		public CApParm() {
			ProcessFlow_id = 0;
			ProcessNode_auto = 0;
			ProcessCheck_auto = 0;
			Role_id = "";
			Emp_id = "";
		}

		public CApParm(int idApParm) {
			ezProcessDSTableAdapters.ProcessApParmTableAdapter adProcessApParm = new ezProcessDSTableAdapters.ProcessApParmTableAdapter();
			ezProcessDS.ProcessApParmDataTable dtProcessApParm = adProcessApParm.GetDataByAuto(idApParm);
			if(dtProcessApParm.Count > 0) {
				ProcessFlow_id = dtProcessApParm[0].ProcessFlow_id;
				ProcessNode_auto = dtProcessApParm[0].ProcessNode_auto;
				ProcessCheck_auto = dtProcessApParm[0].ProcessCheck_auto;
				Role_id = dtProcessApParm[0].Role_id;
				Emp_id = dtProcessApParm[0].Emp_id;
			}
		}
	}

	[Serializable]
	public class CApView {
		public int ProcessFlow_id = 0;
		public string Role_id = "";
		public string Emp_id = "";
		public string tag1 = "";
		public string tag2 = "";
		public string tag3 = "";

		public CApView() {
			ProcessFlow_id = 0;
			Role_id = "";
			Emp_id = "";
			tag1 = "";
			tag2 = "";
			tag3 = "";
		}

		public CApView(int idApView) {
			ezProcessDSTableAdapters.ProcessApViewTableAdapter adProcessApView = new ezProcessDSTableAdapters.ProcessApViewTableAdapter();
			ezProcessDS.ProcessApViewDataTable dtProcessApView = adProcessApView.GetDataByAuto(idApView);
			if(dtProcessApView.Count > 0) {
				ProcessFlow_id = dtProcessApView[0].ProcessFlow_id;
				Role_id = dtProcessApView[0].Role_id;
				Emp_id = dtProcessApView[0].Emp_id;
				tag1 = dtProcessApView[0].tag1;
				tag2 = dtProcessApView[0].tag2;
				tag3 = dtProcessApView[0].tag3;
			}
		}
	}

    public Service () {
        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

	[WebMethod]
	public int GetProcessID() {
		return CProcess.GetProcessID();
	}

	[WebMethod]
	public bool FlowStart(int idProcess, string idFlowTree, string idRole_Start, string idEmp_Start, 
		string idRole_Agent, string idEmp_Agent) {
		//如果流程失效，就無法繼續
		ezFlowDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataByIdAndDate(idFlowTree);
		if(dtFlowTree.Count == 0) {
			CProcess.WriteProcessException(idProcess, 0, 0, ErrorType.Warning, "原因：流程已失效");
			return false;
		}

		//如果流程沒有拉節點，就無法繼續
		ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataByFlowTree(idFlowTree);
		string nStart_id = "";
		if(dtFlowNode.Count == 0) {
			CProcess.WriteProcessException(idProcess, 0, 0, ErrorType.Error, "原因：流程沒有拉節點");
			return false;
		}
		else {
			bool hasStart = false;
			for(int i = 0; i < dtFlowNode.Count; i++) {
				if(dtFlowNode[i].nodeType == "1") {
					hasStart = true;
					nStart_id = dtFlowNode[i].id;
				}
				if(hasStart) break;
			}
			//如果流程沒有拉開始節點
			if(!hasStart) {
				CProcess.WriteProcessException(idProcess, 0, 0, ErrorType.Error, "原因：流程找不到開始節點");
				return false;
			}
		}

		//如果 FlowLink 沒拉，也無法繼續 :(
		ezFlowDS.FlowLinkDataTable dtFlowLink = adFlowLink.GetDataByFlowNodeSource(idFlowTree, nStart_id);
		if(dtFlowLink.Count == 0) {
			CProcess.WriteProcessException(idProcess, 0, 0, ErrorType.Error, "原因：開始節點沒有拉線到下一點");
			return false;
		}

		ezProcessDS.ProcessFlowDataTable dtProcessFlow = new ezProcessDS.ProcessFlowDataTable();
		ezProcessDS.ProcessFlowRow rowProcessFlow = dtProcessFlow.NewProcessFlowRow();
		rowProcessFlow.id = idProcess;
		rowProcessFlow.FlowTree_id = idFlowTree;
		rowProcessFlow.adate = DateTime.Now;
		rowProcessFlow.Role_id = idRole_Start;
		rowProcessFlow.Emp_id = idEmp_Start;
		rowProcessFlow.isFinish = false;
		rowProcessFlow.isError = false;
		rowProcessFlow.isCancel = false;
		rowProcessFlow.isMultiFlow = false;
		dtProcessFlow.AddProcessFlowRow(rowProcessFlow);
		adProcessFlow.Update(dtProcessFlow);

		ezProcessDS.ProcessApViewDataTable dtProcessApView = new ezProcessDS.ProcessApViewDataTable();
		ezProcessDS.ProcessApViewRow rowProcessApView = dtProcessApView.NewProcessApViewRow();
		rowProcessApView.ProcessFlow_id = idProcess;
		rowProcessApView.Role_id = idRole_Start;
		rowProcessApView.Emp_id = idEmp_Start;
		rowProcessApView.tag1 = "";
		rowProcessApView.tag2 = "";
		rowProcessApView.tag3 = "";
		dtProcessApView.AddProcessApViewRow(rowProcessApView);
		adProcessApView.Update(dtProcessApView);

		ezProcessDS.ProcessFlowShareDataTable dtProcessFlowShare = adProcessFlowShare.GetDataByProcessFlow(idProcess);
		bool isFind = false;
		foreach(DataRow drProcessFlowShare in dtProcessFlowShare.Rows) {
			ezProcessDS.ProcessFlowShareRow rowProcessFlowShare = (ezProcessDS.ProcessFlowShareRow)drProcessFlowShare;
			if(rowProcessFlowShare.Emp_id == idEmp_Start) {
				isFind = true;
				break;
			}
		}
		if(!isFind) {
			ezProcessDS.ProcessFlowShareRow rowProcessFlowShare = dtProcessFlowShare.NewProcessFlowShareRow();
			rowProcessFlowShare.ProcessFlow_id = idProcess;
			rowProcessFlowShare.Role_id = idRole_Start;
			rowProcessFlowShare.Emp_id = idEmp_Start;
			rowProcessFlowShare.isStarter = false;
			dtProcessFlowShare.AddProcessFlowShareRow(rowProcessFlowShare);
		}

		if(idRole_Agent.Trim().Length > 0) {
			isFind = false;
			ezProcessDS.ProcessFlowShareRow rowProcessFlowShare;
			foreach(DataRow drProcessFlowShare in dtProcessFlowShare.Rows) {
				rowProcessFlowShare = (ezProcessDS.ProcessFlowShareRow)drProcessFlowShare;
				if(rowProcessFlowShare.Emp_id == idEmp_Agent) {
					isFind = true;
					break;
				}
			}
			if(!isFind) {
				rowProcessFlowShare = dtProcessFlowShare.NewProcessFlowShareRow();
				rowProcessFlowShare.ProcessFlow_id = idProcess;
				rowProcessFlowShare.Role_id = idRole_Agent;
				rowProcessFlowShare.Emp_id = idEmp_Agent;
				rowProcessFlowShare.isStarter = true;
				dtProcessFlowShare.AddProcessFlowShareRow(rowProcessFlowShare);
			}
		}

		adProcessFlowShare.Update(dtProcessFlowShare);

		List<string> lstNode_Next = CFlow.GetLinkNextNode(idProcess, 0, 0, idFlowTree, nStart_id);
		if(lstNode_Next.Count == 0) {
			CProcess.WriteProcessException(idProcess, 0, 0, ErrorType.Error, "原因：沒有合適的下一個節點，請檢查線段條件");
			return false;
		}

		bool ret = CFlow.GoToNextNode(idProcess, 0, 0, idFlowTree, nStart_id, idRole_Start, idEmp_Start, lstNode_Next);

		return ret;
	}

	[WebMethod]
	public void FlowShare(int idProcess,string idRole_Share,string idEmp_Share) {
		ezProcessDS.ProcessFlowShareDataTable dtProcessFlowShare = adProcessFlowShare.GetDataByProcessFlow(idProcess);
		bool isSave = false;
		for(int i = 0; i < dtProcessFlowShare.Count; i++) {
			if(dtProcessFlowShare[i].Role_id == idRole_Share) {
				isSave = true;
				break;
			}
		}
		if(!isSave) {
			ezProcessDS.ProcessFlowShareRow rowProcessFlowShare = dtProcessFlowShare.NewProcessFlowShareRow();
			rowProcessFlowShare.ProcessFlow_id = idProcess;
			rowProcessFlowShare.Role_id = idRole_Share;
			rowProcessFlowShare.Emp_id = idEmp_Share;
			rowProcessFlowShare.isStarter = false;
			dtProcessFlowShare.AddProcessFlowShareRow(rowProcessFlowShare);
			adProcessFlowShare.Update(dtProcessFlowShare);
		}
	}

	[WebMethod]
	public CApParm GetApParm(int idApParm) {
		CApParm apParm = new CApParm(idApParm);
		return apParm;
	}

	[WebMethod]
	public CApView GetApView(int idApView) {
		CApView apView = new CApView(idApView);
		return apView;
	}

	[WebMethod]
	public void SetApView(int idProcess, string tag1, string tag2, string tag3) {
		ezProcessDS.ProcessApViewDataTable dtProcessApView = adProcessApView.GetDataByFlowProcess_id(idProcess);
		if(dtProcessApView.Count > 0) {
			ezProcessDS.ProcessApViewRow rowProcessApView = dtProcessApView[0];
			rowProcessApView.tag1 = tag1;
			rowProcessApView.tag2 = tag2;
			rowProcessApView.tag3 = tag3;			
			adProcessApView.Update(dtProcessApView);
		}
	}

	[WebMethod]
	public bool WorkFinish(int idApParm) {
		CApParm apParm = new CApParm(idApParm);

		ezProcessDS.SendMailLogDataTable dtSendMailLog = adSendMailLog.GetDataByEmp(apParm.Emp_id);
		if(dtSendMailLog.Count > 0) {
			dtSendMailLog[0].counter = 0;
			dtSendMailLog[0].adate = DateTime.Now;
			adSendMailLog.Update(dtSendMailLog);
		}

		ezProcessDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(apParm.ProcessFlow_id);
		ezProcessDS.ProcessNodeDataTable dtProcessNode_Finish = adProcessNode.GetDataByAuto(apParm.ProcessNode_auto);
		ezProcessDS.ProcessCheckDataTable dtProcessCheck_Finish = adProcessCheck.GetDataByAuto(apParm.ProcessCheck_auto);

		int idProcess = dtProcessFlow[0].id;
		int idProcessNode_Source = dtProcessNode_Finish[0].auto;
		int idProcessCheck_Source = dtProcessCheck_Finish[0].auto;
		string idFlowTree = dtProcessFlow[0].FlowTree_id;
		string idFlowNode_Finish = dtProcessNode_Finish[0].FlowNode_id;
		string idRoleSource = dtProcessCheck_Finish[0].Role_idDefault;
		string idEmpSource = dtProcessCheck_Finish[0].Emp_idDefault;

		//檢查前置作業
		if(apParm.Role_id.Trim().Length == 0 || apParm.Emp_id.Trim().Length == 0) {
			CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
			ErrorType.Error, "原因：ProcessApParm 沒有充足的資訊");
			return false;
		}

		if(apParm.Role_id != dtProcessCheck_Finish[0].Role_idDefault &&
			apParm.Role_id != dtProcessCheck_Finish[0].Role_idAgent) {
			ezOrgDS.RoleDataTable dtRole_Other = adRole.GetDataById(apParm.Role_id);
			ezOrgDS.PosDataTable dtPos_Other = adPos.GetDataById(dtRole_Other[0].Pos_id);
			ezOrgDS.EmpDataTable dtEmp_Other = adEmp.GetDataById(apParm.Emp_id);
			CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
				ErrorType.Error, "原因：執行者'" + dtPos_Other[0].name + "-" + dtEmp_Other[0].name + "'沒有執行此動作的權力");
			return false;
		}

		List<string> lstNode_NewNext = null;

		ezFlowDS.FlowNodeDataTable dtFlowNode_Finish = adFlowNode.GetDataById(idFlowNode_Finish);
		bool isOK = true;
		if(dtFlowNode_Finish[0].nodeType == "3") {
			CMan Man_Default = null;
			CMan Man_Agent = null;
			bool isRight = false;
			ezFlowDS.NodeMangLoopBreakDataTable dtNodeMangLoopBreak = adNodeMangLoopBreak.GetDataByFlowNode(idFlowNode_Finish);
			if(dtNodeMangLoopBreak.Count == 0) isRight = true;
			else {
				if(adNodeMangLoopBreak.Connection.State != ConnectionState.Open) adNodeMangLoopBreak.Connection.Open();

				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = adNodeMangLoopBreak.Connection;

				foreach(DataRow drNodeMangLoopBreak in dtNodeMangLoopBreak.Rows) {
					string criteria = "";
					ezFlowDS.NodeMangLoopBreakRow rowNodeMangLoopBreak = (ezFlowDS.NodeMangLoopBreakRow)drNodeMangLoopBreak;
					sqlCommand.CommandText = "Select * From " + rowNodeMangLoopBreak.tableName +
						" Where idProcess = " + idProcess.ToString();

					criteria = CFlow.GetCriteriaString(rowNodeMangLoopBreak.fdName1,
										rowNodeMangLoopBreak.fdType1, rowNodeMangLoopBreak.criteria1,
										rowNodeMangLoopBreak.minValue1, rowNodeMangLoopBreak.maxValue1);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = CFlow.GetCriteriaString(rowNodeMangLoopBreak.fdName2,
										rowNodeMangLoopBreak.fdType2, rowNodeMangLoopBreak.criteria2,
										rowNodeMangLoopBreak.minValue2, rowNodeMangLoopBreak.maxValue2);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = CFlow.GetCriteriaString(rowNodeMangLoopBreak.fdName3,
										rowNodeMangLoopBreak.fdType3, rowNodeMangLoopBreak.criteria3,
										rowNodeMangLoopBreak.minValue3, rowNodeMangLoopBreak.maxValue3);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = CFlow.GetCriteriaString(rowNodeMangLoopBreak.fdName4,
										rowNodeMangLoopBreak.fdType4, rowNodeMangLoopBreak.criteria4,
										rowNodeMangLoopBreak.minValue4, rowNodeMangLoopBreak.maxValue4);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = CFlow.GetCriteriaString(rowNodeMangLoopBreak.fdName5,
										rowNodeMangLoopBreak.fdType5, rowNodeMangLoopBreak.criteria5,
										rowNodeMangLoopBreak.minValue5, rowNodeMangLoopBreak.maxValue5);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					criteria = CFlow.GetCriteriaString(rowNodeMangLoopBreak.fdName6,
										rowNodeMangLoopBreak.fdType6, rowNodeMangLoopBreak.criteria6,
										rowNodeMangLoopBreak.minValue6, rowNodeMangLoopBreak.maxValue6);
					if(criteria.Length > 0) sqlCommand.CommandText += criteria;

					try {
						SqlDataReader rdCriteria = sqlCommand.ExecuteReader();
						if(rdCriteria.HasRows) isRight = true;
						rdCriteria.Close();
						if(isRight) break;
					}
					catch(Exception ex) {
						CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
							ErrorType.Error, "原因：" + ex.Message);
						isRight = false;
						isOK = false;
					}
				}
				adNodeMangLoopBreak.Connection.Close();
			}

			if(isOK && !isRight) {
				Man_Default = COrg.GetManager(idProcess, idRoleSource);

            repert:
                //若承送的工號與抓到的主管同一人，則繼續抓主管
                if (Man_Default.idEmp == idEmpSource )
                {
                    idRoleSource = Man_Default.idRole;
                    idEmpSource = Man_Default.idEmp;
                    Man_Default = COrg.GetManager(idProcess, Man_Default.idRole);
                    goto repert;
                }

				if(Man_Default == null) {
					ezOrgDS.RoleDataTable dtRole = adRole.GetDataById(idRoleSource);
					if(dtRole[0].idParent.Trim().Length > 0) {
						CProcess.WriteProcessException(idProcess, idProcessNode_Source, idProcessCheck_Source,
							ErrorType.Error, "原因：找不到主管");
						isOK = false;
					}
					else { //可能到部門頂端了						
						lstNode_NewNext = CFlow.GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNode_Finish);
						isOK = CFlow.GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source,
							idFlowTree, idFlowNode_Finish, idRoleSource, idEmpSource, lstNode_NewNext);
					}
				}
				else {
					//是否需要找代理人
					ezOrgDS.EmpDataTable dtEmp_Default = adEmp.GetDataById(Man_Default.idEmp);
					if(dtEmp_Default[0].isNeedAgent) Man_Agent = COrg.GetAgent(idProcess, Man_Default.idRole, Man_Default.idEmp);
					CProcess.WriteProcessNodeAndCheck(idProcessNode_Source, idProcess, idFlowNode_Finish, Man_Default, Man_Agent);
				}
			}
			else {
				lstNode_NewNext = CFlow.GetLinkNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source, idFlowTree, idFlowNode_Finish);
				isOK = CFlow.GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source,
					idFlowTree, idFlowNode_Finish, idRoleSource, idEmpSource, lstNode_NewNext);
			}
		}
		else {
			lstNode_NewNext = CFlow.GetLinkNextNode(idProcess,idProcessNode_Source,idProcessCheck_Source, 
				idFlowTree, idFlowNode_Finish);
			isOK = CFlow.GoToNextNode(idProcess, idProcessNode_Source, idProcessCheck_Source,
				idFlowTree, idFlowNode_Finish, idRoleSource, idEmpSource, lstNode_NewNext);
		}

		if(isOK) {
			dtProcessNode_Finish[0].isFinish = true;
			adProcessNode.Update(dtProcessNode_Finish);

			dtProcessCheck_Finish[0].Role_idReal = apParm.Role_id;
			dtProcessCheck_Finish[0].Emp_idReal = apParm.Emp_id;
			dtProcessCheck_Finish[0].adate = DateTime.Now;
			adProcessCheck.Update(dtProcessCheck_Finish);
		}

		return isOK;
	}

	[WebMethod]
	public void AddMultiFlow(int idProcess, string idSubFlowTree, string idSubInitRole, string idSubInitEmp, string idSubDynamicRole, string idSubDynamicEmp) {		
		ezProcessDS.ProcessMultiFlowDataTable dtProcessMultiFlow = new ezProcessDS.ProcessMultiFlowDataTable();
		ezProcessDS.ProcessMultiFlowRow rowProcessMultiFlow = dtProcessMultiFlow.NewProcessMultiFlowRow();
		rowProcessMultiFlow.ProcessFlow_id = idProcess;
		rowProcessMultiFlow.ProcessNode_auto = 0;
		rowProcessMultiFlow.SubFlowTree_id = idSubFlowTree;
		rowProcessMultiFlow.SubInitRole_id = idSubInitRole;
		rowProcessMultiFlow.SubInitEmp_id = idSubInitEmp;
		rowProcessMultiFlow.SubDynamicRole_id = idSubDynamicRole;
		rowProcessMultiFlow.SubDynamicEmp_id = idSubDynamicEmp;
		dtProcessMultiFlow.AddProcessMultiFlowRow(rowProcessMultiFlow);

		adProcessMultiFlow.Update(dtProcessMultiFlow);
	}

	[WebMethod]
	public int GetMainProcess(int idSubProcess) {
		int idProcess = 0;
		ezProcessDS.ProcessMultiFlowDataTable dtProcessMultiFlow = new ezProcessDSTableAdapters.ProcessMultiFlowTableAdapter().GetDataBySubProcess(idSubProcess);
		if (dtProcessMultiFlow.Count > 0) idProcess = dtProcessMultiFlow[0].ProcessFlow_id;

		return idProcess;
	}
}
