using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_Forms_View
    {
        List<FormsDto> GetFormsList();
        List<FormsDto> GetFormsListByCode(List<string> CodeList);
        int GetProcessID();
    }
}
