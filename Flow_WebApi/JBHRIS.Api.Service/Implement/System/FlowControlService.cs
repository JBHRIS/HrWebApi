using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FlowControlService : IFlowControlInterface
    {
        private ISystem_FlowControl_View _system_FlowControl_View;
        public FlowControlService(ISystem_FlowControl_View system_FlowControl_View)
        {
            this._system_FlowControl_View = system_FlowControl_View;
        }

        public List<FlowControlCodeDto> GetFlowControlCodeList()
        {
            return _system_FlowControl_View.GetFlowControlCodeList();
        }

        public List<FlowControlDto> GetFlowControlListByCode(FlowControlCondition Cond)
        {
            
            
            return _system_FlowControl_View.GetFlowControlByCode(Cond.Form, Cond.Code);
        }
    }
}
