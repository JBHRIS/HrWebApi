using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class OtVdb
    {
        public List<OtTypeTable> OtTypeData { set; get; }
    }

    public class OtCalculateRow
    {
        /// <summary>
        /// 時數
        /// </summary>
        public decimal Hour { set; get; }
        /// <summary>
        /// 分鐘數
        /// </summary>
        public int Minute { set; get; }
        /// <summary>
        /// 實際時數
        /// </summary>
        public decimal RealHour { set; get; }
        /// <summary>
        /// 實際分鐘數
        /// </summary>
        //public int RealMinute { set; get; }
        /// <summary>
        /// 總時數
        /// </summary>
        public decimal TotalHour { set; get; }
        /// <summary>
        /// 總時分鐘數
        /// </summary>
        //public int TotalMinute { set; get; }
        /// <summary>
        /// 休息時數
        /// </summary>
        public decimal ResHour { set; get; }
        /// <summary>
        /// 休息分鐘數
        /// </summary>
        //public int ResMinute { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 休息時間
        /// </summary>
        public List<RoteResRow> RoteRes { set; get; }
    }

    /// <summary>
    /// 加班類別資料
    /// </summary>
    public class OtTypeTable
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 顯示
        /// </summary>
        public bool Display { set; get; }
    }

    /// <summary>
    /// 加班原因代碼
    /// </summary>
    public class OtrcdRow
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 顯示
        /// </summary>
        public string DisplayName { set; get; }
        /// <summary>
        /// 是否計算
        /// </summary>
        public bool NoCalc { set; get; }
        /// <summary>
        /// Otratecd
        /// </summary>
        public string Otratecd { set; get; }
    }

    public class OtRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 加班日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string TimeB { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string TimeE { get; set; }
        /// <summary>
        /// 加班開始日期時間
        /// </summary>
        public DateTime DateTimeB { get; set; }
        /// <summary>
        /// 加班結束日期時間
        /// </summary>
        public DateTime DateTimeE { get; set; }
        /// <summary>
        /// 加班班別
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 總時數
        /// </summary>
        public decimal Hour { get; set; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal OtHour { get; set; }
        /// <summary>
        /// 補休時數
        /// </summary>
        public decimal ResHour { get; set; }
        /// <summary>
        /// 加班原因代碼
        /// </summary>
        public string Otrcd { get; set; }
        /// <summary>
        /// 加班原因名稱
        /// </summary>
        public string OtrcdName { get; set; }
        /// <summary>
        /// 加班原因備註
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 單號
        /// </summary>
        public string Serno { set; get; }

        /// <summary>
        /// 加班型態(OSH)
        /// </summary>
        public string OTType { get; set; }
    }
}