using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJobs : IEmployee_View_GetJobs
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_GetJobs(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<JobDto> GetJob()
        {
            var data = _unitOfWork.Repository<Jobs>().Reads().Select(p => new JobDto
            {
                JobId = p.Jobs1,
                JobName = p.JobName,
                JobIdDisplay = p.JobsDisp,
            }).ToList();
            return data;
        }
    }
}
