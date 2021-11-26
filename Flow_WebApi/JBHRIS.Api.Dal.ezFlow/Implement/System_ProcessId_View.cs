using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_ProcessId_View : ISystem_ProcessId_View
    {
        private ezFlowContext _context;
        public System_ProcessId_View(ezFlowContext context)
        {
            this._context = context;
        }

        public ProcessIdDto GetProcessId()
        {
            var Max = _context.ProcessIDs.Max(p => p.value);
            var ProcessId = _context.ProcessIDs.FirstOrDefault(p => p.value == Max);
            ProcessIdDto result = new ProcessIdDto()
            {
                value = ProcessId.value,
                key = ProcessId.key,
                genDatetime = ProcessId.genDatetime
            };
            
            return result;

        }
    }
}
