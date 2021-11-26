using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetDept : IEmployee_View_GetDept
    {
        private JBHRContext _context;
        public Employee_View_GetDept(JBHRContext context)
        {
            _context = context;
        }
        public List<DeptDto> GetDeptView()
        {
            //throw new NotImplementedException();
            var data = _context.Dept.Select(p => new DeptDto
            {
                DepartmentId = p.DNo,
                DepartmentName = p.DName,
                DepartmentNameE = p.DEname,
                DepartmentIdDisplay = p.DNoDisp
               
            }).ToList();
            return data;
        }
    }
}
