using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAbsTran
    {
        public int iAutoKey { get; set; }
        public string sAbsDetailKey { get; set; }
        public string sKey { get; set; }
        public string sAbsPlusKey { get; set; }
        public DateTime dAbsPlusDateB { get; set; }
        public DateTime dAbsPlusDateE { get; set; }
        public string sAbsPlusTimeB { get; set; }
        public string sAbsPlusTimeE { get; set; }
        public string sAbsPlusHcode { get; set; }
        public DateTime? dEventDate { get; set; }
        public string sKeyName { get; set; }
        public decimal iAbsPlusMax { get; set; }
        public decimal iAbsPlusUse { get; set; }
        public decimal iAbsPlusBalance { get; set; }
        public DateTime dDateTimeB { get; set; }
        public DateTime dDateTimeE { get; set; }
        public DateTime dDateB { get; set; }
        public string sTimeB { get; set; }
        public string sTimeE { get; set; }
        public string sHcode { get; set; }
        public decimal iUse { get; set; }
        public decimal iBalance { get; set; }
    }
}
