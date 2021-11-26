using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Qadetail
    {
        public int Id { get; set; }
        public int QamasterId { get; set; }
        public int QqitemId { get; set; }
        public int? McqIntValue { get; set; }
        public string McqStringValue { get; set; }
        public bool? TfqValue { get; set; }
        public string SaqValue { get; set; }
    }
}
