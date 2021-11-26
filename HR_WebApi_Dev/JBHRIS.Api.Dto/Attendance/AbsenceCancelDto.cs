using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AbsenceCancelDto
    {
        public string EmployeeId { get; set; }
        public string Hcode { get; set; }
        public DateTime AbsenceDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string YYMM { get; set; }
        public decimal Taken { get; set; }
        public string Remark { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
        public string Guid { get; set; }

    }
}