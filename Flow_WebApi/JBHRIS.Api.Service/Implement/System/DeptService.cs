using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Service.Implement.System
{
    public class DeptService : IDeptInterface
    {
        private ISystem_Dept_View _system_Dept_View;
        public DeptService(ISystem_Dept_View system_Dept_View)
        {
            _system_Dept_View = system_Dept_View;
        }

        public List<DeptDto> GetDeptList()
        {
            return _system_Dept_View.GetDeptList();
        }

        public List<DeptDto> GetDeptListAllByDeptId(List<string> DeptId)
        {
            var Data = _system_Dept_View.GetDeptList();
            var result = new List<DeptDto>();

            foreach (var d in Data)
            {
                var DeptPath = d.Path.Split("/");
                foreach (var oDept in DeptPath)
                {
                    if (DeptId.Contains(oDept))
                        result.Add(d);
                }
            }
            return result.Distinct().ToList();
        }

        public List<string> GetDeptListAllByEmpId(List<string> EmpId)
        {
            var Data = _system_Dept_View.GetDeptList();
            var DeptList = _system_Dept_View.GetDeptListByEmpId(EmpId);
            var result = new List<string>();

            foreach (var d in Data)
            {
                var DeptPath = d.Path.Split("/");
                foreach (var oDept in DeptPath)
                {
                    if (DeptList.Contains(oDept))
                        result.Add(d.DeptID);
                }
            }
            return result.Distinct().ToList();
        }

        public List<string> GetDeptListByEmpId(List<string> EmpId)
        {
            return _system_Dept_View.GetDeptListByEmpId(EmpId);
        }

        public List<DeptDto> GetDeptListById(List<string> Id)
        {
            return _system_Dept_View.GetDeptListById(Id);
        }
    }
}
