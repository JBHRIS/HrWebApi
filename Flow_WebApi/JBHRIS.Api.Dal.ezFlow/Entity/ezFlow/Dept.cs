using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class Dept
    {
        public string id { get; set; }
        public string idParent { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string DeptLevel_id { get; set; }
    }
}
