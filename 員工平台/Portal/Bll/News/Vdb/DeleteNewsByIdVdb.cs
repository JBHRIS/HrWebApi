using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.News.Vdb
{
  public  class DeleteNewsByIdVdb
    {
    }
    public class DeleteNewsByIdConditions : DataConditions
    {
        public string id { get; set; }
    }
    
    public class DeleteNewsByIdApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }

    }
    public class DeleteNewsByIdRow : StandardDataRow
    {
        
    }
}
