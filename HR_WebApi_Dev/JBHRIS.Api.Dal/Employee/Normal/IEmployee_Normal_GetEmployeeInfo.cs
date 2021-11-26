using JBHRIS.Api.Dto.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Employee
{
    public interface IEmployee_Normal_GetEmployeeInfo
    {
        List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList);
    }
}
