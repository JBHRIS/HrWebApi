using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsTemplettype
    {
        public int AutoKey { get; set; }
        public string TempletId { get; set; }
        public string Type { get; set; }
        public decimal? Rate { get; set; }
        public int? Order { get; set; }
        public string Catename { get; set; }
        public string Catenote { get; set; }
        public string Cateitemname { get; set; }
        public string Cateitemnote { get; set; }
        public bool? Showcatename { get; set; }
        public bool? Showcatenote { get; set; }
        public bool? Showcateitemname { get; set; }
        public bool? Showcateitemnote { get; set; }
        public string Effsmode { get; set; }
        public string TitleId { get; set; }
    }
}
