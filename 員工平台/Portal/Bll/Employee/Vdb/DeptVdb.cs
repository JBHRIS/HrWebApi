using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class DeptVdb
    {
    }

    public class DeptConditions : DataConditions
    {
    }


    public class DeptApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string departmentId { get; set; }
            public string departmentName { get; set; }
            public string departmentNameE { get; set; }
            public string departmentParentId { get; set; }
            public string departmentManager { get; set; }
            public string departmentIdDisplay { get; set; }
            public string departmentLevel { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class DeptRow : StandardDataRow
    {
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
    }
}