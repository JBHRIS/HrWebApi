using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class Menu
    {
        public string sCode { get; set; }
        public string sName { get; set; }
        public string sParentCode { get; set; }
        public int iSort { get; set; }
    }
}
