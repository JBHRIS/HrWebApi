using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Yrinsur
    {
        public int Auto { get; set; }
        public string Year { get; set; }
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public decimal RelLab { get; set; }
        public decimal RelHel { get; set; }
        public decimal RelGrp { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Equal { get; set; }
        public string Saladr { get; set; }
        public decimal RelSup { get; set; }
        public decimal? RelLabComp { get; set; }
        public decimal? RelHelComp { get; set; }
    }
}
