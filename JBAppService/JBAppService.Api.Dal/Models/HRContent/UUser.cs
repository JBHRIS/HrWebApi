using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UUser
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool Super { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool Procsuper { get; set; }
        public string Workadr { get; set; }
        public bool Mangsuper { get; set; }
        public string EMail { get; set; }
        public bool Admin { get; set; }
        public string Nobr { get; set; }
    }
}
