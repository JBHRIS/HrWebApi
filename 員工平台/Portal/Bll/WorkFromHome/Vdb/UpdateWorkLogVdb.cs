using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.WorkFromHome.Vdb
{
    public class UpdateWorkLogVdb
    {
    }

    public class UpdateWorkLogConditions : DataConditions
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


    public class UpdateWorkLogApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }

    }

    public class UpdateWorkLogRow : StandardDataRow
    {
        public string result { get; set; }
    }
}