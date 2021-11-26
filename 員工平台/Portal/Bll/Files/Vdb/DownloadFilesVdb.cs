using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Files.Vdb
{
    public  class DownloadFilesVdb
    {
    }

    public class DownloadFilesConditions : DataConditions
    { 
        public string fileGuid { get; set; }
    }
    
    public class DownloadFilesApiRow : StandardDataBaseApiRow
    {
    }

    public class DownloadsFileRow
    {
    }
}
