using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface.System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Implement.System
{
    public class RoleService : IRoleInterface
    {

        private ISystem_Role_View _ISystem_Role_View;

        public RoleService(ISystem_Role_View  system_Role_View)
        {
            this._ISystem_Role_View = system_Role_View;
        }

        public List<string> GetEmpIdByDeptId(List<string> DeptId)
        {
            return _ISystem_Role_View.GetEmpIdByDeptId(DeptId);
        }

        public List<RoleDto> GetRoleList()
        {
            return this._ISystem_Role_View.GetRoleList();
        }

        public List<RoleDto> GetRoleListByEmpId(List<string> EmpId)
        {
            return this._ISystem_Role_View.GetRoleListByEmpId(EmpId);
        }
        public List<RoleRow> GetRoleData(string idEmp, string idRole)
        {
            return this._ISystem_Role_View.GetRoleData(idEmp, idRole);
        }
    }
}
