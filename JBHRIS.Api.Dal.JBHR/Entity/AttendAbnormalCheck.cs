using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class AttendAbnormalCheck
    {
        public int Id { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Type { get; set; }
        public string RemarkType { get; set; }
        public string Remark { get; set; }
        public string Serno { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateMan { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateMan { get; set; }
    }
}
