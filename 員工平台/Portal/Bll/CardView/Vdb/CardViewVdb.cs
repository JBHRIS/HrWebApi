using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.CardView.Vdb
{
    public class CardViewVdb
    {
    }
    public class CardViewConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public bool isForget { get; set; }
    }

    public class CardViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeID { get; set; }
            public string employeeName { get; set; }
            public string deptCode { get; set; }
            public string deptName { get; set; }
            public DateTime puchInDate { get; set; }
            public string puchInTime { get; set; }
            public bool forget { get; set; }
            public string forgetReason { get; set; }
            public string remarks { get; set; }
        }
        public List<Result> result { get; set; }

    }
    public class CardViewRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime DateA { get; set; }
        public string AttcardTime { get; set; }
        public string ForgetReason { get; set; }
        public int DetailAutokey { get; set; }
    }
}
