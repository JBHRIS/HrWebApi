using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Emp.Vdb
{
  public  class EmpVdb
    {
    }
    public class EmpConditions : DataConditions
    {
    }

    public class EmpApiRow : StandardDataBaseApiRow
    {
        public class Res
        {
            public string EmpId { get; set; }
            public string Password { get; set; }
            public string EmpName { get; set; }
            public bool IsNeedAgent { get; set; }
            public string Email { get; set; }
            public string Sex { get; set; }
        }
        public List<Res> Result { get; set; }
    }
    public class EmpRow
    {
        public string EmpId { get; set; }
        public string Password { get; set; }
        public string EmpName { get; set; }
        public bool IsNeedAgent { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
    }
}
