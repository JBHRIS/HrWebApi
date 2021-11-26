using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface IEmpRepo
    {
        List<Dto.EmpDto> GetEmpList(List<string> EmployeeList);
    }
}
