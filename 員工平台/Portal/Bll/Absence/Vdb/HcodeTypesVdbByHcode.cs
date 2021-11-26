using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
  public  class HcodeTypesByHcodeVdb
    {
    }
    public class HcodeTypesByHcodeConditions : DataConditions
    {
        public List<string> htype { get; set; }
        public List<string> flag { get; set; }
    }
    
    public class HcodeTypesByHcodeApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string hCode { get; set; }
            public string hCodeName { get; set; }
            public string hCodeUnit { get; set; }
            public string flag { get; set; }
            public string htype { get; set; }
        }
        public List<Result> result { get; set; }

    }
    public class HcodeTypesByHcodeRow : StandardDataRow
    {
        public string Hcode { get; set; }
        public string HCodeName { get; set; }
    }
}
