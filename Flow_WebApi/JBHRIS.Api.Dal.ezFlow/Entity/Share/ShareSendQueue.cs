using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class ShareSendQueue
    {
        public int AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string Code { get; set; }
        public string SendTypeCode { get; set; }
        public string FromAddr { get; set; }
        public string FromName { get; set; }
        public string ToAddr { get; set; }
        public string ToName { get; set; }
        public string ToAddrCopy { get; set; }
        public string ToNameCopy { get; set; }
        public string ToAddrConfidential { get; set; }
        public string ToNameConfidential { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Retry { get; set; }
        public bool Sucess { get; set; }
        public bool Suspend { get; set; }
        public DateTime DateSend { get; set; }
        public int Sort { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
