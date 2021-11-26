using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class AnnualLeaveVdb
    {
    }

    public class AnnualLeaveConditions : DataConditions
    { 
        public string YYMM { get; set; }
        public string Seq { get; set; }
    }
    
    public class AnnualLeaveApiRow : StandardDataBaseApiRow
    {
        
        public Decimal result { get; set; }
    }

    public class AnnualLeaveRow
    {
        public Decimal Hour { get; set; }
    }
}
