using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Chkidno
    {
        public string Nobr { get; set; }
        public string Idno { get; set; }
        public string NameC { get; set; }
        public string Sex { get; set; }
        public string Ethnic { get; set; }
        public DateTime Birdt { get; set; }
        public string Organ { get; set; }
        public string Addr { get; set; }
        public DateTime Chkdate { get; set; }
        public DateTime Ddate { get; set; }
        public DateTime KeyDate { get; set; }
        public string IdTime { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? IdAdate { get; set; }
        public DateTime? IdDdate { get; set; }
    }
}
