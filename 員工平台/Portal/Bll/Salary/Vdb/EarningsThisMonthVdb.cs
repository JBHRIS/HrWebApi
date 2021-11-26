using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class EarningsThisMonthVdb
    {
    }

    public class EarningsThisMonthConditions : DataConditions
    { 
        public string yymm { get; set; }
        public string seq { get; set; }
        public string password { get; set; }
    }
    
    public class EarningsThisMonthApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string title { get; set; }
            public string number { get; set; }
            public string init { get; set; }
            public string memo { get; set; }
            
        }
        public List<Result> result { get; set; }
    }

    public class EarningsThisMonthRow
    {
    }
}
