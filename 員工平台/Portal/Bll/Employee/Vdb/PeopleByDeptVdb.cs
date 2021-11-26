using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class PeopleByDeptVdb
    {
    }

    public class PeopleByDeptConditions : DataConditions
    {
        public DateTime checkDate { get; set; }
        public List<string> deptList { get; set; }
    }


    public class PeopleByDeptApiRow : StandardDataBaseApiRow
    {
        public List<string> result { get; set; }
        
    }

    public class PeopleByDeptRow : StandardDataRow
    {
        public string EmpId { get; set; }
    }
}