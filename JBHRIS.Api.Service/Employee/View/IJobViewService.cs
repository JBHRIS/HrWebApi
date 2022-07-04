using JBHRIS.Api.Dto.Employee.View;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Employee.View
{
    public interface IJobViewService
    {
        List<JobDto> GetJob();
        List<JobDto> GetJobs();
        List<JobDto> GetJobl();
        List<JobDto> GetJobo();
    }
}