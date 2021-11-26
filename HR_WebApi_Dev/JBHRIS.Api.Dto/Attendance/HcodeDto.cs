using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class HcodeDto
    {
        public string Hcode { get; set; }
        public string Hname { get; set; }
        public string Unit { get; set; }
        public decimal Min { get; set; }
        public decimal Interval { get; set; }
        public bool IsIncludeHoliday { get; set; }
        public string Id { get; set; }
        public string Sex { get; set; }
        public int Sort { get; set; }
        public bool System { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateMan { get; set; }
    }
}