using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.OverTime.Vdb
{
  public  class OverTimeByDateVdb
    {
    }
    public class OverTimeByDateConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class OverTimeByDateApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string EmployeeId { get; set; }
            public DateTime OvertimeDate { get; set; }
            public string BeginTime { get; set; }
            public string EndTime { get; set; }
            public int OvertimeHours { get; set; }
            public int ExpenseHours { get; set; }
            public int RestHours { get; set; }
        }
        public List<Result> result { get; set; }
        
    }
    public class OverTimeByDateRow 
    {
        public string EmpId { get; set; }
        public DateTime OvertimeDate { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public int OvertimeHours { get; set; }
        public int ExpenseHours { get; set; }
        public int RestHours { get; set; }

    }
}
