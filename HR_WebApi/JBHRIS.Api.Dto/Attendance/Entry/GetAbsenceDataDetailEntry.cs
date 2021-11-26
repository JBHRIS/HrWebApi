using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Absence.Entry
{
    public class GetAbsenceDataDetailEntry
    {
        public string Nobr { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string HCode { get; set; }
    }
}
