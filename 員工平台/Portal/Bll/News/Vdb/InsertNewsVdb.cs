using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.News.Vdb
{
  public  class InsertNewsVdb
    {
    }
    public class InsertNewsConditions : DataConditions
    {
        public int iAutoKey { get; set; }
        public string newsId { get; set; }
        public string newsHead { get; set; }
        public string newsBody { get; set; }
        public DateTime postDate { get; set; }
        public DateTime postDeadline { get; set; }
        public bool isOn { get; set; }
        public string newsfileid { get; set; }
        public int sort { get; set; }
    }
    
    public class InsertNewsApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }

    }
    public class InsertNewsRow : StandardDataRow
    {
        
    }
}
