using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Role.Vdb
{
  public  class RoleVdb
    {
    }

    public class RoleConditions : DataConditions
    { 
    }
    
    public class RoleApiRow : StandardDataBaseApiRow
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

    public class RoleRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAdminRole { get; set; }
        public bool IsVisible { get; set; }
    }
}
