using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Files.Vdb
{
  public  class FilesByFileTicketVdb
    {
    }

    public class FilesByFileTicketConditions : DataConditions
    { 
        public string fileTicket { get; set; }
    }
    
    public class FilesByFileTicketApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public int fileId { get; set; }
            public string fileGuid { get; set; }
            public string fileName { get; set; }
            public string extensionName { get; set; }
            public string fullName { get; set; }
            public string fileStream { get; set; }
            public string contentType { get; set; }
            public int fileSize { get; set; }
            public string fileTicket { get; set; }
            public string createMan { get; set; }
            public DateTime createTime { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class FilesByFileTicketRow
    {
        public string FileId { get; set; }
        public string FileGuid { get; set; }
        public string FileSize { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }

    }
}
