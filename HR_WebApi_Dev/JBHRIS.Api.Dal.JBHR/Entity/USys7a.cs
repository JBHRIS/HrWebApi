using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class USys7a
    {
        public int Auto { get; set; }
        public string CardName { get; set; }
        public string DataSource { get; set; }
        public string InitailCatalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Datatable { get; set; }
        public string ColNobr { get; set; }
        public string ColAdate { get; set; }
        public string ColOntime { get; set; }
        public string ColCardno { get; set; }
        public string ColChecktime { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public DateTime LatestCheck { get; set; }
        public string ColSource { get; set; }
        public string ColIpadd { get; set; }
        public string Sql { get; set; }
    }
}
