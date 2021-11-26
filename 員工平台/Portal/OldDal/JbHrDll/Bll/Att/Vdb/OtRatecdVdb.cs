using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class OtRatecdVdb
    {
    }

    public class OtRatecdRow
    {
        /// <summary>
        /// 加班頻率名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 加班頻率代碼
        /// </summary>
        public string OtRatecdCode { get; set; }
        /// <summary>
        /// 加班頻率名稱
        /// </summary>
        public string OtRatecdName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Unit { get; set; }
        public string Value { get; set; }
    }
}