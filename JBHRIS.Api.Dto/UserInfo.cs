using System.Collections.Generic;

namespace JBHRIS.Api.Dto
{
    public class UserInfo
    {
        /// <summary>
        /// 使用者編號(員工編號)
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 部門
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 擁有部門權限
        /// </summary>
        public List<string> DepartmentExtra { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 簽核部門
        /// </summary>
        public string DeptA { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        public string DeptAName { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 資料群組
        /// </summary>
        public List<string> DataGroups { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public List<string> Role { get; set; }
        /// <summary>
        /// 薪資群組
        /// </summary>
        public string Saladr { get; set; }
        /// <summary>
        /// 連DB
        /// </summary>
        public string Connection { get; set; }

    }
}