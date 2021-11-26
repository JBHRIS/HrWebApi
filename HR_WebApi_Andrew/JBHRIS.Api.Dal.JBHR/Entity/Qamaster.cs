using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Qamaster
    {
        public int Id { get; set; }
        public int QaPublishedId { get; set; }
        public string Nobr { get; set; }
        public int? SysRole { get; set; }
        public string FillerCategory { get; set; }
        public string DeptCode { get; set; }
        public DateTime? WriteDate { get; set; }
        public DateTime? FillFormDatetimeB { get; set; }
        public DateTime? FillFormDatetimeE { get; set; }
        public int? TotalScore { get; set; }
        public string FillInBy { get; set; }
        public string MailLog { get; set; }
    }
}
