using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class USys7
    {
        public int Auto { get; set; }
        public string CardName { get; set; }
        public int? NobrPos { get; set; }
        public int? NobrLen { get; set; }
        public int? SerPos { get; set; }
        public int? SerLen { get; set; }
        public int? DatePos { get; set; }
        public int? DateLen { get; set; }
        public int? TimePos { get; set; }
        public int? TimeLen { get; set; }
        public string Carddateformat { get; set; }
        public bool? Cardnoeuqalnobr { get; set; }
        public string SpiltSignal { get; set; }
        public string TextType { get; set; }
        public string IgnoreSignal { get; set; }
        public int? CodePos { get; set; }
        public int? CodeLen { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
    }
}
