﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysApiVoidBlackListDto
    {
        public string Nobr { get; set; }
        public List<string> ApiVoidCode { get; set; }
    }
}
