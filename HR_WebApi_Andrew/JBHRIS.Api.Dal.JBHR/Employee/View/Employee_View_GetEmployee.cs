using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_View_GetEmployee : IEmployee_View_GetEmployee
    {
        private JBHRContext _context;
        public Employee_View_GetEmployee(JBHRContext context)
        {
            _context = context;
        }
        public List<EmployeeViewDto> GetEmployeeView(List<string> employeeList)
        {
            var data = _context.Base.Where(p => employeeList.Contains(p.Nobr)).Select(p => new EmployeeViewDto
            {
                EmployeeId = p.Nobr,
                EmployeeName = p.NameC,
            }).ToList();
            return data;
        }
    }
}
