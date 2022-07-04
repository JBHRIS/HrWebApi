using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Userdefinevalue
    {
        public int Ak { get; set; }
        public string Code { get; set; }
        public Guid Controlid { get; set; }
        public Guid? Sourceid { get; set; }
        public string Valuetype { get; set; }
        public string Value { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
