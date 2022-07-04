using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysPageToApiVoidDto
    {
        public string PageCode { get; set; }
        public string PageName { get; set; }
        public List<SysApiVoidDto> HaveApiVoid { get; set; }
    }
}
