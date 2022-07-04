using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsTempletcateitem
    {
        public int AutoKey { get; set; }
        public string TempletId { get; set; }
        public string EffsId { get; set; }
        public int Order { get; set; }
        public decimal? EffsMinNum { get; set; }
        public decimal? EffsMaxNum { get; set; }
        public decimal? Rate { get; set; }
        public string TypeId { get; set; }
        public string EffsCateId { get; set; }
    }
}
