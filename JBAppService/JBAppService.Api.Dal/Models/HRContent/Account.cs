using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Account
    {
        public string AccountType { get; set; }
        public string Nobr { get; set; }
        public string BankCode { get; set; }
        public string AccountNo { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
