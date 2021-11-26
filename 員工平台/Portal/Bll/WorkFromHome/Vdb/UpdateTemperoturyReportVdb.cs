using System;

namespace Bll.WorkFromHome.Vdb
{
    public class UpdateTemperoturyReportVdb
    {
    }

    public class UpdateTemperoturyReportConditions : DataConditions
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendDate { get; set; }
        public string ReportType { get; set; }
        public Decimal Temperotury { get; set; }
        public string Description { get; set; }
        public string KeyMan { get; set; }
        public Guid Guid { get; set; }
        public UpdateTemperoturyReportConditions()
        {
            Description = "";
            AutoKey = 0;
            Guid = Guid.NewGuid();
        }
    }


    public class UpdateTemperoturyReportApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class UpdateTemperoturyReportRow : StandardDataRow
    {
        public string result { get; set; }
    }
}