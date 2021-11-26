using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CARD_MACHINE
    {
        public int CARD_MACHINE_ID { get; set; }
        public string CARD_MACHINE_NAME { get; set; }
        public int? CARD_POSITION { get; set; }
        public int? CARD_LENGTH { get; set; }
        public int? SERIAL_POSITION { get; set; }
        public int? SERIAL_LENGTH { get; set; }
        public int? DATE_POSITION { get; set; }
        public int? DATE_LENGTH { get; set; }
        public int? TIME_POSITION { get; set; }
        public int? TIME_LENGTH { get; set; }
        public string CARD_DATE_FORMAT { get; set; }
        public bool? CARDNO_EQUAL_EMPLOYEENO { get; set; }
        public string SEPARATE_SIGNAL { get; set; }
        public string TEXT_TYPE { get; set; }
        public string IGNORE_SIGNAL { get; set; }
        public int? SOURCE_POSITION { get; set; }
        public int? SOURCE_LENGTH { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
