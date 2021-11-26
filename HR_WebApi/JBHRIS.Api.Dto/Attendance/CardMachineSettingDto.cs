namespace JBHRIS.Api.Dto.Attendance.Normal
{
    public class CardMachineSettingDto
    {
        public int CodePosition { get;  set; }
        public int CodeLength { get;  set; }
        public int DatePosition { get;  set; }
        public int DateLength { get;  set; }
        public int TimePosition { get;  set; }
        public int TimeLength { get;  set; }
        public int NobrPosition { get; set; }
        public int NobrLength { get; set; }
        public int SernoPosition { get;  set; }
        public int SernoLength { get;  set; }
        public string TextType { get;  set; }
        public string SpiltSignal { get;  set; }
        public string IgnoreSignal { get;  set; }
        public bool CardNoIsEmployeeId { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
    }
}