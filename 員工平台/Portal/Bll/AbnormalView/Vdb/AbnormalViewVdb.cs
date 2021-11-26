using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.AbnormalView.Vdb
{
  public  class AbnormalViewVdb
    {
    }
    public class AbnormalViewConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public bool isNoCheck { get; set; }
    }

    public class AbnormalViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeID { get; set; }
            public string employeeName { get; set; }
            public string deptCode { get; set; }
            public string deptName { get; set; }
            public DateTime attendDate { get; set; }
            public string abnormalType { get; set; }
            public string abnormalName { get; set; }
            public string abnormalErrorMins { get; set; }
            public string roteOnTime { get; set; }
            public string roteOffTime { get; set; }
            public string cardOnTime { get; set; }
            public string cardOffTime { get; set; }
            public string roteName { get; set; }
            public bool isCheck { get; set; }
            public string remarkType { get; set; }
            public string remarkTypeName { get; set; }
            public string serno { get; set; }
        }
        public List<Result> result { get; set; }
        
    }
    public class AbnormalViewRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime DateA { get; set; }
        public string AbnormalType { get; set; }
        public string AbnormalMin { get; set; }
        public string RoteName { get; set; }
        public string AttcardTime { get; set; }
        public string Marked { get; set; }
        public string MarkNote { get; set; }
    }
}
