using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Websalbasd
    {
        public int Id { get; set; }
        public string SalCode { get; set; }
        public string SalName { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
