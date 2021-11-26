using System;

namespace JBHR.Att.Attendance.Dto
{
    public class ScheduleTypeDto
    {
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 上班時間
        /// </summary>
        //public TimeSpan OnTime { get; set; }
        public string OnTime { get; set; }
        /// <summary>
        /// 下班時間
        /// </summary>
        //public TimeSpan OffTime { get; set; }
        public string OffTime { get; set; }
        /// <summary>
        /// 出勤性質
        /// ex.平日(空白),休息日(0X),國定假日(00),例假日(0Z)
        /// </summary>
        public string AttenType { get; set; }
        /// <summary>
        /// 間隔時數
        /// </summary>
        public decimal Interval { get; set; }
        
    }
}