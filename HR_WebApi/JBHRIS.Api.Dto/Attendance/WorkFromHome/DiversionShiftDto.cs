using System;

namespace HR_WebApi.Dto.Attendance
{
    /*
     * 2.AB班出勤設定(班別：居家上班、公司上班、假日(可不設定))
            -日期,AB分流 (優先)
            -星期(1-7),AB班
            -週(1-52),AB班
     */
    public class DiversionShiftDto
    {
        public string DiversionGroup { get; set; }
        public string DiversionGroupName { get; set; }
        public DateTime AttendDate { get; set; }
        /// <summary>
        /// 分流上班類別
        /// Attend正常出勤,WFH居家上班,Dayoff休假
        /// </summary>
        public string DiversionAttendType { get; set; }
        public string DiversionAttendTypeName { get; set; }
    }
}