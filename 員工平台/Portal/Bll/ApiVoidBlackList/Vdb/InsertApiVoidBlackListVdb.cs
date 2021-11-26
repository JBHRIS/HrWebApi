using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoidBlackList.Vdb
{
  public  class InsertApiVoidBlackListVdb
    {
    }

    public class InsertApiVoidBlackListConditions : DataConditions
    { 
        public string nobr { get; set; }
        public string apiVoidCode { get; set; }
    }
    
    public class InsertApiVoidBlackListApiRow : StandardDataBaseApiRow
    {
         public bool result { get; set; }
    }

    public class InsertApiVoidBlackListRow
    {
         public bool Result { get; set; }

    }
}
