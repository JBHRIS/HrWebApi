using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppAbnService : IFormsAppAbnInterface
    {
        private ISystem_FormsAppAbn_View _ISystem_FormsAppAbn_View;
        public FormsAppAbnService(ISystem_FormsAppAbn_View system_FormsAppAbn_View)
        {
            this._ISystem_FormsAppAbn_View = system_FormsAppAbn_View;
        }

        public List<AbnVdb> GetFormsAppAbnByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsAppAbn_View.GetFormsAppAbnByProcessId(ProcessFlowID,  Sign,  SignState,  Status);
        }
    }
}
