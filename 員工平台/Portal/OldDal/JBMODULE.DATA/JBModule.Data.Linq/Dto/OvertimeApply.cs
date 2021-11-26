using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class OvertimeApply
    {
        public string EmployeeID;
        public DateTime AttendDate;
        public DateTime ApplyBeginDate;
        public DateTime ApplyEndDate;
        public string OtRote;
        public OverTimeType OtType;
        public enum OverTimeType
        {
            OtHours,
            RestHours,
        }
    }
}
