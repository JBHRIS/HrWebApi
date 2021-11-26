using System;
using System.Collections.Generic;

namespace Bll.Employee.Vdb
{
    public class EffEmployeeViewVdb
    {
    }

    public class EffEmployeeViewConditions : DataConditions
    {
        public string empID { get; set; }
        public List<string> yymm { get; set; }
    }


    public class EffEmployeeViewApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public string EmpId { get; set; }
            public string Yymm { get; set; }
            public string EfflvlCode { get; set; }
            public string EfflvlName { get; set; }
            public Decimal EffScore { get; set; }
            public string EfftypeCode { get; set; }
            public string EfftypeName { get; set; }
            public bool Import { get; set; }
            public DateTime KeyDate { get; set; }
            public string KeyMan { get; set; }
        }
        public List<Result> result { get; set; }
        
    }

    public class EffEmployeeViewRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public string EffCode{ get; set; }
        public string EffName { get; set; }
        public string EffTypeCode{ get; set; }
        public string EffTypeName { get; set; }
        public Decimal EffScore { get; set; }

    }
}