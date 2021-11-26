using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJob : IEmployee_View_GetJob
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_GetJob(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<JobDto> GetJob()
        {
            var data = _unitOfWork.Repository<Job>().Reads().Select(p => new JobDto
            {
                JobId = p.Job1,
                JobName = p.JobName,
                JobNameE = p.JobEname,
                JobIdDisplay = p.JobDisp,
                JobLevel = p.Jobl
            }).ToList();
            return data;
        }
    }
}
