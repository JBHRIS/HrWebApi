using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance
{
    public class WorkScheduleCheckWithQueryEntry
    {
        public WorkScheduleCheckWithQueryEntry()
        {
            CheckTypes = new List<string>();
        }
        /// <summary>
        /// 檢核種類
        /// </summary>
        public List<string> CheckTypes { get; set; }
        /// <summary>
        /// 檢核條件
        /// </summary>
        public WorkScheduleCheckDto workScheduleCheck { get; set; }
    }
}