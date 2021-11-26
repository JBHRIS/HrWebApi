using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class SystemPage
    {
        public int AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public int RoleKey { get; set; }
        public string ParentCode { get; set; }
        public string Icon { get; set; }
        public bool? Href { get; set; }
        public bool OpenWindow { get; set; }
        public string Note { get; set; }
        public int Sort { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
