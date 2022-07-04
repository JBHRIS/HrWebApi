using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.View;
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
        private IEmployee_View_GetEmployee _employee_View_GetEmployee;

        public EmployeeListService(IEmployee_Normal_GetPeopleByBirthday employee_Normail_GetPeopleByBirthday, IEmployee_Normal_GetPeopleByDept employee_Normal_GetPeopleByDept
           , IEmployee_Normal_GetPeopleByLeaveDate employee_Normal_GetPeopleByLeaveDate
            , IEmployee_Normal_GetPeopleByOnBoardDate employee_Normal_GetPeopleByOnBoardDate
            , IEmployee_View_GetEmployee employee_View_GetEmployee
            )
        {
            _employee_Normal_GetPeopleByBirthday = employee_Normail_GetPeopleByBirthday;
            _employee_Normal_GetPeopleByDept = employee_Normal_GetPeopleByDept;
            _employee_Normal_GetPeopleByLeaveDate = employee_Normal_GetPeopleByLeaveDate;
            _employee_Normal_GetPeopleByOnBoardDate = employee_Normal_GetPeopleByOnBoardDate;
            _employee_View_GetEmployee = employee_View_GetEmployee;
        }

        public List<EmployeeViewDto> GetPeople()
        {
            return _employee_View_GetEmployee.GetEmployee();
        }

        public List<string> GetPeopleByBirthday(List<string> employeeList, int[] Months)
        {
            return _employee_Normal_GetPeopleByBirthday.GetPeopleByBirthday(employeeList, Months);
        }


        public List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _employee_Normal_GetPeopleByDept.GetPeopleByDept(employeeList, DeptList, CheckDate);
        }

        public List<string> GetPeopleByDeptTree(List<string> employeeList, DateTime checkDate,bool Manager)
        {
            List<string> filterEmpList = new  List<string>();
            filterEmpList = _employee_View_GetEmployee.GetPeopleByDeptTree(employeeList, checkDate);
            if (!Manager)
            {
                List<string> deptMangerList = _employee_View_GetEmployee.GetAllDeptManger();
                deptMangerList.ForEach(d =>filterEmpList.Remove(d));
            }
            return filterEmpList;
        }

        public List<string> GetPeopleByDeptaTree(List<string> employeeList, DateTime checkDate, bool Manager)
        {
            List<string> filterEmpList = new List<string>();
            filterEmpList = _employee_View_GetEmployee.GetPeopleByDeptaTree(employeeList, checkDate);
            if (!Manager)
            {
                List<string> deptMangerList = _employee_View_GetEmployee.GetAllDeptaManger();
                deptMangerList.ForEach(d => filterEmpList.Remove(d));
            }
            return filterEmpList;
        }

        public List<string> GetPeopleByLeaveDate(List<string> employeeList, DateTime BeginDate, DateTime EndDate)
        {
            return _employee_Normal_GetPeopleByLeaveDate.GetPeopleByLeaveDate(BeginDate, EndDate);
        }

        public List<string> GetPeopleByOnBoardDate(List<string> employeeList, DateTime BeginDate, DateTime EndDate)
        {
            return _employee_Normal_GetPeopleByOnBoardDate.GetPeopleByOnBoardDate(employeeList, BeginDate, EndDate);
        }

        public List<PeopleApDateViewDto> GetPeopleApDate(DateTime BeginDate, DateTime EndDate)
        {
            return _employee_View_GetEmployee.GetPeopleApDate(BeginDate, EndDate);
        }

        public List<AllPassTypeDto> GetAllPassType()
        {
            return _employee_View_GetEmployee.GetAllPassType();
        }

        public List<EffemployViewDto> GetEffemployView(EffemployEntryDto effemployEntryDto)
        {
            return _employee_View_GetEmployee.GetEffemployView(effemployEntryDto);
        }

        public List<string> GetAllPeopleByDept(List<string> DeptList, DateTime CheckDate)
        {
            return _employee_Normal_GetPeopleByDept.GetAllPeopleByDept(DeptList, CheckDate);
        }
    }
}
