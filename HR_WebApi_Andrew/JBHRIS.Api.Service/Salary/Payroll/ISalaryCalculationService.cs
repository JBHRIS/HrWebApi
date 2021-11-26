using JBHRIS.Api.Dto.Salary.Payroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Salary.Payroll
{
    public interface ISalaryCalculationService
    {
        SalaryCalculationResult Calculate(SalaryCalculationEntry salaryCalculationEntry);
    }
}
