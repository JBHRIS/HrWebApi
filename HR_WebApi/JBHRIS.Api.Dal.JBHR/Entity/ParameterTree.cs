using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ParameterTree
    {
        public int Auto { get; set; }
        public int Pid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Display { get; set; }
        public int Sort { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
    }
}
