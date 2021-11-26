using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_GetPeopleByLeaveDate
    {
        List<string> GetPeopleByLeaveDate(DateTime beginDate, DateTime endDate);
    }
}