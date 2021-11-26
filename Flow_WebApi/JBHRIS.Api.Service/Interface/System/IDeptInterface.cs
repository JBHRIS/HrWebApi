using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IDeptInterface
    {

        List<DeptDto> GetDeptList();
        List<DeptDto> GetDeptListById(List<string> Id);
        List<DeptDto> GetDeptListAllByDeptId(List<string> DeptId);
        List<string> GetDeptListAllByEmpId(List<string> EmpId);
        List<string> GetDeptListByEmpId(List<string> EmpId);

    }
}
