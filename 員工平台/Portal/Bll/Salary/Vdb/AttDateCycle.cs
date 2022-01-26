using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class AttDateCycleVdb
    {
    }

    public class AttDateCycleConditions : DataConditions
    { 
        public string nobr { get; set; }
        public DateTime date { get; set; }
    }
    
    public class AttDateCycleApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
           public DateTime attDateB { get; set; }
           public DateTime attDateE { get; set; }
        }
        public Result result { get; set; }
    }

    public class AttDateCycleRow
    {
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
    }
}
