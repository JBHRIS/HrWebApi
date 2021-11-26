using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.News.Vdb
{
  public  class NewsByIdVdb
    {
    }
    public class NewsByIdConditions : DataConditions
    { 
        public string id { get; set; }
    }
    
    public class NewsByIdApiRow : StandardDataBaseApiRow
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
        public Result result { get; set; }

    }
    public class NewsByIdRow : StandardDataRow
    {
        public DateTime PostDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string ContentTitle { get; set; }
        public string Content { get; set; }
        public string ContentId { get; set; }
        public bool IsOn { get; set; }
        public string FileTicket { get; set; }
        public NewsByIdRow()
        {
            PostDate = DateTime.Now;
            DeadLine = DateTime.Now.AddMonths(+1).AddDays(-1);
            ContentTitle = "";
            Content = "";
            ContentId = "New";
            AutoKey = 0;
            IsOn = false;
        }
            
    }
}
