using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class SystemUserAccountBind
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string UserCode { get; set; }
        public string ThirdPartyAccountId { get; set; }
        public string ThirdPartyTypeCode { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
