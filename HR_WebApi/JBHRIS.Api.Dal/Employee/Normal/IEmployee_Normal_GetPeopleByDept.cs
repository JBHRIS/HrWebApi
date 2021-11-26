using JBHRIS.Api.Dto.Employee.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Employee
{
    public interface IEmployee_Normal_GetPeopleByDept
    {
        List<string> GetPeopleByDept(List<string> employeeList,List<string> DeptList, DateTime CheckDate);
        List<string> GetPeopleByDeptTree(string dept);
        List<string> GetAllPeopleByDept(List<string> DeptList, DateTime CheckDate);
    }
}
