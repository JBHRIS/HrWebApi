using JBHRIS.Api.Dto.Employee.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Employee
{
    public interface IEmployee_Normal_GetPeopleByDepta
    {
        List<string> GetPeopleByDepta(List<string> employeeList, List<string> DeptaList, DateTime CheckDate);
        List<string> GetPeopleByDeptaTree(string depta);
    }
}
