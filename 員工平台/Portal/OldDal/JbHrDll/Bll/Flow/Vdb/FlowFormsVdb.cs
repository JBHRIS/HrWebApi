using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Flow.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class FlowFormsVdb
    {
        /// <summary>
        /// 請假資料
        /// </summary>
        public List<FlowAbsTable> FlowAbsData { set; get; }
        /// <summary>
        /// 加班資料
        /// </summary>
        public List<FlowOtTable> FlowOtData { set; get; }
    }

    /// <summary>
    /// 表單分類
    /// </summary>
    public enum FormCategroy
    {
        /// <summary>
        /// 請假
        /// </summary>
        Abs = 1,
        /// <summary>
        /// 公出
        /// </summary>
        Abs1 = 2,
        /// <summary>
        /// 銷假
        /// </summary>
        Absc = 3,
        /// <summary>
        /// 加班
        /// </summary>
        Ot = 4,
        /// <summary>
        /// 忘刷
        /// </summary>
        Card = 5,
        /// <summary>
        /// 長調
        /// </summary>
        ShiftLong = 6,
        /// <summary>
        /// 短調
        /// </summary>
        ShiftShort = 7,
    }

    /// <summary>
    /// 請假資料
    /// </summary>
    public class FlowAbsTable
    {
        /// <summary>
        /// 流程序號
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// 檢查表序號
        /// </summary>
        public int ApViewID { set; get; }
        /// <summary>
        /// 檢視Url
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { set; get; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE { set; get; }
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
        /// 假別代碼
        /// </summary>
        public string Hcode { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HcodeName { set; get; }
        /// <summary>
        /// 總天數
        /// </summary>
        public decimal TotalDay { set; get; }
        /// <summary>
        /// 總時數 
        /// </summary>
        public decimal TotalHour { set; get; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 計薪年月
        /// </summary>
        public string YYMM { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 主管誰審核的
        /// </summary>
        public string Approver { set; get; }
        /// <summary>
        /// 審核者
        /// </summary>
        public string CheckName { set; get; }
        /// <summary>
        /// 代理人
        /// </summary>
        public string AgentName { set; get; }
        /// <summary>
        /// 暫存的字串
        /// </summary>
        public string FlowAbsdD { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string Dept { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 請假扣休明細
        /// </summary>
        public List<FlowAbsdTable> FlowAbsd { set; get; }
    }

    /// <summary>
    /// 請假扣休明細
    /// </summary>
    public class FlowAbsdTable
    {
        /// <summary>
        /// 加項編號
        /// </summary>
        public string SernoAdd{ set; get; }
        /// <summary>
        /// 減項編號
        /// </summary>
        public string SernoSubtract { set; get; }
        /// <summary>
        /// 使用時數
        /// </summary>
        public decimal UseHour { set; get; }
    }

    /// <summary>
    /// 加班資料
    /// </summary>
    public class FlowOtTable
    {
        /// <summary>
        /// 流程序號
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// 檢查表序號
        /// </summary>
        public int ApViewID { set; get; }
        /// <summary>
        /// 檢視Url
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { set; get; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { set; get; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE { set; get; }
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
        /// 總時數 
        /// </summary>
        public decimal TotalHour { set; get; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal OtHour { set; get; }
        /// <summary>
        /// 補休時數
        /// </summary>
        public decimal ResHour { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 計薪年月
        /// </summary>
        public string YYMM { set; get; }
        /// <summary>
        /// 加班類別代碼
        /// </summary>
        public string OtTypeCode { set; get; }
        /// <summary>
        /// 加班類別名稱
        /// </summary>
        public string OtTypeName { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 主管誰審核的
        /// </summary>
        public string Approver { set; get; }
        /// <summary>
        /// 審核者
        /// </summary>
        public string CheckName { set; get; }
        /// <summary>
        /// 代理人
        /// </summary>
        public string AgentName { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string Dept { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 加班類別
        /// </summary>
        public string OvertimeCategory { set; get; }
        /// <summary>
        /// 用餐
        /// </summary>
        public decimal Meal { set; get; }
        /// <summary>
        /// KeyMan
        /// </summary>
        public string KeyMan { set; get; }
    }
}