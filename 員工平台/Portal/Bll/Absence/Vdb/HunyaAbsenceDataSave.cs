using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
    public class HunyaAbsenceDataSaveVdb
    {
    }
    public class HunyaAbsenceDataSaveConditions : DataConditions
    {
        public DateTime atteendDate { get; set; }
        public string onTime { get; set; }
        public string offTime { get; set; }
        public string nobr { get; set; }
    }
    
    public class HunyaAbsenceDataSaveApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public bool pass { get; set; }
            public string sessionid { get; set; }
        }
        public Result result { get; set; }

    }
    public class HunyaAbsenceDataSaveRow : StandardDataRow
    {
        public bool pass { get; set; }
    }
}
