using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Web;

namespace Bll.Files.Vdb
{
    public  class UploadSingleFileVdb
    {
    }

    public class UploadSingleFileConditions : DataConditions
    { 
        public HttpFileCollection file { get; set; }
    }
    
    public class UploadSingleFileApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string fileGuid { get; set; }
            public string fileName { get; set; }
            public string contentType { get; set; }
            public int fileSize { get; set; }
            public string fileTicket { get; set; }
        }
        public Result result { get; set; }
        
    }

    public class UploadSingleFileRow
    {
        public string FileName { get; set; }
        public string FileGuid { get; set; }
        public string FileTicket { get; set; }
        
    }
}
