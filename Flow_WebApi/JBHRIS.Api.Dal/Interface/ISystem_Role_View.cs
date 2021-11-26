using JBHRIS.Api.Dto.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_Role_View
    {
        List<RoleDto> GetRoleList();
        List<string> GetEmpIdByDeptId(List<string> DeptId);
        List<RoleDto> GetRoleListByEmpId(List<string> EmpId);
        List<RoleRow> GetRoleData(string idEmp, string idRole);
    }
}
