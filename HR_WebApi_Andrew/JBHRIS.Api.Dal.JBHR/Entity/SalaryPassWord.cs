using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SalaryPassWord
    {
        public int IAutoKey { get; set; }
        public string SNobr { get; set; }
        public string SPassWord { get; set; }
        public string SIp { get; set; }
        public DateTime? DKeyDate { get; set; }
        public DateTime? DLoginDate { get; set; }
        public string SLoginIp { get; set; }
    }
}
