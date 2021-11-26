using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public class EmployeeListService : IEmployeeListService
    {
        private IEmployee_Normal_GetPeopleByBirthday _employee_Normal_GetPeopleByBirthday;
        private IEmployee_Normal_GetPeopleByDept _employee_Normal_GetPeopleByDept;
        private IEmployee_Normal_GetPeopleByLeaveDate _employee_Normal_GetPeopleByLeaveDate;
        private IEmployee_Normal_GetPeopleByOnBoardDate _employee_Normal_GetPeopleByOnBoardDate;

        public EmployeeListService(IEmployee_Normal_GetPeopleByBirthday employee_Normail_GetPeopleByBirthday, IEmployee_Normal_GetPeopleByDept employee_Normal_GetPeopleByDept
           , IEmployee_Normal_GetPeopleByLeaveDate employee_Normal_GetPeopleByLeaveDate
            , IEmployee_Normal_GetPeopleByOnBoardDate employee_Normal_GetPeopleByOnBoardDate
            )
        {
            _employee_Normal_GetPeopleByBirthday = employee_Normail_GetPeopleByBirthday;
            _employee_Normal_GetPeopleByDept = employee_Normal_GetPeopleByDept;
            _employee_Normal_GetPeopleByLeaveDate = employee_Normal_GetPeopleByLeaveDate;
            _employee_Normal_GetPeopleByOnBoardDate = employee_Normal_GetPeopleByOnBoardDate;
        }

        public List<string> GetPeopleByBirthday(List<string> employeeList, int[] Months)
        {
            return _employee_Normal_GetPeopleByBirthday.GetPeopleByBirthday(employeeList, Months);
        }


        public List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _employee_Normal_GetPeopleByDept.GetPeopleByDept(employeeList, DeptList, CheckDate);
        }

        public List<string> GetPeopleByLeaveDate(List<string> employeeList, DateTime BeginDate, DateTime EndDate)
        {
            return _employee_Normal_GetPeopleByLeaveDate.GetPeopleByLeaveDate(BeginDate, EndDate);
        }

        public List<string> GetPeopleByOnBoardDate(List<string> employeeList, DateTime BeginDate, DateTime EndDate)
        {
            return _employee_Normal_GetPeopleByOnBoardDate.GetPeopleByOnBoardDate(employeeList, BeginDate, EndDate);
        }

    }
}
