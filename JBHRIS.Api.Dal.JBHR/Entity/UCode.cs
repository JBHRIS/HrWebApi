using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class UCode
    {
        public int Autokey { get; set; }
        public string QCode { get; set; }
        public string QName { get; set; }
        public string QField { get; set; }
        public decimal QLens { get; set; }
        public string QAttr { get; set; }
        public bool QOrder { get; set; }
        public string Formname { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string System { get; set; }
        public bool QVar { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
}
