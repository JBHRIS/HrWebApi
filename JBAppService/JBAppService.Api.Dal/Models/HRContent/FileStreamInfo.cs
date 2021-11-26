using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class FileStreamInfo
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string ExtensionName { get; set; }
        public string FullName { get; set; }
        public byte[] FileStream { get; set; }
        public long FileSize { get; set; }
        public string FileTicket { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
