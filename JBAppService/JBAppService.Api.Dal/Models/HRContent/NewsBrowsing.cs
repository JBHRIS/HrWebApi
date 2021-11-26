using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class NewsBrowsing
    {
        public int Id { get; set; }
        public string NewsId { get; set; }
        public string Nobr { get; set; }
        public DateTime? BrowsingTime { get; set; }
    }
}
