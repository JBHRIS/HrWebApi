
using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public class SysRoleViewService : ISysRoleViewService
    {
        private ISystem_View_SysRole _system_View_SysRole;
        private IEmployee_View_GetEmployee _employee_View_GetEmployee;
        private ISystem_View_SysUserRole _system_View_SysUserRole;

        public SysRoleViewService(ISystem_View_SysRole system_View_SysRole,
            IEmployee_View_GetEmployee employee_View_GetEmployee,
            ISystem_View_SysUserRole system_View_SysUserRole
            )
        {
            _system_View_SysRole = system_View_SysRole;
            _employee_View_GetEmployee = employee_View_GetEmployee;
            _system_View_SysUserRole = system_View_SysUserRole;
        }

        public ApiResult<List<SysRoleDto>> DeleteRoleView(string Code)
        {
            _employee_View_GetEmployee.GetEmployee().ForEach(e => {
                SysUserRoleEntry sysUserRoleEntry = new SysUserRoleEntry()
                {
                    Nobr = e.EmployeeId,
                    RoleCode = Code
                };
                _system_View_SysUserRole.DeleteUserRoleView(sysUserRoleEntry);
            });
            return _system_View_SysRole.DeleteRoleView(Code);
        }

        public List<SysRoleDto> GetRoleView()
        {
            return _system_View_SysRole.GetRoleView();
        }

        public ApiResult<List<SysRoleDto>> InsertRoleView(SysRoleDto sysRoleDto)
        {
            return _system_View_SysRole.InsertRoleView(sysRoleDto);
        }

        public ApiResult<List<SysRoleDto>> UpdateRoleView(SysRoleDto sysRoleDto)
        {
            return _system_View_SysRole.UpdateRoleView(sysRoleDto);
        }
    }
}
