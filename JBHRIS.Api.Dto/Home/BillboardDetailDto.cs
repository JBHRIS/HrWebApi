using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Home
{
    public class BillboardDetailDto
    {
        public int IAutoKey { get; set; }
        public string NewsId { get; set; }
        public string NewsHead { get; set; }
        public string NewsBody { get; set; }
        public DateTime PostDate { get; set; }
        public int FileCount { get; set; }
        public int BrowseCount { get; set; }
        public string Newsfileid { get; set; }
        public string KeyMan { get; set; }
    }
}
