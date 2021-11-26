using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace JBHRIS.BLL.Dto
{
    public class FileStreamInfoDto
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string ExtensionName { get; set; }
        public string FullName { get; set; }
        public Stream FileStream { get; set; }
        public long FileSize { get; set; }
        public string FileTicket { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
