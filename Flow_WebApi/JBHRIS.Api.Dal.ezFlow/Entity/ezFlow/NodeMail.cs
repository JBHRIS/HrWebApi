using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class NodeMail
    {
        public string FlowNode_id { get; set; }
        public string receiveType { get; set; }
        public string customEmail { get; set; }
        public string dynamicTable { get; set; }
        public string dynamicFdMail { get; set; }
        public bool? isCustom { get; set; }
        public string subject { get; set; }
        public string mailContent { get; set; }
    }
}
