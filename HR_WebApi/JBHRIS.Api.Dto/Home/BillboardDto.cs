using System;

namespace JBHRIS.Api.Home
{
    public class BillboardDto
    {
        public int IAutoKey { get; set; }
        public string NewsId { get; set; }
        public string NewsHead { get; set; }
        public string NewsBody { get; set; }
        public DateTime PostDate { get; set; }
        public int FileCount { get; set; }
        public int BrowseCount { get; set; }
        public long Sort { get; set; }
        public string KeyMan { get; set; }
    }
}