using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class AllPassTypeVdb
    {
    }

    public class AllPassTypeConditions : DataConditions
    {
    }


    public class AllPassTypeApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public decimal sort { get; set; }
            public bool Display { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class AllPassTypeRow : StandardDataRow
    {
        public string AllPassTypeCode { get; set; }
        public string AllPassTypeName { get; set; }
    }
}