using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.News.Vdb
{
  public  class NewsVdb
    {
    }
    public class NewsConditions : DataConditions
    { 
    
    }
    
    public class NewsApiRow : StandardDataBaseApiRow
    {
        public class Result
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
        public List<Result> result { get; set; }

    }
    public class NewsRow
    {
        public string NewsTitle { get; set; }
        public string NewsMain { get; set; }
        public int NewsId { get; set; }
        public DateTime NewsDate { get; set; }
        public DateTime NewsDeadLine { get; set; }
        public bool IsOn { get; set; }
    }
}
