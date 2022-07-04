using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Hunya
{
    /// <summary>
    /// 取得部門名單-查詢條件
    /// </summary>
    public class EmployeeInfo_GetPeopleByDept_Entry
    {
        /// <summary>
        /// 部門清單
        /// </summary>
        public List<string> deptList { get; set; }
        /// <summary>
        /// 檢核日期
        /// </summary>
        public string CheckDate { get; set; }
    }
}
