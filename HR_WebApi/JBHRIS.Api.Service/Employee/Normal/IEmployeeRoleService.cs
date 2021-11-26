using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public interface IEmployeeRoleService
    {
        List<EmployeeRoleDto> GetEmployeeRolesCache(ClaimsPrincipal user);
        List<string> GetAllowEmloyeeList(ClaimsPrincipal user);
        List<string> GetAllowEmloyeeDeptTreeList(ClaimsPrincipal user);
        List<string> GetAllowEmloyeeDeptaTreeList(ClaimsPrincipal user);
        List<string> GetAllowEmloyeeDeptExtraTreeList(ClaimsPrincipal user);
    }
}
