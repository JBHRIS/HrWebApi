using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Files
{
    public class FileInfoDto
    {
        public int FileId { get; set; }
        public string FileGuid { get; set; }
        public string FileName { get; set; }
        public string ExtensionName { get; set; }
        public string FullName { get; set; }
        public byte[] FileStream { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public string FileTicket { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
