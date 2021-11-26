using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JBHRIS.BLL.Dto;
namespace JBHRIS.BLL.Service
{
    public abstract class FileStreamService
    {
        public virtual FileStreamInfoDto Download(object ID)
        {
            return null;
        }
        public virtual List<FileStreamInfoDto> DownloadByTicket(string Ticket)
        {
            return new List<FileStreamInfoDto>();
        }
        public virtual bool Upload(FileStreamInfoDto file)
        {
            return false;
        }
        public virtual bool Delete(FileStreamInfoDto file)
        {
            return false;
        }
    }

}
