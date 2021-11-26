using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_Normal_GetPeopleByDept : IEmployee_Normal_GetPeopleByDept
    {
        private JBHRContext _context;

        public Employee_Normal_GetPeopleByDept(JBHRContext context)
        {
            _context = context;
        }

        public List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            List<string> results = new List<string>();
            foreach (var empList in employeeList.Split(1000))
            {
                results.AddRange(_GetPeopleByDept(employeeList, DeptList, CheckDate));
            }
            return results;
        }
        List<string> _GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _context.Basetts.Where(p => employeeList.Contains(p.Nobr) && DeptList.Contains(p.Dept) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
        }
    }
}
