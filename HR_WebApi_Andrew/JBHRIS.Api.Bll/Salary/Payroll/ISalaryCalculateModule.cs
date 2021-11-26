using JBHRIS.Api.Dto.Salary.Payroll;

namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public interface ISalaryCalculateModule
    {
        SalaryCalculationResult Calculate(SalaryCalculationEntry salaryCalculationEntry);
    }
}