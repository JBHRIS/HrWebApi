using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class PeopleByDeptTreeVdb
    {
    }

    public class PeopleByDeptTreeConditions : DataConditions
    {
        public DateTime checkDate { get; set; }
        public bool inCludeManager { get; set; }
    }


    public class PeopleByDeptTreeApiRow : StandardDataBaseApiRow
    {
        public List<string> result { get; set; }
        
    }

    public class PeopleByDeptTreeRow : StandardDataRow
    {
        public string EmpId { get; set; }
    }
}