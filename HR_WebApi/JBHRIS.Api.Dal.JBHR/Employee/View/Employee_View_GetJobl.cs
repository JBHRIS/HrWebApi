using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetJobl : IEmployee_View_GetJobl
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_GetJobl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<JobDto> GetJob()
        {
            var data = _unitOfWork.Repository<Jobl>().Reads().Select(p => new JobDto
            {
                JobId = p.Jobl1,
                JobName = p.JobName,
                JobIdDisplay = p.JoblDisp,
            }).ToList();
            return data;
        }
    }
}
