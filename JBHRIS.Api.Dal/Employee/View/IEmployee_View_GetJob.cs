using JBHRIS.Api.Dto.Employee.View;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Employee.View
{
    public interface IEmployee_View_GetJob
    {
        List<JobDto> GetJob();
    }
}