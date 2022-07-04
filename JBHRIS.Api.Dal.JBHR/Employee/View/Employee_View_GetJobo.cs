using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJobo : IEmployee_View_GetJobo
    {
        private JBHRContext _context;
        public Employee_View_GetJobo(JBHRContext context)
        {
            _context = context;
        }

        public List<JobDto> GetJob()
        {
            var data = _context.Jobo.Select(p => new JobDto
            {
                JobId = p.Jobo1,
                JobName = p.JobName,
                JobIdDisplay = p.Jobo1,
                JobNameE = p.JobName,
            }).ToList();

            return data;
        }
    }
}
