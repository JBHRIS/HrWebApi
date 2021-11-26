using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.AbsenceView.Vdb
{
  public  class AnnualLeaveVdb
    {
    }
    public class AnnualLeaveConditions : DataConditions
    {
        public DateTime dateTime { get; set; }
    }

    public class AnnualLeaveApiRow : StandardDataBaseApiRow
    {
        
        public decimal result { get; set; }
        

    }
    public class AnnualLeaveRow
    {
        public decimal Result { get; set; }

    }
}
