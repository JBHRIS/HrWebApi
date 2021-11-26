
namespace JBHRIS.Api.Dto.Attendance
{
    public class HcodeDto
    {
        public string HCode { get; set; }
        public string HCodeDisp { get; set; }
        public string HCodeName { get; set; }
        public string HCodeUnit { get; set; }
        public string Flag { get; set; }
        public string Htype { get; set; }
        public bool InHoli { get; set; }//含假日
        public bool Che { get; set; } //檢查剩餘時數
        public decimal AbsUnit { get; set; } //間格數
        public decimal Minnum { get; set; } //最小數
        public string Sex { get; set; }
    }
}