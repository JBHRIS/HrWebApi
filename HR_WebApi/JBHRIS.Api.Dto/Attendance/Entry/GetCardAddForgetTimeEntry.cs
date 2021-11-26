using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class GetCardAddForgetTimeEntry
    {
        public string EmployeeID { get; set; }
        public DateTime AttendDate { get; set; }
        public List<GetCardAddForgetTimeCardListEntry> getCardAddForgetTimeCardListEntries { get; set; }
    }
}
