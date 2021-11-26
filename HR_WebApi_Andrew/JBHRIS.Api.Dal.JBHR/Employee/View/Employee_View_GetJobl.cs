using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJobl : IEmployee_View_GetJobl
    {
        private JBHRContext _context;
        public Employee_View_GetJobl(JBHRContext context)
        {
            _context = context;
        }
        public List<JobDto> GetJob()
        {
            var data = _context.Jobl.Select(p =>new JobDto
            {
                JobId = p.Jobl1,
                JobName = p.JobName
            }).ToList();
            return data;
        }
    }
}
