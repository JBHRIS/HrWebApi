using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class DeptaVdb
    {
    }

    public class DeptaConditions : DataConditions
    {
    }


    public class DeptaApiRow : StandardDataBaseApiRow
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

    public class DeptaRow : StandardDataRow
    {
        public string DeptaCode { get; set; }
        public string DeptaName { get; set; }
    }
}