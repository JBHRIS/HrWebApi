using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public enum ErrorType { Error,Cancel,Warning };
public enum AgentType { None, Always, Default, Other };

public class CMan {
	public string idRole = "";
	public string idEmp = "";
	public AgentType agentType = AgentType.None;
}

public class COrg
{
    static ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
    static ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
    static ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
    static ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
    static ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();
    static ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrgDSTableAdapters.DeptTableAdapter();
    static ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();

    static ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
    static ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
    static ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
    static ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();

    static ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlowDSTableAdapters.NodeCustomTableAdapter();
    static ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlowDSTableAdapters.NodeDynamicTableAdapter();
    static ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();

	//取得代理人
    public static CMan GetAgent(int idProcess, string Role_idSource, string Emp_idSource)
    {
        ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
        ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
        ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();
        ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrgDSTableAdapters.DeptTableAdapter();
        ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();

        ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
        ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
        ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
        ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();

        ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlowDSTableAdapters.NodeCustomTableAdapter();
        ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlowDSTableAdapters.NodeDynamicTableAdapter();
        ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();

        //如果傳進來的是子流程，則找出主流程序
        ezProcessDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(idProcess);
        string FlowTree_id = dtProcessFlow[0].FlowTree_id;

        //資料宣告
        CMan Man = null;
        //先檢查有沒有設定常態性代理人
        bool isAlwaysAgent = false;
        ezOrgDS.CheckAgentAlwaysDataTable dtCheckAgentAlways;
        //如果有工號，則精準抓出代理人，如果沒有工號，則抓此角色的代理人
        if (Emp_idSource.Trim().Length > 0)
            dtCheckAgentAlways = adCheckAgentAlways.GetDataByIdSource(Role_idSource, Emp_idSource);
        else
            dtCheckAgentAlways = adCheckAgentAlways.GetDataByIdRoleSource(Role_idSource);

        if (dtCheckAgentAlways.Count > 0)
        {
            foreach (DataRow drCheckAgentAlways in dtCheckAgentAlways.Rows)
            {
                ezOrgDS.CheckAgentAlwaysRow rowCheckAgentAlways = (ezOrgDS.CheckAgentAlwaysRow)drCheckAgentAlways;

                //所指定的代理人是否正確的存在角色檔中，如果不存在，則刪除此代理人
                ezOrgDS.RoleDataTable dtRole_Target = adRole.GetDataByIdAndEmp(rowCheckAgentAlways.Role_idTarget, rowCheckAgentAlways.Emp_idTarget);
                if (dtRole_Target.Count == 0)
                {
                    rowCheckAgentAlways.Delete();
                    continue;
                }

                //檢查常態性代理人是否請假了
                ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(rowCheckAgentAlways.Emp_idTarget);
                if (dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE) continue;

                //檢查常態性代理人，是否有可簽部門限制
                ezOrgDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = adCheckAgentPowerM.GetDataByCheckAgentAlways(rowCheckAgentAlways.auto);
                foreach (DataRow drCheckAgentPowerM in dtCheckAgentPowerM.Rows)
                {
                    ezOrgDS.CheckAgentPowerMRow rowCheckAgentPowerM = (ezOrgDS.CheckAgentPowerMRow)drCheckAgentPowerM;

                    //先檢查部門是否仍存在於資料庫，不存在的話，就刪除該筆資料
                    ezOrgDS.DeptDataTable dtDept_Criteria = adDept.GetDataById(rowCheckAgentPowerM.Dept_id);
                    if (dtDept_Criteria.Count == 0)
                    {
                        rowCheckAgentPowerM.Delete();
                        continue;
                    }

                    bool isRightDept = false;
                    if (rowCheckAgentPowerM.isAllSub)
                    {
                        ezOrgDS.DeptDataTable dtDept_Target = adDept.GetDataById(dtRole_Target[0].Dept_id);
                        if (dtDept_Target[0].path.IndexOf(dtDept_Criteria[0].path) != -1) isRightDept = true;
                    }
                    else
                    {
                        if (dtRole_Target[0].Dept_id == rowCheckAgentPowerM.Dept_id) isRightDept = true;
                    }

                    if (!isRightDept) continue;

                    //檢查常態性代理人，是否有可簽流程限制
                    if (FlowTree_id.Trim().Length > 0)
                    {
                        ezOrgDS.CheckAgentPowerDDataTable dtCheckAgentPowerD = adCheckAgentPowerD.GetDataByCheckAgentPowerM(rowCheckAgentPowerM.auto);
                        if (dtCheckAgentPowerD.Count > 0)
                        {
                            bool isRightFlow = false;
                            foreach (DataRow drCheckAgentPowerD in dtCheckAgentPowerD.Rows)
                            {
                                ezOrgDS.CheckAgentPowerDRow rowCheckAgentPowerD = (ezOrgDS.CheckAgentPowerDRow)drCheckAgentPowerD;
                                ezFlowDS.FlowTreeDataTable dtFlowTreeCheck = adFlowTree.GetDataById(rowCheckAgentPowerD.FlowTree_id);
                                if (dtFlowTreeCheck.Count == 0)
                                {
                                    drCheckAgentPowerD.Delete();
                                    continue;
                                }
                                if (FlowTree_id == rowCheckAgentPowerD.FlowTree_id)
                                {
                                    isRightFlow = true;
                                    break;
                                }
                            }
                            adCheckAgentPowerD.Update(dtCheckAgentPowerD);
                            if (!isRightFlow) continue;
                        }
                    }
                    isAlwaysAgent = true;
                    break;
                }
                adCheckAgentPowerM.Update(dtCheckAgentPowerM);

                //常態性代理人可以沒有流程的限制，但不可以沒有部門的限制
                if (isAlwaysAgent)
                {
                    Man = new CMan();
                    Man.idRole = rowCheckAgentAlways.Role_idTarget;
                    Man.idEmp = rowCheckAgentAlways.Emp_idTarget;
                    Man.agentType = AgentType.Always;
                }
            }
        }
        adCheckAgentAlways.Update(dtCheckAgentAlways);

        if (isAlwaysAgent) return Man;

        //如果沒有常態性代理人，則找預設代理人
        bool isDefaultAgent = false;

        ezOrgDS.EmpDataTable dtEmp_Source = null;
        ezOrgDS.CheckAgentDefaultDataTable dtCheckAgentDefault = null;

        if (Emp_idSource.Trim().Length > 0)
        {
            dtEmp_Source = adEmp.GetDataById(Emp_idSource);
            dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdSource(Role_idSource, Emp_idSource);
        }
        else
        {
            dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdRoleSource(Role_idSource);
        }

        if (dtCheckAgentDefault.Count > 0 && (Emp_idSource.Trim().Length == 0 || (dtEmp_Source[0].isNeedAgent &&
            DateTime.Now >= dtEmp_Source[0].dateB && DateTime.Now <= dtEmp_Source[0].dateE)))
        {

            ezOrgDS.RoleDataTable dtRole_Target;

            //確認代理人符合組織資料
            dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget1, dtCheckAgentDefault[0].Emp_idTarget1);
            if (dtRole_Target.Count == 0)
            {
                dtCheckAgentDefault[0].Role_idTarget1 = "";
                dtCheckAgentDefault[0].Emp_idTarget1 = "";
            }
            else
            {
                ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget1);
                if (!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE))
                {
                    Man = new CMan();
                    Man.idRole = dtCheckAgentDefault[0].Role_idTarget1;
                    Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget1;
                    Man.agentType = AgentType.Default;
                    isDefaultAgent = true;
                }
            }
            //抓取第二順位代理人
            if (!isDefaultAgent)
            {
                //確認代理人符合組織資料
                dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget2, dtCheckAgentDefault[0].Emp_idTarget2);
                if (dtRole_Target.Count == 0)
                {
                    dtCheckAgentDefault[0].Role_idTarget2 = "";
                    dtCheckAgentDefault[0].Emp_idTarget2 = "";
                }
                else
                {
                    ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget2);
                    if (!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE))
                    {
                        Man = new CMan();
                        Man.idRole = dtCheckAgentDefault[0].Role_idTarget2;
                        Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget2;
                        Man.agentType = AgentType.Default;
                        isDefaultAgent = true;
                    }
                }
            }
            //抓取第三順位代理人
            if (!isDefaultAgent)
            {
                //確認代理人符合組織資料
                dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget3, dtCheckAgentDefault[0].Emp_idTarget3);
                if (dtRole_Target.Count == 0)
                {
                    dtCheckAgentDefault[0].Role_idTarget3 = "";
                    dtCheckAgentDefault[0].Emp_idTarget3 = "";
                }
                else
                {
                    ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget3);
                    if (!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE))
                    {
                        Man = new CMan();
                        Man.idRole = dtCheckAgentDefault[0].Role_idTarget3;
                        Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget3;
                        Man.agentType = AgentType.Default;
                        isDefaultAgent = true;
                    }
                }
            }

            if (dtCheckAgentDefault[0].Role_idTarget1.Trim().Length == 0)
            {
                dtCheckAgentDefault[0].Role_idTarget1 = dtCheckAgentDefault[0].Role_idTarget2;
                dtCheckAgentDefault[0].Emp_idTarget1 = dtCheckAgentDefault[0].Emp_idTarget2;
                dtCheckAgentDefault[0].Role_idTarget2 = "";
                dtCheckAgentDefault[0].Emp_idTarget2 = "";
            }

            if (dtCheckAgentDefault[0].Role_idTarget2.Trim().Length == 0)
            {
                dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
                dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
                dtCheckAgentDefault[0].Role_idTarget3 = "";
                dtCheckAgentDefault[0].Emp_idTarget3 = "";
            }
        }
        adCheckAgentDefault.Update(dtCheckAgentDefault);

        if (isDefaultAgent) return Man;

        bool isAgent = false;
        //如果沒有常態性代理&預設代理，則嘗試尋找同角色
        if (dtEmp_Source[0].isNeedAgent && DateTime.Now >= dtEmp_Source[0].dateB && DateTime.Now <= dtEmp_Source[0].dateE)
        {
            ezOrgDS.RoleDataTable dtRole_Agent = adRole.GetDataBySortEmpID(Role_idSource);
            for (int i = 0; i < dtRole_Agent.Count; i++)
            {
                if (!dtRole_Agent[i].IsEmp_idNull() && dtRole_Agent[i].Emp_id.Trim().Length > 0)
                {
                    if (Emp_idSource.Trim().Length > 0)
                    {
                        if (dtRole_Agent[i].Emp_id == Emp_idSource)
                        {
                            if (i + 1 < dtRole_Agent.Count)
                            {
                                ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtRole_Agent[i + 1].Emp_id);
                                if (!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE))
                                {
                                    Man = new CMan();
                                    Man.idRole = dtRole_Agent[i + 1].id;
                                    Man.idEmp = dtRole_Agent[i + 1].Emp_id;
                                    Man.agentType = AgentType.Other;
                                    isAgent = true;
                                }
                            }

                            if (!isAgent)
                            {
                                for (int j = i - 1; j >= 0; j--)
                                {
                                    ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtRole_Agent[j].Emp_id);
                                    if (!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE))
                                    {
                                        Man = new CMan();
                                        Man.idRole = dtRole_Agent[j].id;
                                        Man.idEmp = dtRole_Agent[j].Emp_id;
                                        Man.agentType = AgentType.Other;
                                        isAgent = true;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                    else
                    {
                        Man = new CMan();
                        Man.idRole = dtRole_Agent[i].id;
                        Man.idEmp = dtRole_Agent[i].Emp_id;
                        Man.agentType = AgentType.Other;
                        isAgent = true;
                        break;
                    }
                }
            }
        }
        if (isAgent) return Man;
        else return null;
    }

	//取得主管
    public static CMan GetManager(int idProcess, string Role_idMinion)
    {
        ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
        ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
        ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();
        ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrgDSTableAdapters.DeptTableAdapter();
        ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();

        ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
        ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
        ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
        ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();

        ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlowDSTableAdapters.NodeCustomTableAdapter();
        ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlowDSTableAdapters.NodeDynamicTableAdapter();
        ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();

        ezOrgDS.RoleDataTable dtRole_Minion = adRole.GetDataById(Role_idMinion);
        CMan Man = null;
        ezOrgDS.RoleDataTable dtRole_Manager = new ezOrgDS.RoleDataTable();
        if (dtRole_Minion.Count > 0)
        {
            if (dtRole_Minion[0].idParent.Trim().Length > 0)
            {
                dtRole_Manager = adRole.GetDataById(dtRole_Minion[0].idParent);
            }
            else
            {
                ezOrgDS.DeptDataTable dtDept_Minion = adDept.GetDataById(dtRole_Minion[0].Dept_id);
                dtRole_Manager = adRole.GetDataByDeptMang(dtDept_Minion[0].idParent);
                if (dtRole_Manager.Count == 0)
                {
                    string _dept = dtDept_Minion[0].idParent;
                    while (dtRole_Manager.Count == 0)
                    {
                        dtDept_Minion = adDept.GetDataById(_dept);
                        if (dtDept_Minion.Count > 0)
                        {
                            dtRole_Manager = adRole.GetDataByDeptMang(dtDept_Minion[0].idParent);
                            _dept = dtDept_Minion[0].idParent;

                        }

                        //20111101 BY MING
                        if (_dept == null || _dept == "") break;
                    }
                }
            }
        }

        bool bAbs = true;

        if (dtRole_Manager.Count > 0)
        {
            ezOrgDS.RoleRow rowRole_Manager = null;
            for (int i = 0; i < dtRole_Manager.Count; i++)
            {
                rowRole_Manager = dtRole_Manager[i];
                //不抓虛擬角色
                if (!dtRole_Manager[i].IsEmp_idNull() && dtRole_Manager[i].Emp_id.Trim().Length > 0)
                {
                    rowRole_Manager = dtRole_Manager[i];
                    ezOrgDS.EmpDataTable dtEmp_Manager = adEmp.GetDataById(dtRole_Manager[i].Emp_id);
                    //以取得沒請假的主管為主

                    //原本的主管 20120117 by ming
                    Man = new CMan();
                    Man.idRole = dtRole_Manager[i].id;
                    Man.idEmp = dtRole_Manager[i].Emp_id;

                    if (!(dtEmp_Manager[0].isNeedAgent && DateTime.Now >= dtEmp_Manager[0].dateB && DateTime.Now <= dtEmp_Manager[0].dateE))
                    {
                        bAbs = false;
                        break;
                    }
                }
            }

            //如果是虛擬角色，則抓取可替代人選
            if (Man == null)
            {
                if (bAbs)
                    Man = GetAgent(idProcess, rowRole_Manager.id, rowRole_Manager.Emp_id);

                //如果抓不到虛擬角色的代理人，則抓虛擬角色的主管
                //而且這裡形成遞回，所以必定往上抓到主管為止
                if (Man == null)
                    Man = GetManager(idProcess, rowRole_Manager.id);
            }
        }

        return Man;
    }

	//取得流程起始者
	public static CMan GetFlowInit(int idProcess) {
		ezProcessDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(idProcess);
		CMan Man = new CMan();
		Man.idRole = dtProcessFlow[0].Role_id;
		Man.idEmp = dtProcessFlow[0].Emp_id;
		return Man;
	}

	//會簽起始者
	public static CMan GetMultiInit(int idProcess, string idFlowNode_MultiStart) {
		ezProcessDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByIdProcessAndIdFlowNode(idProcess, idFlowNode_MultiStart);
		ezProcessDS.ProcessCheckDataTable dtProcessCheck = adProcessCheck.GetDataByProcessNode(dtProcessNode[0].auto);
		CMan Man = new CMan();
		Man.idRole = dtProcessCheck[0].Role_idReal;
		Man.idEmp = dtProcessCheck[0].Emp_idReal;
		return Man;
	}

	//自訂簽核者
	public static CMan GetCustom(string idFlowNode_Custom) {
		ezFlowDS.NodeCustomDataTable dtNodeCustom = adNodeCustom.GetDataByFlowNode(idFlowNode_Custom);
		CMan Man = null;
		if(dtNodeCustom[0].Role_id.Trim().Length > 0 && dtNodeCustom[0].Emp_id.Trim().Length > 0) {
			Man = new CMan();
			Man.idRole = dtNodeCustom[0].Role_id;
			Man.idEmp = dtNodeCustom[0].Emp_id;
		}
		return Man;
	}

	//動態簽核者
	public static CMan GetDynamic(int idProcess,string idFlowNode_Dynamic) {
        ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
        ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
        ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();
        ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrgDSTableAdapters.DeptTableAdapter();
        ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();

        ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
        ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
        ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
        ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();

        ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlowDSTableAdapters.NodeCustomTableAdapter();
        ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlowDSTableAdapters.NodeDynamicTableAdapter();
        ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();


		ezFlowDS.NodeDynamicDataTable dtNodeDynamic = adNodeDynamic.GetDataByFlowNode(idFlowNode_Dynamic);
		CMan Man = null;
		if(dtNodeDynamic[0].tableName.Trim().Length > 0 && dtNodeDynamic[0].fdRole.Trim().Length > 0) {
			if(adNodeDynamic.Connection.State != ConnectionState.Open) adNodeDynamic.Connection.Open();

			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.Connection = adNodeDynamic.Connection;
			sqlCommand.CommandText = "Select * From " + dtNodeDynamic[0].tableName +
				" Where idProcess = " + idProcess.ToString() + " and idFlowNode = '" + idFlowNode_Dynamic + "'";
			SqlDataReader drDynamicRole = sqlCommand.ExecuteReader();
			if(drDynamicRole.HasRows && drDynamicRole.Read()) {
				//角色有抓取到值
				if(drDynamicRole[dtNodeDynamic[0].fdRole] != null && 
					drDynamicRole[dtNodeDynamic[0].fdRole].ToString().Trim().Length > 0) {
					//工號有抓取到值
					if(dtNodeDynamic[0].fdEmp.Trim().Length > 0 &&
						drDynamicRole[dtNodeDynamic[0].fdEmp] != null &&
						drDynamicRole[dtNodeDynamic[0].fdEmp].ToString().Length > 0) {
						Man = new CMan();
						Man.idRole = drDynamicRole[dtNodeDynamic[0].fdRole].ToString();
						Man.idEmp = drDynamicRole[dtNodeDynamic[0].fdEmp].ToString();
					}
					else {
						//若沒設定工號，則抓角色預設的人選
						ezOrgDS.RoleDataTable dtRole = adRole.GetDataById(drDynamicRole[dtNodeDynamic[0].fdRole].ToString());
						for(int i = 0; i < dtRole.Count; i++) {							
							if(dtRole[i].Emp_id.Trim().Length == 0) continue;
							ezOrgDS.EmpDataTable dtEmp = adEmp.GetDataById(dtRole[i].Emp_id);
							if(!dtEmp[0].isNeedAgent) {
								Man = new CMan();
								Man.idRole = dtRole[i].id;
								Man.idEmp = dtRole[i].Emp_id;
								break;
							}
						}

						if(Man == null && dtRole.Count > 0) {
							for(int i = 0; i < dtRole.Count; i++) {
								if(dtRole[i].Emp_id.Trim().Length > 0) {
									Man = new CMan();
									Man.idRole = dtRole[i].id;
									Man.idEmp = dtRole[i].Emp_id;
									break;
								}
							}
						}
					}
				}
			}
			adNodeDynamic.Connection.Close();

			if (adNodeDynamic.Connection.State == ConnectionState.Closed) adNodeDynamic.Connection.Open();
			sqlCommand.CommandText = "Delete From " + dtNodeDynamic[0].tableName +
				" Where idProcess = " + idProcess.ToString() + " and idFlowNode = '" + idFlowNode_Dynamic + "'";
			sqlCommand.ExecuteNonQuery();
			adNodeDynamic.Connection.Close();
		}

		return Man;
	}

	//代理起始者
	public static CMan GetAgentInit(int idProcess) {
		ezProcessDS.ProcessFlowShareDataTable dtProcessFlowShare = adProcessFlowShare.GetDataByProcessFlow(idProcess);
		CMan Man = null;
		for(int i = 0; i < dtProcessFlowShare.Count; i++) {
			if(dtProcessFlowShare[i].isStarter) {
				Man = new CMan();
				Man.idRole = dtProcessFlowShare[i].Role_id;
				Man.idEmp = dtProcessFlowShare[i].Emp_id;
				break;
			}
		}

		return Man;
	}

	//只抓預設代理人
	public static CMan GetDefaultAgent(string Role_idSource,string Emp_idSource, string Emp_idRef) {
        ezOrgDSTableAdapters.RoleTableAdapter adRole = new ezOrgDSTableAdapters.RoleTableAdapter();
        ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
        ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezOrgDSTableAdapters.CheckAgentAlwaysTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezOrgDSTableAdapters.CheckAgentPowerMTableAdapter();
        ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezOrgDSTableAdapters.CheckAgentPowerDTableAdapter();
        ezOrgDSTableAdapters.DeptTableAdapter adDept = new ezOrgDSTableAdapters.DeptTableAdapter();
        ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();

        ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
        ezProcessDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezProcessDSTableAdapters.ProcessFlowShareTableAdapter();
        ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
        ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();

        ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlowDSTableAdapters.NodeCustomTableAdapter();
        ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlowDSTableAdapters.NodeDynamicTableAdapter();
        ezFlowDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezFlowDSTableAdapters.FlowTreeTableAdapter();


		ezOrgDS.EmpDataTable dtEmp_Source = null;
		ezOrgDS.CheckAgentDefaultDataTable dtCheckAgentDefault = null;

		CMan Man = null;

		if(Emp_idSource.Trim().Length > 0) {
			dtEmp_Source = adEmp.GetDataById(Emp_idSource);
			dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdSource(Role_idSource, Emp_idSource);
		}
		else {
			dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdRoleSource(Role_idSource);
		}

		if(dtCheckAgentDefault.Count > 0 && (Emp_idSource.Trim().Length == 0 || (dtEmp_Source[0].isNeedAgent &&
			DateTime.Now >= dtEmp_Source[0].dateB && DateTime.Now <= dtEmp_Source[0].dateE))) {

			ezOrgDS.RoleDataTable dtRole_Target;

			//確認代理人符合組織資料
			dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget1, dtCheckAgentDefault[0].Emp_idTarget1);
			if(dtRole_Target.Count == 0) {
				dtCheckAgentDefault[0].Role_idTarget1 = "";
				dtCheckAgentDefault[0].Emp_idTarget1 = "";
			}
			else {
				ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget1);
                //if(!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE))
                {
					Man = new CMan();
					Man.idRole = dtCheckAgentDefault[0].Role_idTarget1;
					Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget1;
					Man.agentType = AgentType.Default;
				}
			}
			//抓取第二順位代理人
			if(Man == null || Man.idEmp == Emp_idRef) {
				//確認代理人符合組織資料
				dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget2, dtCheckAgentDefault[0].Emp_idTarget2);
				if(dtRole_Target.Count == 0) {
					dtCheckAgentDefault[0].Role_idTarget2 = "";
					dtCheckAgentDefault[0].Emp_idTarget2 = "";
				}
				else {
					ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget2);
					if(!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE)) {
						Man = new CMan();
						Man.idRole = dtCheckAgentDefault[0].Role_idTarget2;
						Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget2;
						Man.agentType = AgentType.Default;						
					}
				}
			}
			//抓取第三順位代理人
			if(Man == null || Man.idEmp == Emp_idRef) {
				//確認代理人符合組織資料
				dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget3, dtCheckAgentDefault[0].Emp_idTarget3);
				if(dtRole_Target.Count == 0) {
					dtCheckAgentDefault[0].Role_idTarget3 = "";
					dtCheckAgentDefault[0].Emp_idTarget3 = "";
				}
				else {
					ezOrgDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget3);
					if(!(dtEmp_Target[0].isNeedAgent && DateTime.Now >= dtEmp_Target[0].dateB && DateTime.Now <= dtEmp_Target[0].dateE)) {
						Man = new CMan();
						Man.idRole = dtCheckAgentDefault[0].Role_idTarget3;
						Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget3;
						Man.agentType = AgentType.Default;						
					}
				}
			}

			if(dtCheckAgentDefault[0].Role_idTarget1.Trim().Length == 0) {
				dtCheckAgentDefault[0].Role_idTarget1 = dtCheckAgentDefault[0].Role_idTarget2;
				dtCheckAgentDefault[0].Emp_idTarget1 = dtCheckAgentDefault[0].Emp_idTarget2;
				dtCheckAgentDefault[0].Role_idTarget2 = "";
				dtCheckAgentDefault[0].Emp_idTarget2 = "";
			}

			if(dtCheckAgentDefault[0].Role_idTarget2.Trim().Length == 0) {
				dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
				dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
				dtCheckAgentDefault[0].Role_idTarget3 = "";
				dtCheckAgentDefault[0].Emp_idTarget3 = "";
			}
		}
		adCheckAgentDefault.Update(dtCheckAgentDefault);

		//再一次的確定，抓到的人與參考的人是不同一個人，才是正確的
		if(Man != null) {
			if(Man.idEmp == Emp_idRef) Man = null;
		}

		return Man;
	}
}
