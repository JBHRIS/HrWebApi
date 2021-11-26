using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class AttendVdb
    {
        /// <summary>
        /// 出勤資料
        /// </summary>
        public List<AttendTable> AttendData { set; get; }
        /// <summary>
        /// 出勤資料 細項
        /// </summary>
        public List<AttendDetailTable> AttendDetailData { set; get; }
    }

    /// <summary>
    /// 出勤資料
    /// </summary>
    public class AttendTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 真實班別
        /// </summary>
        public string RoteCodeH { set; get; }
        /// <summary>
        /// 使用的彈性分鐘數
        /// </summary>
        public int ElasticityMin { get; set; }
        /// <summary>
        /// 是否假日
        /// </summary>
        public bool IsHoliDay { get; set; }
    }

    public class AttendByOtRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 真實班別
        /// </summary>
        public string RoteCodeH { set; get; }
        /// <summary>
        /// 表訂上班時間48
        /// </summary>
        public string OnTime { get; set; }
        /// <summary>
        /// 表訂下班時間48
        /// </summary>
        public string OffTime { get; set; }
        /// <summary>
        /// 加班開始時間48
        /// </summary>
        public string OtBeginTime { get; set; }
        /// <summary>
        /// 固定加班時數
        /// </summary>
        public decimal OtHour { get; set; }
        /// <summary>
        /// 是否假日
        /// </summary>
        public bool IsHoliDay { get; set; }
        /// <summary>
        /// 固定加班起始時間
        /// </summary>
        public string StrTime { get; set; }
    }

    /// <summary>
    /// 出勤資料 細項
    /// </summary>
    public class AttendDetailTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 真實班別
        /// </summary>
        public string RoteCodeH { set; get; }
        /// <summary>
        /// 遲到
        /// </summary>
        public int LatesMin { get; set; }
        /// <summary>
        /// 早退
        /// </summary>
        public int EarlierMin { get; set; }
        /// <summary>
        /// 曠職
        /// </summary>
        public bool Abs { get; set; }
        /// <summary>
        /// 忘刷
        /// </summary>
        public int Card { get; set; }
    }

    /// <summary>
    /// 出勤資料 細項
    /// </summary>
    public class AttendDetailRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 真實班別
        /// </summary>
        public string RoteCodeH { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteName { set; get; }
        /// <summary>
        /// 上班時間
        /// </summary>
        public string T1 { set; get; }
        /// <summary>
        /// 下班時間
        /// </summary>
        public string T2 { set; get; }
        /// <summary>
        /// 遲到
        /// </summary>
        public int LatesMin { get; set; }
        /// <summary>
        /// 早退
        /// </summary>
        public int EarlierMin { get; set; }
        /// <summary>
        /// 曠職
        /// </summary>
        public bool Abs { get; set; }
        /// <summary>
        /// 忘刷
        /// </summary>
        public int Card { get; set; }
    }

    /// <summary>
    /// 新人考核表專用
    /// </summary>
    public class AttendByAssessRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 事假
        /// </summary>
        public decimal Leave1 { set; get; }
        /// <summary>
        /// 病假
        /// </summary>
        public decimal Leave2 { set; get; }
        /// <summary>
        /// 遲到次
        /// </summary>
        public int LatesNum { get; set; }
        /// <summary>
        /// 早退次
        /// </summary>
        public int EarlierNum { get; set; }
    }

    /// <summary>
    /// 早來晚走異常
    /// </summary>
    public class AttendAbnormalRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 註記類別(早來或晚走)
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsError { set; get; }
        /// <summary>
        /// 早來或晚走分鐘數
        /// </summary>
        public int ErrorMins { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 班別上班時間
        /// </summary>
        public string OnTime { set; get; }
        /// <summary>
        /// 班別下班時間
        /// </summary>
        public string OffTime { set; get; }
        /// <summary>
        /// 班別上班允許分鐘數
        /// </summary>
        public int OnTimeBuffer { set; get; }
        /// <summary>
        /// 班別下班允許分鐘數
        /// </summary>
        public int OffTimeBuffer { set; get; }
        /// <summary>
        /// 實際上班時間
        /// </summary>
        public string OnTimeActual { set; get; }
        /// <summary>
        /// 實際下班時間
        /// </summary>
        public string OffTimeActual { set; get; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime CreateDate { set; get; }
        /// <summary>
        /// 新增人員
        /// </summary>
        public string CreateMan { set; get; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
        /// <summary>
        /// 修改人員
        /// </summary>
        public string UpdateMan { set; get; }
    }

    /// <summary>
    /// 註記資料
    /// </summary>
    public class AttendCheckRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 註記日期
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 註記類別(早來或晚走)
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 註記原因代碼
        /// </summary>
        public string RemarkType { set; get; }
        /// <summary>
        /// 註記原因
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime CreateDate { set; get; }
        /// <summary>
        /// 新增人員
        /// </summary>
        public string CreateMan { set; get; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
        /// <summary>
        /// 修改人員
        /// </summary>
        public string UpdateMan { set; get; }
    }

    /// <summary>
    /// 註記資料
    /// </summary>
    public class AttendCheckApiRow 
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 註記日期
        /// </summary>
        public string DateA { set; get; }
        /// <summary>
        /// 註記類別(早來或晚走)
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 註記原因代碼
        /// </summary>
        public string RemarkType { set; get; }
        /// <summary>
        /// 註記原因
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public string CreateDate { set; get; }
        /// <summary>
        /// 新增人員
        /// </summary>
        public string CreateMan { set; get; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public string UpdateDate { set; get; }
        /// <summary>
        /// 修改人員
        /// </summary>
        public string UpdateMan { set; get; }
    }
}