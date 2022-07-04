using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysPageApiVoidDto
    {
        public int AutoKey { get; set; }
        public string PageCode { get; set; }
        public string ApiVoidCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyName { get; set; }
    }
}
