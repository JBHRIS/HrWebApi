using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MeetingRoomRentAttendee
    {
        public int Id { get; set; }
        public int MeetingRoomRentRecordId { get; set; }
        public string EmpNo { get; set; }
    }
}
