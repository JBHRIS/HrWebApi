using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{

    /// <summary>
    /// 
    /// </summary>
    public class CardVdb
    {
    }

    /// <summary>
    /// 忘刷原因
    /// </summary>
    public class CardCauseRow
    {
        /// <summary>
        /// 忘刷原因代碼
        /// </summary>
        public string CauseID { get; set; }
        /// <summary>
        /// 忘刷原因可見代碼
        /// </summary>
        public string CauseCode { get; set; }
        /// <summary>
        /// 忘刷原因名稱
        /// </summary>
        public string CauseNameC { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { get; set; }
        /// <summary>
        /// 影響出勤
        /// </summary>
        public bool EffectFullAttend { get; set; }
        /// <summary>
        /// 不是暫借卡
        /// </summary>
        public bool NotTempCard { set; get; }
    }

    /// <summary>
    /// 刷卡資料
    /// </summary>
    public class CardDataRow
    {
        /// <summary>
        /// CardDataID
        /// </summary>
        public int CardDataID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 卡機來源
        /// </summary>
        public string SourceCode { set; get; }
        /// <summary>
        /// 卡號
        /// </summary>
        public string CardNo { set; get; }
        /// <summary>
        /// 刷卡日期
        /// </summary>
        public DateTime CardDate { set; get; }
        /// <summary>
        /// 刷卡時間
        /// </summary>
        public string CardTime { set; get; }
        /// <summary>
        /// 刷卡日期時間
        /// </summary>
        public DateTime CardDateTime { set; get; }
        /// <summary>
        /// 不轉換
        /// </summary>
        public bool NotTran { set; get; }
        /// <summary>
        /// 忘刷卡
        /// </summary>
        public bool IsForgetCard { set; get; }
        /// <summary>
        /// 忘刷原因代碼
        /// </summary>
        public string ForgetCardCauseID { set; get; }
        /// <summary>
        /// 忘刷原因
        /// </summary>
        public CardCauseRow CardCause { set; get; }
        /// <summary>
        /// IPAddress
        /// </summary>
        public string IPAddress { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { set; get; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { set; get; }
    }

    /// <summary>
    /// 假單主檔資訊
    /// </summary>
    public class CardFlowAppRow : FlowAppRow
    {
        /// <summary>
        /// 忘刷明細檔資訊
        /// </summary>
        public List<CardFlowAppsRow> FlowApps { get; set; }
    }

    /// <summary>
    /// 刷卡單明細檔資訊
    /// </summary>
    public class CardFlowAppsRow
    {

        /// <summary>
        /// ProcessID
        /// </summary>
        public int AutoKey { set; get; }

        /// <summary>
        /// ProcessID
        /// </summary>
        public string ProcessID { set; get; }

        /// <summary>
        /// EmpID
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public string RoteID { get; set; }

        /// <summary>
        /// 出勤開始日期時間
        /// </summary>
        public DateTime? RoteDateTimeB { set; get; }
        /// <summary>
        /// 出勤結束日期時間
        /// </summary>
        public DateTime? RoteDateTimeE { set; get; }
        /// <summary>
        /// 刷卡開始日期時間
        /// </summary>
        public DateTime? CardDateTimeB { set; get; }
        /// <summary>
        /// 刷卡結束日期時間
        /// </summary>
        public DateTime? CardDateTimeE { set; get; }
        /// <summary>
        /// 歸屬日期
        /// </summary>
        public DateTime? Date { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime? DateB { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime? DateE { set; get; }
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
        public DateTime? DateTimeB { set; get; }
        /// <summary>
        /// 結束日期時間
        /// </summary>
        public DateTime? DateTimeE { set; get; }


        /// <summary>
        /// 忘刷代碼
        /// </summary>
        public string CardLostCode { set; get; }

        /// <summary>
        /// 忘刷原因
        /// </summary>
        public string CardLostName { set; get; }



        /// <summary>
        /// 原因
        /// </summary>
        public string CauseID1 { set; get; }
        /// <summary>
        /// 原因名稱
        /// </summary>
        public string CauseName1 { set; get; }
        /// <summary>
        /// 原因
        /// </summary>
        public string CauseID2 { set; get; }
        /// <summary>
        /// 原因名稱
        /// </summary>
        public string CauseName2 { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }
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
        public bool Sign { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string SignState { set; get; }

        /// <summary>
        /// 資料列狀態
        /// </summary>
        public string Status { set; get; }


        /// <summary>
        /// 異常代碼(用逗號分開)
        /// </summary>
        public string ExceptionalCode { set; get; }
        /// <summary>
        /// 異常名稱(用逗號分開)
        /// </summary>
        public string ExceptionalName { set; get; }

        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptCode { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string JobCode { set; get; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { set; get; }


        public string InsertMan { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateMan { get; set; }

        public DateTime UpdateDate { get; set; }

    }




    public class ReissueCardFlowAppRow : FlowAppRow
    {
        /// <summary>
        /// 忘刷明細檔資訊
        /// </summary>
        public List<ReissueCardFlowAppsRows> FlowApps { get; set; }
    }

    public class ReissueCardFlowAppsRows
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
        /// 檔案
        /// </summary>
        public List<UploadFileRow> UploadFile { get; set; }
        /// <summary>
        /// 歸屬日期
        /// </summary>
        public string Date { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public string DateB { set; get; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 開始日期時間
        /// </summary>
        public DateTime? DateTimeB { set; get; }
        /// <summary>
        /// 原因
        /// </summary>
        public string CauseID1 { set; get; }
        /// <summary>
        /// 原因名稱
        /// </summary>
        public string CauseName1 { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 異常代碼(用逗號分開)
        /// </summary>
        public string ExceptionalCode { set; get; }
        /// <summary>
        /// 異常名稱(用逗號分開)
        /// </summary>
        public string ExceptionalName { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public string MailBody { set; get; }
    }


    /// <summary>
    /// 刷卡資訊明細延伸欄位
    /// </summary>
    public class CardFlowAppsExtendRow : CardFlowAppsRow
    {
        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { set; get; }
        //private DateTime? _Date;
        ///// <summary>
        ///// 歸屬日期
        ///// </summary>
        //public new DateTime? Date
        //{
        //    set
        //    {
        //        _Date = value;
        //        base.Date = value.ToString();
        //    }
        //    get
        //    {
        //        return _Date;
        //    }
        //}
        //private DateTime? _RoteDateTimeB;
        ///// <summary>
        ///// 出勤開始日期時間
        ///// </summary>
        //public new DateTime? RoteDateTimeB
        //{
        //    set
        //    {
        //        _RoteDateTimeB = value;
        //        base.RoteDateTimeB = value.ToString();
        //    }
        //    get
        //    {
        //        return _RoteDateTimeB;
        //    }
        //}
        //private DateTime? _RoteDateTimeE;
        ///// <summary>
        ///// 出勤結束日期時間
        ///// </summary>
        //public new DateTime? RoteDateTimeE
        //{
        //    set
        //    {
        //        _RoteDateTimeE = value;
        //        base.RoteDateTimeE = value.ToString();
        //    }
        //    get
        //    {
        //        return _RoteDateTimeE;
        //    }
        //}
        //private DateTime? _CardDateTimeB;
        ///// <summary>
        ///// 刷卡開始日期時間
        ///// </summary>
        //public new DateTime? CardDateTimeB
        //{
        //    set
        //    {
        //        _CardDateTimeB = value;
        //        base.CardDateTimeB = value.ToString();
        //    }
        //    get
        //    {
        //        return _CardDateTimeB;
        //    }
        //}
        //private DateTime? _CardDateTimeE;
        ///// <summary>
        ///// 刷卡結束日期時間
        ///// </summary>
        //public new DateTime? CardDateTimeE
        //{
        //    set
        //    {
        //        _CardDateTimeE = value;
        //        base.CardDateTimeE = value.ToString();
        //    }
        //    get
        //    {
        //        return _CardDateTimeE;
        //    }
        //}
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
        //private DateTime? _DateE;
        ///// <summary>
        ///// 結束日期
        ///// </summary>
        //public new DateTime? DateE
        //{
        //    set
        //    {
        //        _DateE = value;
        //        base.DateE = value.ToString();
        //    }
        //    get
        //    {
        //        return _DateE;
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
}
