using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Mailqueue
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string FromAddr { get; set; }
        public string FromName { get; set; }
        public string ToAddr { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Retry { get; set; }
        public bool Success { get; set; }
        public bool Suspend { get; set; }
        public DateTime FreezeTime { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public string Note5 { get; set; }
    }
}
