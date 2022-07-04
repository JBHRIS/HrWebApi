using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_GetPeopleByOnBoardDate
    {
        List<string> GetPeopleByOnBoardDate(List<string> employeeList, DateTime beginDate, DateTime endDate);
    }
}