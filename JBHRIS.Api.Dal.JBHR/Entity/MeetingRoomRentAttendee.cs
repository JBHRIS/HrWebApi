using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class MeetingRoomRentAttendee
    {
        public int Id { get; set; }
        public int MeetingRoomRentRecordId { get; set; }
        public string EmpNo { get; set; }
    }
}
