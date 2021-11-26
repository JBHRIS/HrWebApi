using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class SalaryLockVdb
    {
    }

    public class SalaryLockConditions : DataConditions
    { 
    }
    
    public class SalaryLockApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string saladr { get; set; }
            public string yymm { get; set; }
            public string seq { get; set; }
            public string meno { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class SalaryLockRow
    {
        public string SalaryType { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalaryList { get; set; }
        public string TotalValue { get; set; }
    }
}
