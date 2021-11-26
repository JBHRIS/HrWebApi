using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface.Employee
{
    public interface IEmployeeViewService
    {
        List<EmployeeJobViewDto> GetEmployeeJobView(List<string> employeeList);
        
    }
}
