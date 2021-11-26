using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppEmployService : IFormsAppEmployInterface
    {
        private ISystem_FormsAppEmploy_View _ISystem_FormsAppEmploy_View;
        public FormsAppEmployService(ISystem_FormsAppEmploy_View system_FormsAppEmploy_View)
        {
            this._ISystem_FormsAppEmploy_View = system_FormsAppEmploy_View;
        }

        public List<EmployVdb> GetFormsAppEmployByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsAppEmploy_View.GetFormsAppEmployByProcessId(ProcessFlowID,  Sign,  SignState,  Status);
        }
    }
}
