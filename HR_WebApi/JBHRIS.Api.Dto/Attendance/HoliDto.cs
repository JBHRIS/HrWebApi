using System;

namespace JBHRIS.Api.Dto.Attendance.Action
{
    public class HoliDto
    {
        public DateTime HDate { get; set; }
        public string AttCode { get; set; }
        public bool Holi1 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string HoliCode { get; set; }
        public string Othcode { get; set; }
        public string Othcode_Rote { get; set; }
    }
}