using System;
using System.Collections.Generic;

namespace OldBll.Att.Vdb
{
    /// <summary>
    /// TransCardVdb
    /// </summary>
    public class TransCardVdb
    {
        /// <summary>
        /// 刷卡轉出勤判斷條件
        /// </summary>
        public TransCardCondition TransCardCond { get; set; }
        /// <summary>
        /// 基本資料
        /// </summary>
        public List<BaseTable> BaseData { get; set; }
        /// <summary>
        /// 班別資料
        /// </summary>
        public List<RoteTable> RoteData { get; set; }
        /// <summary>
        /// 班別資料單天
        /// </summary>
        public RoteTable RoteDataDay { get; set; }
        /// <summary>
        /// 休息時資料
        /// </summary>
        public List<RoteResTable> RoteResData { get; set; }
        /// <summary>
        /// 請假資料
        /// </summary>
        public List<AbsTable> AbsData { get; set; }
        /// <summary>
        /// 請假資料 單天
        /// </summary>
        public List<AbsTable> AbsDataDay { get; set; }
        /// <summary>
        /// 加班資料
        /// </summary>
        public List<OtTable> OtData { get; set; }
        /// <summary>
        /// 刷卡資料
        /// </summary>
        public List<CardTable> CardData { get; set; }
        /// <summary>
        /// 刷卡資料 單天
        /// </summary>
        public List<CardTable> CardDataDay { get; set; }
        /// <summary>
        /// 暫存專用的出勤資料
        /// </summary>
        public List<AttEndTempTable> AttEndTempData { get; set; }
        /// <summary>
        /// 出勤刷卡資料 刷卡資料可以拼出許多同一天的出勤資料
        /// </summary>
        public List<AttCardTable> AttCardData { get; set; }
        /// <summary>
        /// 出勤刷卡資料 刷卡資料可以拼出許多同一天的出勤資料 單天
        /// </summary>
        public List<AttCardTable> AttCardDataDay { get; set; }
        /// <summary>
        /// 出勤班別資料
        /// </summary>
        public AttEndTable AttEndData { get; set; }
        /// <summary>
        /// 個人彈性分鐘數
        /// </summary>
        public List<AttElasticityRow> AttElasticityData { set; get; }
    }

    public class TransCardCondition
    {
        /// <summary>
        /// 工號陣列
        /// </summary>
        public List<string> lsNobr { get; set; }
        /// <summary>
        /// 開始工號
        /// </summary>
        public string sNobrB { get; set; }
        /// <summary>
        /// 結束工號
        /// </summary>
        public string sNobrE { get; set; }
        /// <summary>
        /// 開始部門
        /// </summary>
        public string sDeptB { get; set; }
        /// <summary>
        /// 結束部門
        /// </summary>
        public string sDeptE { get; set; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime dDateB { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime dDateE { get; set; }
        /// <summary>
        /// 工作地
        /// </summary>
        public List<string> lsWorkcd { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public string sRote { get; set; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string sKeyMan { get; set; }
        /// <summary>
        /// 轉換刷卡時間
        /// </summary>
        public bool bAttCard { get; set; }
        /// <summary>
        /// 判斷異常
        /// </summary>
        public bool bAttEnd { get; set; }
        /// <summary>
        /// 簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)
        /// </summary>
        public bool bEzAttCard { get; set; }
        /// <summary>
        /// 登入工號
        /// </summary>
        public string sUserID { get; set; }
        /// <summary>
        /// 公司別
        /// </summary>
        public string sComp { get; set; }
        /// <summary>
        /// 是否管理權限
        /// </summary>
        public bool bAdmin { get; set; }
        /// <summary>
        /// 執行緒數目
        /// </summary>
        public int ThreadCount { get; set; }
        /// <summary>
        /// 加班班別預設強制為ROTE_H
        /// </summary>
        public bool PassOtRote { get; set; } = false;
    }

    #region In
    /// <summary>
    /// 基本判斷資料
    /// </summary>
    public class BaseTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime DateA { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime DateD { get; set; }
        /// <summary>
        /// 需要刷卡 才需要判斷異常
        /// </summary>
        public bool NeedCard { get; set; }
        /// <summary>
        /// 需要上班卡
        /// </summary>
        public bool NeedOnCard { get; set; }
        /// <summary>
        /// 需要下班卡
        /// </summary>
        public bool NeedOffCard { get; set; }
        /// <summary>
        /// 不判計算遲到跟早退
        /// </summary>
        public bool NoTer { get; set; }
        /// <summary>
        /// 計薪人員 代碼是2
        /// </summary>
        public string Saltp { get; set; }
        /// <summary>
        /// 工作地
        /// </summary>
        public string WorkCode { get; set; }
    }

    /// <summary>
    /// 班表
    /// </summary>
    public class RoteTable
    {
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 工作時數
        /// </summary>
        public decimal WorkHour { get; set; }
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
        /// 可遲到分鐘數
        /// </summary>
        public int LatesMin { get; set; }
        /// <summary>
        /// 可彈性分鐘數
        /// </summary>
        public int ElasticityMin { get; set; }
        /// <summary>
        /// 可彈性分鐘數(間隔)
        /// </summary>
        public int ElasticityMinInterval { get; set; }
        /// <summary>
        /// 可彈性分鐘數(提前來)
        /// </summary>
        public int ElasticityBeforeMin { get; set; }
        /// <summary>
        /// 休息時間
        /// </summary>
        public List<RoteResTable> DayRes { get; set; }
        /// <summary>
        /// 提前上班卡分鐘
        /// </summary>
        public int OnMin { get; set; }
        /// <summary>
        /// 延後下班卡分鐘
        /// </summary>
        public int OffMin { get; set; }
    }

    /// <summary>
    /// 休息時間
    /// </summary>
    public class RoteResTable
    {
        /// <summary>
        /// 開始休息時間48
        /// </summary>
        public string ResB { get; set; }
        /// <summary>
        /// 結束休息時間48
        /// </summary>
        public string ResE { get; set; }
    }

    /// <summary>
    /// 請假資料
    /// </summary>
    public class AbsTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 請假日期
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
        /// 請假開始日期時間
        /// </summary>
        public DateTime DateTimeB { get; set; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime DateTimeE { get; set; }
        /// <summary>
        /// 請假時數
        /// </summary>
        public decimal Hour { get; set; }
        /// <summary>
        /// 假別單位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 扣薪假
        /// </summary>
        public bool A01 { get; set; }
    }

    /// <summary>
    /// 加班資料
    /// </summary>
    public class OtTable
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 加班日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 加班班別
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal OtHour { get; set; }
    }

    /// <summary>
    /// 刷卡資料
    /// </summary>
    public class CardTable
    {
        /// <summary>
        /// 卡機代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 刷卡日期
        /// </summary>
        public DateTime CardDate { get; set; }
        /// <summary>
        /// 刷卡時間24
        /// </summary>
        public string CardTime24 { get; set; }
        /// <summary>
        /// 刷卡時間48
        /// </summary>
        public string CardTime48 { get; set; }
        /// <summary>
        /// 刷卡原因代碼
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 完整日期及時間
        /// </summary>
        public DateTime CardDateTime { get; set; }
        /// <summary>
        /// 是否忘刷
        /// </summary>
        public bool Los { get; set; }
        /// <summary>
        /// 是否被使用過
        /// </summary>
        public bool Use { get; set; }
        /// <summary>
        /// 卡片DateTime欄位
        /// </summary>
        public DateTime? ONDATETIME { get; set; }
    }

    /// <summary>
    /// 出勤分類
    /// </summary>
    public enum AttEndType : int
    {
        /// <summary>
        /// 出勤1
        /// </summary>
        Att = 1,
        /// <summary>
        /// 休息2
        /// </summary>
        Res = 2,
        /// <summary>
        /// 請假3
        /// </summary>
        Abs = 3
    }

    /// <summary>
    /// 暫存專用的出勤資料
    /// </summary>
    public class AttEndTempTable
    {
        /// <summary>
        /// 開始日期時間
        /// </summary>
        public DateTime DateTimeB { get; set; }
        /// <summary>
        /// 結束日期時間
        /// </summary>
        public DateTime DateTimeE { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public AttEndType Type { get; set; }
    }
    #endregion

    #region Out
    /// <summary>
    /// 出勤資料
    /// </summary>
    public class AttCardTable
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
        public DateTime? DT1 { get; set; }
        /// <summary>
        /// 下班刷卡時間DateTime欄位
        /// </summary>
        public DateTime? DT2 { get; set; }
    }

    /// <summary>
    /// 出勤班別資料
    /// </summary>
    public class AttEndTable
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
        /// 班別代碼
        /// </summary>
        public string RoteCode { get; set; }
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
        /// <summary>
        /// 提早到分鐘
        /// </summary>
        public int EarlyMin { get; set; }
        /// <summary>
        /// 延後走分鐘
        /// </summary>
        public int DelayMin { get; set; }
        /// <summary>
        /// 使用的彈性分鐘數
        /// </summary>
        public int ElasticityMin { get; set; }
    }
    #endregion
}