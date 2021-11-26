using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public interface IEmployeeInfoService
    {
        List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList);
        bool UpdateEmployeeInfo(EmployeeInfoDto empInfo);
        /// <summary>
        /// 更新員工密碼
        /// </summary>
        /// <param name="oldPWD">舊密碼</param>
        /// <param name="newPWD">新密碼</param>
        /// <returns></returns>
        bool UpdateEmployeePassword(string oldPWD, string newPWD);
    }
}
