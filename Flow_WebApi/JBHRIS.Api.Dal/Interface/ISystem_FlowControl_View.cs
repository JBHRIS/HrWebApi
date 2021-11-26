using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_FlowControl_View
    {
        List<FlowControlCodeDto> GetFlowControlCodeList();
        List<FlowControlDto> GetFlowControlByCode(List<string> Form,List<string> Code);

    }
}
