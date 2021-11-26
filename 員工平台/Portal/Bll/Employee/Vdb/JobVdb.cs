using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class JobVdb
    {
    }

    public class JobConditions : DataConditions
    {
    }


    public class JobApiRow : StandardDataBaseApiRow
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

    public class JobRow : StandardDataRow
    {
        public string JobCode { get; set; }
        public string JobName { get; set; }
    }
}