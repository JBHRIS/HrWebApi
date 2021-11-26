using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.RolePage.Vdb
{
    public  class DeleteRolePageVdb
    {
    }

    public class DeleteRolePageConditions : DataConditions
    {
        public string roleCode { get; set; }
        public string pageCode { get; set; }

    }

    public class DeleteRolePageApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class DeleteRolePageRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
