using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Inslab
    {
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public string Code { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string LrateCode { get; set; }
        public string HrateCode { get; set; }
        public decimal LAmt { get; set; }
        public decimal HAmt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Seq { get; set; }
        public string Code1 { get; set; }
        public string Note { get; set; }
        public string SNo { get; set; }
        public decimal RAmt { get; set; }
        public string Sptyp { get; set; }
        public string Wbsptyp { get; set; }
        public DateTime? RoutDate { get; set; }
        public bool? Pemp { get; set; }
        public bool? Pemp1 { get; set; }
    }
}
