using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trcosc
    {
        public string Guid { get; set; }
        public string Code { get; set; }
        public string Course { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public decimal CosFee { get; set; }
        public string TrComp { get; set; }
        public decimal TrHrs { get; set; }
        public bool Aborad { get; set; }
        public string Country { get; set; }
        public string TrDept { get; set; }
        public string TrType { get; set; }
        public string TrMemo { get; set; }
        public string TrAsno { get; set; }
        public string Handout { get; set; }
        public bool Planin { get; set; }
        public bool Planto { get; set; }
        public string TrPerson { get; set; }
        public string TrIso { get; set; }
        public string TrInout { get; set; }
        public string TrTeach { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
