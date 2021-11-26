using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IFormsAppInterface
    {
        List<FormsAppDto> GetFormsAppList();
        List<FormsAppDto> GetFormsAppListById(List<int> Id);
    }
}
