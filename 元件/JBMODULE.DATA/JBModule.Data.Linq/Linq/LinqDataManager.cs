using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class LinqDataManager
    {
        public HrDBDataContext dataContext { get; set; }
        public LinqDataManager()
        {
            dataContext = new HrDBDataContext();
        }
        public EmployeeAgent CreateEmployeeAgent()
        {
            EmployeeAgent value = new EmployeeAgent(dataContext);
            return value;
        }
        public SalaryAgent CreateSalaryAgent()
        {
            SalaryAgent value = new SalaryAgent(dataContext);
            return value;
        }
        public AbsAgent CreateAbsAgent()
        {
            AbsAgent value = new AbsAgent(dataContext);
            return value;
        }
        public AttendanceAgent CreateAttendanceAgent()
        {
            AttendanceAgent value = new AttendanceAgent(dataContext);
            return value;
        }
        public OtAgent CreateOtAgent()
        {
            OtAgent value = new OtAgent(dataContext);
            return value;
        }
        public CodeAgent CreateCodeAgent()
        {
            CodeAgent value = new CodeAgent(dataContext);
            return value;
        }
    }
}
