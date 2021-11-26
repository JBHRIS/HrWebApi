using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoidBlackList.Vdb
{
  public  class ApiVoidBlackListVdb
    {
    }

    public class ApiVoidBlackListConditions : DataConditions
    { 
        public List<string> EmpList { get; set; }
    }
    
    public class ApiVoidBlackListApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string nobr { get; set; }
            public List<string> apiVoidCode { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class ApiVoidBlackListRow
    {
        public List<string> ApiVoidCode { get; set; }
    }
}
