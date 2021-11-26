using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class CardLosdVdb
    {
    }

    public class CardLosdRow
    {      
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 影響出勤
        /// </summary>
        public bool Att { get; set; }
    }
}