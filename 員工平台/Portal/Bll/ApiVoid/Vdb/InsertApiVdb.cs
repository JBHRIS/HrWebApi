using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoid.Vdb
{
  public  class InsertApiVoidVdb
    {
    }

    public class InsertApiVoidConditions : DataConditions
    {
        public string name { get; set; }
        public string routePath { get; set; }
    }
    
    public class InsertApiVoidApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class InsertApiVoidRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
