using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class SystemUserInfo
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string AnonymousName { get; set; }
        public DateTime Birthday { get; set; }
        public string CardId { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public DateTime TelA { get; set; }
        public DateTime TelD { get; set; }
        public string Email { get; set; }
        public DateTime EmailA { get; set; }
        public DateTime EmailD { get; set; }
        public string Sex { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
