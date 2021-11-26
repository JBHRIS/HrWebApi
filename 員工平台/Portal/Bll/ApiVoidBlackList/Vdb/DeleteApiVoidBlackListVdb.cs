using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoidBlackList.Vdb
{
    public  class DeleteApiVoidBlackListVdb
    {
    }

    public class DeleteApiVoidBlackListConditions : DataConditions
    { 
        public string nobr { get; set; }
        public string apiVoidCode { get; set; }
    }
    
    public class DeleteApiVoidBlackListApiRow : StandardDataBaseApiRow
    {
         public bool result { get; set; }
    }

    public class DeleteApiVoidBlackListRow
    {
         public bool Result { get; set; }

    }
}
