using System;

namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class SalVdb
    {
    }

    /// <summary>
    /// 計薪前鎖檔
    /// </summary>
    public class SalaryLockBeginRow
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupID { set; get; }
    }

    /// <summary>
    /// 計薪後鎖檔
    /// </summary>
    public class SalaryLockAfterRow
    {
        /// <summary>
        /// 計薪年月
        /// </summary>
        public string Yymm { set; get; }
        /// <summary>
        /// 期別
        /// </summary>
        public string Seq { set; get; }
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupID { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Meno { set; get; }
    }

    /// <summary>
    /// 計算年月
    /// </summary>
    public class SalaryYymm
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 計算年月
        /// </summary>
        public string Yymm { set; get; }
    }

    /// <summary>
    /// 出勤結算日
    /// </summary>
    public class SalaryMonthDay
    {
        /// <summary>
        /// 公司代碼
        /// </summary>
        public string CompID { set; get; }
        /// <summary>
        /// 出勤結算日
        /// </summary>
        public int CloseDay { set; get; }
    }
}
