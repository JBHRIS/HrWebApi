using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfWebValidate
    {
        public int iAutoKey { get; set; }
        public string sValidateKey { get; set; }
        public DateTime dDateWriter { get; set; }
        public DateTime? dDateOpen { get; set; }
        public string sParm { get; set; }
    }
}
