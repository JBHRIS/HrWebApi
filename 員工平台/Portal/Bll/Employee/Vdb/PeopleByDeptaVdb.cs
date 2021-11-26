using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class PeopleByDeptaTreeVdb
    {
    }

    public class PeopleByDeptaTreeConditions : DataConditions
    {
        public DateTime checkDate { get; set; }
        public bool inCludeManager { get; set; }
    }


    public class PeopleByDeptaTreeApiRow : StandardDataBaseApiRow
    {
        public List<string> result { get; set; }
        
    }

    public class PeopleByDeptaTreeRow : StandardDataRow
    {
        public string EmpId { get; set; }
    }
}