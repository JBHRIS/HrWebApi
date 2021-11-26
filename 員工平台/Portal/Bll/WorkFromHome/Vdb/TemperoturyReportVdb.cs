using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.WorkFromHome.Vdb
{
    public class TemperoturyReportVdb
    {
    }

    public class TemperoturyReportConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }


    public class TemperoturyReportApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public DateTime AttendDate { get; set; }
            public string ReportType { get; set; }
            public string Description { get; set; }
            public Decimal Temperotury { get; set; }
            public string KeyMan { get; set; }
            public Decimal AutoKey { get; set; }
            public Guid Guid { get; set; }
        }

        public List<Result> result { get; set; }

    }

    public class TemperoturyReportRow 
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public int AutoKey { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Guid Guid { get; set; }
    }
}