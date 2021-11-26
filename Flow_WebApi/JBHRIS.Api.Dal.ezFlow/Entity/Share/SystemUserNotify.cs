using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class SystemUserNotify
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string UserCode { get; set; }
        public string UserCodeSend { get; set; }
        public string UserName { get; set; }
        public string NotifyTypeCode { get; set; }
        public string AppName { get; set; }
        public string AppCode { get; set; }
        public string TitleContents { get; set; }
        public string Contents { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
