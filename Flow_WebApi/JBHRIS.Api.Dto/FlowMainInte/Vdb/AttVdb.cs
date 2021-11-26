using System;
using System.Collections.Generic;
using System.Text;
using static JBHRIS.Api.Dto.FlowMainInte.Vdb.MultiEnum;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{


    /// <summary>
    /// AttVdb
    /// </summary>
    public class AttVdb
    {
    }

    /// <summary>
    /// 出勤資料
    /// </summary>
    public class AttendRow
    {
        /// <summary>
        /// AttendID
        /// </summary>
        public int AttendID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteID { set; get; }
        /// <summary>
        /// 班別代碼(最終代碼)
        /// </summary>
        public string ActualRoteID { set; get; }
        /// <summary>
        /// 假日班別代碼
        /// </summary>
        public string HolidayRoteID { set; get; }
        /// <summary>
        /// 遲到
        /// </summary>
        public int LateMins { set; get; }
        /// <summary>
        /// 早退
        /// </summary>
        public int EarlyMins { set; get; }
        /// <summary>
        /// 曠職
        /// </summary>
        public bool IsAbsent { set; get; }
        /// <summary>
        /// 不判斷異常
        /// </summary>
        public bool IsAbnormal { set; get; }
        /// <summary>
        /// 是否彈性
        /// </summary>
        public bool IsFlexibleMinute { set; get; }
        /// <summary>
        /// 忘刷次數
        /// </summary>
        public int ForgetCard { set; get; }
        /// <summary>
        /// 早來
        /// </summary>
        public int OnBeforeMins { set; get; }
        /// <summary>
        /// 晚走
        /// </summary>
        public int OffAfterMins { set; get; }
        /// <summary>
        /// 園區出勤日
        /// </summary>
        public bool IsBonusLeave { set; get; }
        /// <summary>
        /// 出勤時數
        /// </summary>
        public decimal AttHours { set; get; }
        /// <summary>
        /// 班別資訊
        /// </summary>
        public RoteRow Rote { set; get; }
        /// <summary>
        /// 換班班別資訊
        /// </summary>
        public RoteRow ActualRote { set; get; }
        /// <summary>
        /// 假日班別資訊
        /// </summary>
        public RoteRow HolidayRote { set; get; }
    }

    /// <summary>
    /// 出勤資料
    /// </summary>
    public class AttendSumRoteRow
    {
        /// <summary>
        /// 班別代碼
        /// </summary>
        public int RoteID { set; get; }
        /// <summary>
        /// 班別資訊
        /// </summary>
        public RoteRow Rote { set; get; }
        /// <summary>
        /// 總計
        /// </summary>
        public int Sum { set; get; }
    }

    /// <summary>
    /// 出勤資料
    /// </summary>
    public class AttendCalendarRow
    {
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 班別代碼(最終代碼)
        /// </summary>
        public int ActualRoteID { set; get; }
        /// <summary>
        /// 遲到
        /// </summary>
        public int LateMins { set; get; }
        /// <summary>
        /// 早退
        /// </summary>
        public int EarlyMins { set; get; }
        /// <summary>
        /// 曠職
        /// </summary>
        public bool IsAbsent { set; get; }
        /// <summary>
        /// 忘刷次數
        /// </summary>
        public int ForgetCard { set; get; }
        /// <summary>
        /// 換班班別別資訊
        /// </summary>
        public RoteRow ActualRote { set; get; }
        /// <summary>
        /// 請假資訊
        /// </summary>
        public AbsDetailRow AbsDetail { set; get; }
        /// <summary>
        /// 流程中請假資訊
        /// </summary>
        public AbsFlowAppsDetailRow AbsFlowAppsDetail { set; get; }
        /// <summary>
        /// 流程中銷假資訊
        /// </summary>
        public AbscFlowAppsExtendRow AbscFlowApps { set; get; }
    }

    /// <summary>
    /// 出勤資料(行事曆)
    /// </summary>
    public class AttendCalendarSimplifyRow
    {
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 班別id
        /// </summary>
        public string ActualRoteID { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string ActualRoteCode { set; get; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string ActualRoteName { set; get; }
        /// <summary>
        /// 假日班
        /// </summary>
        public bool Holiday { set; get; }
        /// <summary>
        /// 上班時間
        /// </summary>
        public string OnTime { set; get; }
        /// <summary>
        /// 下班時間
        /// </summary>
        public string OffTime { set; get; }
        /// <summary>
        /// 出勤是否異常
        /// </summary>
        public bool AttendExceptional { set; get; }
        /// <summary>
        /// 是否請假
        /// </summary>
        public bool Abs { set; get; }
        /// <summary>
        /// 是否請假進行中
        /// </summary>
        public bool AbsFlow { set; get; }
    }

    /// <summary>
    /// 出勤資料異常(行事曆)
    /// </summary>
    public class AttendCalendarExceptionalRow
    {
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 班別id
        /// </summary>
        public int ActualRoteID { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string ActualRoteCode { set; get; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string ActualRoteName { set; get; }
        /// <summary>
        /// 上班時間
        /// </summary>
        public string OnTime { set; get; }
        /// <summary>
        /// 下班時間
        /// </summary>
        public string OffTime { set; get; }
        /// <summary>
        /// 上班刷卡時間
        /// </summary>
        public string OnCardTime { set; get; }
        /// <summary>
        /// 下班刷卡時間
        /// </summary>
        public string OffCardTime { set; get; }
        /// <summary>
        /// 遲到
        /// </summary>
        public int LateMins { set; get; }
        /// <summary>
        /// 早退
        /// </summary>
        public int EarlyMins { set; get; }
        /// <summary>
        /// 曠職
        /// </summary>
        public bool IsAbsent { set; get; }
        /// <summary>
        /// 忘刷次數
        /// </summary>
        public int ForgetCard { set; get; }
        /// <summary>
        /// 早來
        /// </summary>
        public int OnBeforeMins { set; get; }
        /// <summary>
        /// 晚走
        /// </summary>
        public int OffAfterMins { set; get; }
    }

    /// <summary>
    /// 出勤請假資料
    /// </summary>
    public class AttendCalendarAbsRow
    {
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 請假開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 請假結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public int HoliDayID { set; get; }
        /// <summary>
        /// 假別名稱
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
        /// 批核日期
        /// </summary>
        public DateTime SignDateTime { set; get; }
    }

    /// <summary>
    /// 假日班別Mapping
    /// </summary>
    public class RoteMappingRow
    {
        /// <summary>
        /// 假日班別Mapping代碼
        /// </summary>
        public string RoteMappingCode { set; get; }
        /// <summary>
        /// 假日班別Mapping名稱
        /// </summary>
        public string RoteMappingName { set; get; }
        /// <summary>
        /// 假日班別代碼
        /// </summary>
        public string RoteID { set; get; }
    }

    /// <summary>
    /// 假日班別代碼
    /// </summary>
    public class RoteMappingByHolidayRow
    {
        /// <summary>
        /// 挪休日
        /// </summary>
        public string ChangeHoliday { set; get; }
        /// <summary>
        /// 例假日
        /// </summary>
        public string Holidays { set; get; }
        /// <summary>
        /// 國定假日
        /// </summary>
        public string NationalHoliday { set; get; }
        /// <summary>
        /// 休息日
        /// </summary>
        public string OffDay { set; get; }
    }

    /// <summary>
    /// 出勤異常資料
    /// </summary>
    public class AttendExceptionalRow : AttendRow
    {
        /// <summary>
        /// 出勤資料
        /// </summary>
        public List<AttendCardRow> AttendCard { set; get; }
    }

    /// <summary>
    /// 考勤資訊
    /// </summary>
    public class AttendInfoRow
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
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 編制部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 班別代碼(最終代碼)
        /// </summary>
        public string ActualRoteID { set; get; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteNameC { set; get; }
        /// <summary>
        /// 上班時間
        /// </summary>
        public string OnTime { set; get; }
        /// <summary>
        /// 下班時間
        /// </summary>
        public string OffTime { set; get; }
        /// <summary>
        /// 上班刷卡時間
        /// </summary>
        public string OnCardTime { set; get; }
        /// <summary>
        /// 下班刷卡時間
        /// </summary>
        public string OffCardTime { set; get; }
        /// <summary>
        /// 出勤請假資訊
        /// </summary>
        public List<AttendAbsInfoRow> AttendAbsInfo { set; get; }
        /// <summary>
        /// 是否搭車
        /// </summary>
        public bool Ride { set; get; }
        /// <summary>
        /// 車誤
        /// </summary>
        public bool Behind { set; get; }
        /// <summary>
        /// 彈性分鐘數
        /// </summary>
        public decimal FlexibleMinute { set; get; }
        /// <summary>
        /// 遲到
        /// </summary>
        public int LateMins { set; get; }
        /// <summary>
        /// 早退
        /// </summary>
        public int EarlyMins { set; get; }
        /// <summary>
        /// 曠職
        /// </summary>
        public bool IsAbsent { set; get; }
        /// <summary>
        /// 忘刷次數
        /// </summary>
        public int ForgetCard { set; get; }
        /// <summary>
        /// 換班班別別資訊
        /// </summary>
        public RoteRow ActualRote { set; get; }
    }

    /// <summary>
    /// 出勤請假資訊
    /// </summary>
    public class AttendAbsInfoRow
    {
        /// <summary>
        /// 請假或出差
        /// </summary>
        public string AbsType { set; get; }
        /// <summary>
        /// AbsID
        /// </summary>
        public string AbsID { set; get; }
    }

    /// <summary>
    /// 員工考勤異動資料
    /// </summary>
    public class AttendBasettsRow
    {
        /// <summary>
        /// AttendBasettsID
        /// </summary>
        public int AttendBasettsID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime EffectDate { set; get; }
        /// <summary>
        /// 排班方式
        /// </summary>
        public string AttendBasettsType { set; get; }
        /// <summary>
        /// 預定班別所採用的代碼
        /// </summary>
        public string RoteID { set; get; }
        /// <summary>
        /// 輪班方式
        /// </summary>
        public string ShiftID { set; get; }
        /// <summary>
        /// 行事曆
        /// </summary>
        public int CalendarID { set; get; }
        /// <summary>
        /// 平日加班比率
        /// </summary>
        public int NormalOvertimeRateMasterID { set; get; }
        /// <summary>
        /// 例假日加班比率
        /// </summary>
        public int HolidayOvertimeRateMasterID { set; get; }
        /// <summary>
        /// 休息日
        /// </summary>
        public int RestOvertimeRateMasterID { set; get; }
        /// <summary>
        /// 國定假日
        /// </summary>
        public int NationalOvertimeRateMasterID { set; get; }
        /// <summary>
        /// 考勤群組
        /// </summary>
        public int AttendGroupMasterID { set; get; }
        /// <summary>
        /// 出勤設定細部資料
        /// </summary>
        public AttendGroupDetailRow AttendGroupDetail { set; get; }
    }

    /// <summary>
    /// 出勤類別
    /// </summary>
    public class AttendTypeRow
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
        public AttendType Type { get; set; }
    }

    /// <summary>
    /// 出勤設定細部資料
    /// </summary>
    public class AttendGroupDetailRow
    {
        /// <summary>
        /// 判斷曠職
        /// </summary>
        public string ComputingAbsent { set; get; }
        /// <summary>
        /// 刷卡否
        /// </summary>
        public string ComputingCard { set; get; }
        /// <summary>
        /// 判斷早退
        /// </summary>
        public string ComputingEarlyLeave { set; get; }
        /// <summary>
        /// 判斷忘刷卡
        /// </summary>
        public string ComputingForgetCard { set; get; }
        /// <summary>
        /// 判斷遲到
        /// </summary>
        public string ComputingLateCome { set; get; }
        /// <summary>
        /// 特休計算方式
        /// </summary>
        public string YearHolidayCountMethod { set; get; }
    }

    /// <summary>
    /// 假日異常出勤(有刷卡，或是沒有請假)
    /// </summary>
    public class AttendHolidayExceptionRow
    {
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 出勤資料
        /// </summary>
        public AttendRow Attend { set; get; }
        /// <summary>
        /// 出勤刷卡資料
        /// </summary>
        public List<AttendCardRow> AttendCard { set; get; }
        /// <summary>
        /// 請假細節資訊
        /// </summary>
        public List<AbsDetailRow> AbsDetail { set; get; }
    }

    /// <summary>
    /// 班別已排班天數
    /// </summary>
    public class AttendRoteDayRow
    {
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 總天數
        /// </summary>
        public int DayCount { set; get; }
        /// <summary>
        /// 班別可見代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 班別別資訊
        /// </summary>
        public RoteRow Rote { set; get; }
        /// <summary>
        /// 那些日期
        /// </summary>
        public List<AttendRoteDayDetailRow> AttendRoteDayDetail { set; get; }
    }

    /// <summary>
    /// 那些日期
    /// </summary>
    public class AttendRoteDayDetailRow
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime AttendDate { set; get; }
        /// <summary>
        /// 相關資訊
        /// </summary>
        public AttendRow Attend { set; get; }
    }

    /// <summary>
    /// 員工刷卡資料(結果)
    /// </summary>
    public class AttendCardRow
    {
        /// <summary>
        /// AttendCardID
        /// </summary>
        public int AttendCardID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CardDate { set; get; }
        /// <summary>
        /// 上班刷卡時間
        /// </summary>
        public string OnTime { set; get; }
        /// <summary>
        /// 上班刷卡時間48小時
        /// </summary>
        public string OnTime48 { set; get; }
        /// <summary>
        /// 上班刷卡日期時間
        /// </summary>
        public DateTime? OnDateTime { set; get; }
        /// <summary>
        /// 下班刷卡時間
        /// </summary>
        public string OffTime { set; get; }
        /// <summary>
        /// 下班刷卡時間48小時
        /// </summary>
        public string OffTime48 { set; get; }
        /// <summary>
        /// 下班刷卡日期時間
        /// </summary>
        public DateTime? OffDateTime { set; get; }
        /// <summary>
        /// 上班忘刷
        /// </summary>
        public bool OnTimeForget { set; get; }
        /// <summary>
        /// 下班忘刷
        /// </summary>
        public bool OffTimeForget { set; get; }
        /// <summary>
        /// 不允許修改
        /// </summary>
        public bool NotModify { set; get; }
    }

    /// <summary>
    /// 意願備註表
    /// </summary>
    public class AttendWishRow
    {
        /// <summary>
        /// AttendWishID
        /// </summary>
        public int AttendWishID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 備註類別
        /// </summary>
        public string WishTypeID { set; get; }
        /// <summary>
        /// 備註類別名稱
        /// </summary>
        public string WishTypeName { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 假別群組代碼
    /// </summary>
    public class HoliDayKindRow
    {
        /// <summary>
        /// 假別群組代碼
        /// </summary>
        public string HoliDayKindID { set; get; }
        /// <summary>
        /// 假別群組可見代碼
        /// </summary>
        public string HoliDayKindCode { set; get; }
        /// <summary>
        /// 假別群組名稱
        /// </summary>
        public string HoliDayKindNameC { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 假別單位代碼(應該無作用)
        /// </summary>
        public string Unit { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public List<HoliDayRow> HoliDay { set; get; }
    }


    public class HoliDayKindRowView
    {
        /// <summary>
        /// 假別群組代碼
        /// </summary>
        public int HoliDayKindID { set; get; }
        /// <summary>
        /// 假別群組可見代碼
        /// </summary>
        public string HoliDayKindCode { set; get; }
        /// <summary>
        /// 假別群組名稱
        /// </summary>
        public string HoliDayKindNameC { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 假別單位代碼(應該無作用)
        /// </summary>
        public string Unit { set; get; }

    }



    /// <summary>
    /// 假別代碼
    /// </summary>
    public class HoliDayRow
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
        /// 假別名稱
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
        /// 最小使用數
        /// </summary>
        public decimal MinNum { set; get; }
        /// <summary>
        /// 包含假日
        /// </summary>
        public bool IncludeHoliDay { set; get; }
        /// <summary>
        /// 最大使用數
        /// </summary>
        public decimal MaxNum { set; get; }
        /// <summary>
        /// 檢查剩餘數
        /// </summary>
        public bool CheckRestHour { set; get; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { set; get; }
        /// <summary>
        /// 要顯示
        /// </summary>
        public bool IsDisplay { set; get; }
        /// <summary>
        /// 請假間隔數
        /// </summary>
        public decimal AbsentUnit { set; get; }
        /// <summary>
        /// HoliDayKindID
        /// </summary>
        public string HoliDayKindID { set; get; }
        /// <summary>
        /// 加減項
        /// </summary>
        public string HoliDayFlag { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { set; get; }
        /// <summary>
        /// 自動產生假
        /// </summary>
        public bool AutoCreate { set; get; }
        /// <summary>
        /// 自動流程
        /// </summary>
        public bool AutoFlowStart { set; get; }
        /// <summary>
        /// 出差或公出假種
        /// </summary>
        public bool AbsentLeave { set; get; }
        /// <summary>
        /// 說明、備註
        /// </summary>
        public string Memo { set; get; }
        /// <summary>
        /// 請假不參考班別
        /// </summary>
        public bool IsNotRefRote { set; get; }
        /// <summary>
        /// 是否顯示已請
        /// </summary>
        public bool IsDisMinus { set; get; }
        /// <summary>
        /// 是否顯示剩餘
        /// </summary>
        public bool IsDisBalance { set; get; }
        /// <summary>
        /// 是否顯示代扣
        /// </summary>
        public bool IsDisWithHolding { set; get; }
        /// <summary>
        /// 是否顯示當年度扣假
        /// </summary>
        public bool IsThisYear { set; get; }
        /// <summary>
        /// 是否可循環
        /// </summary>
        public bool IsCycle { set; get; }
        /// <summary>
        /// 請假最小總數
        /// </summary>
        public decimal AtLeastSum { set; get; }
        /// <summary>
        /// 是否要填入事件發生日
        /// </summary>
        public bool IsEventDate { set; get; }
        /// <summary>
        /// 是否要填入稱謂
        /// </summary>
        public bool IsKeyName { set; get; }
    }

    /// <summary>
    /// 請假簽核權限表
    /// </summary>
    public class HoliDayFlowConditionRow
    {
        /// <summary>
        /// HoliDayFlowConditionID
        /// </summary>
        public int HoliDayFlowConditionID { set; get; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayCode { set; get; }
        /// <summary>
        /// 樹層級
        /// </summary>
        public decimal Tree { get; set; }
        /// <summary>
        /// 請假天數
        /// </summary>
        public decimal AbsUseDay { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
    }

    /// <summary>
    /// 請假簽核權限表(檢視用)
    /// </summary>
    public class HoliDayFlowConditionViewRow
    {
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HoliDayCode { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HoliDayNameC { set; get; }
        /// <summary>
        /// 一級主管可批核天數
        /// </summary>
        public decimal Max1 { get; set; }
        /// <summary>
        /// 二級主管可批核天數
        /// </summary>
        public decimal Max2 { get; set; }
        /// <summary>
        /// 三級主管可批核天數
        /// </summary>
        public decimal Max3 { get; set; }
    }

    /// <summary>
    /// 簽核條件內容
    /// </summary>
    public class SignConditionRow
    {
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { get; set; }
        /// <summary>
        /// 申請人工號
        /// </summary>
        public string AppEmpID { get; set; }
        /// <summary>
        /// 主管工號
        /// </summary>
        public string CheckEmpID { get; set; }
        /// <summary>
        /// 主管代碼
        /// </summary>
        //public string ChiefCode { get; set; }
        /// <summary>
        /// 主管層級
        /// </summary>
        public decimal Tree { get; set; }
        /// <summary>
        /// 表單流程代碼
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// 審核條件1
        /// </summary>
        public string Cond1 { get; set; }
        /// <summary>
        /// 審核條件2
        /// </summary>
        public string Cond2 { get; set; }
        /// <summary>
        /// 審核條件3
        /// </summary>
        public string Cond3 { get; set; }
        /// <summary>
        /// 審核條件4
        /// </summary>
        public string Cond4 { get; set; }
        /// <summary>
        /// 審核條件5
        /// </summary>
        public string Cond5 { get; set; }
        /// <summary>
        /// 審核條件6
        /// </summary>
        public string Cond6 { get; set; }
        /// <summary>
        /// 上呈
        /// </summary>
        public bool Sign { get; set; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool Reject { get; set; }
        /// <summary>
        /// 簽核完成
        /// </summary>
        public bool SignComplete { get; set; }
    }

    /// <summary>
    /// 班別代碼
    /// </summary>
    public class RoteRow
    {
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteID { set; get; }
        /// <summary>
        /// 班別可見代碼
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteNameC { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 上班日期時間
        /// </summary>
        public DateTime OnDateTime { set; get; }
        /// <summary>
        /// 下班日期時間
        /// </summary>
        public DateTime OffDateTime { set; get; }
        /// <summary>
        /// 上班時間
        /// </summary>
        public string OnTime { set; get; }
        /// <summary>
        /// 下班時間
        /// </summary>
        public string OffTime { set; get; }
        /// <summary>
        /// 工作時數
        /// </summary>
        public decimal WorkHours { set; get; }
        /// <summary>
        /// 投入工時
        /// </summary>
        public decimal DWorkHours { set; get; }
        /// <summary>
        /// 最早上班時間
        /// </summary>
        public int OnTimeEarliest { set; get; }
        /// <summary>
        /// 最晚下班時間
        /// </summary>
        public int OffTimeLatest { set; get; }
        /// <summary>
        /// 加班開始時間
        /// </summary>
        public string OtBeginTime { set; get; }
        /// <summary>
        /// 年休時數
        /// </summary>
        public decimal YearRestHours { set; get; }
        /// <summary>
        /// 請假下班時間
        /// </summary>
        public string LeaveOffTime { set; get; }
        /// <summary>
        /// 彈性分鐘數
        /// </summary>
        public decimal FlexibleMinute { set; get; }
        /// <summary>
        /// 彈性分鐘數(往前)
        /// </summary>
        public decimal FlexibleMinuteForward { set; get; }
        /// <summary>
        /// 彈性分鐘數(往後)
        /// </summary>
        public decimal FlexibleMinuteBehind { set; get; }
        /// <summary>
        /// 可遲到分鐘數
        /// </summary>
        public decimal LateMinute { set; get; }
        /// <summary>
        /// 工作間隔時數
        /// </summary>
        public decimal WorkInterval { set; get; }
        /// <summary>
        /// 要不要刷卡
        /// </summary>
        public bool IsCard { set; get; }
        /// <summary>
        /// 可不可以調班
        /// </summary>
        public bool IsShift { set; get; }
        /// <summary>
        /// 可不可以不等工時調班
        /// </summary>
        public bool IsDifferShift { set; get; }
        /// <summary>
        /// 是否搭車
        /// </summary>
        public bool Ride { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { set; get; }
        /// <summary>
        /// 假日班
        /// </summary>
        public bool Holiday { set; get; }
        /// <summary>
        /// 休息時間
        /// </summary>
        public List<RoteRestRow> RoteRest { set; get; }
        /// <summary>
        /// 假日班別Mapping
        /// </summary>
        public RoteMappingRow RoteMapping { set; get; }
    }

    /// <summary>
    /// 休息時間
    /// </summary>
    public class RoteRestRow
    {
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteID { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { set; get; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 分鐘數
        /// </summary>
        public int Minute { set; get; }
        /// <summary>
        /// 平日請假使用
        /// </summary>
        public bool IsNormalAbs { set; get; }
        /// <summary>
        /// 平日加班使用
        /// </summary>
        public bool IsNormalOt { set; get; }
        /// <summary>
        /// 假日請假使用
        /// </summary>
        public bool IsHoliDayAbs { set; get; }
        /// <summary>
        /// 假日加班使用
        /// </summary>
        public bool IsHoliDayOt { set; get; }
    }

    /// <summary>
    /// 刷卡轉出勤參數
    /// </summary>
    public class TransCardCondition
    {
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime DateB { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateE { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public int RoteID { get; set; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 轉換刷卡時間
        /// </summary>
        public bool AttCard { get; set; }
        /// <summary>
        /// 判斷異常
        /// </summary>
        public bool AttEnd { get; set; }
        /// <summary>
        /// 簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)
        /// </summary>
        public bool EzAttCard { get; set; }
        /// <summary>
        /// 上班時間代碼
        /// </summary>
        public string OnTimeCode { get; set; }
        /// <summary>
        /// 下班時間代碼
        /// </summary>
        public string OffTimeCode { get; set; }
    }

    #region 介接
    /// <summary>
    /// 車誤代碼
    /// </summary>
    public class StayDayRow
    {
        /// <summary>
        /// 員工號
        /// </summary>
        public string EmpId { get; set; }
        /// <summary>
        /// 交通車是否誤點
        /// </summary>
        public bool IsDelay { get; set; }
        /// <summary>
        /// 抵達時間
        /// </summary>
        public string ArriveTime { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string errMsg { get; set; }
        /// <summary>
        /// 是否搭車
        /// </summary>
        public bool IsTransCar { get; set; }
    }

    /// <summary>
    /// 加班資料(傳入用)
    /// </summary>
    public class OvertimeMainRow
    {
        /// <summary>
        /// 員工號 (123456)
        /// </summary>
        public string EmployId { get; set; }
        /// <summary>
        /// 加班歸屬日 (2019/02/10)
        /// </summary>
        public string DutyDt { get; set; }
    }

    /// <summary>
    /// 加班資料
    /// </summary>
    public class OvertimeRow : OvertimeMainRow
    {
        /// <summary>
        /// 加班歸屬日 (2019/02/10)
        /// </summary>
        public new DateTime DutyDt { get; set; }
        /// <summary>
        /// "Y" = 當日有加班，"N" = 當日無加班
        /// </summary>
        public string isOT { get; set; }
        /// <summary>
        /// 加班單號16碼
        /// </summary>
        public string FormNo { get; set; }
        /// <summary>
        /// 空值 = 簽核中 "Z" = 已結案(核准)
        /// </summary>
        public string Status { get; set; }
    }
    /// <summary>
    /// 留停資料
    /// </summary>
    public class SuspendRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpId { get; set; }
        /// <summary>
        /// 到職日
        /// </summary>
        public string INDT { get; set; }
        /// <summary>
        /// 福利起算日
        /// </summary>
        public string BNFTDT { get; set; }
        /// <summary>
        /// 留停日
        /// </summary>
        public string SUSPDATE { get; set; }
        /// <summary>
        /// 復職日
        /// </summary>
        public string REVYDATE { get; set; }
        /// <summary>
        /// 留停天日
        /// </summary>
        public string SUSPDAYS { get; set; }
        /// <summary>
        /// 更新日
        /// </summary>
        public string UPTDT { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string errMsg { get; set; }
    }
    #endregion
}
