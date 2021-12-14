using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class QuestionReply
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string QuestionMainCode { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int RoleKey { get; set; }
        public string IpAddress { get; set; }
        public string ReplyToCode { get; set; }
        public string ParentCode { get; set; }
        public bool Send { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
