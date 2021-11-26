using System;

namespace Bll.WorkFromHome.Vdb
{
    public class InsertTemperoturyReportVdb
    {
    }

    public class InsertTemperoturyReportConditions : DataConditions
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendDate { get; set; }
        public string ReportType { get; set; }
        public Decimal Temperotury { get; set; }
        public string Description { get; set; }
        public string KeyMan { get; set; }
        public Guid Guid { get; set; }
        public InsertTemperoturyReportConditions()
        {
            Description = "";
            AutoKey = 0;
            Guid = Guid.NewGuid();
        }
    }


    public class InsertTemperoturyReportApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class InsertTemperoturyReportRow : StandardDataRow
    {
        public string result { get; set; }
    }
}