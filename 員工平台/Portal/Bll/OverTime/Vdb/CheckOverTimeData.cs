using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.OverTime.Vdb
{
  public  class CheckOverTimeDataVdb
    {
    }
    public class CheckOverTimeDataConditions : DataConditions
    {
        public List<OverTimeByDateRow> lsOvertime { get; set; }
    }

    public class CheckOverTimeDataApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string EmployeeId { get; set; }
            public Decimal TotHours { get; set; }
        }
        public List<Result> result { get; set; }
        
    }
    public class CheckOverTimeDataRow 
    {
        public string EmpId { get; set; }
        public Decimal TotHours { get; set; }

    }
}
