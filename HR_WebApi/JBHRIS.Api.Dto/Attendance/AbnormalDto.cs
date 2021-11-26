using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CheckAbnormalDto
    {
        /// <summary>
        /// 註記類別
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 註記名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 早來或晚走分鐘數
        /// </summary>
        public int Mins { get; set; }
        /// <summary>
        /// 是否被註記
        /// </summary>
        public bool Check { get; set; }
    }
}
