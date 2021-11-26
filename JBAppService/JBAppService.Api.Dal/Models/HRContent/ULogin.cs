using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ULogin
    {
        public DateTime InTime { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Workadr { get; set; }
        public bool? Procsuper { get; set; }
        public bool? Mangsuper { get; set; }
        public bool? Super { get; set; }
        public string System { get; set; }
    }
}
