using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
  public  class HcodeTypesVdb
    {
    }
    public class HcodeTypesConditions : DataConditions
    { 
    
    }
    
    public class HcodeTypesApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string htype { get; set; }
            public string typeName { get; set; }
            public string getCode { get; set; }
            public int sort { get; set; }
            public string yearMax { get; set; }
            public bool autoCreateHours { get; set; }
            public bool mergeDisplay { get; set; }
            public string unit { get; set; }
            public DateTime keyDate { get; set; }
            public string keyMan { get; set; }
            public string extendCode { get; set; }
            public string expireCode { get; set; }
        }
        public List<Result> result { get; set; }

    }
    public class HcodeTypesRow : StandardDataRow
    {
        public string Htype { get; set; }
        public string TypeName { get; set; }
    }
}
