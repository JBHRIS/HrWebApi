using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoidWhiteList.Vdb
{
  public  class DeleteApiVoidWhiteListVdb
    {
    }

    public class DeleteApiVoidWhiteListConditions : DataConditions
    {
        public List<string> EmpList { get; set; }
        public List<string> apiVoidCode { get; set; }
    }
    
    public class DeleteApiVoidWhiteListApiRow : StandardDataBaseApiRow
    {
        
        public bool result { get; set; }
    }

    public class DeleteApiVoidWhiteListRow
    {
        public bool Result { get; set; }

    }
}
