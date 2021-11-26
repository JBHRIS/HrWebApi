using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ABSENT_MINUS_FILE
    {
        public int ABSENT_MINUS_FILE_ID { get; set; }
        public int ABSENT_MINUS_ID { get; set; }
        public string ABSENT_MINUS_FILE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
