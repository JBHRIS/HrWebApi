using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.View
{
    public class JobViewService : IJobViewService
    {
        private IEmployee_View_GetJob _employee_View_GetJob;
        private IEmployee_View_GetJobs _employee_View_GetJobs;
        private IEmployee_View_GetJobl _employee_View_GetJobl;
        private IEmployee_View_GetJobo _employee_View_GetJobo;

        public JobViewService(IEmployee_View_GetJob employee_View_GetJob
            , IEmployee_View_GetJobs employee_View_GetJobs
            , IEmployee_View_GetJobl employee_View_GetJobl
            , IEmployee_View_GetJobo employee_View_GetJobo)
        {
            _employee_View_GetJob = employee_View_GetJob;
            _employee_View_GetJobs = employee_View_GetJobs;
            _employee_View_GetJobl = employee_View_GetJobl;
            _employee_View_GetJobo = employee_View_GetJobo;
        }

        public List<JobDto> GetJob()
        {
            return _employee_View_GetJob.GetJob();
        }

        public List<JobDto> GetJobs()
        {
            return _employee_View_GetJobs.GetJob();
        }

        public List<JobDto> GetJobl()
        {
            return _employee_View_GetJobl.GetJob();
        }

        public List<JobDto> GetJobo()
        {
            return _employee_View_GetJobo.GetJob();
        }
    }
}
