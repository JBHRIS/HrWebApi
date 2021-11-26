using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.ezEngineServices
{
    public class CDateImplement : ICDataInterface
    {
        private ICData_Dal _ICData_Dal;
        public CDateImplement(ICData_Dal cData_Dal)
        {
            this._ICData_Dal = cData_Dal;
        }

        public List<CheckAgentDataRow> GetCheckAgentData(string EmpId)
        {
            return this._ICData_Dal.GetCheckAgentData(EmpId);
        }

        public List<CheckAgentFlowTreeDataRow> GetCheckAgentFlowTreeData(string CheckAgent_Guid)
        {
            return this._ICData_Dal.GetCheckAgentFlowTreeData(CheckAgent_Guid);
        }

        public List<EmpAgentDateDataRow> GetEmpAgentDateData(string EmpId)
        {
            return this._ICData_Dal.GetEmpAgentDateData(EmpId);
        }

        public List<FlowNodeApNameRow> GetFlowNodeAppName(List<string> lsFlowNodeId)
        {
            return this._ICData_Dal.GetFlowNodeAppName(lsFlowNodeId);
        }

        public string GetFlowParmUrl(int iApParmID, bool bOnlyUrl = false)
        {
            return this._ICData_Dal.GetFlowParmUrl(iApParmID, bOnlyUrl );
        }

        public List<FlowSearchCompleteRow> GetFlowSearchComplete(string sNobr, DateTime dAppB, DateTime dAppE)
        {
            return this._ICData_Dal.GetFlowSearchComplete(sNobr, dAppB, dAppE);
        }

        public List<FlowSearchIngRow> GetFlowSearchIng(string sNobr)
        {
            return this._ICData_Dal.GetFlowSearchIng(sNobr);
        }

        public List<FlowSignRow> GetFlowSign(string sNobr, string sAppNobr)
        {
            return this._ICData_Dal.GetFlowSign( sNobr,  sAppNobr);
        }

        public List<FlowTreeDataRow> GetFlowTreeData(string sNobr, string sDeptm)
        {
            return this._ICData_Dal.GetFlowTreeData(sNobr, sDeptm);
        }

        public List<FlowTreePathRow> GetFlowTreePath(List<string> lsFlowTreeId )
        {
            return this._ICData_Dal.GetFlowTreePath(lsFlowTreeId);
        }

        public List<FlowViewRow> GetFlowView(bool bManage = false, string sNobr = "", DateTime? dDateSignB = null, DateTime? dDateSignE = null, DateTime? dDateAppB = null, DateTime? dDateAppE = null, string sState = "1", string sFormCode = "0", int iProcessID = 0, string sApp = "1")
        {
            return this._ICData_Dal.GetFlowView(bManage ,  sNobr , dDateSignB , dDateSignE , dDateAppB , dDateAppE ,sState , sFormCode ,iProcessID , sApp );
        }

        public string GetFlowViewUrl(int idProcess, bool bOnlyUrl = false)
        {
            return this._ICData_Dal.GetFlowViewUrl(idProcess, bOnlyUrl );
        }

        public List<ProcessDataRow> GetProcessData(List<int> lsProcessID)
        {
            return this._ICData_Dal.GetProcessData(lsProcessID);
        }
    }
}
