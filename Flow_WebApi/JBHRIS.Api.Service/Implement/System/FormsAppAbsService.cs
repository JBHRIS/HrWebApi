using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppAbsService : IFormsAppAbsInterface
    {
        private ISystem_FormsAppAbs_View _system_FormsAppAbs_View;
        public FormsAppAbsService(ISystem_FormsAppAbs_View system_FormsAppAbs_View)
        {
            this._system_FormsAppAbs_View = system_FormsAppAbs_View;
        }

        public AbsFlowAppRow GetFormsAppAbsByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._system_FormsAppAbs_View.GetFormsAppAbsByProcessId( ProcessFlowID,  Sign,  SignState,  Status);
        }

        public List<FormsAppAbsUseDto> GetFormsAppAbsUseListByProcessId(List<string> ProcessId)
        {
            return _system_FormsAppAbs_View.GetFormsAppAbsUseListByProcessId(ProcessId);
        }
    }
}
