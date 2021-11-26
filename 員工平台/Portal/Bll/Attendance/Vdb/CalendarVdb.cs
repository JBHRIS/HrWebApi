using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Attendance.Vdb
{
  public  class CalendarVdb
    {
    }

    public class CalendarConditions : DataConditions
    { 
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public List<string> attendTypeList { get; set; }
    }
    
    public class CalendarApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeId { get; set; }
            public DateTime calendarDate { get; set; }
            public string calendarType { get; set; }
            public string beginTime { get; set; }
            public string endTime { get; set; }
            public string remark { get; set; }
            public string color { get; set; }
            public decimal use { get; set; }
            public string name { get; set; }
            public int sort { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class CalendarRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public  DateTime AttendDate { set; get; }
        public string AttendTypeCode { get; set; }
        public new  string Name { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string Color { get; set; }
        public decimal Use { get; set; }
        public string Remark { get; set; }
    }
}
