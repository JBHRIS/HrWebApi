namespace JBHRIS.Api.Bll.Salary.Payroll
{
    public interface ISalaryCalculateModuleFactory
    {
        ISalaryCalculateModule Create(string moduleType);
    }
}