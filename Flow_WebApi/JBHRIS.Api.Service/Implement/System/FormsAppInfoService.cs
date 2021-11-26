using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppInfoService : IFormsAppInfoInterface
    {
        private ISystem_FormsAppInfo_View _system_FormsAppInfo_View;
        public FormsAppInfoService(ISystem_FormsAppInfo_View system_FormsAppInfo_View)
        {
            this._system_FormsAppInfo_View = system_FormsAppInfo_View;
        }

        public List<FormsAppInfoDto> GetFormsAppInfoList()
        {
            return _system_FormsAppInfo_View.GetFormsAppInfoList();
        }

        public List<FormsAppInfoDto> GetFormsAppInfoListByProcessId(List<string> ProcessId)
        {
            return _system_FormsAppInfo_View.GetFormsAppInfoListByProcessId(ProcessId);
        }

        
    }
}
