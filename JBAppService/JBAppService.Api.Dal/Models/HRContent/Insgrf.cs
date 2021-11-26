using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Insgrf
    {
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
