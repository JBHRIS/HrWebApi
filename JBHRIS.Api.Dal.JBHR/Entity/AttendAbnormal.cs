using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class AttendAbnormal
    {
        public int Id { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Type { get; set; }
        public bool IsError { get; set; }
        public int ErrorMins { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string OnTimeActual { get; set; }
        public string OffTimeActual { get; set; }
        public decimal OnTiemBufferMins { get; set; }
        public decimal OffTimeBufferMins { get; set; }
        public string RoteCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateMan { get; set; }
    }
}
