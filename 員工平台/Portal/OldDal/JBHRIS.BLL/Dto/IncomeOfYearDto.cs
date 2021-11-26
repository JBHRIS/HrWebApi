using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class IncomeOfYearDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeNane { get; set; }
        public string YYMM { get; set; }
        public string Seq { get; set; }
        public string Format { get; set; }
        public string IncomeType { get; set; }
        public decimal Income { get; set; }
        public decimal Tax { get; set; }
        //public static string SelfRetire = "自提退休金";
        public string TaxNO { get; set; }
        public string TradeType { get; set; }
        public string PayItem { get; set; }
        public decimal AdditionalInsurance { get; set; }
        public string Company { get; set; }
        public string Remark { get; set; }
        public string ErrorRemark { get; set; }
    }
}
