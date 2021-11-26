using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Securitydetails
    {
        public int Securitydetailid { get; set; }
        public int? Userid { get; set; }
        public short? Deptid { get; set; }
        public short? Schedule { get; set; }
        public short? Userinfo { get; set; }
        public short? Enrollfingers { get; set; }
        public short? Reportview { get; set; }
        public string Report { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? FullControl { get; set; }
    }
}
