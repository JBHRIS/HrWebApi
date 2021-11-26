using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Role.Vdb
{
    public  class DeleteRoleVdb
    {
    }

    public class DeleteRoleConditions : DataConditions
    { 
    }

    public class DeleteRoleApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string code { get; set; }
            public string name { get; set; }
            public bool isAdminRole { get; set; }
            public bool isVisible { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class DeleteRoleRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
