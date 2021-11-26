using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.WorkFromHome.Vdb
{
    public class DeleteWorkLogVdb
    {
    }

    public class DeleteWorkLogConditions : DataConditions
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
        public string KeyMan { get; set; }
        public Guid Guid { get; set; }
    }


    public class DeleteWorkLogApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }

    }

    public class DeleteWorkLogRow : StandardDataRow
    {
        public string result { get; set; }
    }
}