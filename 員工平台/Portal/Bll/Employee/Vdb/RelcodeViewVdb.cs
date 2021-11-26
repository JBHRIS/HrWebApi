using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public  class RelcodeViewVdb
    {
    }

    public class RelcodeViewConditions : DataConditions
    {
    }

    //public class EmployeeViewApiRow : StandardDataBaseApiRow
    //{
    //    public ResultApiRow result { get; set; }
    //    public class ResultApiRow
    //    {

    //    }
    //}

    public class RelcodeViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string relCode1 { get; set; }
            public string relName { get; set; }
        }
        public List<Result> result { get; set; }
        

    }
    public class RelcodeViewRow : StandardDataRow
    {
        public string Relcode { get; set; }
        public string RelName { get; set; }
    }
}
