using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ezEngineServices.Vdb;

namespace ezEngineServices.Vdb
{
    public class EmpVdb
    {
    }

    public class EmpRow
    {
        public string EmpId { set; get; }
        public string LoginId { set; get; }
        public string Name { set; get; }
        public string DisplayName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public MultiEnum.SexEnum Sex { set; get; }
    }
}