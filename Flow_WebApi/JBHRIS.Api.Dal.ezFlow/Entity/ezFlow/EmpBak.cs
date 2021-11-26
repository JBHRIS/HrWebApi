using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class EmpBak
    {
        public string id { get; set; }
        public string pw { get; set; }
        public string name { get; set; }
        public bool? isNeedAgent { get; set; }
        public DateTime? dateB { get; set; }
        public DateTime? dateE { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string sex { get; set; }
    }
}
