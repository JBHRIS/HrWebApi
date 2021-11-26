using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
  public  class CardReasonVdb
    {
    }
    public class CardReasonCondition : DataConditions
    {
        public List<string> employeeList { get; set; }
    }



    public class CardReasonApiRow
    {
        public string employeeId { get; set; }
        public string employeeName { get; set; }

    }
    public class CardReasonRow
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
    }
}
