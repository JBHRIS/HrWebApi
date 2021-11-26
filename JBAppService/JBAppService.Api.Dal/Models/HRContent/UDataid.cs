using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UDataid
    {
        public string UserId { get; set; }
        public string Dept { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string System { get; set; }
    }
}
