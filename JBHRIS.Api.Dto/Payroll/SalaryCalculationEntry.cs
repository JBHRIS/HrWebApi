using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Salary.Payroll
{
    public class SalaryCalculationEntry
    {
        public SalaryCalculationEntry()
        {
            ModuleTypes = new List<string>();
        }
        public List<string> ModuleTypes { get; set; }
    }
}