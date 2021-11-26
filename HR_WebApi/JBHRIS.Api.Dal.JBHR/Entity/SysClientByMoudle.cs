using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysClientByMoudle
    {
        public string ClientId { get; set; }
        public string MoudleId { get; set; }
        public string KeyMan { get; set; }
        public DateTime UpadateDate { get; set; }
        public string Note { get; set; }
    }
}
