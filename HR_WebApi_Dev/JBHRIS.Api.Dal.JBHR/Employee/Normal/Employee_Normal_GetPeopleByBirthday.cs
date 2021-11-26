using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dto.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_Normal_GetPeopleByBirthday : IEmployee_Normal_GetPeopleByBirthday
    {
        private JBHRContext _context;

        public Employee_Normal_GetPeopleByBirthday(JBHRContext context)
        {
            _context = context;
        }

        public List<string> GetPeopleByBirthday(List<string> employeeList, int[] months)
        {
            var paras = new
            {
                empIds = employeeList
                ,
                months = months
            };

            Expression<Func<Base, bool>> predicate =
                b => b.Birdt.HasValue
                && paras.months.Contains(b.Birdt.Value.Month)
                && paras.empIds.Contains(b.Nobr);
            return _context.Base.Where(predicate).Select(b => b.Nobr).ToList();
        }

    }
}
