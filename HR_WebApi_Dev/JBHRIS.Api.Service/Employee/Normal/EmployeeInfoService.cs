using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dto.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private IEmployee_Normal_GetEmployeeInfo _employee_Normal_GetEmployeeInfo;
        private IEmployee_Normal_GetPeopleByDept _employee_Normal_GetPeopleByDept;
        private IEmployee_Normal_EmployeeInfoRepository _employee_Normal_EmployeeInfoRepository;
        private IEmployee_Normal_EmployeePasswordRepository _employee_Normal_EmployeePasswordRepository;

        public EmployeeInfoService(IEmployee_Normal_GetEmployeeInfo employee_Normal_GetEmployeeInfo
            , IEmployee_Normal_GetPeopleByDept employee_Normal_GetPeopleByDept
            , IEmployee_Normal_EmployeeInfoRepository employee_Normal_EmployeeInfoRepository
            , IEmployee_Normal_EmployeePasswordRepository employee_Normal_EmployeePasswordRepository)
        {
            _employee_Normal_GetEmployeeInfo = employee_Normal_GetEmployeeInfo;
            _employee_Normal_GetPeopleByDept = employee_Normal_GetPeopleByDept;
            _employee_Normal_EmployeeInfoRepository = employee_Normal_EmployeeInfoRepository;
            _employee_Normal_EmployeePasswordRepository = employee_Normal_EmployeePasswordRepository;
        }

        public List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList)
        {
            return _employee_Normal_GetEmployeeInfo.GetEmployeeInfo(employeeList);
        }


        public List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _employee_Normal_GetPeopleByDept.GetPeopleByDept(employeeList,DeptList, CheckDate);
        }

        public bool UpdateEmployeeInfo(EmployeeInfoDto empInfo)
        {
            return _employee_Normal_EmployeeInfoRepository.Update(empInfo);
        }

        public bool UpdateEmployeePassword(string oldPWD, string newPWD)
        {
            return _employee_Normal_EmployeePasswordRepository.Update(oldPWD, newPWD);
        }
    }
}
