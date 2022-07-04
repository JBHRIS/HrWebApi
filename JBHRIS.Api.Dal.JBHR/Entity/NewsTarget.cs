using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class NewsTarget
    {
        public int Id { get; set; }
        public string NewsId { get; set; }
        public string EmpNo { get; set; }
        public string DetpCode { get; set; }
    }
}
