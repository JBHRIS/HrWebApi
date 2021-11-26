using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class EmployeeJobStatusAddChangeVdb
    {
    }

    public class EmployeeJobStatusAddChangeConditions : DataConditions
    {
        public JobStatus TTS { get; set; }
    }
    public class EmployeeJobStatusAddChangeApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class EmployeeJobStatusAddChangeRow : StandardDataRow
    {
       public string Result { get; set; }
    }
}