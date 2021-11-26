using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JBHRIS.Api.Dal.Employee.View
{
    public interface IEmployee_View_GetEmployee
    {
        List<EmployeeViewDto> GetEmployee();
        List<EmployeeViewDto> GetEmployeeView(List<string> employeeList);
        List<ApiRolesDto> GetApiRoles(List<string> Nobr);
        GetEmployeSalAttEndDayDto GetEmployeSalAttEndDay(string Nobr, DateTime date);
        List<string> GetAllDeptManger();
        List<string> GetPeopleByDeptTree(List<string> employeeList, DateTime checkDate);
        List<string> GetAllDeptaManger();
        List<string> GetPeopleByDeptaTree(List<string> employeeList, DateTime CheckDate);
        decimal GetEmployeeOtMin(string employeeId);
        List<PeopleApDateViewDto> GetPeopleApDate(DateTime BeginDate, DateTime EndDate);
        List<AllPassTypeDto> GetAllPassType();
        List<EffemployViewDto> GetEffemployView(EffemployEntryDto effemployEntryDto);
    }
}