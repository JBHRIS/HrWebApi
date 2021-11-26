using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.BillBoard.Vdb
{
  public  class BillboardsByIdVdb
    {
    }
    public class BillboardsByIdConditions : DataConditions
    { 
        public string id { get; set; }
    }
    
    public class BillboardsByIdApiRow : StandardDataBaseApiRow
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
            public string newsfileid { get; set; }
        }
        public Result result { get; set; }

    }
    public class BillboardsByIdRow : StandardDataRow
    {
        public int ID { get; set; }
        public DateTime ContentDate { get; set; }
        public string Content { get; set; }
        public string ContentTitle { get; set; }
        public string FileId { get; set; }
    }
}
