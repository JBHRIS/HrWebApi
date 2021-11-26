using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class SalaryVdb
    {
    }

    public class SalaryConditions : DataConditions
    { 
    }
    
    public class SalaryApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string code { get; set; }
            public string name { get; set; }
            public bool isAdminRole { get; set; }
            public bool isVisible { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class SalaryRow
    {
        public class SalaryData
        { 
            public string Item { get; set; }
            public string Salary { get; set; }
            public SalaryData()
            {
                Item = "";
                Salary = "0";
            }
        }
        public string Title { get; set; }
        public List<SalaryData> Details { get; set; }
        public SalaryData Sum { get; set; }
        public string SalaryView { get; set; }
        public SalaryRow()
        {
            Details = new List<SalaryData>();
            Sum = new SalaryData();
        }
    }
}
