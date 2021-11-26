using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public class NewsDto
    {
        public int IAutoKey { get; set; }
        public string NewsId { get; set; }
        public string NewsHead { get; set; }
        public string NewsBody { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDeadline { get; set; }
        public bool IsOn { get; set; }
        public string Newsfileid { get; set; }
        public long Sort { get; set; }
        public string KeyMan { get; set; }
    }
}
