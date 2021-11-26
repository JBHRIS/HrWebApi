using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface ISysVarInterface
    {
        List<SysVarDto> GetSysVarList();
    }
}
