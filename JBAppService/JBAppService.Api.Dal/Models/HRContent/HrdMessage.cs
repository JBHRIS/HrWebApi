using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class HrdMessage
    {
        public int MessageId { get; set; }
        public string Code { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
        public string Language4 { get; set; }
        public string Language5 { get; set; }
        public string CreateMan { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
