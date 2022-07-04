using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsSelfedu
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string EduCateId { get; set; }
        public string EduCateItemId { get; set; }
        public string Other { get; set; }
        public DateTime? Keydate { get; set; }
    }
}
