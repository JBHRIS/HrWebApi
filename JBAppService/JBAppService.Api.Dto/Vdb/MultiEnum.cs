namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// 共用列舉
    /// </summary>
    public class MultiEnum
    {
        /// <summary>
        /// 出勤分類
        /// </summary>
        public enum AttendType : int
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
        /// 假別計算單位
        /// </summary>
        public enum HoliDayUnit : int
        {
            /// <summary>
            /// 分鐘
            /// </summary>
            Minute = 3,
            /// <summary>
            /// 小時
            /// </summary>
            Hour = 1,
            /// <summary>
            /// 天
            /// </summary>
            Day = 2,
            /// <summary>
            /// 月
            /// </summary>
            Month = 4,
            /// <summary>
            /// 年
            /// </summary>
            Year = 5,
        }

        /// <summary>
        /// 性別分類
        /// </summary>
        public enum SexCategroy : int
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
        /// 流程狀態列舉 ex核椎、駁回、作廢、刪除、抽單
        /// </summary>
        public enum FlowState : int
        {
            /// <summary>
            /// 無
            /// </summary>
            None = 0,
            /// <summary>
            /// 進行中
            /// </summary>
            Go = 1,
            /// <summary>
            /// 核椎
            /// </summary>
            Approve = 3,
            /// <summary>
            /// 駁回
            /// </summary>
            Reject = 2,
            /// <summary>
            /// 作廢
            /// </summary>
            Cancel = 4,
            /// <summary>
            /// 刪除
            /// </summary>
            Delete = 5,
            /// <summary>
            /// 預排
            /// </summary>
            Appointment = 6,
            /// <summary>
            /// 抽單
            /// </summary>
            Take = 7,
            /// <summary>
            /// 轉呈
            /// </summary>
            TransSign = 8,
        }

        /// <summary>
        /// 週變型
        /// </summary>
        public enum WeekType : int
        {
            /// <summary>
            /// 單週
            /// </summary>
            One = 1,
            /// <summary>
            /// 雙週
            /// </summary>
            TwoWeek = 2,
            /// <summary>
            /// 四週
            /// </summary>
            FourWeek = 4,
            /// <summary>
            /// 八週
            /// </summary>
            EightWeek = 8
        }
    }
}
