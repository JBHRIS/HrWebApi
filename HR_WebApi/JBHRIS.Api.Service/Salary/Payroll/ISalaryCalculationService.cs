using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Payroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Salary.Payroll
{
    public interface ISalaryCalculationService
    {
        ApiResult<string> Calculate(SalaryCalculationEntry salaryCalculationEntry);
    }
}
