using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetDepts : IEmployee_View_GetDepts
    {
        private JBHRContext _context;
        public Employee_View_GetDepts(JBHRContext context)
        {
            _context = context;
        }
        public List<DeptDto> GetDeptView()
        {
            //throw new NotImplementedException();
            var data = _context.Depts.Select(p => new DeptDto
            {
                DepartmentId = p.DNo,
                DepartmentName = p.DName,
                DepartmentIdDisplay = p.DNoDisp
                
            }).ToList();
            return data;
        }

       
    }
}
