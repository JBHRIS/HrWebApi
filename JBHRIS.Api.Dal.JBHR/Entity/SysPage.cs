using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysPage
    {
        public string Code { get; set; }
        public string SUrl { get; set; }
        public string SPath { get; set; }
        public string SName { get; set; }
        public string SParentKey { get; set; }
        public int IOrder { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
