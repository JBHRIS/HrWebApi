using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class OvertimeReasonDto
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateMan { get; set; }
    }
}