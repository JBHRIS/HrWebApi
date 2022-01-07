using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Employee
{
    public interface IEmployee_Normal_GetEmployeeInfo
    {
        List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList);
        List<EmployeeWorkDto> GetEmployeeWork(List<string> employeeList);
        List<EmployeeSchoolDto> GetEmployeeSchool(List<string> employeeList);
        List<EmployeeFamilyDto> GetEmployeeFamily(List<string> employeeList);
        List<WorksInfoDto> GetEmployeeWorksInfo(List<string> employeeList);
        List<TtscodeDto> GetTtscode();
        List<CompDto> GetComp();
        List<OutcdDto> GetOutReason();
        List<TtscdDto> GetTtscd();

        List<EmployeeRuleDto> GetEmployeeRule(EmployeeRuleEntry employeeRuleEntry);
        List<HunyaEmployeeInfoViewDto> GetHunyaEmployeeInfoView(HunyaEmployeeInfoEntry hunyaEmployeeInfoEntry);
        List<BaseExpansionDto> GetBaseExpansion(string Code);
    }
}
