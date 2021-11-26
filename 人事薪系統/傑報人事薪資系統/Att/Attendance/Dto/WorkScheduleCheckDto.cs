using System;
using System.Collections.Generic;
using System.Text;

namespace JBHR.Att.Attendance.Dto
{
    public class WorkScheduleCheckDto
    {     
        /// <summary>
        /// 起始日期
        /// 作為推算檢核週期的起始日
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 出勤紀錄
        /// </summary>
        public List<WorkScheduleDto> WorkSchedules { get; set; }
        /// <summary>
        /// 檢核起始日期
        /// 只會針對此區間的異常進行回傳
        /// </summary>
        public DateTime BeginCheckDate { get; set; }
        /// <summary>
        /// 檢核結束日期
        /// 只會針對此區間的異常進行回傳
        /// </summary>
        public DateTime EndCheckDate { get; set; }
        /// <summary>
        /// 班別設定
        /// 作為判斷班別特性
        /// </summary>
        public List<ScheduleTypeDto> ScheduleTypes { get; set; }
    }
}
