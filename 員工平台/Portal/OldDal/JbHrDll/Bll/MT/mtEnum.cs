using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.MT
{
   public  class mtEnum
    {
        /// <summary>
        /// 性別分類
        /// </summary>
        public enum SexCategroy
        {
            /// <summary>
            /// 男性
            /// </summary>
            Male = 1,
            /// <summary>
            /// 女性
            /// </summary>
            Female = 0,
            /// <summary>
            /// 兩者
            /// </summary>
            Both = 2,
        }

        /// <summary>
        /// 假別計算單位
        /// </summary>
        public enum HcodeUnit
        {
            /// <summary>
            /// 分鐘
            /// </summary>
            Minute = 1,
            /// <summary>
            /// 小時
            /// </summary>
            Hour = 2,
            /// <summary>
            /// 天
            /// </summary>
            Day = 3,
            /// <summary>
            /// 月
            /// </summary>
            Month = 4,
            /// <summary>
            /// 年
            /// </summary>
            Year = 5,
        }
    }
}
