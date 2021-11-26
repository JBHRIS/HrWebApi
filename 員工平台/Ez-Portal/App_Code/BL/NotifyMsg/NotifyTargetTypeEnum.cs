using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    /// <summary>
    /// HrUser Ap使用、Emp 單一員工、Role 角色、Dept 部門、EmpsOfDept 該部門所有員工、AllEmps 公司所有員工
    /// </summary>
    public enum NotifyTargetTypeEnum
    {
        HrUser, //Ap使用
        Emp, //單一員工
        Role, //角色
        Dept, //部門
        EmpsOfDept,  //該部門所有員工
        AllEmps, //公司所有員工
        SalaDr,//資料群組        
        Teacher
    }
}
