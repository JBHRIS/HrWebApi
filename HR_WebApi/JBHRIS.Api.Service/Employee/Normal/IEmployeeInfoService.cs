using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public interface IEmployeeInfoService
    {
        List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList);
        bool UpdateEmployeeInfo(UpdateEmployeeInfoViewDto empInfo);
        List<EmployeeInfoViewDto> GetEmployeeInfoView(List<string> employeeList);
        public List<RelcodeDto> GetRelcodeView();
        public List<TtscodeDto> GetTtscode();
        public List<CompDto> GetComp();
        public List<OutcdDto> GetOutReason();
        public List<TtscdDto> GetTtscd();
        public List<EmployeeRuleDto> GetEmployeeRule(EmployeeRuleEntry employeeRuleEntry);
        public List<HunyaEmployeeInfoViewDto> GetHunyaEmployeeInfoView(HunyaEmployeeInfoEntry hunyaEmployeeInfoEntry);
    }
}
