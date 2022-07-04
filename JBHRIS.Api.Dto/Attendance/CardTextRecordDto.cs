namespace JBHRIS.Api.Dto.Attendance.Normal
{
    public class CardTextRecordDto
    {
        public string TextContent { get;  set; }
        public CardRecordDto CardRecord { get;  set; }
        public bool State { get;  set; }
        public string ErrorMessage { get;  set; }
    }
}