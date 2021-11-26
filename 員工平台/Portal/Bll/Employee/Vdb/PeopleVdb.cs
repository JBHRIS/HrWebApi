using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class PeopleVdb
    {
    }

    public class PeopleConditions : DataConditions
    {
    }


    public class PeopleApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string employeeId { get; set; }
            public string employeeName { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class PeopleRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
    }
}