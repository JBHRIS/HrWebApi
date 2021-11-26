using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHRIS.Api.Dto.Attendance;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTimeNW_WorkScheduleCheck : IWorkScheduleCheck
    {
        public DeformationTimeNW_WorkScheduleCheck()
        {

        }
        public int NWeeksN0Z_Weeks { set; get; } = 1;
        public int NWeeksN0Z_0Z { set; get; } = 1;
        public int NWeeksN0ZN00_Weeks { set; get; } = 1;
        public int NWeeksN0ZN00_0Z { set; get; } = 1;
        public int NWeeksN0ZN00_00 { set; get; } = 1;
        public string Error { set; get; } = "CDT1";

        public virtual WorkScheduleCheckResult Check(string CheckType, WorkScheduleCheckDto workScheduleCheck)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if (workScheduleCheck == null)
            {
                result.State = false;
                //_logger.Warn("workScheduleCheck未設定");
                return result;
            }

            workScheduleCheck.WorkSchedules = workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate).ToList();

            int DaysNWN0ZN00 = NWeeksN0ZN00_Weeks * 7;
            int Temp0Z = NWeeksN0ZN00_0Z;
            int Temp00 = NWeeksN0ZN00_00;
            int DaysNWN0Z = NWeeksN0Z_Weeks * 7;
            int TempNWN0Z = NWeeksN0Z_0Z;

            foreach (var WorkSchedule in workScheduleCheck.WorkSchedules)
            {
                var scheduleType = workScheduleCheck.ScheduleTypes.FirstOrDefault(p => p.Code == WorkSchedule.ScheduleType);
                if (scheduleType != null && scheduleType.AttenType.Trim() == "0Z")
                {
                    TempNWN0Z--;
                    Temp0Z--;
                }
                    
                if (scheduleType != null && scheduleType.AttenType.Trim() == "00")
                    Temp00--;

                DaysNWN0Z--;
                DaysNWN0ZN00--;

                if (DaysNWN0Z == 0)
                {
                    if (TempNWN0Z > 0 && WorkSchedule.AttendanceDate >= workScheduleCheck.BeginCheckDate && WorkSchedule.AttendanceDate <= workScheduleCheck.EndCheckDate)
                    {
                        result.State = false;
                        result.workScheduleIssues.Add(new WorkScheduleIssueDto
                        {
                            IssueDate = WorkSchedule.AttendanceDate,
                            CheckType = CheckType,
                            ErrorCode = Error,//"CDT2",
                            ErrorMessage = string.Format("已違反{0}週需{1}例假日規定.", NWeeksN0Z_Weeks, NWeeksN0Z_0Z),
                        });;
                    }

                    DaysNWN0Z = NWeeksN0Z_Weeks * 7;
                    TempNWN0Z = NWeeksN0Z_0Z;
                }

                if (DaysNWN0ZN00 == 0)
                {
                    if (Temp00 > 0 || Temp0Z > 0 && WorkSchedule.AttendanceDate >= workScheduleCheck.BeginCheckDate && WorkSchedule.AttendanceDate <= workScheduleCheck.EndCheckDate)
                    {
                        result.State = false;
                        result.workScheduleIssues.Add(new WorkScheduleIssueDto
                        {
                            IssueDate = WorkSchedule.AttendanceDate,
                            CheckType = CheckType,
                            ErrorCode = Error,//"CDT2",
                            ErrorMessage = string.Format("已違反{0}週需{1}例{2}休規定.", NWeeksN0ZN00_Weeks, NWeeksN0ZN00_0Z, NWeeksN0ZN00_00),
                        });
                    }

                    DaysNWN0ZN00 = NWeeksN0ZN00_Weeks * 7;
                    Temp0Z = NWeeksN0ZN00_0Z;
                    Temp00 = NWeeksN0ZN00_00;
                }
            }
            return result;
        }
    }
}
