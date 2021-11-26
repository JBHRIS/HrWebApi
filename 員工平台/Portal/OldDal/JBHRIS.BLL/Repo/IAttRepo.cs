using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface IAttRepo
    {
        List<string> GetAttendanceList(List<string> EmployeeList, DateTime DateBegin, DateTime DateEnd);

    }
}
