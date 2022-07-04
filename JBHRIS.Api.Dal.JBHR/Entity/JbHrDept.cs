using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class JbHrDept
    {
        public string SDeptCode { get; set; }
        public string SDeptName { get; set; }
        public string SDeptTree { get; set; }
        public DateTime? DAdate { get; set; }
        public DateTime? DDdate { get; set; }
        public string SDeptParent { get; set; }
        public string SDeptPathCode { get; set; }
        public string SDeptPathName { get; set; }
        public string SNobr { get; set; }
        public bool? BRes { get; set; }
        public string SDeptCodeDisp { get; set; }
    }
}
