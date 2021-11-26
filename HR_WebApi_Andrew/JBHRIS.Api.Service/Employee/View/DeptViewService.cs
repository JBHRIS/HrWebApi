using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Service.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public class DeptViewService : IDeptViewService
    {
        private IEmployee_View_GetDept _employee_View_GetDept;
        private IEmployee_View_GetDepta _employee_View_GetDepta;
        private IEmployee_View_GetDepts _employee_View_GetDepts;

        public DeptViewService(IEmployee_View_GetDept employee_Normal_GetDept
            , IEmployee_View_GetDepta employee_Normal_GetDepta
            , IEmployee_View_GetDepts employee_Normal_GetDepts)
        {
            _employee_View_GetDept = employee_Normal_GetDept;
            _employee_View_GetDepta = employee_Normal_GetDepta;
            _employee_View_GetDepts = employee_Normal_GetDepts;
        }

        public List<DeptDto> GetDeptaView()
        {
            return _employee_View_GetDepta.GetDeptView();
        }

        public List<DeptDto> GetDeptsView()
        {
            return _employee_View_GetDepts.GetDeptView();
        }

        public List<DeptDto> GetDeptView()
        {
            return _employee_View_GetDept.GetDeptView();
        }
    }
}