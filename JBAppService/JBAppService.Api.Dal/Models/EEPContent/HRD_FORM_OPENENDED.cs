using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_FORM_OPENENDED
    {
        public int QUIZ_ID { get; set; }
        public int? FORM_ID { get; set; }
        public string QUIZ_TYPE { get; set; }
        public string IS_REQUIRED { get; set; }
        public string QUIZ_EXPLAIN { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
