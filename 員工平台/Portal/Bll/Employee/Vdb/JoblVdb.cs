using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class JoblVdb
    {
    }

    public class JoblConditions : DataConditions
    {
    }


    public class JoblApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string jobId { get; set; }
            public string jobName { get; set; }
            public string jobNameE { get; set; }
            public string jobIdDisplay { get; set; }
            public string jobLevel { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class JoblRow : StandardDataRow
    {
        public string JoblCode { get; set; }
        public string JoblName { get; set; }
    }
}