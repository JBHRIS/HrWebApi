using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_SysVar_View
    {
        List<SysVarDto> GetSysVarList();
    }
}
