using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.ezEngineServices
{
    public class COrgImplement : ICOrgInterface
    {

        private ICOrg_Dal _ICOrg_Dal;

        public COrgImplement(ICOrg_Dal cOrg_Dal)
        {
            this._ICOrg_Dal = cOrg_Dal;
        }

        public CMan GetAgent(int idProcess, string Role_idSource, string Emp_idSource)
        {
            return this._ICOrg_Dal.GetAgent(idProcess, Role_idSource, Emp_idSource);
        }

        public CMan GetAgentInit(int idProcess)
        {
            return this._ICOrg_Dal.GetAgentInit(idProcess);
        }

        public CMan GetCustom(string idFlowNode_Custom)
        {
            return this._ICOrg_Dal.GetCustom(idFlowNode_Custom);
        }

        public CMan GetDynamic(int idProcess, string idFlowNode_Dynamic)
        {
            return this._ICOrg_Dal.GetDynamic(idProcess, idFlowNode_Dynamic);
        }

        public CMan GetFlowInit(int idProcess)
        {
            return this._ICOrg_Dal.GetFlowInit(idProcess);
        }

        public CMan GetManager(int idProcess, string Role_idMinion, bool EmpSameUp )
        {
            return this._ICOrg_Dal.GetManager(idProcess, Role_idMinion, EmpSameUp);
        }

        public CMan GetMultiInit(int idProcess, string idFlowNode_MultiStart)
        {
            return this._ICOrg_Dal.GetMultiInit(idProcess,  idFlowNode_MultiStart);
        }

        public bool IsDeptPathTrue(string OldRole, string NewRole)
        {
            return this._ICOrg_Dal.IsDeptPathTrue( OldRole, NewRole);
        }

        public bool IsManage(string Role, string Nobr)
        {
            return this._ICOrg_Dal.IsManage( Role, Nobr);
        }


    }
}
