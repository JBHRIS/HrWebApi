using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class FlowControlDto
    {
        public int AutoKey { get; set; }
        public string Form { get; set; }
        public string FormCode { get; set; }
        public string Value { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
    public class FlowControlCodeDto
    {
        public int AutoKey { get; set; }
        public string Form { get; set; }
        public string FCode { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
    public class FlowControlCondition
    { 
        public List<string> Form { get; set; }
        public List<string> Code { get; set; }
    }
}
