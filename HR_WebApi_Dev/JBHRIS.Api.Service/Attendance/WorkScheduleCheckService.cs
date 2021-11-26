using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public class WorkScheduleCheckService : IWorkScheduleCheckService
    {
        private IWorkScheduleFacotry _workScheduleFacotry;

        public WorkScheduleCheckService(IWorkScheduleFacotry workScheduleFacotry)
        {
            _workScheduleFacotry = workScheduleFacotry;
        }
        public WorkScheduleCheckResult Check(WorkScheduleCheckEntry workScheduleCheckEntry)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            foreach (var checkType in workScheduleCheckEntry.CheckTypes)
            {
                var checker = _workScheduleFacotry.Create(checkType);
                var checkResult = checker.Check(checkType, workScheduleCheckEntry.workScheduleCheck);
                if (checkResult.workScheduleIssues.Any())
                {
                    result.State = false;
                    result.workScheduleIssues.AddRange(checkResult.workScheduleIssues);
                }
            }
            return result;
        }
    }
}
