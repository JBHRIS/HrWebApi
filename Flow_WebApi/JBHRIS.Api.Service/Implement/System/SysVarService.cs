using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface.System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Implement.System
{
    public class SysVarService : ISysVarInterface
    {

        private ISystem_SysVar_View _ISystem_SysVar_View;

        public SysVarService(ISystem_SysVar_View  system_SysVar_View)
        {
            this._ISystem_SysVar_View = system_SysVar_View;
        }
        public List<SysVarDto> GetSysVarList()
        {
            return this._ISystem_SysVar_View.GetSysVarList();
        }
    }
}
