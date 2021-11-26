using System;
using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class PeopleApDateVdb
    {
    }

    public class PeopleApDateConditions : DataConditions
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public class PeopleApDateApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string empId { get; set; }
            public DateTime indtDate { get; set; }
            public DateTime apDate { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class PeopleApDateRow : StandardDataRow
    {
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public DateTime IndtDate { get; set; }
        public DateTime ApDate { get; set; }
    }
}