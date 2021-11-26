using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_Emp_View
    {
        List<EmpDto> GetEmpList();
        List<EmpDto> GetEmpListByEmpId(List<string> EmpIdList);

    }
}
