using System;

namespace JBHRIS.Api.Dto.Attendance.Normal
{
    public class CardApplyDto
    {
        public string EmplyeeId { get; set; }
        public string CardNo { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}