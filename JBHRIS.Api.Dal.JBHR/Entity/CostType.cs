using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class CostType
    {
        public string CostTypeCode { get; set; }
        public string CostTypeName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
