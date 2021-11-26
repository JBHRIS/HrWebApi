using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class DormitoryManagement
    {
        public int AutoKey { get; set; }
        public int Bed { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public decimal Cost { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string CheckOutReasonCode { get; set; }
        public string Note { get; set; }

        public virtual DormitoryBed BedNavigation { get; set; }
        public virtual Base NobrNavigation { get; set; }
    }
}
