using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    public class WorksInfoDto
    {
        public string Nobr { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string TradeCode { get; set; }
        public bool InMark { get; set; }
        public bool InCabinet { get; set; }
        public decimal Volume { get; set; }
        public string DirTitle { get; set; }
        public string SecTitle { get; set; }
        public decimal People { get; set; }
        public string TelNo { get; set; }
        public string Addr { get; set; }
        public int WorkId { get; set; }
    }
}
