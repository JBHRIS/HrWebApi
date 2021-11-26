using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class HRD_MESSAGE
    {
        public int MESSAGE_ID { get; set; }
        public string CODE { get; set; }
        public string LANGUAGE1 { get; set; }
        public string LANGUAGE2 { get; set; }
        public string LANGUAGE3 { get; set; }
        public string LANGUAGE4 { get; set; }
        public string LANGUAGE5 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
