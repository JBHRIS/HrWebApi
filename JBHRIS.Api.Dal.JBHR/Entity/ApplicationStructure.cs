using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ApplicationStructure
    {
        public int NodeId { get; set; }
        public int ApplicationId { get; set; }
        public int ParentId { get; set; }
        public string ApplicationName { get; set; }
        public int DataAdapterId { get; set; }
        public string CustomizeSetting { get; set; }
        public string ApplicationType { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
        public string Guid { get; set; }
        public string Tag { get; set; }
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
    }
}
