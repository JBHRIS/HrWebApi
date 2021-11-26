using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface.System;
using System.Collections.Generic;
using System.Linq;

namespace JBHRIS.Api.Service.Implement.System
{
    public class ProcessIdService : IProcessIdInterface
    {

        private ISystem_ProcessId_View _ISystem_ProcessId_View;

        public ProcessIdService(ISystem_ProcessId_View system_ProcessId_View)
        {
            this._ISystem_ProcessId_View = system_ProcessId_View;
        }

        public int GetProcessId()
        {
            var result = _ISystem_ProcessId_View.GetProcessId();
            return result.value + 1;
        }

    }
}
