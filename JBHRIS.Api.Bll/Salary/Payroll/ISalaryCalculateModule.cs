using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Payroll;

namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public interface ISalaryCalculateModule
    {
        ApiResult<string> Calculate(SalaryCalculationEntry salaryCalculationEntry);
        string Base64Encode(string AStr);
        string Base64Decode(string ABase64);
    }
}