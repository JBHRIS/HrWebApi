using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoid.Vdb
{
    public  class UpdateApiVoidVdb
    {
    }

    public class UpdateApiVoidConditions : DataConditions
    {
        public string name { get; set; }
        public string routePath { get; set; }
    }
    
    public class UpdateApiVoidApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class UpdateApiVoidRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
