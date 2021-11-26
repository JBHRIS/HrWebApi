using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace JBHRIS.Api.Service.Implement.ezEngineServices
{
    public class CFlowManageImplement : ICFlowManageInterface
    {
        private ICFlowManage_Dal _ICFlowManage_Dal;
        public CFlowManageImplement(ICFlowManage_Dal cFlowManage_Dal)
        {
            this._ICFlowManage_Dal = cFlowManage_Dal;
        }

        public List<int> FlowResubmit(List<int> lsProcessID, string idEmp_Agent, bool bPreviousStep = false)
        {
            return this._ICFlowManage_Dal.FlowResubmit(lsProcessID, idEmp_Agent, bPreviousStep);
        }

        public void FlowSign(List<int> lsProcessID, string idEmp)
        {
            this._ICFlowManage_Dal.FlowSign(lsProcessID, idEmp);
            //return this._ICFlowManage_Dal.FlowSign(lsProcessID, idEmp);
        }

        public List<int> FlowSignSet(List<int> lsProcessID, CMan Man_Default = null, CMan Man_Agent = null)
        {
            return this._ICFlowManage_Dal.FlowSignSet(lsProcessID, Man_Default, Man_Agent);
        }

        public List<int> FlowSignWorkFinish(List<int> lsProcessID, string idEmp, string sNote, bool bSign = true, bool EmpSameUp = true)
        {
            return this._ICFlowManage_Dal.FlowSignWorkFinish(lsProcessID, idEmp, sNote, bSign, EmpSameUp);
        }
        
        public bool DeleteProcessFlow(int ProcessFlowId)
        {
            return this._ICFlowManage_Dal.DeleteProcessFlow(ProcessFlowId);
        }
        public List<int> FlowStateSet(List<int> lsProcessID, FlowState State, string idEmp)
        {
            return this._ICFlowManage_Dal.FlowStateSet(lsProcessID, State, idEmp);
        }
    }
}
