using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Payroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public class SalaryCalculateModule : ISalaryCalculateModule
    {
        public ApiResult<string> Calculate(SalaryCalculationEntry salaryCalculationEntry)
        {
            return new ApiResult<string> { State = true, Result = "測試薪資模組" };
        }

        public string Base64Encode(string AStr)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(AStr));
        }

        public string Base64Decode(string ABase64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(ABase64));
        }
    }
}
