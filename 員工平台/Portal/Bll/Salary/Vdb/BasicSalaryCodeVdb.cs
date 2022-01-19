using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
    public class BasicSalaryCodeVdb
    {
    }

    public class BasicSalaryCodeConditions : DataConditions
    {
        public string nobr { get; set; }
        public DateTime CheckDate { get; set; }
    }


    //public class EmployeeInfoApiRow : StandardDataBaseApiRow
    //{
    //    public ResultApiRow result { get; set; }
    //    public class ResultApiRow
    //    {

    //    }
    //}


    public class BasicSalaryCodeApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string SalCode1 { get; set; }
            public string SalCodeDisp { get; set; }
            public string SalName { get; set; }
            public string SalAttr { get; set; }
            public Decimal Sort { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class BasicSalaryCodeRow : StandardDataRow
    {
        public string SalCode { get; set; }
        public string SalCodeDisp { get; set; }
        public string SalName { get; set; }
        public string SalAttr { get; set; }
    }
}