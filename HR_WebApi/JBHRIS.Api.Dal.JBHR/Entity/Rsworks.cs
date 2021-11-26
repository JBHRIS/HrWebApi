using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Rsworks
    {
        public string Empid { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal Wyear { get; set; }
        public int Salamt { get; set; }
        public string Leave { get; set; }
        public bool Shop { get; set; }
    }
}
