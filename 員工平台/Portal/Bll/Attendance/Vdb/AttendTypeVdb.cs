using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Attendance.Vdb
{
  public  class AttendTypeVdb
    {
    }
    public class AttendTypeConditions : DataConditions
    { 
    
    }
    
    public class AttendTypeApiRow : StandardDataBaseApiRow
    {
        public class ResultApi
        {
            public string code { get; set; }
            public string name { get; set; }
            public int sort { get; set; }
            public bool display { get; set; }
        }
        public List<ResultApi> result { get; set; }
        
    }
    public class AttendTypeRow : StandardDataRow
    {
        public bool Display { get; set; }

    }
}
