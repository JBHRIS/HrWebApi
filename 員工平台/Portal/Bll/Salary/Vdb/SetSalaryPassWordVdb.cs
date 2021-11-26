using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
    public class SetSalaryPassWordVdb
    {
    }

    public class SetSalaryPassWordConditions : DataConditions
    {
        public string password { get; set; }
    }

    public class SetSalaryPassWordApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class SetSalaryPassWordRow
    {
        public string Result { get; set; }
    }
}
