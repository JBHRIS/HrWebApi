using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ApiVoid.Vdb
{
  public  class DeleteApiVoidVdb
    {
    }

    public class DeleteApiVoidConditions : DataConditions
    {
    }
    
    public class DeleteApiVoidApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class DeleteApiVoidRow : StandardDataRow
    {
        public string Result { get; set; }
    }
}
