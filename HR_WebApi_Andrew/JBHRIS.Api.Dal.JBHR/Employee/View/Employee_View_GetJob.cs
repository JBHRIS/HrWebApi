using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJob : IEmployee_View_GetJob
    {
        private JBHRContext _context;
        public Employee_View_GetJob(JBHRContext context)
        {
            _context = context;
        }        
        public List<JobDto> GetJob()
        {
            var data = _context.Job.Select(p => new JobDto
            {
                JobId = p.Job1,
                JobName = p.JobName
            }).ToList();
            return data;
        }
    }
}
