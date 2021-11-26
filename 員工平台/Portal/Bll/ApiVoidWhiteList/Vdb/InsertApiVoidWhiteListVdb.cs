using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoidWhiteList.Vdb
{
  public  class InsertApiVoidWhiteListVdb
    {
    }

    public class InsertApiVoidWhiteListConditions : DataConditions
    {
        public List<string> EmpList { get; set; }
        public List<string> apiVoidCode { get; set; }
    }
    
    public class InsertApiVoidWhiteListApiRow : StandardDataBaseApiRow
    {
        
        public bool result { get; set; }
    }

    public class InsertApiVoidWhiteListRow
    {
        public bool Result { get; set; }

    }
}
