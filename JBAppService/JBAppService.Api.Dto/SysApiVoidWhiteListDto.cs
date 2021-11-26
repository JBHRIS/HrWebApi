using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class SysApiVoidWhiteListDto
    {
        public string Nobr { get; set; }
        public List<string> ApiVoidCode { get; set; }
    }
}
