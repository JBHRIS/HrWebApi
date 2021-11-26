using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UError
    {
        public DateTime OccurTime { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string System { get; set; }
        public string Formname { get; set; }
        public decimal Errno { get; set; }
        public string Errmsg { get; set; }
        public string Errpgname { get; set; }
        public string Errpgcode { get; set; }
        public decimal Errpgline { get; set; }
        public string Aerror { get; set; }
    }
}
