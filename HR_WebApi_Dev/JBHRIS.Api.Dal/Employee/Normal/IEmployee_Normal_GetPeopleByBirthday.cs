using System;
using System.Collections.Generic;
using JBHRIS.Api.Dto.Employee.View;

namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_GetPeopleByBirthday
    {
        /// <summary>
        /// 取得某些月份生日人員工號清單
        /// </summary>
        /// <param name="employeeList">員工工號s</param>
        /// <param name="months">月份s</param>
        /// <returns></returns>
        List<string> GetPeopleByBirthday(List<string> employeeList, int[] months);

    }
}