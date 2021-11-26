using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class PeopleByDepartmentExtraTreeVdb
    {
    }

    public class PeopleByDepartmentExtraTreeConditions : DataConditions
    {
        public DateTime checkDate { get; set; }
        public bool inCludeManager { get; set; }
    }


    public class PeopleByDepartmentExtraTreeApiRow : StandardDataBaseApiRow
    {
        public List<string> result { get; set; }
        
    }

    public class PeopleByDepartmentExtraTreeRow : StandardDataRow
    {
        public string EmpId { get; set; }
    }
}