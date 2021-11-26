using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Files.Vdb
{
    public  class DeleteFilesVdb
    {
    }

    public class DeleteFilesConditions : DataConditions
    { 
        public string fileGuid { get; set; }
    }
    
    public class DeleteFilesApiRow : StandardDataBaseApiRow
    {
    }

    public class DeleteFilesRow
    {
        public bool Result { get; set; }
    }
}
