using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class StatusResultDto
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
