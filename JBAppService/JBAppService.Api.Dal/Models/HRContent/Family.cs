using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Family
    {
        public string FaIdno { get; set; }
        public string FaName { get; set; }
        public string RelCode { get; set; }
        public DateTime? FaBirdt { get; set; }
        public string Nobr { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Addr { get; set; }
        public string Tel { get; set; }
        public string Gsm { get; set; }
        public string Bbc { get; set; }
        public bool Tax { get; set; }
        public bool Autoinslab { get; set; }
        public bool Live { get; set; }
        public string Educode { get; set; }
        public string Compny { get; set; }
        public string Title { get; set; }
        public bool Famforn { get; set; }
    }
}
