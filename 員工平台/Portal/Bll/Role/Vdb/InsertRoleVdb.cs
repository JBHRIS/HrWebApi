using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Role.Vdb
{
    public  class InsertRoleVdb
    {
    }

    public class InsertRoleConditions : DataConditions
    {
        public string name { get; set; }
        public bool isAdminRole { get; set; }
        public bool isVisible { get; set; }
    }
    
    public class InsertRoleApiRow : StandardDataBaseApiRow
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

    public class InsertRoleRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
