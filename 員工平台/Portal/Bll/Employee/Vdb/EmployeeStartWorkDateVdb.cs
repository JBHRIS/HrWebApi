using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public  class EmployeeStartWorkDateVdb
    {
    }

    public class EmployeeStartWorkDateConditions : DataConditions
    {
        public string EmployeeID { get; set; }
    }

    public class EmployeeStartWorkDateApiRow : StandardDataBaseApiRow
    {
        public DateTime result { get; set; }
        

    }
    public class EmployeeStartWorkDateRow : StandardDataRow
    {
        public DateTime WorkDate { get; set; }
    }
}
