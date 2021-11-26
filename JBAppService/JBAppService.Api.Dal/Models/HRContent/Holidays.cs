using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Holidays
    {
        public int Holidayid { get; set; }
        public string Holidayname { get; set; }
        public short? Holidayyear { get; set; }
        public short? Holidaymonth { get; set; }
        public short? Holidayday { get; set; }
        public DateTime? Starttime { get; set; }
        public short? Duration { get; set; }
        public short? Holidaytype { get; set; }
        public string Xinbie { get; set; }
        public string Minzu { get; set; }
        public short? DeptId { get; set; }
        public int? Timezone { get; set; }
    }
}
