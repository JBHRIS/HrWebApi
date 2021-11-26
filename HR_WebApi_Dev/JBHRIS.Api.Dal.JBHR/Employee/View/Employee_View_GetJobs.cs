using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJobs : IEmployee_View_GetJobs
    {
        private JBHRContext _context;
        public Employee_View_GetJobs(JBHRContext context)
        {
            _context = context;
        }
        public List<JobDto> GetJob()
        {
            //throw new NotImplementedException();
            var data = _context.Jobs.Select(p => new JobDto
            {
                JobId = p.Jobs1,
                JobName = p.JobName,
                JobIdDisplay = p.Jobs1,
                JobNameE = p.JobName,
            }).ToList();
            return data;
        }
    }
}
