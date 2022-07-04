using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class OvertimeType
    {
        public string Category { get; set; }
        public string Code { get; set; }
        public string TypeName { get; set; }
        public bool Meal { get; set; }
        public decimal? Frequency { get; set; }
        public bool ComLeave { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public int? Sort { get; set; }
        public bool? Display { get; set; }
        public bool IsOt { get; set; }
    }
}
