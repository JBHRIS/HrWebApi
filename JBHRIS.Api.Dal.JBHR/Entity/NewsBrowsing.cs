using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class NewsBrowsing
    {
        public int Id { get; set; }
        public string NewsId { get; set; }
        public string Nobr { get; set; }
        public DateTime? BrowsingTime { get; set; }
    }
}
