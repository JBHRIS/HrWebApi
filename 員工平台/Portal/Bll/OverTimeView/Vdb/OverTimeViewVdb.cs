using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.OverTimeView.Vdb
{
  public  class OverTimeViewVdb
    {
    }
    public class OverTimeViewConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class OverTimeViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeID { get; set; }
            public string employeeName { get; set; }
            public string deptCode { get; set; }
            public string deptName { get; set; }
            public DateTime overTimeDate { get; set; }
            public string beginTime { get; set; }
            public string endTime { get; set; }
            public string overTimeTotalHours { get; set; }
            public string overTimeHours { get; set; }
            public string restTimeHours { get; set; }
            public string overTimeReason { get; set; }
            public string remarks { get; set; }
            public string yymm { get; set; }
        }
        public List<Result> result { get; set; }
        
    }
    public class OverTimeViewRow 
    {
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public DateTime DateA { get; set; }
        public string OtBeginTime { get; set; }
        public string OtEndTime { get; set; }
        public string TotalTime { get; set; }
        public string OtTime { get; set; }
        public string RestTime { get; set; }
        public string OtReason { get; set; }
        public string Yymm { get; set; }
        public string Note { get; set; }
    }
}
