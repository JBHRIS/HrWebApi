using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FormsAppEmploySalary
    {
        public int AutoKey { get; set; }
        public string EmployCode { get; set; }
        public string SalaryCode { get; set; }
        public string SalaryName { get; set; }
        public decimal MoneyValue { get; set; }
        public decimal EncodeMoneyValue { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
