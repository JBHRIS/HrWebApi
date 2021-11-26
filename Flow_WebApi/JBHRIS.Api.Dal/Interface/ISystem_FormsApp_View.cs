using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_FormsApp_View
    {
        List<FormsAppDto> GetFormsAppList();
        List<FormsAppDto> GetFormsAppListById(List<int> ID);

    }
}
