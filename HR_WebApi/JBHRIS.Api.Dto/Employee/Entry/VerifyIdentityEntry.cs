using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class VerifyIdentityEntry
    {
        public string nobr { get; set; }
        public string idNo { get; set; }
        public string email { get; set; }
        public string redirectUrl { get; set; }
        public string redirectQueryString { get; set; }
    }
}
