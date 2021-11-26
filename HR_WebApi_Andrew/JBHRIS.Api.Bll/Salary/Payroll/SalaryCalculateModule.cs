using JBHRIS.Api.Dto.Salary.Payroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public class SalaryCalculateModule : ISalaryCalculateModule
    {
        public SalaryCalculationResult Calculate(SalaryCalculationEntry salaryCalculationEntry)
        {
            return new SalaryCalculationResult { State = true, Message = "測試薪資模組" };
        }
    }
}
