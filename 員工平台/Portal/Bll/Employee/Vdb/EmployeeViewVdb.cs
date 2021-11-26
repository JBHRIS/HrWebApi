using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
  public  class EmployeeViewVdb
    {
    }

    public class EmployeeViewConditions : DataConditions
    {
        public List<string> ListEmpId { get; set; }
    }

    //public class EmployeeViewApiRow : StandardDataBaseApiRow
    //{
    //    public ResultApiRow result { get; set; }
    //    public class ResultApiRow
    //    {

    //    }
    //}

    public class EmployeeViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeId { get; set; }
            public string employeeName { get; set; }
        }
        public List<Result> result { get; set; }
        

    }

    public class EmployeeViewRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
    }
}
