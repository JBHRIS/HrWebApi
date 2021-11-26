using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IFormsAppInfoInterface
    {
        List<FormsAppInfoDto> GetFormsAppInfoList();
        List<FormsAppInfoDto> GetFormsAppInfoListByProcessId(List<string> ProcessId);
    }
}
