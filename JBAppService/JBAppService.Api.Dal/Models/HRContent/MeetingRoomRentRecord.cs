using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MeetingRoomRentRecord
    {
        public int Id { get; set; }
        public int MeetingRoomId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UsedTimeHours { get; set; }
        public int UsedTimeMins { get; set; }
        public int UsedTotalMins { get; set; }
        public string Topic { get; set; }
        public string Contents { get; set; }
        public bool EmailNotification { get; set; }
        public string WritedBy { get; set; }
        public DateTime? WritedDate { get; set; }
        public bool Cancel { get; set; }
        public string Canceler { get; set; }
        public string GroupCode { get; set; }
    }
}
