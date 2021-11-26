using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class UserInfoDto
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
        /// 部門名稱
        /// </summary>
        public string DepartmentName { get; set; }
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
    }
}
