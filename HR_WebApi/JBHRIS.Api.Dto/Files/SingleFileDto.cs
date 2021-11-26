using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Files
{
    public class SingleFileDto
    {
        public string FileGuid { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileSize { get; set; }
        public string FileTicket { get; set; }
    }
}
