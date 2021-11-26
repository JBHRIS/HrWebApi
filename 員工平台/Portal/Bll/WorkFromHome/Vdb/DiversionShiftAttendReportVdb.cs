using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.WorkFromHome.Vdb
{
    public class DiversionShiftAttendReportVdb
    {
    }

    public class DiversionShiftAttendReportConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }


    public class DiversionShiftAttendReportApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public DateTime AttendDate { get; set; }
            public string Rote { get; set; }
            public string RoteName { get; set; }
            public string CardOnTime { get; set; }
            public string CardOffTime { get; set; }
            public string Location { get; set; }
            public string DiversionGroup { get; set; }
            public string DiversionGroupName { get; set; }
            public string DiversionAttendType { get; set; }
            public string DiversionAttendTypeName { get; set; }
            public List<string> AttendErrorList { get; set; }
        }

        public List<Result> result { get; set; }

    }

    public class DiversionShiftAttendReportRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string DiversionGroupName { get; set; }
        public string DiversionTypeName { get; set; }
        public List<string> ErrorList { get; set; }
    }
}