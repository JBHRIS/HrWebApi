using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class HunyaAbsenceDataSaveEntry
    {
        public DateTime AtteendDate { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string Nobr { get; set; }
    }
}
