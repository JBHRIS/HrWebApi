using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
    public class AddSalaryChangeVdb
    {
    }

    public class AddSalaryChangeConditions : DataConditions
    {
        public string employeeId { get; set; }
        public string SalaryCode { get; set; }
        public DateTime ChageDate { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
    }

    public class AddSalaryChangeApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class AddSalaryChangeRow : StandardDataRow
    {
        public string Result { get; set; }
    }
}