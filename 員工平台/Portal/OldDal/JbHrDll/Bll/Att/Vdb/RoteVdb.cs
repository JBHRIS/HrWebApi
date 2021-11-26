using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class RoteVdb
    {
    }

    public class RoteRow
    {
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 班別代碼_DISP
        /// </summary>
        public string RoteCode_DISP { get; set; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 表訂上班時間48
        /// </summary>
        public string OnTime { get; set; }
        /// <summary>
        /// 表訂下班時間48
        /// </summary>
        public string OffTime { get; set; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal MoHrs { get; set; }
        /// <summary>
        /// 固定加班起始時間
        /// </summary>
        public string StrTime { get; set; }
    }

    public class RoteDetailRow
    {
        public RoteDetailRow()
        {
            MiddleTimeB = "";
            MiddleTimeE = "";
        }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 工作時數
        /// </summary>
        public decimal WorkHour { get; set; }
        /// <summary>
        /// 年休時數
        /// </summary>
        public decimal YrRestHour { get; set; }
        /// <summary>
        /// 表訂上班時間48
        /// </summary>
        public string OnTime { get; set; }
        /// <summary>
        /// 表訂下班時間48
        /// </summary>
        public string OffTime { get; set; }
        /// <summary>
        /// 最晚下班時間24
        /// </summary>
        public string OffLastTime { get; set; }
        /// <summary>
        /// 加班開始時間48
        /// </summary>
        public string OtBeginTime { get; set; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string AbsEndTime { get; set; }
        /// <summary>
        /// 可遲到分鐘數
        /// </summary>
        public int LatesMin { get; set; }
        /// <summary>
        /// 可彈性分鐘數
        /// </summary>
        public int ElasticityMin { get; set; }
        /// <summary>
        /// 休息時間
        /// </summary>
        public List<RoteResRow> DayRes { get; set; }
        /// <summary>
        /// 中間時間開始
        /// </summary>
        public string MiddleTimeB { get; set; }
        /// <summary>
        /// 中間時間結束
        /// </summary>
        public string MiddleTimeE { get; set; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal MoHrs { get; set; }
        public string DayRes1 { get; set; }
    }

    /// <summary>
    /// 休息時間
    /// </summary>
    public class RoteResRow
    {
        /// <summary>
        /// 開始休息時間48
        /// </summary>
        public string ResTimeB { get; set; }
        /// <summary>
        /// 結束休息時間48
        /// </summary>
        public string ResTimeE { get; set; }
    }
}