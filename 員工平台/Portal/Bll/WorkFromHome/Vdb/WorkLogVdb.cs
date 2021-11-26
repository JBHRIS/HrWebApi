using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.WorkFromHome.Vdb
{
    public class WorkLogVdb
    {
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public DateTime DateB { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string Note { get; set; }
        public string GUID { get; set; }

    }

    public class WorkLogConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }


    public class WorkLogApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public DateTime AttendDate { get; set; }
            public string BeginTime { get; set; }
            public string EndTime { get; set; }
            public Decimal WorkHours { get; set; }
            public string Workitem { get; set; }
            public string Description { get; set; }
            public string FileId { get; set; }
        }

        public List<Result> result { get; set; }

    }

    public class WorkLogRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime Date { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public Decimal Hours { get; set; }
        public string Type { get; set; }
        public string Guid { get; set; }
    }
}