using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class AttcardVdb
    {
    }

    /// <summary>
    /// 出勤資料 細項
    /// </summary>
    public class AttcardRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 不轉換
        /// </summary>
        public bool NoTrans { get; set; }
        /// <summary>
        /// 上班刷卡時間24
        /// </summary>
        public string OnCardTime24 { get; set; }
        /// <summary>
        /// 下班刷卡時間24
        /// </summary>
        public string OffCardTime24 { get; set; }
        /// <summary>
        /// 上班刷卡時間48
        /// </summary>
        public string OnCardTime48 { get; set; }
        /// <summary>
        /// 下班刷卡時間48
        /// </summary>
        public string OffCardTime48 { get; set; }
        /// <summary>
        /// 上班忘刷
        /// </summary>
        public bool OnLos { get; set; }
        /// <summary>
        /// 下班忘刷
        /// </summary>
        public bool OffLos { get; set; }
        /// <summary>
        /// 上班刷卡時間DateTime欄位
        /// </summary>
        public DateTime? DateTimeB { get; set; }
        /// <summary>
        /// 下班刷卡時間DateTime欄位
        /// </summary>
        public DateTime? DateTimeE { get; set; }
    }
}