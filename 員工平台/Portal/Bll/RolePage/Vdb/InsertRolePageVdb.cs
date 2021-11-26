using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.RolePage.Vdb
{
    public  class InsertRolePageVdb
    {
    }

    public class InsertRolePageConditions : DataConditions
    {
        public string roleCode { get; set; }
        public string pageCode { get; set; }

    }

    public class InsertRolePageApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class InsertRolePageRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
