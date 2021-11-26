using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Card.Vdb
{
  public  class CardVdb
    {
    }
    public class CardConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class CardApiRow
    {
        public string employeeID { get; set; }
        public DateTime puchInDate { get; set; }
        public string puchInTime { get; set; }
        public string source { get; set; }
        public bool forget { get; set; }
        public string forgetReason { get; set; }
        public string remarks { get; set; }
    }
    public class CardRow
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public DateTime CardDate { get; set; }
        public string CardTime { get; set; }
        public string ForgetReason { get; set; }
        public string Note { get; set; }
    }
}
