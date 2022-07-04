using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysClients
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Note { get; set; }
    }
}
