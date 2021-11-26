using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_Dept_View : ISystem_Dept_View
    {

        private ezFlowContext _context;

        public System_Dept_View(ezFlowContext ezFlowContext) {

            this._context = ezFlowContext;
        }

        public List<DeptDto> GetDeptList()
        {
            List<DeptDto> result = new List<DeptDto>();

            result = (from d in _context.Depts
                      select new DeptDto
                      {
                          DeptID = d.id,
                          DeptName = d.name,
                          Path = d.path,
                          ParentDeptID = d.idParent,
                          DeptLevel_ID = d.DeptLevel_id
                      }).ToList();

            return result;
        }

        public List<string> GetDeptListByEmpId(List<string> EmpId)
        {
            List<string> result = new List<string>();

            result = (from d in _context.Roles
                        where EmpId.Contains(d.Emp_id)
                        select d.Dept_id).Distinct().ToList();

            //result = (from d in _context.Depts
            //          where Dept.Contains(d.id)
            //          select new DeptDto
            //          {
            //              DeptID = d.id,
            //              DeptName = d.name,
            //              Path = d.path,
            //              ParentDeptID = d.idParent,
            //              DeptLevel_ID = d.DeptLevel_id
            //          }).ToList();

            return result;
        }

        public List<DeptDto> GetDeptListById(List<string> id)
        {
            List<DeptDto> result = new List<DeptDto>();

            result = (from d in _context.Depts
                      where id.Contains(d.id)
                      select new DeptDto
                      {
                          DeptID = d.id,
                          DeptName = d.name,
                          Path = d.path,
                          ParentDeptID = d.idParent,
                          DeptLevel_ID = d.DeptLevel_id
                      }).ToList();

            return result;
        }
    }
}
