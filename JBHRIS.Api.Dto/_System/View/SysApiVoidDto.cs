using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysApiVoidDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RoutePath { get; set; }
    }
}
