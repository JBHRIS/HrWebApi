using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class AppBSSIDAndUserGroupBind
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AppBSSIDCode { get; set; }
        public string AppUserGroupCode { get; set; }
        public string Note { get; set; }
        public int Sort { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
