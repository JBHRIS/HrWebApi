using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CardReasonDto
    {
        public bool EffectAttend { get; set; }
        public string Code { get; set; }
        public string CardReasonCode { get; set; }
        public string CardReasonName { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateMan { get; set; }
        public int Sort { get; set; }
    }
}