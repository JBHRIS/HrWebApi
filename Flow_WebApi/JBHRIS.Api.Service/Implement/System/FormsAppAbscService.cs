using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppAbscService : IFormsAppAbscInterface
    {
        private ISystem_FormsAppAbsc_View _system_FormsAppAbsc_View;

        public FormsAppAbscService(ISystem_FormsAppAbsc_View system_FormsAppAbsc_View)
        {
            this._system_FormsAppAbsc_View = system_FormsAppAbsc_View;
        }

        public AbsFlowAppRow GetFormsAppAbsByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._system_FormsAppAbsc_View.GetFormsAppAbsByProcessId(ProcessFlowID, Sign, SignState, Status);
        }
    }
}
