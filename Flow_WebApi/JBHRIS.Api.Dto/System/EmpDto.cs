using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class EmpDto
    {
        /// <summary>
        /// 工號
        /// </summary>
       public string EmpId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 是否需要代理
        /// </summary>
        public bool IsNeedAgent { get; set; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性別(M=男，F=女)
        /// </summary>
        public string Sex { get; set; }
    }
}
