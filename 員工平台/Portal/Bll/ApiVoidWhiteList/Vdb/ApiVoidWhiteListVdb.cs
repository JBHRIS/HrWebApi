using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoidWhiteList.Vdb
{
  public  class ApiVoidWhiteListVdb
    {
    }

    public class ApiVoidWhiteListConditions : DataConditions
    {
        public List<string> EmpList { get; set; }
    }
    
    public class ApiVoidWhiteListApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string nobr { get; set; }
            public List<string> apiVoidCode { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class ApiVoidWhiteListRow
    {
        public List<string> ApiVoidCode { get; set; }
    }
}
