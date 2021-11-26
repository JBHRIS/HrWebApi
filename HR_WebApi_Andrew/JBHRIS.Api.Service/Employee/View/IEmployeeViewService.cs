using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.View
{
    public interface IEmployeeViewService
    {
        List<EmployeeBirthdayViewDto> GetEmployeeBirthdayView(int Month, int Day);
        List<EmployeeViewDto> GetEmployeeView(List<string> employeeList);
    }
}
