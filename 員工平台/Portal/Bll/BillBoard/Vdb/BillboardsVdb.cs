using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.BillBoard.Vdb
{
  public  class BillboardsVdb
    {
    }
    public class BillboardsConditions : DataConditions
    { 
    
    }
    
    public class BillboardsApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public int iAutoKey { get; set; }
            public string newsId { get; set; }
            public string newsHead { get; set; }
            public string newsBody { get; set; }
            public DateTime postDate { get; set; }
            public string fileCount { get; set; }
            public string browseCount { get; set; }
            public int sort { get; set; }
            public string keyMan { get; set; }
        }
        public List<Result> result { get; set; }

    }
    public class BillboardsRow : StandardDataRow
    {
        public string NewsTitle { get; set; }
        public string NewsMain { get; set; }
        public DateTime NewsDate { get; set; }
        public int NewsKey { get; set; }
        public string Tab { get; set; }
        public string NewsContent { get; set; }
        public bool IsNew { get; set; }
    }
}
