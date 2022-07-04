using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class EffemployViewDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmpId { get; set; }
        /// <summary>
        /// 年月
        /// </summary>
        public string Yymm { get; set; }
        /// <summary>
        /// 考核等級
        /// </summary>
        public string EfflvlCode { get; set; }
        /// <summary>
        /// 考核等級名稱
        /// </summary>
        public string EfflvlName { get; set; }
        /// <summary>
        /// 考核分數
        /// </summary>
        public decimal EffScore { get; set; }
        /// <summary>
        /// 考核種類
        /// </summary>
        public string EfftypeCode { get; set; }
        /// <summary>
        /// 考核種類名稱
        /// </summary>
        public string EfftypeName { get; set; }
        /// <summary>
        /// 是不是透過匯入產生的
        /// </summary>
        public bool Import { get; set; }
        /// <summary>
        /// 登錄日期
        /// </summary>
        public DateTime KeyDate { get; set; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { get; set; }
    }
}
