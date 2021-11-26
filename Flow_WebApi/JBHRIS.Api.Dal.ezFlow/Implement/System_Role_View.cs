using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_Role_View : ISystem_Role_View
    {
        private ezFlowContext _context;
        public System_Role_View(ezFlowContext context)
        {
            this._context = context;
        }

        public List<string> GetEmpIdByDeptId(List<string> DeptId)
        {
            List<string> result = new List<string>();
            result = (from d in _context.Roles
                      where DeptId.Contains(d.Dept_id)
                      select d.Emp_id).Distinct().ToList();
            return result;
        }

        public List<RoleDto> GetRoleList()
        {
            List<RoleDto> result = new List<RoleDto>();

            result = (from r in _context.Roles
                      select new RoleDto
                      {
                          RoleID = r.id,
                          ParentID = r.idParent,
                          DeptID = r.Dept_id,
                          PostDeptID = r.Pos_id,
                          DateB = r.dateB,
                          DateE = r.dateE,
                          EmpID = r.Emp_id,
                          mgDefault = r.mgDefault ?? false,
                          deptMg = r.deptMg ?? false,
                          Sort = r.sort ?? 0
                      }).ToList();



            return result;
        }

        public List<RoleDto> GetRoleListByEmpId(List<string> EmpId)
        {
            List<RoleDto> result = new List<RoleDto>();

            result = (from r in _context.Roles
                      where EmpId.Contains(r.Emp_id)
                      select new RoleDto
                      {
                          RoleID = r.id,
                          ParentID = r.idParent,
                          DeptID = r.Dept_id,
                          PostDeptID = r.Pos_id,
                          DateB = r.dateB,
                          DateE = r.dateE,
                          EmpID = r.Emp_id,
                          mgDefault = r.mgDefault ?? false,
                          deptMg = r.deptMg ?? false,
                          Sort = r.sort ?? 0
                      }).ToList();

            return result;
        }
        public List<RoleRow> GetRoleData(string idEmp = "", string idRole = "")
        {
            List<RoleRow> Vdb = new List<RoleRow>();
            idEmp = idEmp == null ? "" : idEmp;
            idRole = idRole == null ? "" : idRole;


            Vdb = (from role in _context.Roles
                   join emp in _context.Emps on role.Emp_id equals emp.id
                   join dept in _context.Depts on role.Dept_id equals dept.id
                   join pos in _context.Pos on role.Pos_id equals pos.id
                   where (role.Emp_id == idEmp || idEmp.Length == 0)
                   && (role.id == idRole || idRole.Length == 0)
                   //&& role.sort.GetValueOrDefault(1) == 1
                   orderby role.sort.Value
                   select new RoleRow
                   {
                       RoleId = role.id,
                       RoleName = dept.name + "-" + pos.name,
                       EmpId = emp.id,
                       EmpName = emp.name,
                       DeptId = dept.id,
                       DeptName = dept.name,
                       PosId = pos.id,
                       PosName = pos.name,
                       Manage = role.deptMg.Value,
                   }).ToList();



            return Vdb;
        }
    }
}
