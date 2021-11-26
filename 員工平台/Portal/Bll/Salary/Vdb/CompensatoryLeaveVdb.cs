using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class CompensatoryLeaveVdb
    {
    }

    public class CompensatoryLeaveConditions : DataConditions
    { 
        public string YYMM { get; set; }
        public string Seq { get; set; }
    }
    
    public class CompensatoryLeaveApiRow : StandardDataBaseApiRow
    {
        
        public Decimal result { get; set; }
    }

    public class CompensatoryLeaveRow
    {
        public Decimal Hour { get; set; }
    }
}
