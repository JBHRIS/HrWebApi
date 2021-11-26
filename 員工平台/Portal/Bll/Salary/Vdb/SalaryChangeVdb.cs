using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
    public class SalaryChangeVdb
    {
    }

    public class SalaryChangeConditions : DataConditions
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


    public class SalaryChangeApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string Nobr { get; set; }
            public string SalCode { get; set; }
            public string SalName { get; set; }
            public Decimal Amt { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class SalaryChangeRow : StandardDataRow
    {
        public string Nobr { get; set; }
        public string SalCode { get; set; }
        public string SalName { get; set; }
        public Decimal Amount { get; set; }
        public string DESData { get; set; }
    }
}