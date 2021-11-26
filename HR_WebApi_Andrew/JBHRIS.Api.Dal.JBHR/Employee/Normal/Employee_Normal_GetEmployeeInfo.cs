using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dto.Employee.Normal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_Normal_GetEmployeeInfo : IEmployee_Normal_GetEmployeeInfo
    {
        private JBHRContext _context;

        public Employee_Normal_GetEmployeeInfo(JBHRContext context)
        {
            _context = context;
        }
        public List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList)
        {
            var data = _context.Base.Where(p => employeeList.Contains(p.Nobr)).Select(p => new EmployeeInfoDto
            {
                Address1 = p.Addr1,
                Address2 = p.Addr2,
                Birthday = p.Birdt.Value,
                EmployeeId = p.Nobr,
                IdNo = p.Idno,
                PassportId = "",
                ResidentCertificateId = p.Matno,
                Sex = p.Sex,
                TelphoneNo = p.Tel1
            }).ToList();
            return data;
        }
    }
}
