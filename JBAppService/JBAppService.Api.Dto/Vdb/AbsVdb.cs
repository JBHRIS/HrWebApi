using System;
using System.Collections.Generic;
using System.Linq;

namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// AbsVdb
    /// </summary>
    public class AbsVdb
    {
    }

    /// <summary>
    /// 計算請假使用
    /// </summary>
    public class CalculateRow
    {
        /// <summary>
        /// 實際使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 計算後使用
        /// </summary>
        public decimal CalAfterUse { set; get; }
        /// <summary>
        /// 符合最小
        /// </summary>
        public bool Min { set; get; }
        /// <summary>
        /// 符合間隔
        /// </summary>
        public bool Interval { set; get; }
    }

    /// <summary>
    /// 請假判斷簽核層級
    /// </summary>
    public class AbsFlowSignTreeRow
    {
        /// <summary>
        /// 簽核層級
        /// </summary>
        public int Tree { get; set; }
        /// <summary>
        /// 假別ID
        /// </summary>
        public string HoliDayID { get; set; }
        /// <summary>
        /// 天數
        /// </summary>
        public decimal Day { get; set; }
    }

    /// <summary>
    /// 假別剩餘數
    /// </summary>
    public class AbsBalanceRow
    {
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 假別可見代碼
        /// </summary>
        public string HoliDayCode { set; get; }
        /// <summary>
        /// 假別中文名稱
        /// </summary>
        public string HoliDayNameC { set; get; }
        /// <summary>
        /// 假別單位代碼
        /// </summary>
        public string HoliDayUnit { set; get; }
        /// <summary>
        /// 假別單位名稱
        /// </summary>
        public string HoliDayUnitName { set; get; }
        /// <summary>
        /// 檢查剩餘時數
        /// </summary>
        public bool CheckBalance { set; get; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 可休最大數
        /// </summary>
        public decimal Max { set; get; }
        /// <summary>
        /// 已使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 剩餘
        /// </summary>
        public decimal Balance { set; get; }
        /// <summary>
        /// 真實剩餘
        /// </summary>
        public decimal RealBalance { set; get; }
        /// <summary>
        /// 群組最大數
        /// </summary>
        public decimal MaxGroup { set; get; }
        /// <summary>
        /// 群組使用
        /// </summary>
        public decimal UseGroup { set; get; }
        /// <summary>
        /// 群組剩餘
        /// </summary>
        public decimal BalanceGroup { set; get; }
        /// <summary>
        /// 真實群組剩餘
        /// </summary>
        public decimal RealBalanceGroup { set; get; }
        /// <summary>
        /// 顯示餘假資訊
        /// </summary>
        public bool DisplayForm { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { set; get; }
        /// <summary>
        /// 加項請假代碼
        /// </summary>
        public List<string> ListAbsPlusID { set; get; }
        /// <summary>
        /// 群組假別代碼
        /// </summary>
        public List<string> ListHoliDayID { set; get; }
        /// <summary>
        /// 假別資訊
        /// </summary>
        public HoliDayRow HoliDay { set; get; }
    }

    /// <summary>
    /// 假別剩餘數
    /// </summary>
    public class HoliDayBalanceRow : HoliDayKindRow
    {
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 可休最大數
        /// </summary>
        public decimal Max { set; get; }
        /// <summary>
        /// 已使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 流程已使用
        /// </summary>
        public decimal FlowUse { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow FlowUseDayHourMinute { set; get; }
        /// <summary>
        /// 剩餘
        /// </summary>
        public decimal Balance { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow BalanceDayHourMinute { set; get; }
        /// <summary>
        /// 剩餘(實際在HR資料庫)
        /// </summary>
        public decimal BalanceReal { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow BalanceRealDayHourMinute { set; get; }
        /// <summary>
        /// 加項請假代碼
        /// </summary>
        public List<HoliDayRow> HoliDayAddition { set; get; }
        /// <summary>
        /// 減項請假代碼
        /// </summary>
        public List<HoliDayRow> HoliDaySubtract { set; get; }
        /// <summary>
        /// 加項資料
        /// </summary>
        public List<AbsPlusRow> AbsAddition { set; get; }
        /// <summary>
        /// 減項資料
        /// </summary>
        public List<AbsBalanceDataRow> AbsDeduction { set; get; }
        /// <summary>
        /// 超休時數
        /// </summary>
        public decimal ExceptionUse { set; get; }
        /// <summary>
        /// 流程進行中資料(包含正在申請)
        /// </summary>
        public List<AbsFlowAppsRow> AbsFlowApps { set; get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AbsBalanceDataRow
    {
        /// <summary>
        /// 假別可見代碼
        /// </summary>
        public string HoliDayCode { set; get; }
        /// <summary>
        /// 假別中文名稱
        /// </summary>
        public string HoliDayNameC { set; get; }
        /// <summary>
        /// 假別單位代碼
        /// </summary>
        public string HoliDayUnit { set; get; }
        /// <summary>
        /// 已使用
        /// </summary>
        public DayHourMinuteRow Use { set; get; }
        /// <summary>
        /// 剩餘
        /// </summary>
        public DayHourMinuteRow Balance { set; get; }
        /// <summary>
        /// 流程已使用
        /// </summary>
        public DayHourMinuteRow FlowUse { set; get; }
    }
    /// <summary>
    /// 進行中流程時數
    /// </summary>
    public class AbsFlowRow
    {
        /// <summary>
        /// 請假日期
        /// </summary>
        public string DateB { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public int HoliDayID { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }

    }

    /// <summary>
    /// 請假計算
    /// </summary>
    public class AbsCalculateRow
    {
        /// <summary>
        /// 總使用
        /// </summary>
        public decimal TotalUse { set; get; }
        /// <summary>
        /// 使用拆分
        /// </summary>
        public DayHourMinuteRow TotalUseDayHourMinute { set; get; }
        /// <summary>
        /// 詳細請假資料
        /// </summary>
        public AbsRow Abs { set; get; }
        /// <summary>
        /// 假別剩餘時數資料
        /// </summary>
        public HoliDayBalanceRow HoliDayBalanceData { set; get; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public List<string> ErrorMsg { set; get; }
    }

    /// <summary>
    /// 請假計算(轉換流程資料)
    /// </summary>
    public class AbsCalculateFlowDataRow
    {
        /// <summary>
        /// 總使用
        /// </summary>
        public decimal TotalUse { set; get; }
        /// <summary>
        /// 使用拆分
        /// </summary>
        public DayHourMinuteRow TotalUseDayHourMinute { set; get; }
        /// <summary>
        /// 計算後組成的流程資料
        /// </summary>
        public List<AbsFlowAppsRow> FlowApps { set; get; }
        /// <summary>
        /// 超休時數
        /// </summary>
        public decimal ExceptionUse { set; get; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public List<string> ErrorMsg { set; get; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOK { get; set; }
    }

    /// <summary>
    /// 顯示天、時、分
    /// </summary>
    public class DayHourMinuteRow
    {
        /// <summary>
        /// 天
        /// </summary>
        public decimal Day { set; get; }
        /// <summary>
        /// 時
        /// </summary>
        public int Hour { set; get; }
        /// <summary>
        /// 分
        /// </summary>
        public int Minute { set; get; }
    }

    /// <summary>
    /// 請假資料
    /// </summary>
    public class AbsRow
    {
        /// <summary>
        /// AbsID
        /// </summary>
        public int AbsID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 請假開始日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 請假結束日期
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 請假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 請假開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 使用拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 計薪年月
        /// </summary>
        public string SalaryYYMM { set; get; }
        /// <summary>
        /// 對沖主鍵
        /// </summary>
        public string KeyName { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public DateTime? EventDate { set; get; }
        /// <summary>
        /// 假別資訊
        /// </summary>
        public HoliDayRow HoliDay { set; get; }
        /// <summary>
        /// 請假細節資訊
        /// </summary>
        public List<AbsDetailRow> AbsDetail { set; get; }
        /// <summary>
        /// 當天申請
        /// </summary>
        public bool Today { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 代理人工號1
        /// </summary>
        public string AgentNobr1 { set; get; }
        /// <summary>
        /// 代理人姓名1
        /// </summary>
        public string AgentName1 { set; get; }
        /// <summary>
        /// 交待事項
        /// </summary>
        public string AgentNote { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { set; get; }
        /// <summary>
        /// 部門中文名稱
        /// </summary>
        public string DeptNameC { set; get; }
        /// <summary>
        /// 部門英文名稱
        /// </summary>
        public string DeptNameE { set; get; }
        /// <summary>
        /// 基底時數
        /// </summary>
        public decimal AttHrs { set; get; }
        /// <summary>
        /// 流程編號
        /// </summary>
        public int ProcessFlowID { set; get; }
    }

    /// <summary>
    /// 請假細節
    /// </summary>
    public class AbsDetailRow
    {
        /// <summary>
        /// AbsID
        /// </summary>
        public string AbsID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 請假日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 請假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 請假開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 計薪年月
        /// </summary>
        public string SalaryYYMM { set; get; }
        /// <summary>
        /// 對沖主鍵
        /// </summary>
        public string KeyName { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public DateTime? EventDate { set; get; }
        /// <summary>
        /// 假別資訊
        /// </summary>
        public HoliDayRow HoliDay { set; get; }
        /// <summary>
        /// 當天申請
        /// </summary>
        public bool Today { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 班別休息時間
        /// </summary>
        public List<RoteRestRow> RoteRestList { set; get; }
        /// <summary>
        /// 員工基本資料
        /// </summary>
        public BaseRow Base { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { set; get; }
        /// <summary>
        /// 部門中文名稱
        /// </summary>
        public string DeptNameC { set; get; }
        /// <summary>
        /// 部門英文名稱
        /// </summary>
        public string DeptNameE { set; get; }
        /// <summary>
        /// 基底時數
        /// </summary>
        public decimal AttHrs { set; get; }
        /// <summary>
        /// 流程編號
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 建檔日期
        /// </summary>
        public DateTime? CreatDate { set; get; }
        /// <summary>
        /// 班別資訊
        /// </summary>
        public RoteRow Rote { set; get; }
        /// <summary>
        /// 請假明細ID
        /// </summary>
        public int AbsDetailID { set; get; }
    }

    /// <summary>
    /// 得假資料
    /// </summary>
    public class AbsPlusRow
    {
        /// <summary>
        /// AbsPlusID
        /// </summary>
        public int AbsPlusID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string BTime { set; get; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string ETime { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 總數
        /// </summary>
        public decimal TotalAmount { set; get; }
        /// <summary>
        /// 請假數
        /// </summary>
        public decimal AbsAmount { set; get; }
        /// <summary>
        /// 剩餘數
        /// </summary>
        public decimal RestAmount { set; get; }
        /// <summary>
        /// 剩餘數拆分
        /// </summary>
        public DayHourMinuteRow RestAmountDayHourMinute { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// AbsPlusType
        /// </summary>
        public string AbsPlusType { set; get; }
        /// <summary>
        /// 對沖主鍵
        /// </summary>
        public string KeyName { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public DateTime? EventDate { set; get; }
        /// <summary>
        /// 假別資訊
        /// </summary>
        public HoliDayRow HoliDay { set; get; }
        /// <summary>
        /// 請假細節資訊
        /// </summary>
        public List<AbsTransRow> AbsTrans { set; get; }
        /// <summary>
        /// 歸屬年度
        /// </summary>
        public int? Year { set; get; }
    }

    /// <summary>
    /// 餘假資料
    /// </summary>
    public class View_HRM_ATTEND_ABSENT_PLUS_Row
    {
        /// <summary>
        /// 員工號
        /// </summary>
        public string employid { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string lvcd { set; get; }
        /// <summary>
        /// 基本單位
        /// </summary>
        public string lvunit { set; get; }
        /// <summary>
        /// 假別單位
        /// </summary>
        public string clvunit { set; get; }
        /// <summary>
        /// 假別中文名稱
        /// </summary>
        public string cdesc { set; get; }
        /// <summary>
        /// 假別英文名稱
        /// </summary>
        public string edesc { set; get; }
        /// <summary>
        /// 新增數
        /// </summary>
        public int addmax { set; get; }
        /// <summary>
        /// 已請數
        /// </summary>
        public int lv { set; get; }
        /// <summary>
        /// 剩餘數
        /// </summary>
        public int stck { set; get; }
        /// <summary>
        /// 基本分鐘數
        /// </summary>
        public int bsmnt { set; get; }
        /// <summary>
        /// 起始日
        /// </summary>
        public DateTime strdt { set; get; }
        /// <summary>
        /// 結束日
        /// </summary>
        public DateTime enddt { set; get; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime createdt { set; get; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime uptdt { set; get; }
        /// <summary>
        /// 新增人
        /// </summary>
        public string creater { set; get; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string upter { set; get; }
    }

    /// <summary>
    /// 得假交易資料細節
    /// </summary>
    public class AbsTransRow
    {
        /// <summary>
        /// AbsTransID
        /// </summary>
        public int AbsTransID { set; get; }
        /// <summary>
        /// AbsPlusID
        /// </summary>
        public string AbsPlusID { set; get; }
        /// <summary>
        /// AbsMinusID
        /// </summary>
        public string AbsMinusID { set; get; }
        /// <summary>
        /// 請假日期(單天)
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 請假資料
        /// </summary>
        public List<AbsRow> Abs { set; get; }
    }

    #region 請假單
    /// <summary>
    /// 請假單主檔資訊
    /// </summary>
    public class AbsFlowAppRow : FlowAppRow
    {
        /// <summary>
        /// 總天數
        /// </summary>
        public decimal Day { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public int HoliDayID { set; get; }
        /// <summary>
        /// 請假單單筆主檔資訊
        /// </summary>
        public List<AbsFlowAppsRow> FlowApps { get; set; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
    }

    /// <summary>
    /// 請假單單筆主檔資訊
    /// </summary>
    public class AbsFlowAppsRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string AppEmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string AppEmpNameC { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public string RoteID { get; set; }
        /// <summary>
        /// 請假開始日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 請假結束日期
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 請假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 請假開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HoliDayNameC { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 轉換為天判斷用
        /// </summary>
        public decimal Day { set; get; }
        /// <summary>
        /// 剩餘
        /// </summary>
        public decimal Balance { set; get; }
        /// <summary>
        /// 假別單位名稱
        /// </summary>
        public string HoliDayUnitName { set; get; }
        /// <summary>
        /// 代理人工號1
        /// </summary>
        public string AgentNobr1 { set; get; }
        /// <summary>
        /// 代理人姓名1
        /// </summary>
        public string AgentName1 { set; get; }
        /// <summary>
        /// 交待事項
        /// </summary>
        public string AgentNote { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }
        /// <summary>
        /// 對沖主鍵
        /// </summary>
        public string KeyName { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public string EventDate { set; get; }
        /// <summary>
        /// 請假單明細檔資訊(拆每一天)
        /// </summary>
        public List<AbsFlowAppsDetailRow> AbsFlowAppsDetail { get; set; }
        /// <summary>
        /// 檔案
        /// </summary>
        public List<UploadFileRow> UploadFile { get; set; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public string MailBody { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 當日申請
        /// </summary>
        public bool Today { set; get; }
        /// <summary>
        /// 循環
        /// </summary>
        public bool Circulate { set; get; }
        /// <summary>
        /// 預排
        /// </summary>
        public bool Appointment { set; get; }
        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// Serno
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HoliDayName { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 職務名稱
        /// </summary>
        public string JobName { set; get; }
        /// <summary>
        /// 部門ID
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 假別不參考班別
        /// </summary>
        public bool HoliDayIsNotRefRote { set; get; }
        /// <summary>
        /// 基礎工時
        /// </summary>
        public decimal BaseHours { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string sGuid { get; set; }
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }

        public TusinessTripInfo TusinessTrip { get; set; }

    }

    /// <summary>
    /// 請假單明細檔資訊(拆每一天)
    /// </summary>
    public class AbsFlowAppsDetailRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 請假開始日期
        /// </summary>
        public DateTime? DateB { set; get; }
        /// <summary>
        /// 請假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 請假開始日期時間
        /// </summary>
        public DateTime? DateTimeB { set; get; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime? DateTimeE { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 班別ID
        /// </summary>
        public string RoteID { set; get; }
        /// <summary>
        /// 班別ID
        /// </summary>
        public RoteRow Rote { set; get; }
        /// <summary>
        /// 使用拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 請假交易明細檔
        /// </summary>
        public List<AbsFlowAppsTransRow> AbsFlowAppsTrans { get; set; }
        /// <summary>
        /// 班別休息時間
        /// </summary>
        public List<RoteRestRow> RoteRestList { get; set; }
        /// <summary>
        /// 請假明細的ID
        /// </summary>
        public int AbsentMinusDetailId { get; set; }

        /// <summary>
        /// 狀態(銷假單使用)
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool IsDelete { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessID { get; set; }
    }

    /// <summary>
    /// 請假交易明細檔
    /// </summary>
    public class AbsFlowAppsTransRow
    {
        /// <summary>
        /// 得假資料Key
        /// </summary>
        public string AbsPlusKey { set; get; }
        /// <summary>
        /// 得假開始日期時間
        /// </summary>
        public DateTime? AbsPlusDateB { set; get; }
        /// <summary>
        /// 得假結束日期時間
        /// </summary>
        public DateTime? AbsPlusDateE { set; get; }
        /// <summary>
        /// 得假開始時間
        /// </summary>
        public string AbsPlusTimeB { set; get; }
        /// <summary>
        /// 得假結束時間
        /// </summary>
        public string AbsPlusTimeE { set; get; }
        /// <summary>
        /// 得假代碼
        /// </summary>
        public string AbsPlusHcode { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public DateTime? EventDate { set; get; }
        /// <summary>
        /// 對沖主鍵
        /// </summary>
        public string KeyName { set; get; }
        /// <summary>
        /// 得假可休最大數
        /// </summary>
        public decimal AbsPlusMax { set; get; }
        /// <summary>
        /// 得假使用
        /// </summary>
        public decimal AbsPlusUse { set; get; }
        /// <summary>
        /// 得假剩餘
        /// </summary>
        public decimal AbsPlusBalance { set; get; }
        /// <summary>
        /// 請假開始日期時間
        /// </summary>
        public DateTime? DateTimeB { set; get; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime? DateTimeE { set; get; }
        /// <summary>
        /// 請假日期
        /// </summary>
        public DateTime? DateB { set; get; }
        /// <summary>
        /// 請假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 請假代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 使用時數
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 剩餘時數
        /// </summary>
        public decimal Balance { set; get; }
    }

    /// <summary>
    /// 請假檢查條件資料
    /// </summary>
    public class AbsFlowCheckRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 請假開始日期
        /// </summary>
        public string DateB { set; get; }
        /// <summary>
        /// 請假結束日期
        /// </summary>
        public string DateE { set; get; }
        /// <summary>
        /// 請假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 請假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 狀態(0=正準備新增的)
        /// </summary>
        public string State { set; get; }
    }
    #endregion

    #region 銷假單
    /// <summary>
    /// 銷假單主檔資訊
    /// </summary>
    public class AbscFlowAppRow : FlowAppRow
    {
        /// <summary>
        /// 總天數
        /// </summary>
        public decimal Day { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 銷假單主檔資訊
        /// </summary>
        public List<AbscFlowAppsRow> FlowApps { get; set; }
        /// <summary>
        /// 銷假單主檔資訊
        /// </summary>
        public List<AbscFlowAppsExtendRow> FlowAppsExtend { get; set; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
    }

    /// <summary>
    /// 銷假單主檔資訊
    /// </summary>
    public class AbscFlowAppsRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 銷假開始日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 銷假開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 銷假結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 銷假開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 銷假結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayID { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HoliDayNameC { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 基底時數
        /// </summary>
        public decimal BaseHour { set; get; }
        /// <summary>
        /// 轉換為天判斷用
        /// </summary>
        public decimal Day { set; get; }
        /// <summary>
        /// 假別單位名稱
        /// </summary>
        public string HoliDayUnitName { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public string MailBody { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string JobName { set; get; }
        /// <summary>
        /// 代理人工號1
        /// </summary>
        public string AgentNobr1 { set; get; }
        /// <summary>
        /// 代理人姓名1
        /// </summary>
        public string AgentName1 { set; get; }
        /// <summary>
        /// 請假明細的ID
        /// </summary>
        public int AbsentMinusDetailId { get; set; }
    }

    /// <summary>
    /// 銷假單主檔資訊延伸欄位
    /// </summary>
    public class AbscFlowAppsExtendRow : AbscFlowAppsRow
    {
        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HoliDayName { set; get; }

        //private DateTime? _DateB;
        ///// <summary>
        ///// 開始日期
        ///// </summary>
        //public new DateTime? DateB
        //{
        //    set
        //    {
        //        _DateB = value;
        //        base.DateB = value.ToString();
        //    }
        //    get
        //    {
        //        return _DateB;
        //    }
        //}
        //private DateTime? _DateTimeB;
        ///// <summary>
        ///// 開始日期時間
        ///// </summary>
        //public new DateTime? DateTimeB
        //{
        //    set
        //    {
        //        _DateTimeB = value;
        //        base.DateTimeB = value.ToString();
        //    }
        //    get
        //    {
        //        return _DateTimeB;
        //    }
        //}
        //private DateTime? _DateTimeE;
        ///// <summary>
        ///// 結束日期時間
        ///// </summary>
        //public new DateTime? DateTimeE
        //{
        //    set
        //    {
        //        _DateTimeE = value;
        //        base.DateTimeE = value.ToString();
        //    }
        //    get
        //    {
        //        return _DateTimeE;
        //    }
        //}
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public class EventDateRow
    {
        /// <summary>
        /// 得假事件發生日
        /// </summary>
        public DateTime EventDate { set; get; }

        /// <summary>
        /// 剩餘轉日、時、分
        /// </summary>
        public DayHourMinuteRow BalanceDayHourMinute { set; get; }
    }

    public class TusinessTripInfo
    {
        /// <summary>
        /// 職等名稱
        /// </summary>
        public string JobLevel { get; set; }
        /// <summary>
        /// 職等代碼
        /// </summary>
        public string JobLevelCode { get; set; }
        /// <summary>
        /// 所屬部門路徑
        /// </summary>
        public string DeptPath { get; set; }
        /// <summary>
        /// 工作地城市
        /// </summary>
        public string Station { get; set; }
        /// <summary>
        /// 出差城市
        /// </summary>
        public string DriveNum { get; set; }
        /// <summary>
        /// 所屬部門代碼
        /// </summary>
        public string DriveNo { get; set; }
        /// <summary>
        /// 交通工具
        /// </summary>
        public string Drive { get; set; }
        /// <summary>
        /// 其他交通工具
        /// </summary>
        public string DriveEtc { get; set; }
    }

    #region AbscView
    public class AbscView
    {

    }
    #endregion
}