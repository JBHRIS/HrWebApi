using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_Dept_View
    {
        List<DeptDto> GetDeptList();
        List<DeptDto> GetDeptListById(List<string> id);
        List<string> GetDeptListByEmpId(List<string> EmpId);
    }
}
