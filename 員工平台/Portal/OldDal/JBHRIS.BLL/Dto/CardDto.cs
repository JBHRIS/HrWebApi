using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class CardDto
    {
        public string EmployeeID { get; set; }
        public DateTime CardTime { get; set; }
        public string Remark { get; set; }
        public bool ForgetCard { get; set; }
    }
    //public enum ForgetCardType
    //{
    //    Ontime,
    //    Offtime,
    //    None,
    //}
}
