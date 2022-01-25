using JBHRIS.Api.Dal.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_Normal_GetPeopleByLeaveDate : IEmployee_Normal_GetPeopleByLeaveDate
    {
        private JBHRContext _context;

        public Employee_Normal_GetPeopleByLeaveDate(JBHRContext context)
        {
            _context = context;
        }
        public List<string> GetPeopleByLeaveDate(DateTime beginDate, DateTime endDate)
        {
            //var data = _context.Basetts.Where(p =>   DateTime.Now >= p.Adate && DateTime.Now <= p.Ddate.Value ).Select(p => p).Distinct().ToList();//有效日期的名單
           
            return _context.Basetts.Where(p => beginDate <= p.Oudt && p.Oudt <= endDate && DateTime.Now.Date >= p.Adate && DateTime.Now.Date <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
          
        }

    }
}
