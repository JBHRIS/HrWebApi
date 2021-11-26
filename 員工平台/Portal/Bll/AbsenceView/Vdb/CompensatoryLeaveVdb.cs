using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.AbsenceView.Vdb
{
  public  class CompensatoryLeaveVdb
    {
    }
    public class CompensatoryLeaveConditions : DataConditions
    {
        public DateTime dateTime { get; set; }
    }

    public class CompensatoryLeaveApiRow : StandardDataBaseApiRow
    {
        
        public decimal result { get; set; }
        

    }
    public class CompensatoryLeaveRow
    {
        public decimal Result { get; set; }

    }
}
