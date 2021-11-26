using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoid.Vdb
{
  public  class ApiVoidVdb
    {
    }

    public class ApiVoidConditions : DataConditions
    { 
    }
    
    public class ApiVoidApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string code { get; set; }
            public string name { get; set; }
            public string routePath { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class ApiVoidRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RoutePath { get; set; }
    }
}
