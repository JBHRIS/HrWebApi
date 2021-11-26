using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
 public   interface IEmployeeListService
    {
        /// <summary>
        /// 部門人員名單
        /// </summary>
        /// <param name="DeptList">部門清單</param>
        /// <param name="CheckDate">參考日期</param>
        /// <returns></returns>
        List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate);
        /// <summary>
        /// 生日名單
        /// </summary>
        /// /// <param name="employeeList">查詢對象</param>        
        /// <param name="Months">月</param>        
        /// <returns></returns>
        List<string> GetPeopleByBirthday(List<string> employeeList, int[] Months);
        /// <summary>
        /// 期間到職名單
        /// </summary>
        /// <param name="BeginDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns></returns>
        List<string> GetPeopleByOnBoardDate(List<string> employeeList, DateTime BeginDate,DateTime EndDate);
        /// <summary>
        /// 期間離職
        /// </summary>
        /// <param name="BeginDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns></returns>
        List<string> GetPeopleByLeaveDate(List<string> employeeList, DateTime BeginDate, DateTime EndDate);
    }
}
