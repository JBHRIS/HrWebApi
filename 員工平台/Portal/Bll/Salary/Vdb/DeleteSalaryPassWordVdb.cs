using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
    public class DeleteSalaryPassWordVdb
    {
    }

    public class DeleteSalaryPassWordConditions : DataConditions
    {
        public string EmpId { get; set; }
    }

    public class DeleteSalaryPassWordApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class DeleteSalaryPassWordRow
    {
        public string Result { get; set; }
    }
}
