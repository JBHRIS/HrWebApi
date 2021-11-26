using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_FormsAppInfo_View
    {
        List<FormsAppInfoDto> GetFormsAppInfoList();
        List<FormsAppInfoDto> GetFormsAppInfoListByProcessId(List<string> ProcessId);

    }
}
